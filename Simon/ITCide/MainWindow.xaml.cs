using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace ITCide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NuevoArchivo(object sender, RoutedEventArgs e)
        {
           
        }

        private void AbrirArchivo(object sender, RoutedEventArgs e)
        {
            
        }

        private void GuardarArchivo(object sender, RoutedEventArgs e)
        {


            FileStream fs = new FileStream("c:\\test.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            Console.WriteLine("Enter the text which you want to write to the file");
            string str = Console.ReadLine();
            sw.WriteLine(str);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        private void GuardarComo(object sender, RoutedEventArgs e)
        {

        }

      
    }
}
