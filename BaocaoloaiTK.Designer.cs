
namespace QLtietkiem
{
    partial class BaocaoloaiTK
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
            this.crystalReportViewerloaiTK = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerloaiTK
            // 
            this.crystalReportViewerloaiTK.ActiveViewIndex = -1;
            this.crystalReportViewerloaiTK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerloaiTK.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerloaiTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerloaiTK.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerloaiTK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.crystalReportViewerloaiTK.Name = "crystalReportViewerloaiTK";
            this.crystalReportViewerloaiTK.Size = new System.Drawing.Size(1067, 554);
            this.crystalReportViewerloaiTK.TabIndex = 0;
            this.crystalReportViewerloaiTK.ToolPanelWidth = 267;
            // 
            // BaocaoloaiTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.crystalReportViewerloaiTK);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BaocaoloaiTK";
            this.Text = "BaocaoloaiTK";
            this.Load += new System.EventHandler(this.BaocaoloaiTK_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerloaiTK;
    }
}