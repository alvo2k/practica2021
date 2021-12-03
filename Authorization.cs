using System;
using System.Data;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.IO;

namespace praktika3
{
        /* 
         * 
        --- TODO----
        
        1. Проверка на русские буквы в мыле
        2. 

        */

    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        #region Methods

        private void ProceedAppointment()
        {
            this.SetVisibleCore(false);
            Appointment appointment = new Appointment(this);
            appointment.Show();
        }

        private void DBConnect()
        {
            if (!File.Exists("Database.mdf"))
            {
                MessageBox.Show("База данных не найдена!", "Приложение закрывается...");
                this.Close();
                return;
            }
            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                //MessageBox.Show("DB connected!");
            }
        }

        #endregion Methods

        #region Events
        private void loggingIn_Click(object sender, EventArgs e)
        {
            // case 1: singin
            if (singin.Checked)
            {
                ProceedAppointment();
            }
            // case 2: singup
            if (singup.Checked)
            {
                if (EmailCheck() && PasswordCheck()) ProceedAppointment();
            }
        }

        private void singup_CheckedChanged(object sender, EventArgs e)
        {
            if (lblPassword2.Visible == false && tbxPassword2.Visible == false && instructions.Visible == false)
            {
                lblPassword2.Visible = true;
                tbxPassword2.Visible = true;
                instructions.Visible = true;
                loggingIn.Top = Math.Min(loggingIn.Top + 60, 303);
                this.Height = this.Height + 50;
            }
            
            else
            {
                lblPassword2.Visible = false;
                tbxPassword2.Visible = false;
                instructions.Visible = false;
                loggingIn.Top = loggingIn.Top - 50;
                this.Height = this.Height - 50;
            }
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            loggingIn.Top = loggingIn.Top - 50;

            this.Height = this.Height - 50;
            DBConnect();
        }

        #endregion Events

        #region Checks

        private bool EmailCheck()
        {
            if (tbxLogin.Text.EndsWith("@mgok.pro"))
            {
                try
                {
                    MailAddress ma = new MailAddress(tbxLogin.Text);
                    return true;
                }
                catch
                {
                    MessageBox.Show("Invalid email");
                    return false;
                }
            }
            else            
                MessageBox.Show("Введите почту МГОК'а!", "Неправильный email");

            return false;
        }

        private bool PasswordCheck()
        {
            if (tbxPassword.Text.Length == 0 || tbxPassword2.Text.Length == 0)
            {
                MessageBox.Show("Поля пароля пустые!");
                return false;
            }
            if (tbxPassword.Text != tbxPassword2.Text)
            {
                MessageBox.Show("Поля пароля не совпадают!");
                return false;
            }

            if(tbxPassword.Text.Length < 8)
            {
                MessageBox.Show("Пароль должен быть от 8 до 16 символов");
                return false;
            }
            foreach (var e in tbxPassword.Text)
            {
                if (!Regex.Match(e.ToString(), @"[0-9]|[a-zA-Z]").Success)
                {
                    MessageBox.Show("Поле пароля имеет запрещенные символы", "Придумайте другой пароль");
                    return false;
                }
            }

            return true;
        }

        #endregion Checks


    }
}
