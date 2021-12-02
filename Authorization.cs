using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace praktika3
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void loggingIn_Click(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
            Appointment appointment = new Appointment(this);            
            appointment.Show();
        }

        private void Authorization_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Authorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
