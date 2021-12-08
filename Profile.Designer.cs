namespace praktika3
{
    partial class Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pass2 = new System.Windows.Forms.Label();
            this.pass1 = new System.Windows.Forms.Label();
            this.Name1 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.SurName = new System.Windows.Forms.Label();
            this.tbxSurName = new System.Windows.Forms.TextBox();
            this.Dad = new System.Windows.Forms.Label();
            this.tbxPass2 = new System.Windows.Forms.TextBox();
            this.tbxPass1 = new System.Windows.Forms.TextBox();
            this.tbxDadName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(162)))));
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.pass2);
            this.panel1.Controls.Add(this.pass1);
            this.panel1.Controls.Add(this.Name1);
            this.panel1.Controls.Add(this.tbxName);
            this.panel1.Controls.Add(this.SurName);
            this.panel1.Controls.Add(this.tbxSurName);
            this.panel1.Controls.Add(this.Dad);
            this.panel1.Controls.Add(this.tbxPass2);
            this.panel1.Controls.Add(this.tbxPass1);
            this.panel1.Controls.Add(this.tbxDadName);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.ForeColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(41, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 422);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.MistyRose;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(362, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 55);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Lime;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(510, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 55);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pass2
            // 
            this.pass2.AutoSize = true;
            this.pass2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pass2.ForeColor = System.Drawing.SystemColors.Control;
            this.pass2.Location = new System.Drawing.Point(17, 292);
            this.pass2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pass2.Name = "pass2";
            this.pass2.Size = new System.Drawing.Size(229, 38);
            this.pass2.TabIndex = 50;
            this.pass2.Text = "Пароль еще раз:";
            // 
            // pass1
            // 
            this.pass1.AutoSize = true;
            this.pass1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pass1.ForeColor = System.Drawing.SystemColors.Control;
            this.pass1.Location = new System.Drawing.Point(18, 236);
            this.pass1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pass1.Name = "pass1";
            this.pass1.Size = new System.Drawing.Size(118, 38);
            this.pass1.TabIndex = 49;
            this.pass1.Text = "Пароль:";
            // 
            // Name1
            // 
            this.Name1.AutoSize = true;
            this.Name1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name1.ForeColor = System.Drawing.SystemColors.Control;
            this.Name1.Location = new System.Drawing.Point(18, 24);
            this.Name1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Name1.Name = "Name1";
            this.Name1.Size = new System.Drawing.Size(78, 38);
            this.Name1.TabIndex = 46;
            this.Name1.Text = "Имя:";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(260, 31);
            this.tbxName.Margin = new System.Windows.Forms.Padding(4);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(380, 31);
            this.tbxName.TabIndex = 1;
            this.tbxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxName_KeyPress);
            // 
            // SurName
            // 
            this.SurName.AutoSize = true;
            this.SurName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SurName.ForeColor = System.Drawing.SystemColors.Control;
            this.SurName.Location = new System.Drawing.Point(15, 79);
            this.SurName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SurName.Name = "SurName";
            this.SurName.Size = new System.Drawing.Size(138, 38);
            this.SurName.TabIndex = 47;
            this.SurName.Text = "Фамилия:";
            // 
            // tbxSurName
            // 
            this.tbxSurName.Location = new System.Drawing.Point(260, 86);
            this.tbxSurName.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSurName.Name = "tbxSurName";
            this.tbxSurName.Size = new System.Drawing.Size(380, 31);
            this.tbxSurName.TabIndex = 2;
            this.tbxSurName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxName_KeyPress);
            // 
            // Dad
            // 
            this.Dad.AutoSize = true;
            this.Dad.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Dad.ForeColor = System.Drawing.SystemColors.Control;
            this.Dad.Location = new System.Drawing.Point(15, 135);
            this.Dad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Dad.Name = "Dad";
            this.Dad.Size = new System.Drawing.Size(141, 38);
            this.Dad.TabIndex = 48;
            this.Dad.Text = "Отчество:";
            // 
            // tbxPass2
            // 
            this.tbxPass2.Location = new System.Drawing.Point(259, 300);
            this.tbxPass2.Margin = new System.Windows.Forms.Padding(4);
            this.tbxPass2.Name = "tbxPass2";
            this.tbxPass2.Size = new System.Drawing.Size(380, 31);
            this.tbxPass2.TabIndex = 5;
            // 
            // tbxPass1
            // 
            this.tbxPass1.Location = new System.Drawing.Point(260, 244);
            this.tbxPass1.Margin = new System.Windows.Forms.Padding(4);
            this.tbxPass1.Name = "tbxPass1";
            this.tbxPass1.Size = new System.Drawing.Size(380, 31);
            this.tbxPass1.TabIndex = 4;
            // 
            // tbxDadName
            // 
            this.tbxDadName.Location = new System.Drawing.Point(260, 143);
            this.tbxDadName.Margin = new System.Windows.Forms.Padding(4);
            this.tbxDadName.Name = "tbxDadName";
            this.tbxDadName.Size = new System.Drawing.Size(380, 31);
            this.tbxDadName.TabIndex = 3;
            this.tbxDadName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxName_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(687, 186);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Личные данные";
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBox2.Location = new System.Drawing.Point(0, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(687, 216);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Смена пароля";
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::praktika3.Properties.Resources.fon21;
            this.ClientSize = new System.Drawing.Size(769, 512);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Profile";
            this.ShowInTaskbar = false;
            this.Text = "Профиль";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Profile_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label pass2;
        private System.Windows.Forms.Label pass1;
        private System.Windows.Forms.Label Name1;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label SurName;
        private System.Windows.Forms.TextBox tbxSurName;
        private System.Windows.Forms.Label Dad;
        private System.Windows.Forms.TextBox tbxPass2;
        private System.Windows.Forms.TextBox tbxPass1;
        private System.Windows.Forms.TextBox tbxDadName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}