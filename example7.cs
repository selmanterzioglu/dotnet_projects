using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace example7
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker bw1 = new BackgroundWorker();
        public MainWindow()
        {
            InitializeComponent();
            lblResult.Content = "Press start to see the result";
            bw1.DoWork += Bw1_DoWork;
        }

        private void Bw1_DoWork(object sender, DoWorkEventArgs e)
        {
            MyProcess();
        }

        int c = 0;
        void MyProcess()
        {
            while (true)
            {
                c++;
                Dispatcher.Invoke(() =>
                {
                    lblResult.Content = c;
                    prg.Value = c / 10000.0;
                });
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //Task t = new Task(() =>
            //{
            //    MyProcess();
            //});
            //t.Start();

            bw1.RunWorkerAsync();
        }
    }
}