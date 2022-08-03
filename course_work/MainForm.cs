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
    public partial class MainForm : Form
    {
        //change language
        public void Change()
        {
            this.Text = rs.GetString("mainform");
            button1.Text = rs.GetString("Mainbutton1.Text");
            button2.Text = rs.GetString("Mainbutton2.Text");
            button3.Text = rs.GetString("button6.Text");
            languageToolStripMenuItem.Text = rs.GetString("languageToolStripMenuItem.Text");
            algorithmToolStripMenuItem.Text = rs.GetString("algorithmToolStripMenuItem.Text");
            courseWorkInfoToolStripMenuItem1.Text = rs.GetString("courseWorkInfoToolStripMenuItem1.Text");
        }
        ResourceManager rs = null;
        public MainForm()
        {
            InitializeComponent();
            rs = new ResourceManager("course_work.Eng", typeof(MainForm).Assembly);
            Change();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrossoverModel model = new CrossoverModel();
            Form1 view1 = new Form1(model);
            view1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CrossoverModel model = new CrossoverModel();
            Form2 view2 = new Form2(model);
            view2.Show();
        }

        private void algorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(rs.GetString("algoinfo"));
        }

        private void courseWorkInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(rs.GetString("workinfo"));
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
    }
}
