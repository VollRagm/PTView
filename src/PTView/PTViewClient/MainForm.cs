using PTViewClient.PTView;
using PTViewClient.PTView.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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

        private DriverInterface Driver;

        public MainForm()
        {
            InitializeComponent();

            VirtualAddress pml4e = new VirtualAddress(0xfffff807071ff180);

            PML4ListBox.Columns.Add("", -2);
            PDPTListBox.Columns.Add("", -2);
            PDListBox.Columns.Add("", -2);
            PTListBox.Columns.Add("", -2);

            Driver = new DriverInterface();
            //if (!Driver.Initialize("PTView"))
            //{

            //    MessageBox.Show("Driver could not be initialized, make sure it's loaded properly.");
            //    Environment.Exit(0);
            //}
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
        }

        private void DumpPageTables()
        {
            PML4Es = Driver.DumpPageTables(SelectedProcessDirbase).Cast<PML4E>().ToArray();

            var isPml4ListEmpty = PML4ListBox.Items.Count == 0;

            for(int i = 0; i < PML4Es.Length; i++)
            {
                var item = $"[ {i} ] ➔ PFN: 0x{(PML4Es[i].PFN << 12):X8}";
                if (isPml4ListEmpty)
                    PML4ListBox.Items.Add(item);
                else
                    PML4ListBox.Items[i] = new ListViewItem(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var proc  = Process.Start("sc", "start PTView");
            proc.WaitForExit();
            Driver.Initialize("PTView");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("sc", "stop PTView");
        }
    }
}
