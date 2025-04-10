using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Halı_Yıkama_Fabrikası
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttoncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonmusteri_Click(object sender, EventArgs e)
        {
            customer Customer= new customer();
            Customer.Show();
        }

        private void buttonhali_Click(object sender, EventArgs e)
        {
            carpet Carpet = new carpet();
            Carpet.Show();
        }

        private void buttondurum_Click(object sender, EventArgs e)
        {
            state State=new state();
            State.Show();
        }
    }
}
