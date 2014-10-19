using Leap;

namespace HackProject.Model
{
    public class SignatureReader : ISignatureReader
    {
        private SignatureListener _listener;
        private Controller _controller;

        public void StartSignatureRecognition()
        {
            _listener = new SignatureListener();
            _controller = new Controller();
            _controller.AddListener(_listener);
        }

       

        public Signature StopSignatureRecognition()
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