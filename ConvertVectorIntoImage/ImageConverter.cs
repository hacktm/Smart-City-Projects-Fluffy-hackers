using System.Collections.Generic;
using System.Drawing;
using PubNubMessaging.Core;

namespace ConvertVectorIntoImage
{
    public class ImageConverter : IImageConverter
    {
        public void ConvertImage(List<Point> arrayOfPoints)
        {
            var form = new InvPanel {ListOfPoints = arrayOfPoints};
            SendToParse(arrayOfPoints);
            form.Show();
        }

        private async void SendToParse(List<Point> arrayOfPoints)
        {
            //ParseClient.Initialize("f5GJkGjHuPWLQ5AbkXSHoggmpszwZ6UHfhDxiJDh", "urQHFZzZARPpv0xJ7nmYLC2dgjcoTTiz5XfSYBa0");
            //var obj = new ParseObject("ListOfPoints");

            //StringBuilder messageWithPoints;

            //obj["x"] = arrayOfPoints[0].X;
            //obj["y"] = arrayOfPoints[0].Y;

            var pubnub = new Pubnub("pub-c-af0c28d6-36d3-4667-bd7b-707dc6e07515",
                 "sub-c-a7b31746-56d3-11e4-a7f8-02ee2ddab7fe", "sec-c-MTMyMzkzODktN2I1NC00YzkxLThlMTYtYWFhM2Q1ODE1ODBi");
            string channel = "fluffy";
            pubnub.Publish(channel, arrayOfPoints, dummyfunction, errorCallbackMethod);
            //ShowStatus(info);

            /*
            var obj = new ParseObject("testObj");
            obj["x"] = 1;
            obj["y"] = 2;
             * */

        }

        private void errorCallbackMethod(PubnubClientError obj)
        {
            throw new System.NotImplementedException();
        }

        private void dummyfunction(object obj)
        {
            int i = new int();
            i = 5;
            //
        }


        private void dummyfunction()
        {

        }
    }
}
