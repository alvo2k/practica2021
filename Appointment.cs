using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace praktika3
{
    public partial class Appointment : Form
    {
        /* 
         
        --- TODO----
        
        1. Ссылка на сайт мгока
        2. Востановление формы из recordsBox readonly
        3. Добавить время работы
        4. Проверка валидности времени
        5. Добавить "обо мне"

        */
        Authorization _authorization;
        public Appointment(Authorization authorization)
        {
            InitializeComponent();            
            _authorization = authorization;
        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            
            dateTimePicker.Value = DateTime.Now;
            dateTimePicker.MinDate = DateTime.Now;
            dateTimePicker.MaxDate = dateTimePicker.Value.AddDays(45);
            recordsBox.Items.Add("(черновик)");
            
            LoadUnsent(); // загрузка с unsent.txt незавершенной анкеты
            LoadListBox(); // чтение savedData.txt и загрузка значений в recordBox
        }

        private void Submit_Click(object sender, EventArgs e)
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

            return false;
        }

        private void cancelRecord_Click(object sender, EventArgs e)
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
                    if (InputFile[i].Equals(tbxName.Text) && InputFile[i+1].Equals(tbxSurName.Text) && InputFile[i+5].Equals(tbxTheame.Text) && !flag)
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

        private void LoadUnsent() // чтение unsent.txt и запись значений в textbox`ы 
        {
            if (!File.Exists("unsent.txt"))
            {
                File.Create("unsent.txt").Close();
                return;

            }

            string[] lines = File.ReadAllLines("unsent.txt");
            tbxName.Text = lines[0];
            tbxSurName.Text = lines[1];
            tbxDadName.Text = lines[2];
            tbxGroup.Text = lines[3];
            tbxPosition.Text = lines[4];
            tbxTheame.Text = lines[5];
            tbxEmail.Text = lines[6];
            if(DateTime.Parse(lines[7]) > DateTime.Now)
                dateTimePicker.Value = DateTime.Parse(lines[7]);
        }

        private void LoadListBox() // стартовая загрузка данных с savedata.txt в поля recordbox
        {
            if (!File.Exists("savedData.txt"))
            {
                File.Create("savedData.txt").Close();
                return;
            }

            string[] lines = File.ReadAllLines("savedData.txt");

            int i = 5;
            while(i < lines.Length)
            {
                recordsBox.Items.Add($"{lines[i]} {lines[i + 2]}");
                i += 8;
            }
        }

        private void SaveUnsent(TextBox tb)
        {
            if (tb.ReadOnly != true)
            {
                string fileName = "unsent.txt";
                FileStream fstream = new FileStream(fileName, FileMode.Truncate);

                StreamWriter sw = new StreamWriter(fstream);
                fstream.Seek(0, SeekOrigin.End);
                sw.WriteLine($"{tbxName.Text}\n{tbxSurName.Text}\n{tbxDadName.Text}\n{tbxGroup.Text}\n{tbxPosition.Text}\n{tbxTheame.Text}\n{tbxEmail.Text}\n{dateTimePicker.Value}");
                sw.Close();
            }
        }

        private void SaveUnsent(DateTimePicker dt)
        {
            if (!File.Exists("unsent.txt"))
                File.Create("unsent.txt").Close();

            if (dt.Enabled == true)
            {
                string fileName = "unsent.txt";
                FileStream fstream = new FileStream(fileName, FileMode.Truncate);

                StreamWriter sw = new StreamWriter(fstream);
                fstream.Seek(0, SeekOrigin.End);
                sw.WriteLine($"{tbxName.Text}\n{tbxSurName.Text}\n{tbxDadName.Text}\n{tbxGroup.Text}\n{tbxPosition.Text}\n{tbxTheame.Text}\n{tbxEmail.Text}\n{dateTimePicker.Value}");
                sw.Close();
            }
        }


        private void OnlyLetters(KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success)
            {
                e.Handled = true;
            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", "https://mgok.mskobr.ru/#/");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyLetters(e);
            SaveUnsent(tbxName);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyLetters(e);
            SaveUnsent(tbxSurName);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyLetters(e);
            SaveUnsent(tbxDadName);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyLetters(e);
            SaveUnsent(tbxPosition);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyLetters(e);
            SaveUnsent(tbxTheame);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveUnsent(tbxGroup);
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //if(e.ToString() != DateTime.Now.ToString())
                //SaveUnsent(dateTimePicker);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveUnsent(tbxEmail);
        }

        private void Appointment_FormClosing(object sender, FormClosingEventArgs e)
        {
            _authorization.Close();
        }
    }
}
