using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Form form3 = new LogoutScreen();
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            form3.ShowDialog();
            this.Close();
        }
    }
}
