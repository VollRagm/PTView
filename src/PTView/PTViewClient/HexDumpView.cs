using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTViewClient
{
    public partial class HexDumpView : Form
    {
        private byte[] Data;

        public HexDumpView(byte[] data)
        {
            InitializeComponent();
            Data = data;

            ByteViewer bw = new ByteViewer();
            bw.SetBytes(Data);
            bw.Height = ByteViewerPanel.Height;
            ByteViewerPanel.Controls.Add(bw);
        }

        private void SaveRawBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save dump...";
            sfd.InitialDirectory = Directory.GetCurrentDirectory();
            
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(sfd.FileName, Data);
            }
        }
    }
}
