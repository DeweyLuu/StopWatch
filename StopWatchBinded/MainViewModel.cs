using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatchBinded
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// The main view model.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The time.
        /// </summary>
        private TimeSpan time;

        /// <summary>
        /// The running.
        /// </summary>
        private bool running;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            this.Split = new ObservableCollection<TimeSpan>();
        }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        public TimeSpan Time
        {
            get
            {
                return this.time;
            }

            set
            {
                this.time = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether running.
        /// </summary>
        public bool Running
        {
            get
            {
                return this.running;
            }

            set
            {
                this.running = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the split.
        /// </summary>
        public ObservableCollection<TimeSpan> Split { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
