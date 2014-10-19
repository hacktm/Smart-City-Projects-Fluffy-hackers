using System.Collections.Generic;
using System.Drawing;

namespace HackProject.Model
{
    public class Signature : List<Point>
    {
        public event AddEvent AddPointEvent;
        public Point AddPoint(Point point)
        {
            Add(point);
            if (AddPointEvent != null)
            {
                AddPointEvent(this,new AddEventArgs(point));
            }
            return point;
        }
    }

    
}