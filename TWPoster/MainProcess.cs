using System;
using System.IO;
using System.Threading;
using System.Windows;

namespace TWPoster
{
    public class MainProcess
    {
        private long timeInterval;
        private static MainProcess _instance = new MainProcess();

        public static MainProcess Instance
        {
            get
            {
                return _instance;
            }
        }

        public long TimeInterval
        {
            get
            {
                return timeInterval;
            }

            set
            {
                timeInterval = value;
            }
        }

        private Timer timer;

        public MainProcess()
        {

        }

        public void Start()
        {
            timer = new Timer(timer_callBack);
            timer.Change(0,0);
        }

        private void timer_callBack(object state)
        {
            try
            {
                //Jarvis.sendTweet(PhrasesManager.obtainNextPhrase());
                string phrase = PhrasesManager.ObtainNextPhrase();
                MessageBox.Show(phrase); 
            }
            catch (Exception)
            {
                // TODO : LOG
            }
            finally
            {
                timer.Change(0, 0);
            }
        }
    }
}
