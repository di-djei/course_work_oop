using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_work
{
    
    class Form1Controller
    {
        private Form1 view;
        private CrossoverModel model;
        public Form1Controller(Form1 view, CrossoverModel model)
        {
            this.view = view;
            this.model = model;
        }
        public void Go(int p1, int p2, int[] ch1, int[] ch2)
        {
            this.model.DoCrossover(p1, p2, ch1, ch2);
        }
    }
}
