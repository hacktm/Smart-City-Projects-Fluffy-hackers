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
        public MainWindow()
        {
            InitializeComponent();
            _reader = new SignatureReader();
        }

        private void StartRead(object sender, RoutedEventArgs e)
        {
            _reader.WriteSignature();
        }

        private void StopRead(object sender, RoutedEventArgs e)
        {
            var signature = _reader.GetReadSignature();
            foreach (System.Drawing.Point point in signature)
            {
                ListOfPositions.Items.Add(point.X + " " + point.Y);

            }
            IImageConverter imageConverter = new ImageConverter();
            imageConverter.ConvertImage(signature);
           
        }
    }
}
