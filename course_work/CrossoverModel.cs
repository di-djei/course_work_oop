using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_work
{
    public class CrossoverModel
    {
        private int size;
        private int point1;
        private int point2;
        private int[] chromosome1;
        private int[] chromosome2;
        private ArrayList listners;

        public CrossoverModel()
        {
            this.size = 0;
            this.point1 = 0;
            this.point2 = 0;
            this.chromosome1 = null;
            this.chromosome2 = null;
            this.listners = new ArrayList();
        }
        public void Swap(ref int a, ref int b) 
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }
        public void DoCrossover(int p1, int p2, int[] ch1, int[] ch2)
        {
            this.chromosome1 = ch1;
            this.chromosome2 = ch2;
            this.point1 = p1;
            this.point2 = p2;
            if (p1 > p2) Swap(ref p1, ref p2);
            if (p1 != p2)
            {
                for (int i = p1; i<p2; i++)
                {
                    Swap(ref ch1[i], ref ch2[i]);
                }
            }
        }
        public void Register(IObserver o)
        {
            this.listners.Add(o);
        }
        public void ClearListners()
        {
            this.listners.Clear();
        }
    }
}
