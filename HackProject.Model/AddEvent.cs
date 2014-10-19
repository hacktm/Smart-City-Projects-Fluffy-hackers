using System.Drawing;

namespace HackProject.Model
{
    public delegate void AddEvent(object sender, AddEventArgs args);

    public class AddEventArgs
    {
        private readonly Point _point;

        public AddEventArgs(Point point)
        {
            _point = point;
        }

        public Point Point
        {
            get { return _point; }
        }
    }
}