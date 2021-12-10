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
            
            //LoadData("Meetings");
        }

        private void LoadData(string tabel)
        {
            var source = new DataTable();
            string command = $"SELECT * FROM {tabel}";
            new SqlDataAdapter(command, _connection).Fill(source);

            dataGridView1.DataSource = source;
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

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleate_Click(object sender, EventArgs e)
        {

        }
    }
}
