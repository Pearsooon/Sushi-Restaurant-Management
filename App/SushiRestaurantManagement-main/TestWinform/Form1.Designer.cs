namespace TestWinform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CustomerButtonLogin = new Button();
            txt_Username = new TextBox();
            txt_password = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            EmployeeLoginButton = new Button();
            SignUpButton = new Button();
            SuspendLayout();
            // 
            // CustomerButtonLogin
            // 
            CustomerButtonLogin.Font = new Font("Segoe UI", 12F);
            CustomerButtonLogin.Location = new Point(406, 522);
            CustomerButtonLogin.Name = "CustomerButtonLogin";
            CustomerButtonLogin.Size = new Size(381, 65);
            CustomerButtonLogin.TabIndex = 0;
            CustomerButtonLogin.Text = "Login as Customer";
            CustomerButtonLogin.UseVisualStyleBackColor = true;
            CustomerButtonLogin.Click += button1_Click_1;
            // 
            // txt_Username
            // 
            txt_Username.Location = new Point(406, 309);
            txt_Username.Name = "txt_Username";
            txt_Username.Size = new Size(789, 39);
            txt_Username.TabIndex = 1;
            txt_Username.TextChanged += txt_Username_TextChanged;
            // 
            // txt_password
            // 
            txt_password.Location = new Point(406, 421);
            txt_password.Name = "txt_password";
            txt_password.Size = new Size(789, 39);
            txt_password.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(601, 145);
            label1.Name = "label1";
            label1.Size = new Size(430, 72);
            label1.TabIndex = 3;
            label1.Text = "SUSHIX WEBSITE";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(270, 312);
            label2.Name = "label2";
            label2.Size = new Size(121, 32);
            label2.TabIndex = 4;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(280, 421);
            label3.Name = "label3";
            label3.Size = new Size(111, 32);
            label3.TabIndex = 5;
            label3.Text = "Password";
            // 
            // EmployeeLoginButton
            // 
            EmployeeLoginButton.Font = new Font("Segoe UI", 12F);
            EmployeeLoginButton.Location = new Point(814, 522);
            EmployeeLoginButton.Name = "EmployeeLoginButton";
            EmployeeLoginButton.Size = new Size(381, 65);
            EmployeeLoginButton.TabIndex = 6;
            EmployeeLoginButton.Text = "Login as Employee";
            EmployeeLoginButton.UseVisualStyleBackColor = true;
            EmployeeLoginButton.Click += button2_Click_1;
            // 
            // SignUpButton
            // 
            SignUpButton.Font = new Font("Segoe UI", 12F);
            SignUpButton.Location = new Point(1270, 522);
            SignUpButton.Name = "SignUpButton";
            SignUpButton.Size = new Size(177, 65);
            SignUpButton.TabIndex = 7;
            SignUpButton.Text = "Sign up";
            SignUpButton.UseVisualStyleBackColor = true;
            SignUpButton.Click += SignUpButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1485, 709);
            Controls.Add(SignUpButton);
            Controls.Add(EmployeeLoginButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txt_password);
            Controls.Add(txt_Username);
            Controls.Add(CustomerButtonLogin);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CustomerButtonLogin;
        private TextBox txt_Username;
        private TextBox txt_password;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button EmployeeLoginButton;
        private Button SignUpButton;
    }
}
