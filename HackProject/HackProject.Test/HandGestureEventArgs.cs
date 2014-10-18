using Leap;

namespace HackProject.Test
{
    public delegate void HandGestureEvent(object sender, HandGestureEventArgs args);
    public class HandGestureEventArgs
    {
        private readonly Frame _frame;

        public HandGestureEventArgs(Frame frame)
        {
            _frame = frame;
        }

        public Frame Frame
        {
            get { return _frame; }
        }
    }
}