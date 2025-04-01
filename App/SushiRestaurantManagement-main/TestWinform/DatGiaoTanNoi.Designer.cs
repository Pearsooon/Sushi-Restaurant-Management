namespace TestWinform
{
    partial class DatGiaoTanNoi
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
            ConfirmButton = new Button();
            dataGridView2 = new DataGridView();
            label1 = new Label();
            maChiNhanh_text = new TextBox();
            dataGridView1 = new DataGridView();
            dataGridView3 = new DataGridView();
            ConfirmOrderButton = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ConfirmGiaoTanNoi = new Button();
            BackButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // ConfirmButton
            // 
            ConfirmButton.Location = new Point(604, 281);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(150, 46);
            ConfirmButton.TabIndex = 9;
            ConfirmButton.Text = "Xác nhận";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 725);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 82;
            dataGridView2.Size = new Size(726, 277);
            dataGridView2.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(-5, 281);
            label1.Name = "label1";
            label1.Size = new Size(339, 32);
            label1.TabIndex = 7;
            label1.Text = "Hãy chọn chi nhánh muốn đặt";
            // 
            // maChiNhanh_text
            // 
            maChiNhanh_text.Location = new Point(361, 281);
            maChiNhanh_text.Name = "maChiNhanh_text";
            maChiNhanh_text.Size = new Size(200, 39);
            maChiNhanh_text.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 1);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1364, 277);
            dataGridView1.TabIndex = 5;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(12, 417);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 82;
            dataGridView3.Size = new Size(1249, 277);
            dataGridView3.TabIndex = 10;
            dataGridView3.CellContentClick += dataGridView3_CellContentClick;
            // 
            // ConfirmOrderButton
            // 
            ConfirmOrderButton.Font = new Font("Segoe UI", 12F);
            ConfirmOrderButton.Location = new Point(776, 913);
            ConfirmOrderButton.Name = "ConfirmOrderButton";
            ConfirmOrderButton.Size = new Size(303, 89);
            ConfirmOrderButton.TabIndex = 11;
            ConfirmOrderButton.Text = "Xác nhận món ăn";
            ConfirmOrderButton.UseVisualStyleBackColor = true;
            ConfirmOrderButton.Click += ConfirmOrderButton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1335, 444);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(565, 39);
            textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1335, 546);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(565, 39);
            textBox2.TabIndex = 13;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1335, 643);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(565, 39);
            textBox3.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1335, 409);
            label2.Name = "label2";
            label2.Size = new Size(218, 32);
            label2.TabIndex = 15;
            label2.Text = "Nhập số điện thoại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1335, 511);
            label3.Name = "label3";
            label3.Size = new Size(202, 32);
            label3.TabIndex = 16;
            label3.Text = "Nhập địa chỉ giao";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1335, 608);
            label4.Name = "label4";
            label4.Size = new Size(279, 32);
            label4.TabIndex = 17;
            label4.Text = "Ghi chú món ăn (nếu có)";
            // 
            // ConfirmGiaoTanNoi
            // 
            ConfirmGiaoTanNoi.Location = new Point(1606, 728);
            ConfirmGiaoTanNoi.Name = "ConfirmGiaoTanNoi";
            ConfirmGiaoTanNoi.Size = new Size(294, 46);
            ConfirmGiaoTanNoi.TabIndex = 18;
            ConfirmGiaoTanNoi.Text = "Xác nhận đặt hàng";
            ConfirmGiaoTanNoi.UseVisualStyleBackColor = true;
            ConfirmGiaoTanNoi.Click += ConfirmGiaoTanNoi_Click;
            // 
            // BackButton
            // 
            BackButton.Font = new Font("Segoe UI", 12F);
            BackButton.Location = new Point(1782, 918);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(180, 78);
            BackButton.TabIndex = 19;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // DatGiaoTanNoi
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1974, 1014);
            Controls.Add(BackButton);
            Controls.Add(ConfirmGiaoTanNoi);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(ConfirmOrderButton);
            Controls.Add(dataGridView3);
            Controls.Add(ConfirmButton);
            Controls.Add(dataGridView2);
            Controls.Add(label1);
            Controls.Add(maChiNhanh_text);
            Controls.Add(dataGridView1);
            Name = "DatGiaoTanNoi";
            Text = "DatGiaoTanNoi";
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ConfirmButton;
        private DataGridView dataGridView2;
        private Label label1;
        private TextBox maChiNhanh_text;
        private DataGridView dataGridView1;
        private DataGridView dataGridView3;
        private Button ConfirmOrderButton;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button ConfirmGiaoTanNoi;
        private Button BackButton;
    }
}