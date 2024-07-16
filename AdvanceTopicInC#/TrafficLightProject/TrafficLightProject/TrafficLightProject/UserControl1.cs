using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrafficLightProject.Properties;
using System.Threading;

namespace TrafficLightProject
{
    public partial class UCTrafficLightProject : UserControl
    {
        public UCTrafficLightProject()
        {
            InitializeComponent();
        }

       public void SetImage()
       {
            while (true) 
            {
                Thread t1 = new Thread(() => { pictureBox1.Image = Resources.Red; });
                t1.Start();
                t1.Join();
                Thread.Sleep(5000);
                Thread t2 = new Thread(() => { pictureBox1.Image = Resources.Orange; });
                t2.Start();
                t2.Join();
                Thread.Sleep(2000);
                Thread t3 = new Thread(() => { pictureBox1.Image = Resources.Green; });
                t3.Start();
                t3.Join();
                Thread.Sleep(3000);
                Thread t4 = new Thread(() => { pictureBox1.Image = Resources.Orange; });
                t4.Start();
                t4.Join();
                Thread.Sleep(2000);
            }
        }
    }


}
