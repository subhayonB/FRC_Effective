using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;


namespace FRC_Planner
{
    public partial class Form1 : Form
    {
        Label[] Day_label;
        ListView[] Days;
       
        public Form1()
        {
            InitializeComponent();
            DialogResult build = MessageBox.Show("Do you want to build a robot?","Robot",MessageBoxButtons.YesNo);
            if (build == DialogResult.No)
            {
                MessageBox.Show("OK, come back when you want to");
                this.Close();
                System.Environment.Exit(1);
            }
            using (var stu = new Form5())
            {
                var r = stu.ShowDialog();
                if (stu.DialogResult == DialogResult.OK)
                {
                    if (stu.Grade < 7)
                    {
                        if (stu.T_Size < 4)
                        {
                            MessageBox.Show("You should build a MindStorm");
                            Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show("You should start an FLL Team");
                            Application.Exit();
                        }
                    }
                    if (stu.Grade<9&&stu.Grade>6)
                    {
                        if (stu.T_Size < 4)
                        {
                            MessageBox.Show("You should build a Vex Robot");
                            Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show("You should start an FTC Team");
                            Application.Exit();
                        }
                    }
                    if (stu.Grade>8)
                    {
                        if (stu.T_Size < 10)
                        {
                            MessageBox.Show("You should get more people to start a FRC Team");
                            Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show("Great you should start an FRC Team");
                        }
                    }
                }
            }
                /*using (var grade = new Form3())
                {
                    var r = grade.ShowDialog();
                    if (grade.DialogResult == DialogResult.OK)
                    {
                        g = grade.Grade;
                    }
                }
                if (g==3)
                {
                    MessageBox.Show("You may want to consider FRC");
                }*/

                comboBox1.Items.Add("Week 1");
            comboBox1.Items.Add("Week 2");
            comboBox1.Items.Add("Week 3");
            comboBox1.Items.Add("Week 4");
            comboBox1.Items.Add("Week 5");
            comboBox1.Items.Add("Week 6");
            //comboBox1.Items.Add("All Weeks");
            Day_label = new Label[]{ label1, label2, label3, label4, label5, label6, label7 };
            Days = new ListView[]{ listView1, listView2, listView3, listView4, listView5, listView6, listView7 };
            DialogResult prepop = MessageBox.Show("Do you want some recommended tasks?", "Recommended", MessageBoxButtons.YesNo);
            if (prepop == DialogResult.Yes)
            {
                listView1.Items.Add(new ToDo(1,"Sunday", "KickOff", new string[] { "Mechanical", "Electrical", "Programming", "Design", "Strategy" }));
                listView1.Items.Add(new ToDo(1, "Sunday", "Download IDE and create program movement", new string[] { "Programming"}));
                listView1.Items.Add(new ToDo(1, "Sunday", "Build Chassis", new string[] { "Mechanical" }));
                listView1.Items.Add(new ToDo(1, "Sunday", "Hook up drivemotors and base electronics", new string[] { "Electrical" }));
                listView3.Items.Add(new ToDo(1, "Tuesday", "Decide Primary Objective", new string[] { "Strategy" }));
                listView4.Items.Add(new ToDo(1, "Wednesday", "Prototype methods to complete primary objective", new string[] { "Design", "Mechanical" }));
                listView7.Items.Add(new ToDo(1, "Friday", "Primary Robot design Complete", new string[] { "Design" }));
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //button7_Click(sender, e);
            foreach (ListView l in Days)
            {
                l.Clear();
            }
            string w = comboBox1.Text.Substring(5);
            if (Directory.Exists(w))
            {
                foreach(string s in Directory.GetFiles(w))
                {
                    StreamReader z = new StreamReader(s);
                    
                    int we = Int32.Parse((char)z.Read()+"");
                    z.Read();
                    string day = "";
                    char b='\0';
                    while (b != '|')
                    {
                        day += b;
                        b = (char)z.Read();
                    }
                    b = (char)z.Read();
                    string task = "";
                    while (b != '|')
                    {
                        task += b;
                        b = (char)z.Read();
                    }
                    string[] groupss = new string[Int32.Parse((char)z.Read()+"")];
                    for (int i=0;i<groupss.Length;i++)
                    {
                        b = (char)z.Read();
                        while (b!=' ')
                        {
                            groupss[i] += b;
                            b= (char)z.Read();
                        }
                    }
                    //MessageBox.Show(s);
                    //MessageBox.Show(s.Substring(2, 1));
                    Days[Int16.Parse(s.Substring(2, 1))].Items.Add(new ToDo(we,day,task,groupss));
                    z.Dispose();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var info = new Form2())
            {
                var r = info.ShowDialog();
                if (r==DialogResult.OK)
                {
                    for (int i =0; i< Days.Length;i++)
                    {
                        if (info.Task.Day == Day_label[i].Text)
                        {
                            Days[i].Items.Add(info.Task);
                            Days[i].Items[Days[i].Items.Count - 1].BackColor = backcolor(info.Task.Groups[0]);
                            
                        }
                        
                    }                    

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filter("Mechanical");
        }

        public void filter(string n)
        {
            foreach (ListView s in Days)
            {
                for (int i = 1; i <= s.Items.Count; i++)
                {
                    bool filter = false;
                    ToDo g = (ToDo)(s.Items[i - 1]);
                    for (int j = 0; j < g.Groups.Length; j++)
                    {
                        if (g.Groups[j] == n)
                        {
                            s.Items[i - 1].ForeColor = Color.FromArgb(0,0,0);
                            filter = true;
                        }
                    }
                    if (!filter)
                        s.Items[i - 1].ForeColor = Color.FromArgb(255, 255, 255);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filter("Electrical");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            filter("Programming");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            filter("Design");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            filter("Strategy");
        }

        private void button7_Click(object sender, EventArgs e)
        {

            //DataContractSerializer ser = new DataContractSerializer(typeof(ToDo));
            string dir = comboBox1.Text.Substring(5);
            if (Directory.Exists(dir))
                Directory.Delete(dir, true);
            Directory.CreateDirectory(dir);
            
            for (int i = 0; i < Days.Length; i++)
            {
                
                for (int j = 0; j < Days[i].Items.Count; j++)
                {
                    //File.Create(i +""+j+ ".txt");
                    //File.OpenWrite(i + "" + j + ".txt");
                    File.WriteAllText(dir+@"\"+i+"" + j + ".txt", Days[i].Items[j].ToString());
                    //System.Threading.Thread.Sleep(200);
                  /**  MemoryStream write = new MemoryStream();
                    ser.WriteObject(write, Days[i].Items[j]);
                    write.Position = 0;
                    StreamReader sr = new StreamReader(write);*/
                   // StreamWriter saver = new StreamWriter(i +""+j+".txt");
                    //saver.WriteLine(sr.ReadToEnd());
                    //saver.Write(Days[i].Items[j].ToString());
                    //saver.Close();

                }
            }
        }
        public Color backcolor(string m)
        {
            Color a = new Color();
            switch (m)
            {
                case "Mechanical":
                    a = Color.FromArgb(192, 192, 255);
                    break;
                case "Electrical":
                    a = Color.FromArgb(255, 255, 192);
                    break;
                case "Programming":
                    a = Color.FromArgb(192, 255, 192);
                    break;
                case "Design":
                    a = Color.FromArgb(255, 128, 128);
                    break;
                case "Strategy":
                    a = Color.FromArgb(255, 192, 255);
                    break;
            }
            return a;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                     
            

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            ToDo v = (ToDo)listView1.SelectedItems[0];
            Form4 a = new Form4(v.Week, v.Day, v.Task, v.Groups);
            a.Show();
        }

        private void listView2_Click(object sender, EventArgs e)
        {
            ToDo v = (ToDo)listView2.SelectedItems[0];
            Form4 a = new Form4(v.Week, v.Day, v.Task, v.Groups);
            a.Show();
        }

        private void listView3_Click(object sender, EventArgs e)
        {
            ToDo v = (ToDo)listView3.SelectedItems[0];
            Form4 a = new Form4(v.Week, v.Day, v.Task, v.Groups);
            a.Show();
        }

        private void listView4_Click(object sender, EventArgs e)
        {
            ToDo v = (ToDo)listView4.SelectedItems[0];
            Form4 a = new Form4(v.Week, v.Day, v.Task, v.Groups);
            a.Show();
        }

        private void listView5_Click(object sender, EventArgs e)
        {
            ToDo v = (ToDo)listView5.SelectedItems[0];
            Form4 a = new Form4(v.Week, v.Day, v.Task, v.Groups);
            a.Show();
        }

        private void listView6_Click(object sender, EventArgs e)
        {
            ToDo v = (ToDo)listView6.SelectedItems[0];
            Form4 a = new Form4(v.Week, v.Day, v.Task, v.Groups);
            a.Show();
        }

        private void listView7_Click(object sender, EventArgs e)
        {
            ToDo v = (ToDo)listView7.SelectedItems[0];
            Form4 a = new Form4(v.Week, v.Day, v.Task, v.Groups);
            a.Show();
        }
    }
}
