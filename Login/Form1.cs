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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Form form2 = new Form2();
           
        
        bool StF(string s1, string s2)
        {
            if(s1 == "Munzer" && s2 == "P123")
                return true;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (StF(tbusername.Text,tbpassword.Text))
            {
                this.Visible = false;
                form2.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Enter Right Name And PassWord ", "Error");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = form2.Size;
            tbusername.Focus();

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
