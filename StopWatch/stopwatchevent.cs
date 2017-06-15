namespace StopWatch
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The stopwatch event.
    /// </summary>
    public class StopwatchEvent
    {
        /// <summary>
        /// The stop watch.
        /// </summary>
        private readonly Stopwatch sw = new Stopwatch();

        /// <summary>
        /// The interval.
        /// </summary>
        private readonly int interval;

        /// <summary>
        /// Initializes a new instance of the <see cref="StopwatchEvent"/> class.
        /// </summary>
        /// <param name="interval">
        /// The interval to pull a new value from the stopwatch in milliseconds.
        /// </param>
        public StopwatchEvent(int interval)
        {
            this.interval = interval;
        }

        /// <summary>
        /// The actions.
        /// </summary>
        public enum Actions
        {
            Start,
            Stop,
            Reset,
            Split
        }

        /// <summary>
        /// The time changed.
        /// </summary>
        public event EventHandler<TimeSpan> TimeChanged;

        /// <summary>
        /// Gets the split.
        /// </summary>
        public TimeSpan Split
        {
            get
            {
                return this.sw.Elapsed;
            }
        }

        /// <summary>
        /// The start.
        /// </summary>
        public void Start()
        {
            if (this.sw.IsRunning)
            {
                return;
            }

            this.sw.Start();
            Task.Run(() => { this.RunningTime(); });
        }

        /// <summary>
        /// The stop.
        /// </summary>
        public void Stop()
        {
            this.sw.Stop();
        }

        /// <summary>
        /// The reset.
        /// </summary>
        public void Reset()
        {
            var isRunning = this.sw.IsRunning;
            this.sw.Reset();
            this.TheTime();
            if (isRunning)
            {
                this.sw.Start();
            }
        }

        /// <summary>
        /// The running time.
        /// </summary>
        private void RunningTime()
        {
            while (this.sw.IsRunning)
            {
                Thread.Sleep(this.interval);
                this.TheTime();
            }
        }

        /// <summary>
        /// The the time.
        /// </summary>
        private void TheTime()
        {
            if (this.TimeChanged != null)
            {
                this.TimeChanged(this, this.sw.Elapsed);
            }
        }
    }
}
