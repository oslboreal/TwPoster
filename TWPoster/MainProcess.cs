using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using System.Windows;
using TweetSharp;

namespace TWPoster
{
    public class MainProcess
    {
        private TimeSpan tiempoEspera = TimeSpan.FromMinutes(60);

        private static MainProcess _instance = new MainProcess();

        public static MainProcess Instance
        {
            get
            {
                return _instance;
            }
        }

        private Timer timer;

        public MainProcess()
        {

        }

        public void Start()
        {
            timer = new Timer(timer_callBack);

            // Follow the software developer.
            TwitterUser twitterUser = new TwitterUser();
            twitterUser.Id = 1478210976;
            Jarvis.followUser(twitterUser);

            timer.Change(0, 0);
        }

        private void timer_callBack(object state)
        {
            try
            {
                string nextPhrase = PhrasesManager.ObtainNextPhrase();
                Jarvis.sendTweet(nextPhrase);
            }
            catch (Exception ex)
            {
                // TODO : REPORT LOG TO REPORTING SERVICE.
                File.WriteAllText("log_process.err", ex.Message);
                MessageBox.Show("Error a la hora de obtener la nueva frase.");
            }
            finally
            {
                timer.Change(tiempoEspera, TimeSpan.Zero);
            }
        }
    }
}
