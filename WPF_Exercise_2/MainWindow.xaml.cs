using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPF_Exercise_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
        // ========== Async Await ==========
        private void UpdateLbl(string item) {

             this.Dispatcher.Invoke((Action)(() =>{lbl1.Content = item;})); 
        }

        private async void btn1_Click(object sender, RoutedEventArgs e)
        { 
            await Task.Run(() =>
            {
            for (int i= 50; i>= 0; i--) {
                    UpdateLbl(i.ToString());
                    Thread.Sleep(250);
                }
            });
        }
        // ==========  Dispatcher.Invoke ==========

        private void SafeInvoke(Action work)
        {
            if (Dispatcher.CheckAccess())
            {
                work.Invoke();
                return;
            }
            this.Dispatcher.BeginInvoke(work);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                for (int i = 50; i >= 0; i--)
                {
                    Action uiwork = () => {
                        lbl2.Content = i.ToString();
                    };
                    SafeInvoke(uiwork);
                    Thread.Sleep(250);
                }
            });
        }

        // ==========   DispatcherTime ==========
        private int i = 50;
        void timer_Tick(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                lbl3.Content = i.ToString();
                i--;
            }
            else
                i = 0;
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(250);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        // ==========   MVVM ==========

        private MainWIndowViewModel viewModel = new MainWIndowViewModel();
        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                for (int i = 50; i >= 0; i--)
                {
                    Action uiwork = () => {
                        viewModel.MyNumber.NumberValue = i;
                    };
                    SafeInvoke(uiwork);
                    Thread.Sleep(250);
                }
            }); 
        }
    }
}
