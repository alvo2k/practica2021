using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace praktika3
{
    public partial class Appointment : Form
    {
        /* 
         
        --- TODO----
        
        1. TimePicker
        2. Востановление формы из recordsBox readonly
        3. Открытие ссылки в браузере
        4. Проверка валидности времени
        5. Backspace в textbox'ax

        */
        Authorization _parentForm;
        SqlConnection _connection;
        int _userID;
        bool _isAdmin;
        DataTable unsent = new DataTable();
        
        public Appointment(Authorization parent, SqlConnection connection, int userID)
        {
            InitializeComponent();      
            // для закрытия процесса родительской формы в formclosing
            _parentForm = parent;
            _connection = connection;
            _userID = userID;            
        }

        #region Methods        

        #region Checks
        private void OnlyLetters(KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            // \b \u0001
            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success)
                e.Handled = true;
            
            if (Symbol == "\b" || Symbol == "\u0001")
                e.Handled = false;
        }

        private bool EmailLegit(string email)
        {
            try
            {
                MailAddress ma = new MailAddress(email);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool TimeCheck()
        {
            bool hasFreeTime = true;
            foreach (string str in recordsBox.Items)
            {
                if (str.Contains(dateTimePicker.Value.ToString()))
                    hasFreeTime = false;
            }
            if (dateTimePicker.Value.Hour >= 8 && dateTimePicker.Value.Hour <= 17 && dateTimePicker.Value.Hour != 13 && dateTimePicker.Value.Hour != 14 && dateTimePicker.Value.DayOfWeek != 0 && hasFreeTime)
            {
                return true;
            }

            return true; // testing
        }

        private bool isUserAdmin()
        {
            if (_connection.State != ConnectionState.Open) _connection.Open();
            DataTable admin = new DataTable();
            var command = $"SELECT admin FROM users WHERE userID='{_userID}'";
            new SqlDataAdapter(command, _connection).Fill(admin);
            var isAdmin = admin.Rows[0][0];

            if (Convert.ToInt32(isAdmin) == 1)
            {
                isAdmin = true;
                return true;
            }
            
            return false;
        }

        #endregion Checks

        #region Save/Load
        private void LoadSentRecord(int index) // чтение из saveddata.txt со строки index * 8 и запись в textbox`ы readonly
        {
            string[] lines = File.ReadAllLines("savedData.txt");
            tbxName.Text = lines[(index - 1) * 8];
            tbxName.ReadOnly = true;
            tbxSurName.Text = lines[(index - 1) * 8 + 1];
            tbxSurName.ReadOnly = true;
            tbxDadName.Text = lines[(index - 1) * 8 + 2];
            tbxDadName.ReadOnly = true;
            tbxGroup.Text = lines[(index - 1) * 8 + 3];
            tbxGroup.ReadOnly = true;
            tbxPosition.Text = lines[(index - 1) * 8 + 4];
            tbxPosition.ReadOnly = true;
            tbxTheame.Text = lines[(index - 1) * 8 + 5];
            tbxTheame.ReadOnly = true;
            tbxEmail.Text = lines[(index - 1) * 8 + 6];
            tbxEmail.ReadOnly = true;
            if (DateTime.Parse(lines[(index - 1) * 8 + 7]) > DateTime.Now)
                dateTimePicker.Value = DateTime.Parse(lines[(index - 1) * 8 + 7]);
        }

        private void LoadUnsent() // получение данных из таблицы unsent и запись значений в textbox`ы 
        {
            if (_connection.State != ConnectionState.Open) _connection.Open();
            var command = $"SELECT * FROM unsent";
            new SqlDataAdapter(command, _connection).Fill(unsent);

                var row = unsent.Select();
                var lines = row[0].ItemArray;
                tbxName.Text = lines[0].ToString();
                tbxSurName.Text = lines[1].ToString();
                tbxDadName.Text = lines[2].ToString();
                tbxGroup.Text = lines[3].ToString();
                tbxPosition.Text = lines[4].ToString();
                tbxTheame.Text = lines[5].ToString();
                tbxEmail.Text = lines[6].ToString();
                if (DateTime.Parse(lines[7].ToString()) > DateTime.Now)
                    dateTimePicker.Value = DateTime.Parse(lines[7].ToString());
        }

        private void LoadListBox() // стартовая загрузка встреч с Meetings в поля recordbox. для админа все записи, для пользователя только его
        {
            if (!File.Exists("savedData.txt"))
            {
                File.Create("savedData.txt").Close();
                return;
            }

            string[] lines = File.ReadAllLines("savedData.txt");

            int i = 5;
            while (i < lines.Length)
            {
                recordsBox.Items.Add($"{lines[i]} {lines[i + 2]}");
                i += 8;
            }
        }

        private void SaveUnsent() // при закрытии формы запись данных из полей tbx в таблицу unsent
        {
            if (_connection.State != ConnectionState.Open) _connection.Open();

            // очистка таблицы, чтобы всегда была только одна запись
            var clear = "DELETE FROM unsent";
            new SqlCommand(clear, _connection).ExecuteNonQuery();

            var command = "INSERT INTO unsent (name, surname, middle_name, groupp, position, theame, email, date_time, userID) VALUES (@name, @surname, @middle_name, @group, @position, @theame, @email, @date_time, @userid)";

            var cmd = new SqlCommand(command, _connection);
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = tbxName.Text;
            cmd.Parameters.Add("@surname", SqlDbType.VarChar).Value = tbxSurName.Text;
            cmd.Parameters.Add("@middle_name", SqlDbType.VarChar).Value = tbxDadName.Text;
            cmd.Parameters.Add("@group", SqlDbType.VarChar).Value = tbxGroup.Text;
            cmd.Parameters.Add("@position", SqlDbType.VarChar).Value = tbxPosition.Text;
            cmd.Parameters.Add("@theame", SqlDbType.VarChar).Value = tbxTheame.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = tbxEmail.Text;
            cmd.Parameters.Add("@date_time", SqlDbType.DateTime).Value = dateTimePicker.Value;
            cmd.Parameters.Add("@userid", SqlDbType.Int).Value = _userID;

            cmd.ExecuteNonQuery();
        }

        #endregion Save/Load

        #endregion Methods

        #region Events

        #region Input

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyLetters(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyLetters(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyLetters(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyLetters(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyLetters(e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        #endregion Input

        private void Appointment_Load(object sender, EventArgs e)
        {
            dateTimePicker.Value = DateTime.Now;
            dateTimePicker.MinDate = DateTime.Now;
            dateTimePicker.MaxDate = dateTimePicker.Value.AddDays(45);
            recordsBox.Items.Add("(черновик)");

            LoadUnsent(); // загрузка с unsent незавершенной анкеты (черновик)
            LoadListBox(); // чтение savedData.txt и загрузка значений в recordBox
            isUserAdmin();
        }

        private void Submit_Click(object sender, EventArgs e) // TODO
        {
            if (!TimeCheck())
            {
                MessageBox.Show("На это время запись невозможна!", "Попробуйте выбрать другое время");
            }

            if (tbxName.Text != String.Empty && tbxSurName.Text != String.Empty && tbxTheame.Text != String.Empty && TimeCheck() && EmailLegit(tbxEmail.Text))
            {
                SmtpClient Smtp = new SmtpClient("smtp.yandex.ru", 25);
                Smtp.Credentials = new NetworkCredential("voenkov-alex@yandex.ru", "yatfbpdghuvatpae");
                Smtp.EnableSsl = true;
                Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage Message = new MailMessage();
                Message.From = new MailAddress("voenkov-alex@yandex.ru");
                Message.To.Add(new MailAddress("voenkova@mgok.pro"));
                Message.Subject = "Запись к директору";
                string body = $"Новая запись!\n\n\nИмя: {tbxName.Text}\nФамилия: {tbxSurName.Text}\nОтчество: {tbxDadName.Text}\nГруппа: {tbxGroup.Text}\nДолжность: {tbxPosition.Text}\nТема: {tbxTheame.Text}\nE-mail: {tbxEmail.Text}\nВремя: {dateTimePicker.Value}";
                Message.Body = body;

                try
                {
                    Smtp.Send(Message);
                    MessageBox.Show("Вы были успешно записаны!" + Environment.NewLine + tbxName.Text + " " + tbxSurName.Text + " " + dateTimePicker.Value, "Запись");
                    recordsBox.Items.Add(tbxTheame.Text + " " + dateTimePicker.Value);

                    string fileName = "savedData.txt";
                    FileStream fstream = new FileStream(fileName, FileMode.Append);

                    StreamWriter sw = new StreamWriter(fstream);
                    fstream.Seek(0, SeekOrigin.End);
                    sw.WriteLine($"{tbxName.Text}\n{tbxSurName.Text}\n{tbxDadName.Text}\n{tbxGroup.Text}\n{tbxPosition.Text}\n{tbxTheame.Text}\n{tbxEmail.Text}\n{dateTimePicker.Value}");
                    sw.Close();
                }
                catch (SmtpException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            if (!EmailLegit(tbxEmail.Text))
            {
                MessageBox.Show("Вы ввели неправильный email!", "Проверьте введенный email");
            }

            if (tbxName.Text == String.Empty || tbxSurName.Text == String.Empty || tbxTheame.Text == String.Empty)
            {
                MessageBox.Show("Введите все обязательные поля помеченые \"*\"", "Не все обязательные поля были заполнены!");
            }
        } 

        private void cancelRecord_Click(object sender, EventArgs e) // TODO
        {
            SmtpClient Smtp = new SmtpClient("smtp.yandex.ru", 25);
            Smtp.Credentials = new NetworkCredential("voenkov-alex@yandex.ru", "yatfbpdghuvatpae");
            Smtp.EnableSsl = true;
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress("voenkov-alex@yandex.ru");
            Message.To.Add(new MailAddress("voenkova@mgok.pro"));
            Message.Subject = "Отмена записи";
            string body = $"Отменить запись\n\n\n {recordsBox.SelectedItem.ToString()}";
            Message.Body = body;

            try
            {
                Smtp.Send(Message);
                recordsBox.Items.RemoveAt(recordsBox.SelectedIndex);
                MessageBox.Show("Запись успешно отменена!", "Отмена записи");

                string[] InputFile = File.ReadAllLines(@"savedData.txt");
                File.Delete(@"savedData.txt");

                int i = 0;
                bool flag = false;
                while (i < InputFile.Length)
                {
                    if (InputFile[i].Equals(tbxName.Text) && InputFile[i + 1].Equals(tbxSurName.Text) && InputFile[i + 5].Equals(tbxTheame.Text) && !flag)
                    {
                        i += 8;
                        flag = true;
                        continue;
                    }
                    else
                    {
                        File.AppendAllText(@"savedData.txt", InputFile[i] + Environment.NewLine);
                        i++;
                    }

                }
            }
            catch (SmtpException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void clearForm_Click(object sender, EventArgs e)
        {
            tbxName.Text = String.Empty;
            tbxSurName.Text = String.Empty;
            tbxDadName.Text = String.Empty;
            tbxGroup.Text = String.Empty;
            tbxPosition.Text = String.Empty;
            tbxTheame.Text = String.Empty;
            tbxEmail.Text = String.Empty;
        }

        private void workingHours_Click(object sender, EventArgs e)
        {
            WorkingHours newForm = new WorkingHours(this.Left, this.Top, this.Height, this.Width);
            newForm.Show();
        }

        private void recordsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (recordsBox.SelectedItem != null)
            {
                if (recordsBox.SelectedItem.ToString() != "(черновик)")
                {
                    cancelRecord.Enabled = true;
                    cancelRecord.Visible = true;
                    Submit.Enabled = false;
                    clearForm.Enabled = false;
                    dateTimePicker.Enabled = false;
                    LoadSentRecord(recordsBox.SelectedIndex);
                }

                if (recordsBox.SelectedItem.ToString() == "(черновик)")
                {
                    cancelRecord.Enabled = false;
                    cancelRecord.Visible = false;
                    Submit.Enabled = true;
                    clearForm.Enabled = true;
                    dateTimePicker.Enabled = true;
                    tbxName.ReadOnly = false;
                    tbxSurName.ReadOnly = false;
                    tbxDadName.ReadOnly = false;
                    tbxGroup.ReadOnly = false;
                    tbxPosition.ReadOnly = false;
                    tbxTheame.ReadOnly = false;
                    tbxEmail.ReadOnly = false;
                    LoadUnsent();
                }
            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", "https://mgok.mskobr.ru/#/");
        }

        private void Appointment_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parentForm.Close();
            SaveUnsent();
            _connection.Dispose();
        }

        #endregion Events

    }
}
