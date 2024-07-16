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
    public partial class MyFirstUserControl1 : UserControl
    {

        public class CalculationValues : EventArgs
        {
            public int val1
            { get; }
            public int val2 
            { get; }
            public int result
            { get; }

            public CalculationValues(int val1, int val2, int result)
            {
                this.val1 = val1;
                this.val2 = val2;
                this.result = result;
            }

        }

        public event EventHandler<CalculationValues> OnCalculationValuesChanged;

        public void CalculationValuesChanged(int val1, int val2, int result)
        {
            CalculationValuesChanged(new CalculationValues(val1,val2,result));
        }


        protected virtual void CalculationValuesChanged(CalculationValues e)
        {
            OnCalculationValuesChanged?.Invoke(this, e);
        }



        public event Action<int> OnCalculationComplete;

        protected virtual void CalculationComplete(int person)
        {
            Action<int> handler = OnCalculationComplete;
            if (handler != null)
            { 
                    handler(person); 
            }
        }

        public MyFirstUserControl1()
        {
            InitializeComponent();
        }

        public float result
        { get { return (float)Convert.ToDouble(button4.Text); } }


        private void button3_Click(object sender, EventArgs e)
        {
            //button4.Text = (int.Parse(textBox1.Text) +int.Parse(textBox2.Text)).ToString();
            
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            button4.Text = (int.Parse(textBox1.Text) + int.Parse(textBox2.Text)).ToString();
            if(OnCalculationComplete != null)
                CalculationComplete(int.Parse(Name));
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            if (OnCalculationValuesChanged != null)
                CalculationValuesChanged(1,2,3);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}