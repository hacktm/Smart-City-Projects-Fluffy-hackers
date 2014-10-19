using Leap;

namespace HackProject.Model
{
    public class GestureReader
    {
        private SignatureListener _listener;
        private Controller _controller;
        public void Start(GestureEvent gestureMade)
        {
            // Create a sample listener and controller
            _listener = new SignatureListener();
            _listener.GestureMade += gestureMade;
            _controller = new Controller();

            // Have the sample listener receive events from the controller
            _controller.AddListener(_listener);

        }

        public void Stop()
        {
            var signature = _listener.GestureString;
            _controller.RemoveListener(_listener);
            _controller.Dispose();
            _controller = null;
            _listener = null;
        }
    }
}