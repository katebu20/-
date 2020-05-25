using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        class MySet
        {
            public List<Object> mySet = new List<object>();

            public List<Object> getAsList()
            {
                return mySet;
            }
            public void add(Object obj)
            {
                if (!mySet.Contains(obj))
                    mySet.Add(obj);
            }

            public void del(Object obj)
            {
                mySet.Remove(obj);
            }
            public int size()
            {
                return mySet.Count;
            }
            public void writeToFile(String way)
            {
                using (StreamWriter writetext = new StreamWriter("write.txt"))
                {
                    foreach (var VARIABLE in mySet)
                    {
                        writetext.WriteLine(VARIABLE);

                    }
                }
            }

            public void readFromFile(String way)
            {
                String[] tmp = File.ReadAllLines(way);
                foreach (var VARIABLE in tmp)
                {
                    mySet.Add(VARIABLE);
                }
            }

            public bool contains(Object obj)
            {
                return mySet.Contains(obj);
            }

            public MySet cross(MySet crosser)
            {
                MySet rez = new MySet();
                foreach (var VARIABLE in mySet)

                {
                    if (crosser.contains(VARIABLE))
                        rez.add(VARIABLE);
                }
                return rez;
            }

            public MySet join(MySet joiner)
            {
                MySet rez = new MySet();
                foreach (var VARIABLE in mySet)
                {
                    rez.add(VARIABLE);
                }

                foreach (var VARIABLE in joiner.getAsList())
                {
                    rez.add(VARIABLE);
                }

                return rez;
            }

            public MySet resume(MySet resumer)
            {
                MySet rez = new MySet();
                foreach (var VARIABLE in mySet)
                {
                    rez.add(VARIABLE);
                }
                foreach (var VARIABLE in resumer.getAsList())
                {
                    if (rez.contains(VARIABLE))
                        rez.del(VARIABLE);
                }

                return rez;
            }


        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rez.ResetText();
            MySet mySet = new MySet();
            String[] strs = src.Lines;
            foreach (String str in strs)
            {
                mySet.add(str);
            }
            mySet.add(adder.Lines[0]);
            foreach (Object s in mySet.mySet)
            {
                rez.AppendText(s.ToString()+"\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rez.ResetText();
            MySet mySet = new MySet();
            String[] strs = src.Lines;
            foreach (String str in strs)
            {
                mySet.add(str);
            }
            mySet.del(adder.Lines[0]);
            foreach (Object s in mySet.mySet)
            {
                rez.AppendText(s.ToString() + "\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rez.ResetText();
            MySet mySet = new MySet();
            String[] strs = src.Lines;
            foreach (String str in strs)
            {
                mySet.add(str);
            }
            rez.AppendText(mySet.size().ToString() + "\n");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rez.ResetText();
            MySet mySet = new MySet();
            String[] strs = src.Lines;      //todo fix
            foreach (String str in strs)
            {
                mySet.add(str);
            }
            mySet.writeToFile(adder.Lines[0]);
            using (System.IO.FileStream fs = new System.IO.FileStream(adder.Lines[0], FileMode.Append, FileAccess.Write))
            {
                foreach(Object o in mySet.mySet)
                {
                    fs.Write(Encoding.ASCII.GetBytes(o.ToString()+"\n"), 0, o.ToString().Length);
                }
                
                fs.Flush();
                fs.Close();
            }
            rez.AppendText("Done");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rez.ResetText();
            MySet mySet = new MySet();
            mySet.readFromFile(adder.Lines[0]);
            foreach (Object s in mySet.mySet)
            {
                rez.AppendText(s.ToString() + "\n");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            rez.ResetText();
            MySet mySet = new MySet();
            String[] strs = src.Lines;
            foreach (String str in strs)
            {
                mySet.add(str);
            }
            rez.AppendText(mySet.contains(adder.Lines[0]).ToString() + "\n");

        }

        private void button7_Click(object sender, EventArgs e)
        {

            rez.ResetText();
            MySet mySet = new MySet();
            String[] strs = src.Lines;
            foreach (String str in strs)
            {
                mySet.add(str);
            }
            MySet mySet2 = new MySet();
            foreach (String str in adder.Lines)
            {
                mySet2.add(str);
            }
            
            foreach (Object s in mySet.join(mySet2).mySet)
            {
                rez.AppendText(s.ToString() + "\n");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            rez.ResetText();
            MySet mySet = new MySet();
            String[] strs = src.Lines;
            foreach (String str in strs)
            {
                mySet.add(str);
            }
            MySet mySet2 = new MySet();
            foreach (String str in adder.Lines)
            {
                mySet2.add(str);
            }

            foreach (Object s in mySet.resume(mySet2).mySet)
            {
                rez.AppendText(s.ToString() + "\n");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            rez.ResetText();
            MySet mySet = new MySet();
            String[] strs = src.Lines;
            foreach (String str in strs)
            {
                mySet.add(str);
            }
            MySet mySet2 = new MySet();
            foreach (String str in adder.Lines)
            {
                mySet2.add(str);
            }

            foreach (Object s in mySet.cross(mySet2).mySet)
            {
                rez.AppendText(s.ToString() + "\n");
            }

        }
    }
}
