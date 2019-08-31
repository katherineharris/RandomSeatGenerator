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
                Random rnd = new Random();
                var lines = File.ReadAllLines(txtFile.Text);
                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i];
                    var column = line.Split(',');
                    string name = column[0];
                    int seatNumber = rnd.Next(1, lines.Length);
                    lstSeats.Items.Add($"{name}: Computer {seatNumber}");

                }
            }
        }
    }
}
