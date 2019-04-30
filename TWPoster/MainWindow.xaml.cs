using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Configuration;

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
            InitializeComponent();
            timer.Interval = 300;
            timer.Elapsed += elapsedEventHandler;


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
