namespace HackProject.Model
{
    public interface ISignatureReader
    {
        void StartSignatureRecognition();
        Signature StopSignatureRecognition();
    }
}