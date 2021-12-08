namespace praktika3
{
    partial class Authorization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            this.singin = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.singup = new System.Windows.Forms.RadioButton();
            this.tbxLogin = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbxPassword2 = new System.Windows.Forms.TextBox();
            this.lblPassword2 = new System.Windows.Forms.Label();
            this.loggingIn = new System.Windows.Forms.Button();
            this.instructions = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // singin
            // 
            this.singin.AutoSize = true;
            this.singin.Checked = true;
            this.singin.Location = new System.Drawing.Point(6, 30);
            this.singin.Name = "singin";
            this.singin.Size = new System.Drawing.Size(85, 29);
            this.singin.TabIndex = 0;
            this.singin.TabStop = true;
            this.singin.Text = "Войти";
            this.singin.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(162)))));
            this.groupBox1.Controls.Add(this.singup);
            this.groupBox1.Controls.Add(this.singin);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 105);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите вариант авторизации";
            // 
            // singup
            // 
            this.singup.AutoSize = true;
            this.singup.Location = new System.Drawing.Point(6, 65);
            this.singup.Name = "singup";
            this.singup.Size = new System.Drawing.Size(203, 29);
            this.singup.TabIndex = 0;
            this.singup.Text = "Зарегистрироваться";
            this.singup.UseVisualStyleBackColor = true;
            this.singup.CheckedChanged += new System.EventHandler(this.singup_CheckedChanged);
            // 
            // tbxLogin
            // 
            this.tbxLogin.Location = new System.Drawing.Point(232, 150);
            this.tbxLogin.MaxLength = 64;
            this.tbxLogin.Name = "tbxLogin";
            this.tbxLogin.Size = new System.Drawing.Size(387, 31);
            this.tbxLogin.TabIndex = 2;
            this.tbxLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxLogin_KeyPress);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.White;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLogin.Location = new System.Drawing.Point(12, 150);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(160, 32);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "Логин (email)";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(232, 200);
            this.tbxPassword.MaxLength = 16;
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(387, 31);
            this.tbxPassword.TabIndex = 3;
            this.tbxPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.White;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.Location = new System.Drawing.Point(12, 200);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(96, 32);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Пароль";
            // 
            // tbxPassword2
            // 
            this.tbxPassword2.Location = new System.Drawing.Point(232, 250);
            this.tbxPassword2.MaxLength = 16;
            this.tbxPassword2.Name = "tbxPassword2";
            this.tbxPassword2.Size = new System.Drawing.Size(387, 31);
            this.tbxPassword2.TabIndex = 4;
            this.tbxPassword2.UseSystemPasswordChar = true;
            this.tbxPassword2.Visible = false;
            // 
            // lblPassword2
            // 
            this.lblPassword2.AutoSize = true;
            this.lblPassword2.BackColor = System.Drawing.Color.White;
            this.lblPassword2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPassword2.Location = new System.Drawing.Point(12, 250);
            this.lblPassword2.Name = "lblPassword2";
            this.lblPassword2.Size = new System.Drawing.Size(193, 32);
            this.lblPassword2.TabIndex = 3;
            this.lblPassword2.Text = "Пароль еще раз";
            this.lblPassword2.Visible = false;
            // 
            // loggingIn
            // 
            this.loggingIn.BackColor = System.Drawing.Color.Lime;
            this.loggingIn.Location = new System.Drawing.Point(481, 303);
            this.loggingIn.Name = "loggingIn";
            this.loggingIn.Size = new System.Drawing.Size(138, 34);
            this.loggingIn.TabIndex = 5;
            this.loggingIn.Text = "Продолжить";
            this.loggingIn.UseVisualStyleBackColor = false;
            this.loggingIn.Click += new System.EventHandler(this.loggingIn_Click);
            // 
            // instructions
            // 
            this.instructions.BackColor = System.Drawing.Color.White;
            this.instructions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.instructions.Location = new System.Drawing.Point(14, 290);
            this.instructions.Name = "instructions";
            this.instructions.Size = new System.Drawing.Size(457, 79);
            this.instructions.TabIndex = 5;
            this.instructions.Text = "Для логина используйте почту МГОК\'а\r\nПароль должен состоять из латинских букв и ц" +
    "ифр.\r\nОт 8 до 16 символов";
            this.instructions.Visible = false;
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::praktika3.Properties.Resources.fon21;
            this.ClientSize = new System.Drawing.Size(631, 371);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.loggingIn);
            this.Controls.Add(this.lblPassword2);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.tbxPassword2);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.tbxLogin);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Authorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authorization";
            this.Load += new System.EventHandler(this.Authorization_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton singin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton singup;
        private System.Windows.Forms.TextBox tbxLogin;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbxPassword2;
        private System.Windows.Forms.Label lblPassword2;
        private System.Windows.Forms.Button loggingIn;
        private System.Windows.Forms.Label instructions;
    }
}