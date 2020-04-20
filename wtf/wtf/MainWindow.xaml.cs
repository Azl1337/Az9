using System;
using System.Collections.Generic;
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

namespace wtf
{

        /// <summary>
        /// Логика взаимодействия для MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            DispatcherTimer timer;

            public MainWindow()
            {
                InitializeComponent();
                mainFrame.NavigationService.Navigate(new Uri("Pages/MainPage.xaml", UriKind.Relative));

                InitializeTimer();
            }

            void InitializeTimer()
            {
                timer = new DispatcherTimer();
                timer.Tick += new EventHandler(TimerTick);
                timer.Interval = new TimeSpan(0, 1, 0);
                timer.Start();
                ChangeTime();
            }
            void ChangeTime()
            {
                DateTime dateFuture = new System.DateTime(2020, 10, 21, 0, 0, 0);
                DateTime nowDateTime = DateTime.Now;
                TimeSpan diff1 = dateFuture.Subtract(nowDateTime);
                tbTimeLeft.Text = $"{diff1.Days.ToString()} дней {diff1.Hours.ToString()} часов и {diff1.Minutes.ToString()} минут до старта марафона";
            }
            private void TimerTick(object sender, EventArgs e)
            {
                ChangeTime();

            }


        }
}
