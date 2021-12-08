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
         
        --- TODO----
        
        1. Проверка на русские буквы в мыле
        2. Забыли пароль?

        */

    public partial class Authorization : Form
    {
        // строка подключения и само подключение в методе DBConnect
        SqlConnection connection = new SqlConnection();
        public Authorization()
        {
            InitializeComponent();            
        }

        #region Methods

        private void OnlyEnglish(KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            // \b \u0001
            if (Regex.Match(Symbol, @"[а-яА-Я]").Success)
                e.Handled = true;

            if (Symbol == "\u0001")
                e.Handled = false;
        }

        private void ProceedAppointment(int userID)
        {
            this.SetVisibleCore(false);
            Appointment appointment = new Appointment(this, connection, userID);
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
            
            connection.ConnectionString = connectionString;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                //MessageBox.Show("DB connected!");
            }
        }

        private void Register()
        {
            var command = $"INSERT INTO users (login, pass) VALUES ('{tbxLogin.Text}', '{tbxPassword.Text}')";

            var cmd = new SqlCommand(command, connection);
            if (cmd.ExecuteNonQuery() == 1)
            {
                var users = new DataTable();
                var getUserID = $"SELECT * FROM users WHERE login='{tbxLogin.Text}'";
                new SqlDataAdapter(getUserID, connection).Fill(users);
                MessageBox.Show("Данные добавлены!");
                ProceedAppointment(Convert.ToInt32(users.Rows[0][0]));
            }
            else
                MessageBox.Show("Ошибка при добавлении данных");
        }

        private void LogIn()
        {
            // создается новая таблица
            var users = new DataTable();

            // команда поиска записи по логину
            var command = $"SELECT * FROM users WHERE login='{tbxLogin.Text}'";

            // выполнение команды и запись в таблицу
            new SqlDataAdapter(command, connection).Fill(users);

            if (users.Rows.Count == 0)
            {
                MessageBox.Show("Пользователь не найден!", "Пройдите регистрацию");
                singup.PerformClick();
                return;
            }

            if (users.Rows[0][1].ToString() == tbxLogin.Text && users.Rows[0][2].ToString() == tbxPassword.Text)
            {
                MessageBox.Show("Успешный вход", $"Добро пожаловать, {tbxLogin.Text}!");
                ProceedAppointment(Convert.ToInt32(users.Rows[0][0]));
            }
            else
                MessageBox.Show("Неправильный логин или пароль!", "Попробуйте еще раз");
        }

        #endregion Methods

        #region Events
        private void loggingIn_Click(object sender, EventArgs e)
        {
            // case 1: singin
            if (singin.Checked && connection.State == ConnectionState.Open)
            {
                if (tbxLogin.Text == "" || tbxPassword.Text == "")
                {
                    MessageBox.Show("Введите логин и пароль!", "Введите все обязательные поля");
                    return;
                }  
                LogIn();
            }
            // case 2: singup
            if (singup.Checked && connection.State == ConnectionState.Open)
            {
                if (EmailCheck() && PasswordCheck() && isLoginUnique())
                {
                    Register();
                }
            }

            if (connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет подключения к БД, попробуйте снова");
                DBConnect();
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

        private void tbxLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyEnglish(e);
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            loggingIn.Top = loggingIn.Top - 50;

            this.Height = this.Height - 50;
            DBConnect();

            // testing
            //ProceedAppointment(1);
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
                MessageBox.Show("Введите почту МГОК'а в поле логина!", "Неправильный email");
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

        private bool isLoginUnique()
        {
            // создается новая таблица
            var users = new DataTable();

            // команда поиска записи по логину
            var command = $"SELECT * FROM users WHERE login='{tbxLogin.Text}'";

            // выполнение команды и запись в таблицу
            var adapter = new SqlDataAdapter(command, connection).Fill(users);

            if (users.Rows.Count != 0)
            {
                MessageBox.Show("Такой пользователь уже существует!", "Введите пароль");
                singin.PerformClick();
                return false;
            }

            return true;
        }

        #endregion Checks

        
    }
}
