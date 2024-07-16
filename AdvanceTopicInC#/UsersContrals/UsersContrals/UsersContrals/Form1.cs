using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UsersContrals
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int PersonID = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(myFirstUserControl11.result.ToString());
        }

        private void myFirstUserControl11_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.DataBack += Form2_DataBack;
            form2.ShowDialog();
        }

        private void Form2_DataBack(object sender,int PersonID)
        {
            textBox1.Text = PersonID.ToString();    
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void myFirstUserControl11_OnCalculationValuesChanged(object sender, MyFirstUserControl1.CalculationValues e)
        {
            MessageBox.Show(e.val1.ToString() + e.val2.ToString() + e.result.ToString());

        }
    }
}