namespace TestWinform
{
    partial class ChucNangKH
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed of; otherwise, false.</param>
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
            thongTinCaNhan_button = new Button();
            datTrucTuyen_button = new Button();
            datTanNoi_button = new Button();
            SuspendLayout();
            // 
            // thongTinCaNhan_button
            // 
            thongTinCaNhan_button.Location = new Point(3, 0);
            thongTinCaNhan_button.Name = "thongTinCaNhan_button";
            thongTinCaNhan_button.Size = new Size(301, 60);
            thongTinCaNhan_button.TabIndex = 0;
            thongTinCaNhan_button.Text = "Thông tin cá nhân";
            thongTinCaNhan_button.UseVisualStyleBackColor = true;
            thongTinCaNhan_button.Click += thongTinCaNhan_button_Click;
            // 
            // datTrucTuyen_button
            // 
            datTrucTuyen_button.Location = new Point(3, 149);
            datTrucTuyen_button.Name = "datTrucTuyen_button";
            datTrucTuyen_button.Size = new Size(301, 55);
            datTrucTuyen_button.TabIndex = 1;
            datTrucTuyen_button.Text = "Đặt chỗ trước";
            datTrucTuyen_button.UseVisualStyleBackColor = true;
            datTrucTuyen_button.Click += datTrucTuyen_button_Click;
            // 
            // datTanNoi_button
            // 
            datTanNoi_button.Location = new Point(3, 288);
            datTanNoi_button.Name = "datTanNoi_button";
            datTanNoi_button.Size = new Size(301, 55);
            datTanNoi_button.TabIndex = 2;
            datTanNoi_button.Text = "Đặt giao tận nơi";
            datTanNoi_button.UseVisualStyleBackColor = true;
            datTanNoi_button.Click += datTanNoi_button_Click;
            // 
            // ChucNangKH
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1372, 891);
            Controls.Add(datTanNoi_button);
            Controls.Add(datTrucTuyen_button);
            Controls.Add(thongTinCaNhan_button);
            Name = "ChucNangKH";
            Text = "ChucNangKH";
            Load += ChucNangKH_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button thongTinCaNhan_button;
        private Button datTrucTuyen_button;
        private Button datTanNoi_button;
    }
}
