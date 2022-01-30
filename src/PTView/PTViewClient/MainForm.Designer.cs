
namespace PTViewClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl1 = new System.Windows.Forms.Label();
            this.ProcessesComboBox = new System.Windows.Forms.ComboBox();
            this.PTViewPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.VirtualAddressInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.VirtualAddressOutput = new System.Windows.Forms.TextBox();
            this.VirtualAddressInfoLbl = new System.Windows.Forms.Label();
            this.PTeInfoLbl = new System.Windows.Forms.Label();
            this.PDeInfoLbl = new System.Windows.Forms.Label();
            this.PDPTeLblInfo = new System.Windows.Forms.Label();
            this.PML4eInfoLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PTListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PDListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PDPTListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PML4ListBox = new System.Windows.Forms.ListBox();
            this.DirbaseLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.UpdateContentTmr = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.HighlightModeNx = new System.Windows.Forms.RadioButton();
            this.HighlightModeSupervisor = new System.Windows.Forms.RadioButton();
            this.HighlightModeNone = new System.Windows.Forms.RadioButton();
            this.VirtualAddressInfoLblInput = new System.Windows.Forms.Label();
            this.TranslateBtn = new System.Windows.Forms.Button();
            this.DumpPageBtn = new System.Windows.Forms.Button();
            this.PTViewPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(25, 21);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(48, 13);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Process:";
            // 
            // ProcessesComboBox
            // 
            this.ProcessesComboBox.FormattingEnabled = true;
            this.ProcessesComboBox.Location = new System.Drawing.Point(79, 18);
            this.ProcessesComboBox.Name = "ProcessesComboBox";
            this.ProcessesComboBox.Size = new System.Drawing.Size(211, 21);
            this.ProcessesComboBox.TabIndex = 1;
            this.ProcessesComboBox.DropDown += new System.EventHandler(this.ProcessesComboBox_DropDown);
            this.ProcessesComboBox.SelectedValueChanged += new System.EventHandler(this.ProcessesComboBox_SelectedValueChanged);
            // 
            // PTViewPanel
            // 
            this.PTViewPanel.Controls.Add(this.DumpPageBtn);
            this.PTViewPanel.Controls.Add(this.groupBox2);
            this.PTViewPanel.Controls.Add(this.groupBox1);
            this.PTViewPanel.Controls.Add(this.PTeInfoLbl);
            this.PTViewPanel.Controls.Add(this.PDeInfoLbl);
            this.PTViewPanel.Controls.Add(this.PDPTeLblInfo);
            this.PTViewPanel.Controls.Add(this.PML4eInfoLbl);
            this.PTViewPanel.Controls.Add(this.label4);
            this.PTViewPanel.Controls.Add(this.PTListBox);
            this.PTViewPanel.Controls.Add(this.label3);
            this.PTViewPanel.Controls.Add(this.PDListBox);
            this.PTViewPanel.Controls.Add(this.label2);
            this.PTViewPanel.Controls.Add(this.PDPTListBox);
            this.PTViewPanel.Controls.Add(this.label1);
            this.PTViewPanel.Controls.Add(this.PML4ListBox);
            this.PTViewPanel.Controls.Add(this.DirbaseLbl);
            this.PTViewPanel.Location = new System.Drawing.Point(12, 45);
            this.PTViewPanel.Name = "PTViewPanel";
            this.PTViewPanel.Size = new System.Drawing.Size(1145, 661);
            this.PTViewPanel.TabIndex = 2;
            this.PTViewPanel.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TranslateBtn);
            this.groupBox2.Controls.Add(this.VirtualAddressInfoLblInput);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.VirtualAddressInput);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(906, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 149);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Address Translation";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Virtual Address:";
            // 
            // VirtualAddressInput
            // 
            this.VirtualAddressInput.Location = new System.Drawing.Point(88, 25);
            this.VirtualAddressInput.Name = "VirtualAddressInput";
            this.VirtualAddressInput.Size = new System.Drawing.Size(125, 20);
            this.VirtualAddressInput.TabIndex = 1;
            this.VirtualAddressInput.TextChanged += new System.EventHandler(this.VirtualAddressInput_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.VirtualAddressOutput);
            this.groupBox1.Controls.Add(this.VirtualAddressInfoLbl);
            this.groupBox1.Location = new System.Drawing.Point(906, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 122);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Virtual Address";
            // 
            // VirtualAddressOutput
            // 
            this.VirtualAddressOutput.Location = new System.Drawing.Point(9, 92);
            this.VirtualAddressOutput.Name = "VirtualAddressOutput";
            this.VirtualAddressOutput.ReadOnly = true;
            this.VirtualAddressOutput.Size = new System.Drawing.Size(205, 20);
            this.VirtualAddressOutput.TabIndex = 1;
            // 
            // VirtualAddressInfoLbl
            // 
            this.VirtualAddressInfoLbl.AutoSize = true;
            this.VirtualAddressInfoLbl.Location = new System.Drawing.Point(17, 25);
            this.VirtualAddressInfoLbl.Name = "VirtualAddressInfoLbl";
            this.VirtualAddressInfoLbl.Size = new System.Drawing.Size(0, 13);
            this.VirtualAddressInfoLbl.TabIndex = 0;
            // 
            // PTeInfoLbl
            // 
            this.PTeInfoLbl.AutoSize = true;
            this.PTeInfoLbl.Location = new System.Drawing.Point(687, 495);
            this.PTeInfoLbl.Name = "PTeInfoLbl";
            this.PTeInfoLbl.Size = new System.Drawing.Size(0, 13);
            this.PTeInfoLbl.TabIndex = 4;
            // 
            // PDeInfoLbl
            // 
            this.PDeInfoLbl.AutoSize = true;
            this.PDeInfoLbl.Location = new System.Drawing.Point(469, 497);
            this.PDeInfoLbl.Name = "PDeInfoLbl";
            this.PDeInfoLbl.Size = new System.Drawing.Size(0, 13);
            this.PDeInfoLbl.TabIndex = 4;
            // 
            // PDPTeLblInfo
            // 
            this.PDPTeLblInfo.AutoSize = true;
            this.PDPTeLblInfo.Location = new System.Drawing.Point(259, 497);
            this.PDPTeLblInfo.Name = "PDPTeLblInfo";
            this.PDPTeLblInfo.Size = new System.Drawing.Size(0, 13);
            this.PDPTeLblInfo.TabIndex = 4;
            // 
            // PML4eInfoLbl
            // 
            this.PML4eInfoLbl.AutoSize = true;
            this.PML4eInfoLbl.Location = new System.Drawing.Point(39, 497);
            this.PML4eInfoLbl.Name = "PML4eInfoLbl";
            this.PML4eInfoLbl.Size = new System.Drawing.Size(0, 13);
            this.PML4eInfoLbl.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(778, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "PT";
            // 
            // PTListBox
            // 
            this.PTListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PTListBox.Location = new System.Drawing.Point(678, 58);
            this.PTListBox.Name = "PTListBox";
            this.PTListBox.Size = new System.Drawing.Size(210, 433);
            this.PTListBox.TabIndex = 1;
            this.PTListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.PTListBox_DrawItem);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(567, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "PD";
            // 
            // PDListBox
            // 
            this.PDListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PDListBox.Location = new System.Drawing.Point(462, 58);
            this.PDListBox.Name = "PDListBox";
            this.PDListBox.Size = new System.Drawing.Size(210, 433);
            this.PDListBox.TabIndex = 1;
            this.PDListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.PDListBox_DrawItem);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "PDPT";
            // 
            // PDPTListBox
            // 
            this.PDPTListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PDPTListBox.Location = new System.Drawing.Point(246, 58);
            this.PDPTListBox.Name = "PDPTListBox";
            this.PDPTListBox.Size = new System.Drawing.Size(210, 433);
            this.PDPTListBox.TabIndex = 1;
            this.PDPTListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.PDPTListBox_DrawItem);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "PML4";
            // 
            // PML4ListBox
            // 
            this.PML4ListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PML4ListBox.Location = new System.Drawing.Point(30, 58);
            this.PML4ListBox.Name = "PML4ListBox";
            this.PML4ListBox.Size = new System.Drawing.Size(210, 433);
            this.PML4ListBox.TabIndex = 1;
            this.PML4ListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.PML4ListBox_DrawItem);
            // 
            // DirbaseLbl
            // 
            this.DirbaseLbl.AutoSize = true;
            this.DirbaseLbl.Location = new System.Drawing.Point(13, 12);
            this.DirbaseLbl.Name = "DirbaseLbl";
            this.DirbaseLbl.Size = new System.Drawing.Size(70, 13);
            this.DirbaseLbl.TabIndex = 0;
            this.DirbaseLbl.Text = "Dirbase (cr3):";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(938, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1019, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UpdateContentTmr
            // 
            this.UpdateContentTmr.Tick += new System.EventHandler(this.UpdateContentTmr_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(370, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Highlight Mode:";
            // 
            // HighlightModeNx
            // 
            this.HighlightModeNx.AutoSize = true;
            this.HighlightModeNx.Location = new System.Drawing.Point(457, 54);
            this.HighlightModeNx.Name = "HighlightModeNx";
            this.HighlightModeNx.Size = new System.Drawing.Size(117, 17);
            this.HighlightModeNx.TabIndex = 5;
            this.HighlightModeNx.Text = "Highlight NX Pages";
            this.HighlightModeNx.UseVisualStyleBackColor = true;
            this.HighlightModeNx.CheckedChanged += new System.EventHandler(this.HighlightModeNx_CheckedChanged);
            // 
            // HighlightModeSupervisor
            // 
            this.HighlightModeSupervisor.AutoSize = true;
            this.HighlightModeSupervisor.Location = new System.Drawing.Point(457, 34);
            this.HighlightModeSupervisor.Name = "HighlightModeSupervisor";
            this.HighlightModeSupervisor.Size = new System.Drawing.Size(246, 17);
            this.HighlightModeSupervisor.TabIndex = 5;
            this.HighlightModeSupervisor.Text = "Highlight User (Green) and Kernel (Blue) Pages";
            this.HighlightModeSupervisor.UseVisualStyleBackColor = true;
            // 
            // HighlightModeNone
            // 
            this.HighlightModeNone.AutoSize = true;
            this.HighlightModeNone.Checked = true;
            this.HighlightModeNone.Location = new System.Drawing.Point(457, 15);
            this.HighlightModeNone.Name = "HighlightModeNone";
            this.HighlightModeNone.Size = new System.Drawing.Size(51, 17);
            this.HighlightModeNone.TabIndex = 6;
            this.HighlightModeNone.TabStop = true;
            this.HighlightModeNone.Text = "None";
            this.HighlightModeNone.UseVisualStyleBackColor = true;
            this.HighlightModeNone.CheckedChanged += new System.EventHandler(this.HighlightModeNone_CheckedChanged);
            // 
            // VirtualAddressInfoLblInput
            // 
            this.VirtualAddressInfoLblInput.AutoSize = true;
            this.VirtualAddressInfoLblInput.Location = new System.Drawing.Point(16, 50);
            this.VirtualAddressInfoLblInput.Name = "VirtualAddressInfoLblInput";
            this.VirtualAddressInfoLblInput.Size = new System.Drawing.Size(0, 13);
            this.VirtualAddressInfoLblInput.TabIndex = 2;
            // 
            // TranslateBtn
            // 
            this.TranslateBtn.Location = new System.Drawing.Point(60, 117);
            this.TranslateBtn.Name = "TranslateBtn";
            this.TranslateBtn.Size = new System.Drawing.Size(102, 23);
            this.TranslateBtn.TabIndex = 3;
            this.TranslateBtn.Text = "Translate";
            this.TranslateBtn.UseVisualStyleBackColor = true;
            this.TranslateBtn.Click += new System.EventHandler(this.TranslateBtn_Click);
            // 
            // DumpPageBtn
            // 
            this.DumpPageBtn.Location = new System.Drawing.Point(894, 468);
            this.DumpPageBtn.Name = "DumpPageBtn";
            this.DumpPageBtn.Size = new System.Drawing.Size(129, 23);
            this.DumpPageBtn.TabIndex = 7;
            this.DumpPageBtn.Text = "Dump Selected Page";
            this.DumpPageBtn.UseVisualStyleBackColor = true;
            this.DumpPageBtn.Click += new System.EventHandler(this.DumpPageBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 710);
            this.Controls.Add(this.HighlightModeNone);
            this.Controls.Add(this.HighlightModeSupervisor);
            this.Controls.Add(this.HighlightModeNx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PTViewPanel);
            this.Controls.Add(this.ProcessesComboBox);
            this.Controls.Add(this.lbl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "PTView";
            this.PTViewPanel.ResumeLayout(false);
            this.PTViewPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox ProcessesComboBox;
        private System.Windows.Forms.Panel PTViewPanel;
        private System.Windows.Forms.Label DirbaseLbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox PTListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox PDListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox PDPTListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox PML4ListBox;
        private System.Windows.Forms.Timer UpdateContentTmr;
        private System.Windows.Forms.Label PTeInfoLbl;
        private System.Windows.Forms.Label PDeInfoLbl;
        private System.Windows.Forms.Label PDPTeLblInfo;
        private System.Windows.Forms.Label PML4eInfoLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton HighlightModeNx;
        private System.Windows.Forms.RadioButton HighlightModeSupervisor;
        private System.Windows.Forms.RadioButton HighlightModeNone;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label VirtualAddressInfoLbl;
        private System.Windows.Forms.TextBox VirtualAddressOutput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox VirtualAddressInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label VirtualAddressInfoLblInput;
        private System.Windows.Forms.Button TranslateBtn;
        private System.Windows.Forms.Button DumpPageBtn;
    }
}

