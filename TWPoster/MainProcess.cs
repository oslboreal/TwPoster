using System;
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
        }

        private void timer_callBack(object state)
        {
            throw new NotImplementedException();
        }
    }
}
