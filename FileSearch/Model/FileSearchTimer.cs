using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FileSearch.Model
{
    public class FileSearchTimer : IDisposable
    {
        private int _timeCounter = 0;

        public event EventHandler<TimerEventArgs> TimerElapsed;

        private Timer _timer = new Timer(1000);

        public FileSearchTimer()
        {
            _timer.Elapsed += (s, e) =>
            {
                _timeCounter++;
                OnTimerElapsed(new TimerEventArgs(_timeCounter));
            };
        }       

        public void StartTimer()
        {
            _timeCounter = 0;
            _timer.Start();
        }

        public void StopTimer()
        {
            _timer.Stop();         
        }

        private Task OnTimerElapsed(TimerEventArgs args)
        {
            if (TimerElapsed != null)
            {
                TimerElapsed(this, args);
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {            
            _timer.Dispose();
        }
    }

    public class TimerEventArgs : EventArgs
    {
        public TimerEventArgs(int timecounter)
        {
            TimeElapsed = timecounter;
        }

        public int TimeElapsed { get; private set; }
    }

}
