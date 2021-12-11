﻿using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using System.Data;
namespace praktika3
{
    public partial class Appointment : Form
    {
        Authorization _parentForm;
        SqlConnection _connection;
        int _userID;
        bool _isAdmin;
        DataTable unsent = new DataTable();

        enum letter
        {
            Create,
            Cancel
        }
        
        public Appointment(Authorization parent, SqlConnection connection, int userID)
        {
            InitializeComponent();
            _parentForm = parent;
            _connection = connection;
            _userID = userID;            
        }

        #region Methods        

        #region Checks
        private void OnlyLetters(KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success)
                e.Handled = true;
            
            if (Symbol == "\b" || Symbol == "\u0001")
                e.Handled = false;
        }

        private void OnlyEnglish(KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (Regex.Match(Symbol, @"[а-яА-Я]").Success)
                e.Handled = true;

            if (Symbol == "\u0001")
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

        private bool IsHasFreeTime()
        {
            foreach (DataRowView row in recordsBox.Items)
            {
                string str = row["theameDateTime"].ToString();
                if (str.Contains(dateTimePicker.Value.ToString()))
                    return false;
            }
            if (dateTimePicker.Value.Hour >= 8 && dateTimePicker.Value.Hour <= 17 && dateTimePicker.Value.Hour != 13 && dateTimePicker.Value.Hour != 14 && dateTimePicker.Value.DayOfWeek != 0)
            {
                return true;
            }

            return false;
        }

        private bool isUserAdmin()
        {
            if (_connection.State != ConnectionState.Open) _connection.Open();
            DataTable admin = new DataTable();
            var command = $"SELECT admin FROM users WHERE userID='{_userID}'";
            new SqlDataAdapter(command, _connection).Fill(admin);
            var isAdmin = admin.Rows[0][0];

            if (Convert.ToInt32(isAdmin) == 1)
                return true;            
            
            return false;
        }

        #endregion Checks

        #region Save/Load

        private void LoadSentRecord(int idMeeting)
        {
            if (!showCanceled.Checked)
            {
                var selectedMeeting = new DataTable();
                if (_connection.State != ConnectionState.Open) _connection.Open();
                var command = $"SELECT * FROM Meetings WHERE idMeeting='{idMeeting}'";
                new SqlDataAdapter(command, _connection).Fill(selectedMeeting);

                tbxName.Text = selectedMeeting.Rows[0]["name"].ToString();
                tbxName.ReadOnly = true;
                tbxSurName.Text = selectedMeeting.Rows[0]["surname"].ToString();
                tbxSurName.ReadOnly = true;
                tbxDadName.Text = selectedMeeting.Rows[0]["middle_name"].ToString();
                tbxDadName.ReadOnly = true;
                tbxGroup.Text = selectedMeeting.Rows[0]["groupp"].ToString();
                tbxGroup.ReadOnly = true;
                tbxPosition.Text = selectedMeeting.Rows[0]["position"].ToString();
                tbxPosition.ReadOnly = true;
                tbxTheame.Text = selectedMeeting.Rows[0]["theame"].ToString();
                tbxTheame.ReadOnly = true;
                tbxEmail.Text = selectedMeeting.Rows[0]["email"].ToString();
                tbxEmail.ReadOnly = true;
                try
                {
                    dateTimePicker.Value = DateTime.Parse(selectedMeeting.Rows[0]["date_time"].ToString());
                }
                catch { }
            }

            else
            {
                var selectedMeeting = new DataTable();
                if (_connection.State != ConnectionState.Open) _connection.Open();
                var command = $"SELECT * FROM outdated WHERE idMeeting='{idMeeting}'";
                new SqlDataAdapter(command, _connection).Fill(selectedMeeting);

                tbxName.Text = selectedMeeting.Rows[0]["name"].ToString();
                tbxName.ReadOnly = true;
                tbxSurName.Text = selectedMeeting.Rows[0]["surname"].ToString();
                tbxSurName.ReadOnly = true;
                tbxDadName.Text = selectedMeeting.Rows[0]["middle_name"].ToString();
                tbxDadName.ReadOnly = true;
                tbxGroup.Text = selectedMeeting.Rows[0]["groupp"].ToString();
                tbxGroup.ReadOnly = true;
                tbxPosition.Text = selectedMeeting.Rows[0]["position"].ToString();
                tbxPosition.ReadOnly = true;
                tbxTheame.Text = selectedMeeting.Rows[0]["theame"].ToString();
                tbxTheame.ReadOnly = true;
                tbxEmail.Text = selectedMeeting.Rows[0]["email"].ToString();
                tbxEmail.ReadOnly = true;
                try
                {
                    dateTimePicker.Value = DateTime.Parse(selectedMeeting.Rows[0]["date_time"].ToString());
                }
                catch { }
            }
        }

        private void LoadUnsent()
        {
            if (_connection.State != ConnectionState.Open) _connection.Open();
            var command = $"SELECT * FROM unsent";
            new SqlDataAdapter(command, _connection).Fill(unsent);

            try
            {
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
            catch { }
        }

        private void LoadListBox()
        {
            if (_connection.State != ConnectionState.Open) _connection.Open();

            DataTable meetings = new DataTable();

            if (_isAdmin)
            {
                string command;

                if (showCanceled.Checked) command = $"SELECT * FROM outdated";
                else command = $"SELECT * FROM Meetings";

                new SqlDataAdapter(command, _connection).Fill(meetings);

                var source = new DataTable();
                source.Columns.Add(new DataColumn("idMeeting"));
                source.Columns.Add(new DataColumn("theameDateTime"));

                for (int q = 0; q < meetings.Rows.Count; q++)
                {
                    source.Rows.Add(meetings.Rows[q]["IdMeeting"], $"{meetings.Rows[q]["theame"]} {meetings.Rows[q]["date_time"]}");                                                                             
                }

                recordsBox.ValueMember = "idMeeting";
                recordsBox.DisplayMember = "theameDateTime";
                recordsBox.DataSource = source;
            }
            else
            {
                var command = $"SELECT * FROM Meetings WHERE userID='{_userID}'";
                new SqlDataAdapter(command, _connection).Fill(meetings);               

                var source = new DataTable();
                source.Columns.Add(new DataColumn("idMeeting"));
                source.Columns.Add(new DataColumn("theameDateTime"));

                source.Rows.Add(0, "(черновик)");

                if (meetings.Rows != null)
                {
                    for (int q = 0; q < meetings.Rows.Count; q++)
                    {
                        source.Rows.Add(meetings.Rows[q][0], $"{meetings.Rows[q][6]} {meetings.Rows[q][8]}");                                                                             
                    }
                }
                recordsBox.ValueMember = "idMeeting";
                recordsBox.DisplayMember = "theameDateTime";
                recordsBox.DataSource = source;
            }
        }

        private void SaveUnsent()
        {
            if (_connection.State != ConnectionState.Open) _connection.Open();

            var clear = "DELETE FROM unsent";
            new SqlCommand(clear, _connection).ExecuteNonQuery();

            var command = $"INSERT INTO unsent (name, surname, middle_name, groupp, position, theame, email, date_time, userID) VALUES (@name, @surname, @middle_name, @group, @position, @theame, @email, @date_time, @userid)";

            var cmd = new SqlCommand(command, _connection);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = tbxName.Text;
            cmd.Parameters.Add("@surname", SqlDbType.NVarChar).Value = tbxSurName.Text;
            cmd.Parameters.Add("@middle_name", SqlDbType.NVarChar).Value = tbxDadName.Text;
            cmd.Parameters.Add("@group", SqlDbType.NVarChar).Value = tbxGroup.Text;
            cmd.Parameters.Add("@position", SqlDbType.NVarChar).Value = tbxPosition.Text;
            cmd.Parameters.Add("@theame", SqlDbType.NVarChar).Value = tbxTheame.Text;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = tbxEmail.Text;
            cmd.Parameters.Add("@date_time", SqlDbType.DateTime).Value = dateTimePicker.Value.ToString();
            cmd.Parameters.Add("@userid", SqlDbType.Int).Value = _userID;

            cmd.ExecuteNonQuery();
        }

        private void SaveMeeting()
        {
            if (_connection.State != ConnectionState.Open) _connection.Open();
            var command = $"INSERT INTO Meetings (name, surname, middle_name, groupp, position, theame, email, date_time, userID) VALUES (@name, @surname, @middle_name, @group, @position, @theame, @email, @date_time, @userid)";

            var cmd = new SqlCommand(command, _connection);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = tbxName.Text;
            cmd.Parameters.Add("@surname", SqlDbType.NVarChar).Value = tbxSurName.Text;
            cmd.Parameters.Add("@middle_name", SqlDbType.NVarChar).Value = tbxDadName.Text;
            cmd.Parameters.Add("@group", SqlDbType.NVarChar).Value = tbxGroup.Text;
            cmd.Parameters.Add("@position", SqlDbType.NVarChar).Value = tbxPosition.Text;
            cmd.Parameters.Add("@theame", SqlDbType.NVarChar).Value = tbxTheame.Text;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = tbxEmail.Text;
            cmd.Parameters.Add("@date_time", SqlDbType.DateTime).Value = dateTimePicker.Value.ToString();
            cmd.Parameters.Add("@userid", SqlDbType.Int).Value = _userID;

            cmd.ExecuteNonQuery();

            LoadListBox();
            recordsBox.SelectedIndex = recordsBox.Items.Count - 1;
        }

        private void CancelMeeting(int idMeeting)
        {
            if (_connection.State != ConnectionState.Open) _connection.Open();

            var selectedMeeting = new DataTable();
            var getMeeting = $"SELECT IdMeeting, name, surname, middle_name, groupp, position, theame, email, date_time, userID FROM Meetings WHERE IdMeeting='{idMeeting}'";
            new SqlDataAdapter(getMeeting, _connection).Fill(selectedMeeting);

            var addOutdatedMeeting = $"INSERT INTO outdated (IdMeeting, name, surname, middle_name, groupp, position, theame, email, date_time, userID) VALUES (@IdMeeting, @name, @surname, @middle_name, @group, @position, @theame, @email, @date_time, @userid)";
            var cmd = new SqlCommand(addOutdatedMeeting, _connection);
            cmd.Parameters.Add("@IdMeeting", SqlDbType.NVarChar).Value = selectedMeeting.Rows[0]["IdMeeting"];
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = selectedMeeting.Rows[0]["name"];
            cmd.Parameters.Add("@surname", SqlDbType.NVarChar).Value = selectedMeeting.Rows[0]["surname"];
            cmd.Parameters.Add("@middle_name", SqlDbType.NVarChar).Value = selectedMeeting.Rows[0]["middle_name"];
            cmd.Parameters.Add("@group", SqlDbType.NVarChar).Value = selectedMeeting.Rows[0]["groupp"];
            cmd.Parameters.Add("@position", SqlDbType.NVarChar).Value = selectedMeeting.Rows[0]["position"];
            cmd.Parameters.Add("@theame", SqlDbType.NVarChar).Value = selectedMeeting.Rows[0]["theame"];
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = selectedMeeting.Rows[0]["email"];
            cmd.Parameters.Add("@date_time", SqlDbType.DateTime).Value = selectedMeeting.Rows[0]["date_time"].ToString();
            cmd.Parameters.Add("@userid", SqlDbType.Int).Value = _userID;

            cmd.ExecuteNonQuery();

            var commandDeleate = $"DELETE FROM Meetings WHERE idMeeting='{idMeeting}'";
            new SqlCommand(commandDeleate, _connection).ExecuteNonQuery();

            LoadListBox(); // update
        }

        private void RemoveUnsent()
        {
            if (_connection.State != ConnectionState.Open) _connection.Open();
            var clear = "DELETE FROM unsent";
            new SqlCommand(clear, _connection).ExecuteNonQuery();
        }

        #endregion Save/Load

        private void SendMailToAdmin(letter let)
        {
            SmtpClient Smtp = new SmtpClient("smtp.yandex.ru", 25);
            Smtp.Credentials = new NetworkCredential("voenkov-alex@yandex.ru", "yatfbpdghuvatpae");
            Smtp.EnableSsl = true;
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress("voenkov-alex@yandex.ru", "МГОК");
            Message.To.Add(new MailAddress("voenkova@mgok.pro"));

            switch (let)
            {
                case letter.Create:
                    {
                        Message.Subject = "Новая запись к директору";
                        string body = $"Новая запись на: {dateTimePicker.Value}";
                        Message.Body = body;
                        try
                        {
                            Smtp.Send(Message);
                        }
                        catch (SmtpException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }

                case letter.Cancel:
                    {
                        Message.Subject = "Запись к директору отменена";
                        string body = $"Запись на: {dateTimePicker.Value} отменена";
                        Message.Body = body;
                        try
                        {
                            Smtp.Send(Message);                            
                        }
                        catch (SmtpException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
            }
        }

        private void SendMailToUser(letter let)
        {
            SmtpClient Smtp = new SmtpClient("smtp.yandex.ru", 25);
            Smtp.Credentials = new NetworkCredential("voenkov-alex@yandex.ru", "yatfbpdghuvatpae");
            Smtp.EnableSsl = true;
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress("voenkov-alex@yandex.ru", "МГОК");


            if (tbxEmail.Text.Length > 0 && !EmailLegit(tbxEmail.Text))
            {
                MessageBox.Show("Вы ввели неправильный email!", "Проверьте введенный email");
                return;
            }

            if (EmailLegit(tbxEmail.Text))
            {
                Message.To.Add(new MailAddress($"{tbxEmail.Text}"));
            }

            if (tbxEmail.Text.Length == 0) return;

            switch (let)
            {
                case letter.Create:
                    {
                        Message.Subject = "Вы записались к директору";
                        string body = $"Вы записались к директору на: {dateTimePicker.Value}";
                        Message.Body = body;
                        try
                        {
                            Smtp.Send(Message);
                            MessageBox.Show("Вы были успешно записаны!" + Environment.NewLine + tbxName.Text + " " + tbxSurName.Text + " " + dateTimePicker.Value, "Запись");
                        }
                        catch (SmtpException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }

                case letter.Cancel:
                    {
                        Message.Subject = "Запись к директору отменена";
                        string body = $"Вы отменили запись к директору на: {dateTimePicker.Value}";
                        Message.Body = body;
                        try
                        {
                            Smtp.Send(Message);
                            MessageBox.Show("Запись отменена!" + Environment.NewLine + tbxName.Text + " " + tbxSurName.Text + " " + dateTimePicker.Value, "Отмена записи");
                        }
                        catch (SmtpException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
            }
        }

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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyEnglish(e);
        }

        #endregion Input

        private void Appointment_Load(object sender, EventArgs e)
        {
            dateTimePicker.Value = DateTime.Now;
            dateTimePicker.MinDate = DateTime.Now;
            dateTimePicker.MaxDate = dateTimePicker.Value.AddDays(45);

            _isAdmin = isUserAdmin();
            LoadUnsent();
            LoadListBox();
            if(!_isAdmin)
            {
                showCanceled.Enabled = false;
                showCanceled.Visible = false;
                lblDataBase.Enabled = false;
                lblDataBase.Visible = false;
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (!IsHasFreeTime())
            {
                MessageBox.Show("На это время запись невозможна!", "Попробуйте выбрать другое время");
                return;
            }

            if (tbxEmail.Text.Length > 0 && !EmailLegit(tbxEmail.Text))
            {
                MessageBox.Show("Вы ввели неправильный email!", "Проверьте введенный email");
                return;
            }

            if (tbxName.Text == String.Empty || tbxSurName.Text == String.Empty || tbxTheame.Text == String.Empty)
            {
                MessageBox.Show("Введите все обязательные поля помеченые \"*\"", "Не все обязательные поля были заполнены!");
                return;
            }

            SaveMeeting();
            RemoveUnsent();
            SendMailToAdmin(letter.Create);
            SendMailToUser(letter.Create);
        }

        private void cancelRecord_Click(object sender, EventArgs e)
        {
            DataRowView rowView = recordsBox.SelectedItem as DataRowView;

            CancelMeeting(Convert.ToInt32(rowView[0]));

            SendMailToAdmin(letter.Cancel);
            SendMailToUser(letter.Cancel);
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
                if (recordsBox.SelectedIndex == 0 && !_isAdmin)
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
                if (recordsBox.SelectedIndex != 0 && !_isAdmin)
                {
                    cancelRecord.Enabled = true;
                    cancelRecord.Visible = true;
                    Submit.Enabled = false;
                    clearForm.Enabled = false;
                    dateTimePicker.Enabled = false;
                    DataRowView rowView = recordsBox.SelectedItem as DataRowView;
                    LoadSentRecord(Convert.ToInt32(rowView[0]));
                }
                if(_isAdmin && !showCanceled.Checked)
                {
                    cancelRecord.Enabled = true;
                    cancelRecord.Visible = true;
                    Submit.Enabled = false;
                    Submit.Visible = false;
                    clearForm.Enabled = false;
                    clearForm.Visible = false;
                    dateTimePicker.Enabled = false;
                    DataRowView rowView = recordsBox.SelectedItem as DataRowView;
                    LoadSentRecord(Convert.ToInt32(rowView[0]));
                }
                if (_isAdmin && showCanceled.Checked)
                {
                    Submit.Enabled = false;
                    Submit.Visible = false;
                    clearForm.Enabled = false;
                    clearForm.Visible = false;
                    dateTimePicker.Enabled = false;
                    DataRowView rowView = recordsBox.SelectedItem as DataRowView;
                    LoadSentRecord(Convert.ToInt32(rowView[0]));
                }
            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", "https://mgok.mskobr.ru/#/");
        }

        private void showCanceled_CheckedChanged(object sender, EventArgs e)
        {
            LoadListBox();

            if (showCanceled.Checked)
            {
                cancelRecord.Enabled = false;
                cancelRecord.Visible = false;
            }
            
            else
            {
                cancelRecord.Enabled = true;
                cancelRecord.Visible = true;
            }
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
            Authorization auth = new Authorization();
            auth.Show();
        }

        private void profile_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(this.Left, this.Top, this.Height, this.Width, _userID, _connection);
            profile.Show();
        }

        private void lblDataBase_Click(object sender, EventArgs e)
        {
            Tables tbx = new Tables(this.Left, this.Top, this.Height, this.Width, _userID, _connection);
            tbx.Show();
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
