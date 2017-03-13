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
        private String Alarm;
        private String AlarmaAntigua;

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
            DispatcherTimerSetup();

        }

        public void Initialize()
        {
            
        }

        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            
            startTime = DateTimeOffset.Now;
            lastTime = startTime;
            
            dispatcherTimer.Start();
            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            String[] date = DateTime.Now.ToString().Split(' ');
            txt_data.Text = date[1];
            date = txt_data.Text.Split(':');
            
            if (cbAlarmaOn.IsChecked == true && Alarm != null)
            {
                if (Alarm.Equals(date[0] + ":" + date[1]))
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    MessageBox.Show("es el momento");
                    Alarm = null;
                }
            }
            if (cbAlarmaOn.IsChecked == true && AlarmaAntigua != null && AlarmaAntigua.Equals(date[0] + ":" + date[1]))
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("es el momento");
                AlarmaAntigua = null;
            }
                
        }

        private void Sobre_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" by : KARIM ARAFEH");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbAlarmaOn_Click(object sender, RoutedEventArgs e)
        {
            if (cbAlarmaOn.IsChecked == true)
            {
                String text = System.IO.File.ReadAllText("../../Alarma.txt");
                MessageBox.Show("Tienes alarma guardad a les : " + text + " \n si quieres modificar la \n escribe la nueva alarma y guarda \n y si no te avisamos cuando sea el momento");
                AlarmaAntigua = text;
                lblAlarmHora.Visibility = Visibility.Visible;
                txtAlarmHora.Visibility = Visibility.Visible;
                btSave.Visibility = Visibility.Visible;
            }
            else if (cbAlarmaOn.IsChecked == false)
            {
                lblAlarmHora.Visibility = Visibility.Hidden;
                txtAlarmHora.Clear();
                txtAlarmHora.Visibility = Visibility.Hidden;
                btSave.Visibility = Visibility.Hidden;
            }
                    
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            
            Alarm = txtAlarmHora.Text;
            if (Alarm != "")
            {
                MessageBox.Show("la alarma esta guardad \n cuando sea el momento te avisamos .");
                System.IO.File.WriteAllText("../../Alarma.txt", Alarm);
                txtAlarmHora.Text = null;
            }
            else MessageBox.Show("No introduciste tiempo por la alarma !!!!!");
            
        }

    }


}
