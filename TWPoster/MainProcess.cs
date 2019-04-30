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
            timer = new Timer(timer_callBack);
            timer.Change(0, 0);

            // If the file that we use to know the position of the latest showed phrase doesnt exist.
            // Creates it.
            if (!File.Exists("latestPhrasePosition.json"))
                File.Create("latestPhrasePosition.json").Close();

            if (!File.Exists("phrases.json"))
                File.Create("phrases.json").Close();
        }

        private void timer_callBack(object state)
        {
            Jarvis.sendTweet(this.obtainNextPhrase());
            throw new NotImplementedException();
        }

        private string obtainNextPhrase()
        {
            return "";
        }

        private int obtainLatestPhrasePosition()
        {
            return 0;
        }
    }
}
