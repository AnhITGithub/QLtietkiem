
namespace QLtietkiem
{
    partial class dangnhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dangnhap));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.bt_login = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkTK = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkMK = new System.Windows.Forms.ErrorProvider(this.components);
            this.correctTK = new System.Windows.Forms.ErrorProvider(this.components);
            this.banTK = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkMK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.correctTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banTK)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(362, 115);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 23);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(361, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tài khoản";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(361, 186);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtTK
            // 
            this.txtTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTK.Location = new System.Drawing.Point(366, 139);
            this.txtTK.Margin = new System.Windows.Forms.Padding(4);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(350, 34);
            this.txtTK.TabIndex = 3;
            this.txtTK.TextChanged += new System.EventHandler(this.txtTK_TextChanged);
            // 
            // txtMK
            // 
            this.txtMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMK.Location = new System.Drawing.Point(366, 219);
            this.txtMK.Margin = new System.Windows.Forms.Padding(4);
            this.txtMK.Name = "txtMK";
            this.txtMK.PasswordChar = '*';
            this.txtMK.Size = new System.Drawing.Size(350, 34);
            this.txtMK.TabIndex = 4;
            this.txtMK.TextChanged += new System.EventHandler(this.txtMK_TextChanged);
            // 
            // bt_login
            // 
            this.bt_login.BackColor = System.Drawing.Color.Chartreuse;
            this.bt_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_login.ForeColor = System.Drawing.Color.Black;
            this.bt_login.Location = new System.Drawing.Point(366, 278);
            this.bt_login.Margin = new System.Windows.Forms.Padding(4);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(350, 38);
            this.bt_login.TabIndex = 5;
            this.bt_login.Text = "Đăng Nhập";
            this.bt_login.UseVisualStyleBackColor = false;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            this.bt_login.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bt_login_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.ImageKey = "(none)";
            this.label4.Location = new System.Drawing.Point(362, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Quên mật khẩu ?";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(882, 29);
            this.label6.TabIndex = 9;
            this.label6.Text = "PHẦN MỀM QUẢN LÝ TIỀN GỬI TIẾT KIỆM CHO KHÁCH TẠI NGÂN HÀNG";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(43, 106);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 258);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // checkTK
            // 
            this.checkTK.ContainerControl = this;
            // 
            // checkMK
            // 
            this.checkMK.ContainerControl = this;
            // 
            // correctTK
            // 
            this.correctTK.ContainerControl = this;
            this.correctTK.Icon = ((System.Drawing.Icon)(resources.GetObject("correctTK.Icon")));
            // 
            // banTK
            // 
            this.banTK.ContainerControl = this;
            this.banTK.Icon = ((System.Drawing.Icon)(resources.GetObject("banTK.Icon")));
            // 
            // dangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(938, 466);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bt_login);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "dangnhap";
            this.Text = "ĐĂNG NHẬP";
            this.Load += new System.EventHandler(this.login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkMK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.correctTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banTK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider checkTK;
        private System.Windows.Forms.ErrorProvider checkMK;
        private System.Windows.Forms.ErrorProvider correctTK;
        private System.Windows.Forms.ErrorProvider banTK;
    }
}