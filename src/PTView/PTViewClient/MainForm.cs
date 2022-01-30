using PTViewClient.PTView;
using PTViewClient.PTView.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTViewClient
{
    public partial class MainForm : Form
    {
        private Process SelectedProcess;
        private ulong SelectedProcessDirbase;

        private PML4E[] PML4Es;
        private PDPTE[] PDPTEs;
        private PDE[] PDEs;
        private PTE[] PTEs;

        private DriverInterface Driver;

        public MainForm()
        {
            InitializeComponent();

            Driver = new DriverInterface();
            if (!Driver.Initialize("PTView"))
            {

                MessageBox.Show("Driver could not be initialized, make sure it's loaded properly.");
                Environment.Exit(0);
            }

            this.FormClosing += (o, ev) => Driver.Close();
        }

        private void ProcessesComboBox_DropDown(object sender, EventArgs e)
        {
            var processes = Process.GetProcesses();
            ProcessesComboBox.Items.AddRange(processes.Select(x => $"{x.ProcessName} | {x.Id}").ToArray());
        }

        private void ProcessesComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedItem = ProcessesComboBox.SelectedItem.ToString();
            PTViewPanel.Visible = true;
            var procId = uint.Parse(selectedItem.Substring(selectedItem.IndexOf(" | ") + 3));
            try
            {
                SelectedProcess = Process.GetProcessById((int)procId);
                SelectedProcessDirbase = Driver.GetProcessDirbase(procId);
                DirbaseLbl.Text = $"Dirbase (cr3): 0x{SelectedProcessDirbase:X8}";
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Couldn't get process -> " + ex.Message);
            }

            DumpPageTables();
            UpdateContentTmr.Start();
        }

        private void DumpPageTables()
        {
            PML4Es = Driver.DumpPageTables(SelectedProcessDirbase).Cast<PML4E>().ToArray();
            PopulateListView(PML4Es, PML4ListBox);

            if(PML4ListBox.SelectedItems.Count > 0)
            {
                var pml4Index = PML4ListBox.SelectedIndex;
                var pml4e = PML4Es[pml4Index];

                if (pml4e.PFN != 0x0)
                {
                    PDPTEs = Driver.DumpPageTables(pml4e.PFN).Cast<PDPTE>().ToArray();
                    PopulateListView(PDPTEs, PDPTListBox);
                }
                else
                    PDPTListBox.Items.Clear();
            }
            else PDPTListBox.Items.Clear();

            if (PDPTListBox.SelectedItems.Count > 0)
            {
                var pdptIndex = PDPTListBox.SelectedIndex;
                var pdpte = PDPTEs[pdptIndex];

                if (pdpte.PFN != 0x0)
                {
                    PDEs = Driver.DumpPageTables(pdpte.PFN).Cast<PDE>().ToArray();
                    PopulateListView(PDEs, PDListBox);
                }
                else
                    PDListBox.Items.Clear();
            }
            else PDListBox.Items.Clear();

            if (PDListBox.SelectedItems.Count > 0)
            {
                var pdIndex = PDListBox.SelectedIndex;
                var pde = PDEs[pdIndex];

                if (pde.PFN != 0x0)
                {
                    PTEs = Driver.DumpPageTables(pde.PFN).Cast<PTE>().ToArray();
                    PopulateListView(PTEs, PTListBox);
                }
                else
                    PTListBox.Items.Clear();
            }
            else PTListBox.Items.Clear();
        }

        private void WriteEntryInfo()
        {
            if(PML4ListBox.SelectedItems.Count > 0)
            {
                var pml4e = PML4Es[PML4ListBox.SelectedIndex];
                PML4eInfoLbl.Text = BuildPteInfo((PTE)pml4e);
            }
            else PML4eInfoLbl.Text = "";

            if (PDPTListBox.SelectedItems.Count > 0)
            {
                var pdpte = PDPTEs[PDPTListBox.SelectedIndex];
                PDPTeLblInfo.Text = BuildPteInfo((PTE)pdpte);
            }
            else PDPTeLblInfo.Text = "";

            if (PDListBox.SelectedItems.Count > 0)
            {
                var pde = PDEs[PDListBox.SelectedIndex];
                PDeInfoLbl.Text = BuildPteInfo((PTE)pde);
            }
            else PDeInfoLbl.Text = "";


            if (PTListBox.SelectedItems.Count > 0)
            {
                var pte = PTEs[PTListBox.SelectedIndex];
                PTeInfoLbl.Text = BuildPteInfoEx(pte);
            }
            else PTeInfoLbl.Text = "";
        }

        private string BuildPteInfo(PTE pte)
        {
            return
                $"Present: {pte.Present}\n" +
                $"R/W: {pte.ReadWrite}\n" +
                $"UserSupervisor: {pte.UserSupervisor}\n" +
                $"PageWriteThrough: {pte.PageWriteThrough}\n" +
                $"PageCache: {pte.PageCache}\n" +
                $"Accessed: {pte.Accessed}\n" +
                $"PageSize: {pte.PageSize}\n" +
                $"PFN: 0x{pte.PFN:X8}\n" +
                $"NX: {pte.NX}";
        }

        private string BuildPteInfoEx(PTE pte)
        {
            return
                $"Present: {pte.Present}\n" +
                $"R/W: {pte.ReadWrite}\n" +
                $"UserSupervisor: {pte.UserSupervisor}\n" +
                $"PageWriteThrough: {pte.PageWriteThrough}\n" +
                $"PageCache: {pte.PageCache}\n" +
                $"Accessed: {pte.Accessed}\n" +
                $"Dirty: {pte.Dirty}\n" +
                $"PageAccessType: {pte.PageAccessType}\n" +
                $"Global: {pte.Global}\n" +
                $"PFN: 0x{pte.PFN:X8}\n" +
                $"ProtectionKey: 0x{pte.ProtectionKey:X8}\n" +
                $"NX: {pte.NX}";
        }

        private void PopulateListView(object[] ptes, ListBox listView)
        {
            var isPml4ListEmpty = listView.Items.Count == 0;


            for (int i = 0; i < ptes.Length; i++)
            {
                var item = $"[ {i} ] ➔ PA: 0x{(((PTE)ptes[i]).PFN) << 12:X8}";
                if (isPml4ListEmpty)
                    listView.Items.Add(item);
                else
                    listView.Items[i] = item;
            }
        }

        private void UpdateVirtualAddress()
        {
            string vaInfo = "";
            if (PML4ListBox.SelectedItems.Count > 0)
            {
                vaInfo += "PML4 Index: " + PML4ListBox.SelectedIndex + "\n";
            }

            if (PDPTListBox.SelectedItems.Count > 0)
            {
                vaInfo += "PDPT Index: " + PDPTListBox.SelectedIndex + "\n";
            }

            if (PDListBox.SelectedItems.Count > 0)
            {
                vaInfo += "PD Index: " + PDListBox.SelectedIndex + "\n";
            }

            if (PTListBox.SelectedItems.Count > 0)
            {
                vaInfo += "PT Index: " + PTListBox.SelectedIndex + "\n";
            }

            VirtualAddress virtualAddress = new VirtualAddress(0x0);
            virtualAddress.PML4Index = (ulong)(PML4ListBox.SelectedIndex == -1 ? 0 : PML4ListBox.SelectedIndex);
            virtualAddress.PDPTIndex = (ulong)(PDPTListBox.SelectedIndex == -1 ? 0 : PDPTListBox.SelectedIndex);
            virtualAddress.PDIndex = (ulong)(PDListBox.SelectedIndex == -1 ? 0 : PDListBox.SelectedIndex);
            virtualAddress.PTIndex = (ulong)(PTListBox.SelectedIndex == -1 ? 0 : PTListBox.SelectedIndex);

            //make sure the address is canonical
            if (virtualAddress.PML4Index > 255) virtualAddress.Reserved = 0xFFFF;

            VirtualAddressInfoLbl.Text = vaInfo;
            VirtualAddressOutput.Text = $"0x{virtualAddress.Value:X8}";
        }

        private void UpdateContentTmr_Tick(object sender, EventArgs e)
        {
            DumpPageTables();
            WriteEntryInfo();
            UpdateVirtualAddress();
        }

        private SolidBrush LightBlue = new SolidBrush(Color.LightBlue);
        private SolidBrush LightGreen = new SolidBrush(Color.LightGreen);

        private void PML4ListBox_DrawItem(object sender, DrawItemEventArgs e) => DrawListBoxItem(PML4ListBox, e, PML4Es);
        private void PDPTListBox_DrawItem(object sender, DrawItemEventArgs e) => DrawListBoxItem(PDPTListBox, e, PDPTEs);
        private void PDListBox_DrawItem(object sender, DrawItemEventArgs e) => DrawListBoxItem(PDListBox, e, PDEs);
        private void PTListBox_DrawItem(object sender, DrawItemEventArgs e) => DrawListBoxItem(PTListBox, e, PTEs);

        private void DrawListBoxItem(ListBox listBox, DrawItemEventArgs e, object[] ptes)
        {
            if (e.Index > -1)
            {
                bool isNxHighlightMode = HighlightModeNx.Checked;
                var pml4e = (PML4E)ptes[e.Index];

                if (pml4e.Present > 0 && pml4e.PFN != 0x0 && !HighlightModeNone.Checked)
                {
                    if (isNxHighlightMode && pml4e.NX > 0)
                    {
                        e.Graphics.FillRectangle(LightBlue, e.Bounds);
                    }
                    else if (!isNxHighlightMode)
                    {
                        if (pml4e.UserSupervisor > 0)
                            e.Graphics.FillRectangle(LightGreen, e.Bounds);
                        else
                            e.Graphics.FillRectangle(LightBlue, e.Bounds);
                    }
                    else e.DrawBackground();
                }
                else e.DrawBackground();

                using (Brush textBrush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(listBox.Items[e.Index].ToString(), e.Font, textBrush, e.Bounds.Location);
                }
            }
        }

        private void HighlightModeNx_CheckedChanged(object sender, EventArgs e)
        {
            PML4ListBox.Refresh();
            PDPTListBox.Refresh();
            PDListBox.Refresh();
            PTListBox.Refresh();
        }

        private void HighlightModeNone_CheckedChanged(object sender, EventArgs e)
        {
            PML4ListBox.Refresh();
            PDPTListBox.Refresh();
            PDListBox.Refresh();
            PTListBox.Refresh();
        }

        private void VirtualAddressInput_TextChanged(object sender, EventArgs e)
        {
            if(ulong.TryParse(VirtualAddressInput.Text.Replace("0x", ""), NumberStyles.HexNumber, CultureInfo.CurrentCulture, out ulong address))
            {
                VirtualAddress va = new VirtualAddress(address);
                VirtualAddressInfoLblInput.Text =
                    $"PML4 Index: {va.PML4Index}\n" +
                    $"PDPT Index: {va.PDPTIndex}\n" +
                    $"PD Index: {va.PDIndex}\n" +
                    $"PT Index: {va.PTIndex}\n";
            }
            else
            {
                VirtualAddressInfoLblInput.Text = "";
            }
        }

        private void TranslateBtn_Click(object sender, EventArgs e)
        {
            if (ulong.TryParse(VirtualAddressInput.Text.Replace("0x", ""), NumberStyles.HexNumber, CultureInfo.CurrentCulture, out ulong address))
            {
                VirtualAddress va = new VirtualAddress(address);

                if (PML4ListBox.Items.Count == 512) PML4ListBox.SelectedIndex = (int)va.PML4Index;
                DumpPageTables();
                if (PDPTListBox.Items.Count == 512) PDPTListBox.SelectedIndex = (int)va.PDPTIndex;
                DumpPageTables();
                if (PDListBox.Items.Count == 512) PDListBox.SelectedIndex = (int)va.PDIndex;
                DumpPageTables();
                if (PTListBox.Items.Count == 512) PTListBox.SelectedIndex = (int)va.PTIndex;
            }
            else
            {
                MessageBox.Show("Invalid address!");
            }
        }

        private void DumpPageBtn_Click(object sender, EventArgs e)
        {
            if(PTListBox.SelectedItems.Count > 0)
            {
                var pte = PTEs[PTListBox.SelectedIndex];
                if(pte.Present > 0 && pte.PFN != 0x0)
                {
                    var pageDump = Driver.DumpPage(pte.PFN);
                    HexDumpView hdv = new HexDumpView(pageDump);
                    hdv.Show();
                }
                else
                {
                    if (MessageBox.Show("PTE is invalid, do you want to dump it anyways?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var pageDump = Driver.DumpPage(pte.PFN);
                        HexDumpView hdv = new HexDumpView(pageDump);
                        hdv.Show();
                    }
                }
            }
            else
                MessageBox.Show("No Page Table Entry selected!");
        }
    }
}
