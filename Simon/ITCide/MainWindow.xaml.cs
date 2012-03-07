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
using System.Diagnostics;

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

            FileStream fs = new FileStream("../../../Compilador/bin/debug/programa.itc", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            //Console.WriteLine("Enter the text which you want to write to the file");
            //string str = Console.ReadLine();
            string str = itcCodebox.Text;
            sw.WriteLine(str);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        private void GuardarComo(object sender, RoutedEventArgs e)
        {

        }

        private void Analizador(object sender, RoutedEventArgs e)
        {
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "../../../Compilador/bin/debug/compilador.exe";
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
             p.WaitForExit();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            lexResponse.Text = output;
        }
      
    }
}
