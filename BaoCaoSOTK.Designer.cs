namespace QLtietkiem
{
    partial class BaoCaoSOTK
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
            this.crystalReportViewerSOTK = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerSOTK
            // 
            this.crystalReportViewerSOTK.ActiveViewIndex = -1;
            this.crystalReportViewerSOTK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerSOTK.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerSOTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerSOTK.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerSOTK.Name = "crystalReportViewerSOTK";
            this.crystalReportViewerSOTK.Size = new System.Drawing.Size(800, 450);
            this.crystalReportViewerSOTK.TabIndex = 0;
            // 
            // BaoCaoSOTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crystalReportViewerSOTK);
            this.Name = "BaoCaoSOTK";
            this.Text = "BaoCaoSOTK";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerSOTK;
    }
}