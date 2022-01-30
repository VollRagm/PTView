
namespace PTViewClient
{
    partial class HexDumpView
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
            this.ByteViewerPanel = new System.Windows.Forms.Panel();
            this.SaveRawBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ByteViewerPanel
            // 
            this.ByteViewerPanel.Location = new System.Drawing.Point(1, 2);
            this.ByteViewerPanel.Name = "ByteViewerPanel";
            this.ByteViewerPanel.Size = new System.Drawing.Size(660, 547);
            this.ByteViewerPanel.TabIndex = 0;
            // 
            // SaveRawBtn
            // 
            this.SaveRawBtn.Location = new System.Drawing.Point(586, 555);
            this.SaveRawBtn.Name = "SaveRawBtn";
            this.SaveRawBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveRawBtn.TabIndex = 1;
            this.SaveRawBtn.Text = "Save Raw";
            this.SaveRawBtn.UseVisualStyleBackColor = true;
            this.SaveRawBtn.Click += new System.EventHandler(this.SaveRawBtn_Click);
            // 
            // HexDumpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 590);
            this.Controls.Add(this.SaveRawBtn);
            this.Controls.Add(this.ByteViewerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HexDumpView";
            this.Text = "Hex Dump";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ByteViewerPanel;
        private System.Windows.Forms.Button SaveRawBtn;
    }
}