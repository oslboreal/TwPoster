using System;
using System.IO;
using System.Threading;

namespace TWPoster
{
    public class MainProcess
    {
        private long timeInterval;

        public static MainProcess Instance
        {
            get
            {
                if (Instance == null)
                    Instance = new MainProcess();

                return Instance;
            }
            private set
            {
                Instance = value;
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
            timer.Change(TimeSpan.MinValue, TimeSpan.MaxValue);
        }

        private void timer_callBack(object state)
        {
            try
            {
                //Jarvis.sendTweet(PhrasesManager.obtainNextPhrase());
                string phrase = PhrasesManager.obtainNextPhrase();
            }
            catch (Exception)
            {
                // TODO : LOG
            }
            finally
            {
                timer.Change(TimeSpan.MinValue, TimeSpan.MaxValue);
            }
        }
    }
}
