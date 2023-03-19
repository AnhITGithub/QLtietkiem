
namespace QLtietkiem
{
    partial class BaocaoNV
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
            this.crystalReportViewerNV = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerNV
            // 
            this.crystalReportViewerNV.ActiveViewIndex = -1;
            this.crystalReportViewerNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerNV.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerNV.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerNV.Margin = new System.Windows.Forms.Padding(4);
            this.crystalReportViewerNV.Name = "crystalReportViewerNV";
            this.crystalReportViewerNV.Size = new System.Drawing.Size(1067, 554);
            this.crystalReportViewerNV.TabIndex = 0;
            this.crystalReportViewerNV.ToolPanelWidth = 267;
            // 
            // BaocaoNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.crystalReportViewerNV);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BaocaoNV";
            this.Text = "BaocaoNV";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BaocaoNV_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerNV;
    }
}