using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_work
{
    
    //creating of figures red or blue
    public abstract class AbstractFactory
    {
        public abstract AbstractCircle CreateCircle(bool fullen, int x, int y);
    }
    public class FactoryRed : AbstractFactory
    {
        public override AbstractCircle CreateCircle(bool fullen,  int x, int y)
        {
            return new RedCircle(fullen, x, y);
        }
    }
    public class FactoryBlue : AbstractFactory
    {
        public override AbstractCircle CreateCircle(bool fullen, int x, int y)
        {

            return new BlueCircle(fullen, x, y);
        }
    }

}
