using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoolProject
{
    public partial class PoolControl : UserControl
    {
        public PoolControl()
        {
            InitializeComponent();
        }
        public int Salary
        {
            get; set;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label1.Text = timer1.
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
