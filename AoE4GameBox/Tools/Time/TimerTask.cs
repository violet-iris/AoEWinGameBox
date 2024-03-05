using System;
using System.Threading;

namespace AoE4GameBox.Tools
{
    internal class TimerTask
    {
        private Timer timer;
        private Action taskAction;
        private int interval;

        public TimerTask(Action action, int interval)
        {
            this.taskAction = action;
            this.interval = interval;
            timer = new Timer(TimerCallback, null, Timeout.Infinite, Timeout.Infinite);
        }

        public void Start()
        {
            timer.Change(0, interval);
        }

        public void Stop()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void TimerCallback(object state)
        {
            taskAction?.Invoke();
        }
    }
}
