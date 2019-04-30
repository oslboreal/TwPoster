using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using System.Windows;

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
            timer.Change(0, 0);
        }

        private void timer_callBack(object state)
        {
            try
            {
                string nextPhrase = PhrasesManager.ObtainNextPhrase();
                Jarvis.sendTweet(nextPhrase);
            }
            catch (Exception)
            {
                // TODO : REPORT LOG TO REPORTING SERVICE.
            }
            finally
            {
                timer.Change(tiempoEspera, TimeSpan.Zero);
            }
        }
    }
}
