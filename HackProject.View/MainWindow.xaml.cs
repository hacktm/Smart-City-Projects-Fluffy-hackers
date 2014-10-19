using System;
using System.Collections.Generic;
using System.Drawing;
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
using ImageConverter = ConvertVectorIntoImage.ImageConverter;

namespace HackProject.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SignatureReader _reader;
        public MainWindow()
        {
            InitializeComponent();
            _reader = new SignatureReader();
            _reader.WriteSignature();
        }
        
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _reader.StopSignature();
        }
        

    }
}
