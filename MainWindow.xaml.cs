using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace Lab2
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
            GetBook(uri.Text);
        }
        void GetBook(string uri)
        {
            WebClient wc = new WebClient();

            wc.DownloadStringCompleted += (s, eArgs) =>
            {
                    string theBook = eArgs.Result;
                Dispatcher?.Invoke(() => text.Text = theBook);
            };
            wc.DownloadStringAsync(new Uri(uri));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string testWork = text.Text;
            var result = testWork.Split(new[] { '\r', '\n' });
            string newText = "";
            for(int i = 0; i < result.Length; i++)
            {
                var count = 25 - result[i].Length;
                if (count > 0)
                {
                    result[i] += String.Concat(Enumerable.Repeat("_", count));
                    newText += result[i]+"\n";
                }
                else
                {
                    newText += result[i] + "\n";
                }
            }
            text.Text = newText;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            string testWork = text.Text;
            StringBuilder sb = new StringBuilder(testWork);
            int spaceCount = 0;

            for (int i=0; i<testWork.Length; i++)
            {
                if (sb[i] == ' ' && spaceCount % 2 == 0)
                {
                    sb[i] = 'Ч';
                    spaceCount++;
                }
                else if (sb[i] == ' ' && spaceCount % 2 == 1)
                {
                    sb[i] = 'Н';
                    spaceCount++;
                }
            }
            testWork = sb.ToString();
            text.Text = testWork;

        }
    }
}
