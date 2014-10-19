using System;
using System.Drawing;
using System.Linq;
using ConvertVectorIntoImage;
using Leap;
using ImageConverter = ConvertVectorIntoImage.ImageConverter;

namespace HackProject.Model
{
    public class SignatureListener : Listener
    {
        private readonly Object _thisLock = new Object();

        public Signature Signature
        {
            get { return _signature; }
        }

        private void SafeWriteLine(String line)
        {
            lock (_thisLock)
            {
                   Console.WriteLine(line);
            }
        }

        public override void OnInit(Controller controller)
        {
            SafeWriteLine("Initialized");
        }

        public override void OnConnect(Controller controller)
        {
            SafeWriteLine("Connected");
            controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
            controller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
            _signature = new Signature();
        }

        public override void OnDisconnect(Controller controller)
        {
            //Note: not dispatched when running in a debugger.
            SafeWriteLine("Disconnected");
        }

        public override void OnExit(Controller controller)
        {
            SafeWriteLine("Exited");
        }

        private long _currentTime;
        private long _previousTime;
        private long _timeChange;
        private Signature _signature;

        private static Point CreatePoint(Controller cntrlr)
        {
            if (cntrlr == null) throw new ArgumentNullException("cntrlr", "Leap motion is dissconnected or broken");
            Frame currentFrame = cntrlr.Frame();
            const float w = 600;
            const float h = 400;
            var pointable = currentFrame.Pointables.Frontmost;
            var box = currentFrame.InteractionBox;
            var leapPoint = pointable.StabilizedTipPosition;
            var normalizedPoint = box.NormalizePoint(leapPoint, false);
            float x = normalizedPoint.x*w;
            float y = (1 - normalizedPoint.y)*h;
            MouseCursor.MoveCursor(Convert.ToInt32(x), Convert.ToInt32(y));
            return new Point(Convert.ToInt32(x), Convert.ToInt32(y));
        }

        public override void OnFrame(Controller cntrlr)
        {
            Frame currentFrame = cntrlr.Frame();
            _currentTime = currentFrame.Timestamp;
            _timeChange = _currentTime - _previousTime;
            if (_timeChange > 5000)
            {
                if (!currentFrame.Hands.IsEmpty)
                {
                    int count = currentFrame.Fingers.Count(e => e.IsExtended);
                    if (count > 2)
                    {
                        if (Signature.Count > 5)
                        {
                            IImageConverter imgConverter = new ImageConverter();
                            imgConverter.ConvertImage(Signature);
                            Signature.Clear();
                        }
                        return;
                    }
                    _signature.Add(CreatePoint(cntrlr));
                }
                _previousTime = _currentTime;
            }
        }
    }
}
