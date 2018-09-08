using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRC_Planner
{
    public partial class Form4 : Form
    {
        public Form4(int week = 0, string day = "Day", string task = "Task:", string[] groups = null)
        {
            InitializeComponent();
            textBox1.Text = "Week " + week;
            textBox2.Text = day;
            textBox4.Text = task;
            string s = "";
            foreach (string str in groups)
                s += str+ "\t\t";
            textBox3.Text = s;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
