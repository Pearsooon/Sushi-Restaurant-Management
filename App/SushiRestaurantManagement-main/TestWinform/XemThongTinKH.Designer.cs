namespace TestWinform
{
    partial class XemThongTinKH
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
            BackButton = new Button();
            txt_Username = new TextBox();
            txt_password = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ConfirmButton = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // BackButton
            // 
            BackButton.Location = new Point(3, -1);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(146, 76);
            BackButton.TabIndex = 0;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // txt_Username
            // 
            txt_Username.Location = new Point(413, 128);
            txt_Username.Name = "txt_Username";
            txt_Username.Size = new Size(676, 39);
            txt_Username.TabIndex = 1;
            txt_Username.TextChanged += textBox1_TextChanged;
            // 
            // txt_password
            // 
            txt_password.Location = new Point(413, 257);
            txt_password.Name = "txt_password";
            txt_password.Size = new Size(676, 39);
            txt_password.TabIndex = 2;
            txt_password.TextChanged += txt_password_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(413, 93);
            label1.Name = "label1";
            label1.Size = new Size(218, 32);
            label1.TabIndex = 3;
            label1.Text = "Nhập mã tài khoản";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(413, 222);
            label2.Name = "label2";
            label2.Size = new Size(179, 32);
            label2.TabIndex = 4;
            label2.Text = "Nhập mật khẩu";
            label2.Click += label2_Click;
            // 
            // ConfirmButton
            // 
            ConfirmButton.Location = new Point(939, 344);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(150, 46);
            ConfirmButton.TabIndex = 5;
            ConfirmButton.Text = "Confirm";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(213, 436);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1139, 141);
            dataGridView1.TabIndex = 6;
            // 
            // XemThongTinKH
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1555, 852);
            Controls.Add(dataGridView1);
            Controls.Add(ConfirmButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txt_password);
            Controls.Add(txt_Username);
            Controls.Add(BackButton);
            Name = "XemThongTinKH";
            Text = "XemThongTinKH";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BackButton;
        private TextBox txt_Username;
        private TextBox txt_password;
        private Label label1;
        private Label label2;
        private Button ConfirmButton;
        private DataGridView dataGridView1;
    }
}