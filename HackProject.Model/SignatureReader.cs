using Leap;

namespace HackProject.Model
{
    public class SignatureReader
    {
        private SignatureListener _listener;
        private Controller _controller;

        public void WriteSignature()
        {
            _listener = new SignatureListener();
            _controller = new Controller();
            _controller.AddListener(_listener);
        }

       

        public Signature StopSignature()
        {
            var signature = _listener.Signature;
            _controller.RemoveListener(_listener);
            _controller.Dispose();
            _controller = null;
            _listener = null;
            return signature;
        }
    }

    
}