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
        string archivo="";

        private void AbrirMenuItem_Click(object sender, RoutedEventArgs e)
        {
            
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

                        archivo = dlg.FileName;

                    }

                }
            
                
                
            }
        private void GuardarMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog sdlg = new Microsoft.Win32.SaveFileDialog();

            sdlg.Filter = "Text File (*.txt)|*.txt|Show All Files (*.*)|*.*";
            sdlg.FileName = "Untitled";
            sdlg.Title = "Save As";

            if (archivo != "")
            {
                
                    var range = new TextRange(richTextBox1.Document.ContentStart,
                                              richTextBox1.Document.ContentEnd);
                    File.WriteAllText(archivo,range.Text);
            }
            else
            {
                Nullable<bool> result = sdlg.ShowDialog();


                if (result == true)
                {

                    using (var stream = sdlg.OpenFile())
                    {
                        var range = new TextRange(richTextBox1.Document.ContentStart,
                                                  richTextBox1.Document.ContentEnd);
                        range.Save(stream, DataFormats.Rtf);
                    }
                }
            }
        }
        }   
        }

       
    
