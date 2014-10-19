using System.Collections.Generic;
using System.Drawing;
using PubNubMessaging.Core;

namespace ConvertVectorIntoImage
{
    public class ImageConverter : IImageConverter
    {
        public void ConvertImage(List<Point> arrayOfPoints)
        {
            var form = new InvPanel { ListOfPoints = arrayOfPoints };
            SendToParse(arrayOfPoints);
            form.Show();
            form.Dispose();
        }

        private void SendToParse(IEnumerable<Point> arrayOfPoints)
        {

            var pubnub = new Pubnub("pub-c-af0c28d6-36d3-4667-bd7b-707dc6e07515",
                 "sub-c-a7b31746-56d3-11e4-a7f8-02ee2ddab7fe", "sec-c-MTMyMzkzODktN2I1NC00YzkxLThlMTYtYWFhM2Q1ODE1ODBi");
            const string channel = "fluffy";
            foreach (Point point in arrayOfPoints)
            {
                pubnub.Publish(channel, point, dummyfunction, errorCallbackMethod);
            }

            pubnub.Publish(channel, 1, dummyfunction, errorCallbackMethod);
        }

        private void errorCallbackMethod(PubnubClientError obj)
        {
        }

        private void dummyfunction(object obj)
        {
        }

    }
}
