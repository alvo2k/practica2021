using System;
using System.Windows.Forms;

namespace praktika3
{
    public partial class WorkingHours : Form
    {
        int left, top, height, width;
        public WorkingHours(int X, int Y, int Height, int Width)
        {
            InitializeComponent();
            left = X;
            top = Y;
            height = Height;
            width = Width;
        }
        private void WorkingHours_Load(object sender, EventArgs e)
        {
            this.Left = left + width / 2 - (this.Width / 2);
            this.Top = top + height / 2 - (this.Height / 2);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(linkLabel1.Text);
            MessageBox.Show("Скопированно!", "Добавленно в буфер обмена");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(linkLabel2.Text);
            MessageBox.Show("Скопированно!", "Добавленно в буфер обмена");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(linkLabel3.Text);
            MessageBox.Show("Скопированно!", "Добавленно в буфер обмена");
        }

    }
}
