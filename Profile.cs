using System;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;

namespace praktika3
{
    public partial class Profile : Form
    {
        int left, top, height, width, _userID;
        SqlConnection _connection;

        public Profile(int X, int Y, int Height, int Width, int userID, SqlConnection connection)
        {
            InitializeComponent();
            left = X;
            top = Y;
            height = Height;
            width = Width;
            _userID = userID;
            _connection = connection;
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            this.Left = left + width / 2 - (this.Width / 2);
            this.Top = top + height / 2 - (this.Height / 2);
            LoadData();
        }

        private void LoadData()
        {
            var tbl = new DataTable();
            string getData = $"SELECT * FROM users WHERE userID={_userID}";

            new SqlDataAdapter(getData, _connection).Fill(tbl);

            tbxName.Text = tbl.Rows[0]["name"].ToString();
            tbxSurName.Text = tbl.Rows[0]["surname"].ToString();
            tbxDadName.Text = tbl.Rows[0]["middle_name"].ToString();
        }

        private void OnlyLetters(KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            // \b \u0001
            if (!Regex.Match(Symbol, @"[а-яА-Я]").Success)
                e.Handled = true;

            if (Symbol == "\b" || Symbol == "\u0001")
                e.Handled = false;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_connection.State != System.Data.ConnectionState.Open) _connection.Open();

            if (tbxName.Text.Length != 0)
            {
                var command = $"UPDATE users SET name = @name WHERE userID='{_userID}'";
                var cmd = new SqlCommand(command, _connection);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = tbxName.Text;
                cmd.ExecuteNonQuery();
            }

            if (tbxSurName.Text.Length != 0)
            {
                var command = $"UPDATE users SET surname = @surname WHERE userID='{_userID}'";
                var cmd = new SqlCommand(command, _connection);
                cmd.Parameters.Add("@surname", SqlDbType.NVarChar).Value = tbxSurName.Text;
                cmd.ExecuteNonQuery();
            }

            if (tbxDadName.Text.Length != 0)
            {
                var command = $"UPDATE users SET middle_name = @middlename WHERE userID='{_userID}'";
                var cmd = new SqlCommand(command, _connection);
                cmd.Parameters.Add("@middlename", SqlDbType.NVarChar).Value = tbxDadName.Text;
                cmd.ExecuteNonQuery();
            }

            if (tbxPass1.Text.Length != 0 || tbxPass2.Text.Length != 0)
            {
                if (tbxPass1.Text != tbxPass2.Text)
                {
                    MessageBox.Show("Поля пароля не совпадают!");
                    return;
                }

                if (tbxPass1.Text.Length < 8)
                {
                    MessageBox.Show("Пароль должен быть от 8 до 16 символов");
                    return;
                }

                if (tbxPass1.Text.Length > 16)
                {
                    MessageBox.Show("Пароль должен быть от 8 до 16 символов");
                    return;
                }

                foreach (var c in tbxPass1.Text)
                {
                    if (!Regex.Match(c.ToString(), @"[0-9]|[a-zA-Z]").Success)
                    {
                        MessageBox.Show("Поле пароля имеет запрещенные символы", "Придумайте другой пароль");
                        return;
                    }
                }

                var command = $"UPDATE users SET pass = '{tbxPass1.Text}' WHERE userID='{_userID}'";
                new SqlCommand(command, _connection).ExecuteNonQuery();
            }

            MessageBox.Show("Данные внесены!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyLetters(e);
        }
    }
}
