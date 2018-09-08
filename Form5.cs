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
    public partial class Form5 : Form
    {
        public int Grade { get; set; }
        public int Experience { get; set; }
        public int T_Size{ get; set; }
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Grade = Int32.Parse(textBox1.Text);
            if (radioButton1.Checked)
                Experience = 1;
            if (radioButton2.Checked)
                Experience = 2;
            if (radioButton3.Checked)
                Experience = 3;
            T_Size = Int32.Parse(textBox2.Text);
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5_FormClosing(sender, new FormClosingEventArgs(new CloseReason(),false));
        }
    }
}
