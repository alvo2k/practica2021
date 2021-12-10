using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace praktika3
{
    public partial class Tables : Form
    {
        int left, top, height, width, _userID;
        SqlConnection _connection;
        string activeTabel;
        public Tables(int X, int Y, int Height, int Width, int userID, SqlConnection connection)
        {
            InitializeComponent();
            left = X;
            top = Y;
            height = Height;
            width = Width;
            _userID = userID;
            _connection = connection;
        }

        private void Tables_Load(object sender, EventArgs e)
        {
            this.Left = left + width / 2 - (this.Width / 2);
            this.Top = top + height / 2 - (this.Height / 2);
            
            btnAdd.Enabled = false;
            btnDeleate.Enabled = false;
            btnSave.Enabled = false;
            btnSearch.Enabled = false;
        }

        private void LoadData(string tabel)
        {
            activeTabel = tabel;
            var source = new DataTable();
            string command = $"SELECT * FROM {tabel}";
            new SqlDataAdapter(command, _connection).Fill(source);

            dataGridView1.DataSource = source;

            btnAdd.Enabled = true;
            btnDeleate.Enabled = true;
            btnSave.Enabled = true;
            btnSearch.Enabled = true;
        }

        private void btxUsers_Click(object sender, EventArgs e)
        {
            LoadData("users");
        }

        private void btnZapisi_Click(object sender, EventArgs e)
        {
            LoadData("Meetings");
        }

        private void btnOutDated_Click(object sender, EventArgs e)
        {
            LoadData("outdated");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (_connection.State != ConnectionState.Open) _connection.Open();

                if (activeTabel == "Meetings" || activeTabel == "outdated")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        var row = dataGridView1.SelectedRows[i].Cells;
                        var command = $"INSERT INTO {activeTabel} (name, surname, middle_name, groupp, position, theame, email, date_time, userID) VALUES (@name, @surname, @middle_name, @group, @position, @theame, @email, @date_time, @userid)";

                        var cmd = new SqlCommand(command, _connection);
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = row["name"].Value;
                        cmd.Parameters.Add("@surname", SqlDbType.NVarChar).Value = row["surname"].Value;
                        cmd.Parameters.Add("@middle_name", SqlDbType.NVarChar).Value = row["middle_name"].Value;
                        cmd.Parameters.Add("@group", SqlDbType.NVarChar).Value = row["groupp"].Value;
                        cmd.Parameters.Add("@position", SqlDbType.NVarChar).Value = row["position"].Value;
                        cmd.Parameters.Add("@theame", SqlDbType.NVarChar).Value = row["theame"].Value;
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = row["email"].Value;
                        cmd.Parameters.Add("@date_time", SqlDbType.DateTime).Value = row["date_time"].Value;
                        cmd.Parameters.Add("@userid", SqlDbType.Int).Value = _userID;
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Строки успешно добавлены!", "Успешно");
                            LoadData(activeTabel);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                if (activeTabel == "users")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        var row = dataGridView1.SelectedRows[i].Cells;
                        var command = $"INSERT INTO {activeTabel} (login, pass, admin, name, surname, middle_name) VALUES (@login, @pass, @admin, @name, @surname, @middle_name)";

                        var cmd = new SqlCommand(command, _connection);
                        cmd.Parameters.Add("@login", SqlDbType.NVarChar).Value = row["login"].Value;
                        cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = row["pass"].Value;

                        if (row["admin"].Value == null) cmd.Parameters.Add("@admin", SqlDbType.Bit).Value = 0;
                        else cmd.Parameters.Add("@admin", SqlDbType.Bit).Value = 1;

                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = row["name"].Value;
                        cmd.Parameters.Add("@surname", SqlDbType.NVarChar).Value = row["surname"].Value;
                        cmd.Parameters.Add("@middle_name", SqlDbType.NVarChar).Value = row["middle_name"].Value;

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Строки успешно добавлены!", "Успешно");
                            LoadData(activeTabel);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите строки для добавления!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (_connection.State != ConnectionState.Open) _connection.Open();

                if (activeTabel == "Meetings" || activeTabel == "outdated")
                {
                    for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                    {
                        string command;
                        var cell = dataGridView1.SelectedCells[i];
                        var column = cell.OwningColumn.HeaderText;
                        command = $"UPDATE {activeTabel} SET {column} = @a WHERE IdMeeting = '{cell.OwningRow.Cells["IdMeeting"].Value}'";

                        var cmd = new SqlCommand(command, _connection);

                        switch (column)
                        {
                            case "IdMeeting":
                                {
                                    cmd.Parameters.Add("@a", SqlDbType.Int).Value = cell.Value;
                                    break;
                                }
                            case "userID":
                                {
                                    cmd.Parameters.Add("@a", SqlDbType.Int).Value = cell.Value;
                                    break;
                                }
                            case "date_time":
                                {
                                    cmd.Parameters.Add("@a", SqlDbType.DateTime).Value = cell.Value;
                                    break;
                                }
                            default:
                                {
                                    cmd.Parameters.Add("@a", SqlDbType.NVarChar).Value = cell.Value;
                                    break;
                                }
                        }

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Ячейки успешно обновлены!", "Успешно");
                            LoadData(activeTabel);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }

                if (activeTabel == "users")
                {
                    for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                    {
                        string command;
                        var cell = dataGridView1.SelectedCells[i];
                        var column = cell.OwningColumn.HeaderText;
                        command = $"UPDATE {activeTabel} SET {column} = @a WHERE userID = '{cell.OwningRow.Cells["userID"].Value}'";

                        var cmd = new SqlCommand(command, _connection);

                        switch (column)
                        {
                            case "userID":
                                {
                                    cmd.Parameters.Add("@a", SqlDbType.Int).Value = cell.Value;
                                    break;
                                }
                            case "admin":
                                {
                                    cmd.Parameters.Add("@a", SqlDbType.Bit).Value = cell.Value;
                                    break;
                                }
                            default:
                                {
                                    cmd.Parameters.Add("@a", SqlDbType.NVarChar).Value = cell.Value;
                                    break;
                                }
                        }

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Ячейки успешно обновлены!", "Успешно");
                            LoadData(activeTabel);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }

            else
            {
                MessageBox.Show("Выберите ячейки для обновления!", "Выберите ячейки");
            }
        }

        private void btnDeleate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (_connection.State != ConnectionState.Open) _connection.Open();

                if (activeTabel == "Meetings" || activeTabel == "outdated")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        var command = $"DELETE FROM {activeTabel} WHERE IdMeeting = {dataGridView1.SelectedRows[i].Cells["IdMeeting"].Value}";

                        var cmd = new SqlCommand(command, _connection);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Строка успешно удалена!", "Успешно");
                            LoadData(activeTabel);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                if (activeTabel == "users")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        var command = $"DELETE FROM {activeTabel} WHERE IdMeeting = {dataGridView1.SelectedRows[i].Cells["IdMeeting"].Value}";

                        var cmd = new SqlCommand(command, _connection);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Строка успешно удалена!", "Успешно");
                            LoadData(activeTabel);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите строки для удаления!");
            }
        }
    }
}
