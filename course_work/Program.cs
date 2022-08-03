using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace course_work
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            MainForm view3 = new MainForm();
            Application.Run(view3);
        }
    }
}
