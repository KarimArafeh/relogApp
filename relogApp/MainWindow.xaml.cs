using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

namespace relogApp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer;
        private DateTimeOffset lastTime;
        private DateTimeOffset startTime;

        public MainWindow()
        {

            InitializeComponent();
            DispatcherTimerSetup();

            txt_data.Text = "Time : ";


        }

        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            //IsEnabled defaults to false
            //TimerLog.Text += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
            startTime = DateTimeOffset.Now;
            lastTime = startTime;
            //TimerLog.Text += "Calling dispatcherTimer.Start()\n";
            dispatcherTimer.Start();
            //IsEnabled should now be true after calling start
            //TimerLog.Text += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            txt_data.Text = DateTime.Now.ToString();
            
        }

        private void txt_data_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
