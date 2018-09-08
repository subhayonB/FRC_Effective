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
    public partial class Form2 : Form
    {
        public ToDo Task { get; set; }
  
        public Form2( )
        {
            InitializeComponent();
            comboBox1.Items.Add("Sunday");
            comboBox1.Items.Add("Monday");
            comboBox1.Items.Add("Tuesday");
            comboBox1.Items.Add("Wednesday");
            comboBox1.Items.Add("Thursday");
            comboBox1.Items.Add("Friday");
            comboBox1.Items.Add("Saturday");

            comboBox2.Items.Add("Week1");
            comboBox2.Items.Add("Week2");
            comboBox2.Items.Add("Week3");
            comboBox2.Items.Add("Week4");
            comboBox2.Items.Add("Week5");
            comboBox2.Items.Add("Week6");
            
            checkedListBox1.Items.Add("Mechanical");
            checkedListBox1.Items.Add("Electrical");
            checkedListBox1.Items.Add("Programming");
            checkedListBox1.Items.Add("Design");
            checkedListBox1.Items.Add("Strategy");


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] groups = checkedListBox1.CheckedItems.OfType<string>().ToArray();
            
           /* ListViewGroup z = new ListViewGroup();
            foreach (string g in groups)
            {
                z.Items.Add(g);
            }*/
            Task = new ToDo(Int16.Parse( comboBox2.Text.Substring(4)),comboBox1.Text, textBox1.Text, groups);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
