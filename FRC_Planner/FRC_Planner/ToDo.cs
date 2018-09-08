using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace FRC_Planner
{
    [Serializable]
    public class ToDo : System.Windows.Forms.ListViewItem
    { 
       // [DataMember]
        public string Day { get; set; }
        //[DataMember]
        public string Task { get; set; }
       //[DataMember]
        public /*System.Windows.Forms.ListViewGroup Groups*/string[] Groups { get; set; }
       // [DataMember]
       public int Week { get; set; }
       // public System.Drawing.Color Back { get; set; }
        public ToDo(int week, string day, string task, /*System.Windows.Forms.ListViewGroup*/ string[] groups)
        {
            Week = week;
            Day = day;
            Task = task;
            Groups = groups;
           // Back = back;
            this.Text = task;
        }
        public override string ToString()
        {
            string gs = "";
            foreach (string s in Groups)
                gs += s + " ";
            return Week + "|"+Day+"|"+Task+ "|" +Groups.Length+ gs;
        }

        
    }
}
