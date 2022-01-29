
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
            this.lbl1 = new System.Windows.Forms.Label();
            this.ProcessesComboBox = new System.Windows.Forms.ComboBox();
            this.PTViewPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.PTListBox = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.PDListBox = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.PDPTListBox = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.PML4ListBox = new System.Windows.Forms.ListView();
            this.DirbaseLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.PTViewPanel.SuspendLayout();
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
            this.PTViewPanel.Size = new System.Drawing.Size(1145, 575);
            this.PTViewPanel.TabIndex = 2;
            this.PTViewPanel.Visible = false;
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
            this.PTListBox.FullRowSelect = true;
            this.PTListBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.PTListBox.HideSelection = false;
            this.PTListBox.Location = new System.Drawing.Point(678, 58);
            this.PTListBox.MultiSelect = false;
            this.PTListBox.Name = "PTListBox";
            this.PTListBox.Size = new System.Drawing.Size(210, 433);
            this.PTListBox.TabIndex = 1;
            this.PTListBox.UseCompatibleStateImageBehavior = false;
            this.PTListBox.View = System.Windows.Forms.View.Details;
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
            this.PDListBox.FullRowSelect = true;
            this.PDListBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.PDListBox.HideSelection = false;
            this.PDListBox.Location = new System.Drawing.Point(462, 58);
            this.PDListBox.MultiSelect = false;
            this.PDListBox.Name = "PDListBox";
            this.PDListBox.Size = new System.Drawing.Size(210, 433);
            this.PDListBox.TabIndex = 1;
            this.PDListBox.UseCompatibleStateImageBehavior = false;
            this.PDListBox.View = System.Windows.Forms.View.Details;
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
            this.PDPTListBox.FullRowSelect = true;
            this.PDPTListBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.PDPTListBox.HideSelection = false;
            this.PDPTListBox.Location = new System.Drawing.Point(246, 58);
            this.PDPTListBox.MultiSelect = false;
            this.PDPTListBox.Name = "PDPTListBox";
            this.PDPTListBox.Size = new System.Drawing.Size(210, 433);
            this.PDPTListBox.TabIndex = 1;
            this.PDPTListBox.UseCompatibleStateImageBehavior = false;
            this.PDPTListBox.View = System.Windows.Forms.View.Details;
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
            this.PML4ListBox.FullRowSelect = true;
            this.PML4ListBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.PML4ListBox.HideSelection = false;
            this.PML4ListBox.Location = new System.Drawing.Point(30, 58);
            this.PML4ListBox.MultiSelect = false;
            this.PML4ListBox.Name = "PML4ListBox";
            this.PML4ListBox.Size = new System.Drawing.Size(210, 433);
            this.PML4ListBox.TabIndex = 1;
            this.PML4ListBox.UseCompatibleStateImageBehavior = false;
            this.PML4ListBox.View = System.Windows.Forms.View.Details;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 632);
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
        private System.Windows.Forms.ListView PTListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView PDListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView PDPTListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView PML4ListBox;
    }
}

