
namespace praktika3
{
    partial class Appointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Appointment));
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.Submit = new System.Windows.Forms.Button();
            this.datetime = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.Subject = new System.Windows.Forms.Label();
            this.Position = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Group = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Dad = new System.Windows.Forms.Label();
            this.SurName = new System.Windows.Forms.Label();
            this.Name1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.records = new System.Windows.Forms.Label();
            this.cancelRecord = new System.Windows.Forms.Button();
            this.backGroundColor = new System.Windows.Forms.Panel();
            this.time = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.recordsBox = new System.Windows.Forms.ListBox();
            this.backGroundColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "dd.MM.yyyy - HH:mm";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(924, 379);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(213, 31);
            this.dateTimePicker.TabIndex = 57;
            this.dateTimePicker.Value = new System.DateTime(2021, 6, 22, 13, 37, 57, 0);
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(924, 328);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(455, 31);
            this.textBox7.TabIndex = 56;
            this.textBox7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(924, 271);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(455, 31);
            this.textBox6.TabIndex = 55;
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(924, 216);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(455, 31);
            this.textBox5.TabIndex = 54;
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.Color.Brown;
            this.Cancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Cancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Cancel.Location = new System.Drawing.Point(238, 500);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(232, 65);
            this.Cancel.TabIndex = 53;
            this.Cancel.Text = "Очистить форму";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Submit
            // 
            this.Submit.BackColor = System.Drawing.Color.Lime;
            this.Submit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Submit.Location = new System.Drawing.Point(44, 499);
            this.Submit.Margin = new System.Windows.Forms.Padding(4);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(186, 65);
            this.Submit.TabIndex = 52;
            this.Submit.Text = "Записаться";
            this.Submit.UseVisualStyleBackColor = false;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // datetime
            // 
            this.datetime.AutoSize = true;
            this.datetime.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.datetime.ForeColor = System.Drawing.SystemColors.Control;
            this.datetime.Location = new System.Drawing.Point(718, 374);
            this.datetime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.datetime.Name = "datetime";
            this.datetime.Size = new System.Drawing.Size(193, 38);
            this.datetime.TabIndex = 51;
            this.datetime.Text = "Дата и время:";
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Email.ForeColor = System.Drawing.SystemColors.Control;
            this.Email.Location = new System.Drawing.Point(718, 320);
            this.Email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(89, 38);
            this.Email.TabIndex = 50;
            this.Email.Text = "Email:";
            // 
            // Subject
            // 
            this.Subject.AutoSize = true;
            this.Subject.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Subject.ForeColor = System.Drawing.SystemColors.Control;
            this.Subject.Location = new System.Drawing.Point(718, 264);
            this.Subject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Subject.Name = "Subject";
            this.Subject.Size = new System.Drawing.Size(99, 38);
            this.Subject.TabIndex = 49;
            this.Subject.Text = "Тема*:";
            // 
            // Position
            // 
            this.Position.AutoSize = true;
            this.Position.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Position.ForeColor = System.Drawing.SystemColors.Control;
            this.Position.Location = new System.Drawing.Point(718, 209);
            this.Position.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Position.Name = "Position";
            this.Position.Size = new System.Drawing.Size(164, 38);
            this.Position.TabIndex = 48;
            this.Position.Text = "Должность:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(195, 381);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(455, 31);
            this.textBox4.TabIndex = 47;
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(195, 328);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(455, 31);
            this.textBox3.TabIndex = 46;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(195, 271);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(455, 31);
            this.textBox2.TabIndex = 45;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // Group
            // 
            this.Group.AutoSize = true;
            this.Group.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Group.ForeColor = System.Drawing.SystemColors.Control;
            this.Group.Location = new System.Drawing.Point(41, 374);
            this.Group.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Group.Name = "Group";
            this.Group.Size = new System.Drawing.Size(112, 38);
            this.Group.TabIndex = 44;
            this.Group.Text = "Группа:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(195, 216);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(455, 31);
            this.textBox1.TabIndex = 43;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // Dad
            // 
            this.Dad.AutoSize = true;
            this.Dad.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Dad.ForeColor = System.Drawing.SystemColors.Control;
            this.Dad.Location = new System.Drawing.Point(44, 320);
            this.Dad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Dad.Name = "Dad";
            this.Dad.Size = new System.Drawing.Size(141, 38);
            this.Dad.TabIndex = 42;
            this.Dad.Text = "Отчество:";
            // 
            // SurName
            // 
            this.SurName.AutoSize = true;
            this.SurName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SurName.ForeColor = System.Drawing.SystemColors.Control;
            this.SurName.Location = new System.Drawing.Point(41, 264);
            this.SurName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SurName.Name = "SurName";
            this.SurName.Size = new System.Drawing.Size(150, 38);
            this.SurName.TabIndex = 41;
            this.SurName.Text = "Фамилия*:";
            // 
            // Name1
            // 
            this.Name1.AutoSize = true;
            this.Name1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name1.ForeColor = System.Drawing.SystemColors.Control;
            this.Name1.Location = new System.Drawing.Point(44, 209);
            this.Name1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Name1.Name = "Name1";
            this.Name1.Size = new System.Drawing.Size(90, 38);
            this.Name1.TabIndex = 40;
            this.Name1.Text = "Имя*:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(385, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(749, 96);
            this.label1.TabIndex = 39;
            this.label1.Text = "Запись на прием к директору ГБПОУ МГОК \r\nАртемьеву Игорю Анатольевичу";
            // 
            // records
            // 
            this.records.AutoSize = true;
            this.records.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.records.ForeColor = System.Drawing.SystemColors.Control;
            this.records.Location = new System.Drawing.Point(718, 440);
            this.records.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.records.Name = "records";
            this.records.Size = new System.Drawing.Size(161, 32);
            this.records.TabIndex = 58;
            this.records.Text = "Ваши записи:";
            // 
            // cancelRecord
            // 
            this.cancelRecord.BackColor = System.Drawing.Color.Brown;
            this.cancelRecord.Enabled = false;
            this.cancelRecord.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancelRecord.ForeColor = System.Drawing.SystemColors.Control;
            this.cancelRecord.Location = new System.Drawing.Point(1290, 494);
            this.cancelRecord.Margin = new System.Windows.Forms.Padding(2);
            this.cancelRecord.Name = "cancelRecord";
            this.cancelRecord.Size = new System.Drawing.Size(160, 80);
            this.cancelRecord.TabIndex = 60;
            this.cancelRecord.Text = "Отменить запись";
            this.cancelRecord.UseVisualStyleBackColor = false;
            this.cancelRecord.Visible = false;
            this.cancelRecord.Click += new System.EventHandler(this.cancelRecord_Click);
            // 
            // backGroundColor
            // 
            this.backGroundColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(162)))));
            this.backGroundColor.Controls.Add(this.time);
            this.backGroundColor.Controls.Add(this.linkLabel1);
            this.backGroundColor.Controls.Add(this.recordsBox);
            this.backGroundColor.Controls.Add(this.Cancel);
            this.backGroundColor.Controls.Add(this.cancelRecord);
            this.backGroundColor.Controls.Add(this.Submit);
            this.backGroundColor.Controls.Add(this.label1);
            this.backGroundColor.Controls.Add(this.records);
            this.backGroundColor.Controls.Add(this.Name1);
            this.backGroundColor.Controls.Add(this.dateTimePicker);
            this.backGroundColor.Controls.Add(this.textBox1);
            this.backGroundColor.Controls.Add(this.textBox7);
            this.backGroundColor.Controls.Add(this.SurName);
            this.backGroundColor.Controls.Add(this.textBox6);
            this.backGroundColor.Controls.Add(this.textBox2);
            this.backGroundColor.Controls.Add(this.textBox5);
            this.backGroundColor.Controls.Add(this.Dad);
            this.backGroundColor.Controls.Add(this.textBox3);
            this.backGroundColor.Controls.Add(this.Group);
            this.backGroundColor.Controls.Add(this.datetime);
            this.backGroundColor.Controls.Add(this.textBox4);
            this.backGroundColor.Controls.Add(this.Email);
            this.backGroundColor.Controls.Add(this.Position);
            this.backGroundColor.Controls.Add(this.Subject);
            this.backGroundColor.Location = new System.Drawing.Point(58, 56);
            this.backGroundColor.Margin = new System.Windows.Forms.Padding(2);
            this.backGroundColor.Name = "backGroundColor";
            this.backGroundColor.Size = new System.Drawing.Size(1484, 608);
            this.backGroundColor.TabIndex = 62;
            // 
            // time
            // 
            this.time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(182)))));
            this.time.ForeColor = System.Drawing.SystemColors.Control;
            this.time.Location = new System.Drawing.Point(1146, 379);
            this.time.Margin = new System.Windows.Forms.Padding(4);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(234, 32);
            this.time.TabIndex = 65;
            this.time.Text = "Время работы";
            this.time.UseVisualStyleBackColor = false;
            this.time.Click += new System.EventHandler(this.time_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Image = global::praktika3.Properties.Resources.logo;
            this.linkLabel1.Location = new System.Drawing.Point(44, 34);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(338, 160);
            this.linkLabel1.TabIndex = 64;
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // recordsBox
            // 
            this.recordsBox.FormattingEnabled = true;
            this.recordsBox.ItemHeight = 25;
            this.recordsBox.Location = new System.Drawing.Point(718, 494);
            this.recordsBox.Margin = new System.Windows.Forms.Padding(4);
            this.recordsBox.Name = "recordsBox";
            this.recordsBox.ScrollAlwaysVisible = true;
            this.recordsBox.Size = new System.Drawing.Size(565, 79);
            this.recordsBox.TabIndex = 63;
            this.recordsBox.SelectedIndexChanged += new System.EventHandler(this.recordsBox_SelectedIndexChanged);
            // 
            // Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::praktika3.Properties.Resources.fon21;
            this.ClientSize = new System.Drawing.Size(1599, 739);
            this.Controls.Add(this.backGroundColor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Appointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Запись на прием";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.backGroundColor.ResumeLayout(false);
            this.backGroundColor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label datetime;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.Label Subject;
        private System.Windows.Forms.Label Position;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label Group;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Dad;
        private System.Windows.Forms.Label SurName;
        private System.Windows.Forms.Label Name1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label records;
        private System.Windows.Forms.Button cancelRecord;
        private System.Windows.Forms.Panel backGroundColor;
        private System.Windows.Forms.ListBox recordsBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button time;
    }
}

