using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLightUserControl
{
    public partial class UserControl1 : UserControl
    {
        public delegate void IsChange(object sender);

        public event IsChange OnRed;
        public event IsChange OnOrange;
        public event IsChange OnGreen;

        public UserControl1()
        {
            InitializeComponent();
        }

        private void ChangeColors()
        {
            while(true) 
            {
                PBRed.BringToFront();
                OnRed?.Invoke(this);
                Task.Delay(10000);
                PBOrang.BringToFront();
                OnOrange?.Invoke(this);
                Task.Delay(5000);
                PBGreen.BringToFront();
                OnGreen?.Invoke(this);
                Task.Delay(7000);
                PBOrang.BringToFront();
                OnOrange?.Invoke(this);
                Task.Delay(5000);
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            ChangeColors();
        }
    }

   
}