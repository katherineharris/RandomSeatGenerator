using System;
using System.Collections.Generic;
using System.IO;
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

namespace RandomSeatGenerator
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            var result = dlg.ShowDialog();

            txtFile.Text = dlg.FileName;
        }

        private void btnAssign_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(txtFile.Text) == true)
            {

                var lines = File.ReadAllLines(txtFile.Text);
                List<int> randomNumbers = new List<int>();
                Random random = new Random();
                int row = 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    int number;

                    var line = lines[i];
                    var column = line.Split(',');
                    string name = column[0];
                    do
                    {
                        
                        number = random.Next(1, lines.Length+1);
                        

                    } while(randomNumbers.Contains(number));

                    if (number > 1 && number <= 12)
                        row = 1;
                    else if (number > 12 && number <= 25)
                        row = 2;
                    else if (number > 25 && number <= 38)
                        row = 3;
                    else
                        row = 4;
                    lstSeats.Items.Add($"{name:B}- Computer {number}, (Row {row})");

                    randomNumbers.Add(number);
                   
                }

                
            }

           
        }
        }
    }
