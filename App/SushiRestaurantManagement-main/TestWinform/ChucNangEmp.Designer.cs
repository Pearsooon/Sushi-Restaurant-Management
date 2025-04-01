namespace TestWinform
{
    partial class ChucNangEmp
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
            CreateOrderButton = new Button();
            XemChiNhanhButton = new Button();
            SuspendLayout();
            // 
            // CreateOrderButton
            // 
            CreateOrderButton.Font = new Font("Segoe UI", 12F);
            CreateOrderButton.Location = new Point(81, 202);
            CreateOrderButton.Name = "CreateOrderButton";
            CreateOrderButton.Size = new Size(215, 82);
            CreateOrderButton.TabIndex = 0;
            CreateOrderButton.Text = "Tạo Order";
            CreateOrderButton.UseVisualStyleBackColor = true;
            CreateOrderButton.Click += CreateOrderButton_Click;
            // 
            // XemChiNhanhButton
            // 
            XemChiNhanhButton.Font = new Font("Segoe UI", 12F);
            XemChiNhanhButton.Location = new Point(747, 202);
            XemChiNhanhButton.Name = "XemChiNhanhButton";
            XemChiNhanhButton.Size = new Size(441, 82);
            XemChiNhanhButton.TabIndex = 1;
            XemChiNhanhButton.Text = "Xem thông tin chi nhánh";
            XemChiNhanhButton.UseVisualStyleBackColor = true;
            XemChiNhanhButton.Click += XemChiNhanhButton_Click;
            // 
            // ChucNangEmp
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 856);
            Controls.Add(XemChiNhanhButton);
            Controls.Add(CreateOrderButton);
            Name = "ChucNangEmp";
            Text = "ChucNangEmp";
            ResumeLayout(false);
        }

        #endregion

        private Button CreateOrderButton;
        private Button XemChiNhanhButton;
    }
}