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

namespace wpfPracticas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void AbrirMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string archivo;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            
            Nullable<bool> result = dlg.ShowDialog();

            
            if (result == true)
            {

                    TextRange range;

                    System.IO.FileStream fStream;

                    if (System.IO.File.Exists(dlg.FileName))
                    {

                        range = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);

                        fStream = new System.IO.FileStream(dlg.FileName, System.IO.FileMode.OpenOrCreate);

                        range.Load(fStream, System.Windows.DataFormats.Rtf);

                        fStream.Close();

                    }

                }
            
                
                
            }

       
            
        }

       
    }

