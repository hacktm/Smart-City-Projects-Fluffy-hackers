using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ConvertVectorIntoImage;
using HackProject.Model;

namespace HackProject.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SignatureReader _reader;
        private GestureReader _gestureReader;
        public MainWindow()
        {
            InitializeComponent();
            _reader = new SignatureReader();
            _gestureReader=new GestureReader();
        }

        private void GestureMade(object sender, GestureEventArgs args)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(
                        () => ListOfPositions.Items.Add(args.GestureName), DispatcherPriority.Normal);
            }
          //  ListOfPositions.Items.Add(args.GestureName);
        }

        private void StartRead(object sender, RoutedEventArgs e)
        {
            //_reader.WriteSignature();
            _gestureReader.Start(GestureMade);
        }

        private void StopRead(object sender, RoutedEventArgs e)
        {
            //var signature = _reader.GetReadSignature();
            _gestureReader.Stop();
            //var gestures = _reader.GetGestures();
            //foreach (string s in gestures)
            //{
            //    ListOfPositions.Items.Add(s);
            //  //  IImageConverter imgConverter=new ImageConverter();
            //   // imgConverter.ConvertImage(signature);
            //}
        }


        private void StartTestRead(object sender, RoutedEventArgs e)
        {
        }

        private void StopTestRead(object sender, RoutedEventArgs e)
        {
        }
    }
}
