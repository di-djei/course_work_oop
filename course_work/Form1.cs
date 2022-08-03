using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace course_work
{
    
    public partial class Form1 : Form, IObserver
    {
        //change the language of program
        public void Change()
        {
            label1.Text = rs.GetString("label1.Text");
            helpToolStripMenuItem.Text = rs.GetString("helpToolStripMenuItem.Text");
            languageToolStripMenuItem.Text = rs.GetString("languageToolStripMenuItem.Text");
            label3.Text = rs.GetString("label3.Text");
            label4.Text = rs.GetString("label4.Text");
            label5.Text = rs.GetString("label5.Text");
            label7.Text = rs.GetString("label7.Text");
            button1.Text = rs.GetString("button1.Text");
            button2.Text = rs.GetString("button2.Text");
            button4.Text = rs.GetString("button4.Text");
            button5.Text = rs.GetString("button5.Text");
            button6.Text = rs.GetString("button6.Text");
            this.Text = rs.GetString("FormName");
        }
        ResourceManager rs = null;
        private Form1Controller controller;
        private CrossoverModel model;
        Random rand = new Random();
        int a, b, size;
        public Form1(CrossoverModel model) 
        {
            InitializeComponent();
            rs = new ResourceManager("course_work.Eng", typeof(Form1).Assembly);
            Change();
            this.model = model;
            this.model.Register(this);
            this.controller = InjectController();
        }
        private Form1Controller InjectController()
        {
            return new Form1Controller(this, this.model);
        }
        public void UpdateState()
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //errors if something wrong
            try
            {
                //creating chromosomes
                int[] array1 = textBox1.Text.Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
                int[] array2 = textBox2.Text.Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
                //crossover
                controller.Go(a, b, array1, array2);
                //print
                for (int i = 0; i < array2.Length; i++)
                {
                    richTextBox1.Text += array1[i].ToString() + " ";
                }
                richTextBox1.Text += "\n";
                for (int i = 0; i < array1.Length; i++)
                {
                    richTextBox1.Text += array2[i].ToString() + " ";
                }
                richTextBox1.Text += "\n";
                for (int i = 0; i < array1.Length; i++)
                {
                    //error if something no 1 or 0
                    if ((array1[i] != 1 && array1[i] != 0) || (array2[i] != 1 && array2[i] != 0))
                    {
                        MessageBox.Show(rs.GetString("text6"));
                        richTextBox1.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        break;
                    }
                }
            }
            //error if different length
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show(rs.GetString("text4"));
                richTextBox1.Text = "";
            }
            //other errors
            catch (Exception ex) 
            { 
                MessageBox.Show(rs.GetString("text5"));
                richTextBox1.Text = "";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                size = (int)numericUpDown1.Value;
                //stop  if size ==0
                for (int i = 0; i < size; i++)
                {
                    textBox1.Text += rand.Next(0, 2).ToString() + " ";
                    textBox2.Text += rand.Next(0, 2).ToString() + " ";
                }
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
            catch (Exception ex) { MessageBox.Show(rs.GetString("text3")); }
        }
        //clean all
        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            size = 0;
            a = 0;
            b = 0;
            textBox3.Text = "";
            textBox4.Text = "";
            richTextBox1.Text = "";
            groupBox1.Visible = false;
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rs = new ResourceManager("course_work.Eng", typeof(Form1).Assembly);
            Change();
        }

        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rs = new ResourceManager("course_work.Rus", typeof(Form1).Assembly);
            Change();
        }

        private void helpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(rs.GetString("text1"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] array1 = textBox1.Text.Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
            numericUpDown1.Value = array1.Length;
            size = (int)numericUpDown1.Value;
            textBox3.Text = rand.Next(0, size+1).ToString();
            textBox4.Text = rand.Next(0, size+1).ToString();
            a = int.Parse(textBox3.Text);
            b = int.Parse(textBox4.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try 
            {
                int[] array1 = textBox1.Text.Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
                numericUpDown1.Value = array1.Length;
                size = (int)numericUpDown1.Value;
                a = int.Parse(textBox3.Text);
                b = int.Parse(textBox4.Text);
                if (a>size || b > size)
                {
                    MessageBox.Show(rs.GetString("text7"));
                }
                else groupBox1.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(rs.GetString("text2")); }
        }

    }
}
