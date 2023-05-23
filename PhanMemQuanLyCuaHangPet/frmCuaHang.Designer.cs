namespace PhanMemQuanLyCuaHangPet
{
    partial class frmCuaHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuaHang));
            this.label1 = new System.Windows.Forms.Label();
            this.pbxBird = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pbxFish = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pbxCat = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pbxDog = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnThoat = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDog)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(349, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(625, 37);
            this.label1.TabIndex = 13;
            this.label1.Text = "Chào Mừng Đến Với Cửa Hàng Thú Cưng!";
            // 
            // pbxBird
            // 
            this.pbxBird.Image = ((System.Drawing.Image)(resources.GetObject("pbxBird.Image")));
            this.pbxBird.ImageRotate = 0F;
            this.pbxBird.Location = new System.Drawing.Point(697, 451);
            this.pbxBird.Name = "pbxBird";
            this.pbxBird.Size = new System.Drawing.Size(527, 307);
            this.pbxBird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxBird.TabIndex = 12;
            this.pbxBird.TabStop = false;
            // 
            // pbxFish
            // 
            this.pbxFish.Image = ((System.Drawing.Image)(resources.GetObject("pbxFish.Image")));
            this.pbxFish.ImageRotate = 0F;
            this.pbxFish.Location = new System.Drawing.Point(76, 451);
            this.pbxFish.Name = "pbxFish";
            this.pbxFish.Size = new System.Drawing.Size(527, 307);
            this.pbxFish.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxFish.TabIndex = 11;
            this.pbxFish.TabStop = false;
            // 
            // pbxCat
            // 
            this.pbxCat.Image = ((System.Drawing.Image)(resources.GetObject("pbxCat.Image")));
            this.pbxCat.ImageRotate = 0F;
            this.pbxCat.Location = new System.Drawing.Point(697, 119);
            this.pbxCat.Name = "pbxCat";
            this.pbxCat.Size = new System.Drawing.Size(527, 307);
            this.pbxCat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCat.TabIndex = 10;
            this.pbxCat.TabStop = false;
            // 
            // pbxDog
            // 
            this.pbxDog.Image = ((System.Drawing.Image)(resources.GetObject("pbxDog.Image")));
            this.pbxDog.ImageRotate = 0F;
            this.pbxDog.Location = new System.Drawing.Point(76, 119);
            this.pbxDog.Name = "pbxDog";
            this.pbxDog.Size = new System.Drawing.Size(527, 307);
            this.pbxDog.TabIndex = 9;
            this.pbxDog.TabStop = false;
            // 
            // btnThoat
            // 
            this.btnThoat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThoat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThoat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThoat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThoat.FillColor = System.Drawing.Color.Transparent;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageSize = new System.Drawing.Size(30, 30);
            this.btnThoat.Location = new System.Drawing.Point(1267, -1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(33, 34);
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmCuaHang
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbxBird);
            this.Controls.Add(this.pbxFish);
            this.Controls.Add(this.pbxCat);
            this.Controls.Add(this.pbxDog);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCuaHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCuaHang";
            ((System.ComponentModel.ISupportInitialize)(this.pbxBird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox pbxBird;
        private Guna.UI2.WinForms.Guna2PictureBox pbxFish;
        private Guna.UI2.WinForms.Guna2PictureBox pbxCat;
        private Guna.UI2.WinForms.Guna2PictureBox pbxDog;
        private Guna.UI2.WinForms.Guna2Button btnThoat;
    }
}