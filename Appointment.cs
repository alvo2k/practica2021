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
        public Appointment()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

            if (textBox1.Text != String.Empty && textBox2.Text != String.Empty && textBox6.Text != String.Empty && TimeCheck() && EmailLegit(textBox7.Text))
            {
                SmtpClient Smtp = new SmtpClient("smtp.yandex.ru", 25);
                Smtp.Credentials = new NetworkCredential("voenkov-alex@yandex.ru", "yatfbpdghuvatpae");
                Smtp.EnableSsl = true;
                Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage Message = new MailMessage();
                Message.From = new MailAddress("voenkov-alex@yandex.ru");
                Message.To.Add(new MailAddress("voenkova@mgok.pro"));
                Message.Subject = "Запись к директору";
                string body = $"Новая запись!\n\n\nИмя: {textBox1.Text}\nФамилия: {textBox2.Text}\nОтчество: {textBox3.Text}\nГруппа: {textBox4.Text}\nДолжность: {textBox5.Text}\nТема: {textBox6.Text}\nE-mail: {textBox7.Text}\nВремя: {dateTimePicker.Value}";
                Message.Body = body;
                
                try
                {
                    Smtp.Send(Message);
                    MessageBox.Show("Вы были успешно записаны!" + Environment.NewLine + textBox1.Text + " " + textBox2.Text + " " + dateTimePicker.Value, "Запись");
                    recordsBox.Items.Add(textBox6.Text + " " + dateTimePicker.Value);

                    string fileName = "savedData.txt";
                    FileStream fstream = new FileStream(fileName, FileMode.Append);

                    StreamWriter sw = new StreamWriter(fstream);
                    fstream.Seek(0, SeekOrigin.End);
                    sw.WriteLine($"{textBox1.Text}\n{textBox2.Text}\n{textBox3.Text}\n{textBox4.Text}\n{textBox5.Text}\n{textBox6.Text}\n{textBox7.Text}\n{dateTimePicker.Value}");
                    sw.Close();
                }
                catch (SmtpException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            

            if (!EmailLegit(textBox7.Text))
            {
                MessageBox.Show("Вы ввели неправильный email!", "Проверьте введенный email");
            }

            if (textBox1.Text == String.Empty || textBox2.Text == String.Empty || textBox6.Text == String.Empty)
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
                    if (InputFile[i].Equals(textBox1.Text) && InputFile[i+1].Equals(textBox2.Text) && InputFile[i+5].Equals(textBox6.Text) && !flag)
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

        private void Cancel_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
        }

        private void time_Click(object sender, EventArgs e)
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
                    Cancel.Enabled = false;
                    dateTimePicker.Enabled = false;
                    LoadSentRecord(recordsBox.SelectedIndex);
                }

                if (recordsBox.SelectedItem.ToString() == "(черновик)")
                {
                    cancelRecord.Enabled = false;
                    cancelRecord.Visible = false;
                    Submit.Enabled = true;
                    Cancel.Enabled = true;
                    dateTimePicker.Enabled = true;
                    textBox1.ReadOnly = false;
                    textBox2.ReadOnly = false;
                    textBox3.ReadOnly = false;
                    textBox4.ReadOnly = false;
                    textBox5.ReadOnly = false;
                    textBox6.ReadOnly = false;
                    textBox7.ReadOnly = false;
                    LoadUnsent();
                }
            }
        }

        private void LoadSentRecord(int index) // чтение из saveddata.txt со строки index * 8 и запись в textbox`ы readonly
        {
            string[] lines = File.ReadAllLines("savedData.txt");
            textBox1.Text = lines[(index - 1) * 8];
            textBox1.ReadOnly = true;
            textBox2.Text = lines[(index - 1) * 8 + 1];
            textBox2.ReadOnly = true;
            textBox3.Text = lines[(index - 1) * 8 + 2];
            textBox3.ReadOnly = true;
            textBox4.Text = lines[(index - 1) * 8 + 3];
            textBox4.ReadOnly = true;
            textBox5.Text = lines[(index - 1) * 8 + 4];
            textBox5.ReadOnly = true;
            textBox6.Text = lines[(index - 1) * 8 + 5];
            textBox6.ReadOnly = true;
            textBox7.Text = lines[(index - 1) * 8 + 6];
            textBox7.ReadOnly = true;
            if (DateTime.Parse(lines[(index - 1) * 8 + 7]) > DateTime.Now)
                dateTimePicker.Value = DateTime.Parse(lines[(index - 1) * 8 + 7]);
        }

        private void LoadUnsent() // чтение unsent.txt и запись значений в textbox`ы 
        {
            string[] lines = File.ReadAllLines("unsent.txt");
            textBox1.Text = lines[0];
            textBox2.Text = lines[1];
            textBox3.Text = lines[2];
            textBox4.Text = lines[3];
            textBox5.Text = lines[4];
            textBox6.Text = lines[5];
            textBox7.Text = lines[6];
            if(DateTime.Parse(lines[7]) > DateTime.Now)
                dateTimePicker.Value = DateTime.Parse(lines[7]);
        }

        private void LoadListBox() // стартовая загрузка данных с savedata.txt в поля recordbox
        {
            if (!File.Exists("savedData.txt"))
                File.Create("savedData.txt").Close();

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
                sw.WriteLine($"{textBox1.Text}\n{textBox2.Text}\n{textBox3.Text}\n{textBox4.Text}\n{textBox5.Text}\n{textBox6.Text}\n{textBox7.Text}\n{dateTimePicker.Value}");
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
                sw.WriteLine($"{textBox1.Text}\n{textBox2.Text}\n{textBox3.Text}\n{textBox4.Text}\n{textBox5.Text}\n{textBox6.Text}\n{textBox7.Text}\n{dateTimePicker.Value}");
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
            SaveUnsent(textBox1);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyLetters(e);
            SaveUnsent(textBox2);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyLetters(e);
            SaveUnsent(textBox3);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyLetters(e);
            SaveUnsent(textBox5);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyLetters(e);
            SaveUnsent(textBox6);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveUnsent(textBox4);
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //if(e.ToString() != DateTime.Now.ToString())
                //SaveUnsent(dateTimePicker);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveUnsent(textBox7);
        }
    }
}
