using AutoUpdater;
using System;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace TWPoster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer timer = new Timer();

        public MainWindow()
        {
            try
            {
                // Apenas inicializa el programa corroboramos que esté actualizado.
                var verServer = VersionHelper.CorroborarVersion();
                var verClient = VersionHelper.Version();

                if (verServer != verClient)
                {
                    Process.Start("AutoUpdater.exe");
                    Application.Current.Shutdown();
                }

                InitializeComponent();
            }
            catch (Exception)
            {
                MessageBox.Show("Ha habido un error a la hora de verificar la version del programa, asegurese de estar conectado a internet.");
            }
        }

        private void UpdateLatestMessage(string message)
        {
            bloque.Text = message;
        }

        private void elapsedEventHandler(object sender, ElapsedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Comenzar_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            MainProcess.Instance.Start();
            btnComenzar.IsEnabled = false;
            btnFrases.IsEnabled = false;
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("chrome.exe", "http://twposter.marcosvallejo.info");
        }

        private void AdminPhrases_Click(object sender, RoutedEventArgs e)
        {
            PhraseAdmin window = new PhraseAdmin();
            window.Show();
        }
    }
}
