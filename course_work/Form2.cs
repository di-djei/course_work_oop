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
    
    public partial class Form2 : Form, IObserver
    {
        //change language
        public void Change()
        {
            button1.Text = rs.GetString("button4.Text");
            button2.Text = rs.GetString("button6.Text");
            button4.Text = rs.GetString("button5.Text");
            languageToolStripMenuItem.Text = rs.GetString("languageToolStripMenuItem.Text");
            infoToolStripMenuItem.Text = rs.GetString("helpToolStripMenuItem.Text");
            this.Text = rs.GetString("FormName");
        }
        Graphics context;
        private Form2Controller controller;
        private CrossoverModel model;
        static Random rand = new Random();
        bool randomBool;
        ResourceManager rs = null;
        private AbstractFactory factoryRed;
        private AbstractFactory factoryBlue;
        public Form2(CrossoverModel model)
        {
            InitializeComponent();
            rs = new ResourceManager("course_work.Eng", typeof(MainForm).Assembly);
            Change();
            this.model = model;
            this.model.Register(this);
            this.controller = InjectController();
        }
        private Form2Controller InjectController()
        {
            return new Form2Controller(this, this.model);
        }
        public void UpdateState()
        {

        }
        List<AbstractCircle> list = new List<AbstractCircle>(); //список кругов
        List<AbstractCircle> list1 = new List<AbstractCircle>();
        int[] ch1; int[] ch2; int[] crossed;
        //painter for random generated chromosomes
        private void Painter()
        {
            context = Graphics.FromHwnd(this.Handle);
            foreach (AbstractCircle krug in list)
            {
                {
                    if (krug.F == true)
                    {
                        context.FillEllipse(new SolidBrush(krug.CircleColor()), krug.X, krug.Y, 20, 20);
                    }
                    else context.DrawEllipse(new Pen(krug.CircleColor()), krug.X, krug.Y, 20, 20);
                }
            }
            foreach (AbstractCircle krug in list1)
            {
                if (krug.F == true)
                {
                    context.FillEllipse(new SolidBrush(krug.CircleColor()), krug.X, krug.Y, 20, 20);
                }
                else context.DrawEllipse(new Pen(krug.CircleColor()), krug.X, krug.Y, 20, 20);
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            ch1 = null; ch2 = null; crossed = null;
            list.Clear(); list1.Clear();
            Close();
        }
        //creating and painting chromosomes
        private void button3_Click(object sender, EventArgs e)
        {
            int N = (int)numericUpDown1.Value;
            ch1 = new int[N];
            ch2 = new int[N];
            crossed = new int[N];
            for (int i = 0; i < N; i++)
            {
                randomBool = rand.Next(2) == 1;
                list.Add(factoryRed.CreateCircle(randomBool, 20 + i * 50, 50));
                if (list[i].F == true) ch1[i] = 1;
                else ch1[i] = 0;
                randomBool = rand.Next(2) == 1;
                list1.Add(factoryBlue.CreateCircle(randomBool, 20 + i * 50, 80));
                if (list1[i].F == true) ch2[i] = 1;
                else ch2[i] = 0;
            }
            if (N > 5)
            {
                this.Width +=(N-5)*50;
            }
            Painter();
            groupBox1.Visible = false;
            button1.Visible = true;
            button4.Visible = true;
        }
        //clear all for again
        private void button4_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            ch1 = new int[0]; ch2 = new int[0]; crossed = new int[0];
            list.Clear(); list1.Clear();
            context.FillRectangle(new SolidBrush(this.BackColor), 0, 0, Width, Height);
            groupBox1.Visible = true;
            button1.Visible = false;
            button4.Visible = false;
            this.Width = 283;
        }
        //crossover
        private void button1_Click(object sender, EventArgs e)
        {
            int a = rand.Next(0, ch1.Length+1);
            int b = rand.Next(0, ch1.Length+1);
            controller.Go(a, b, ch1, ch2);
            for (int i = 0; i < ch1.Length; i++)
            {
                if ((i >a && i<b)|| (i < a && i > b))
                {
                    crossed[i] = 1;
                }
                else crossed[i] = 0;
            }
            this.Invalidate();
        }
        //animation
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            if (crossed != null)
            {
                for (int i = 0; i < ch1.Length; i++)
                {
                    if (crossed[i] == 1)
                    {
                        for (int j = 1; j < 11; j++)
                        {
                            if (list[i].F == true)
                            {
                                context.FillEllipse(new SolidBrush(this.BackColor), list[i].X, list[i].Y + 3 * (j - 1), 20, 20);
                                context.FillEllipse(new SolidBrush(list[i].CircleColor()), list[i].X, list[i].Y + 3 * j, 20, 20);
                            }
                            else
                            {
                                context.DrawEllipse(new Pen(this.BackColor), list[i].X, list[i].Y + 3 * (j - 1), 20, 20);
                                context.DrawEllipse(new Pen(list[i].CircleColor()), list[i].X, list[i].Y + 3 * j, 20, 20);
                            }
                            if (list1[i].F == true)
                            {
                                context.FillEllipse(new SolidBrush(this.BackColor), list1[i].X, list1[i].Y - 3 * (j - 1), 20, 20);
                                context.FillEllipse(new SolidBrush(list1[i].CircleColor()), list1[i].X, list1[i].Y - 3 * j, 20, 20);
                            }
                            else
                            {
                                context.DrawEllipse(new Pen(this.BackColor), list1[i].X, list1[i].Y - 3 * (j - 1), 20, 20);
                                context.DrawEllipse(new Pen(list1[i].CircleColor()), list1[i].X, list1[i].Y - 3 * j, 20, 20);
                            }
                        }
                    }
                    else
                    {
                        if (list[i].F == true)
                        {
                            context.FillEllipse(new SolidBrush(list[i].CircleColor()), list[i].X, list[i].Y, 20, 20);
                        }
                        else
                        {
                            context.DrawEllipse(new Pen(list[i].CircleColor()), list[i].X, list[i].Y, 20, 20);
                        }
                        if (list1[i].F == true)
                        {
                            context.FillEllipse(new SolidBrush(list1[i].CircleColor()), list1[i].X, list1[i].Y, 20, 20);
                        }
                        else
                        {
                            context.DrawEllipse(new Pen(list1[i].CircleColor()), list1[i].X, list1[i].Y, 20, 20);
                        }
                    }
                }
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rs = new ResourceManager("course_work.Eng", typeof(Form1).Assembly);
            Change();
        }

        private void русскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rs = new ResourceManager("course_work.Rus", typeof(Form1).Assembly);
            Change();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(rs.GetString("textinfoform2"));
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            context = Graphics.FromHwnd(this.Handle);
            factoryRed = new FactoryRed();
            factoryBlue = new FactoryBlue();
        }

    }
}
