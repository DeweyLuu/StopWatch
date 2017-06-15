using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StopWatchBinded
{
    using StopWatch;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly StopwatchEvent sp = new StopwatchEvent(10);

        private readonly MainViewModel Vm = new MainViewModel();
        public MainWindow()
        {
            this.DataContext = this.Vm;
            this.InitializeComponent();
            this.sp.TimeChanged += (s, e) => this.Vm.Time = e;
        }

        private void Button_Click(object s, RoutedEventArgs e)
        {
            var button = s as UIElement;
            if (button == null)
            {
                return;
            }

            var pressed = (StopwatchEvent.Actions)Enum.Parse(typeof(StopwatchEvent.Actions), button.Uid);


            switch (pressed)
            {
                case StopwatchEvent.Actions.Start:
                    this.sp.Start();
                    this.Vm.Running = true;
                    break;

                case StopwatchEvent.Actions.Stop:
                    this.sp.Stop();
                    this.Vm.Running = false;
                    break;

                case StopwatchEvent.Actions.Reset:
                    this.sp.Reset();
                    break;

                case StopwatchEvent.Actions.Split:
                    this.Vm.Split.Add(this.sp.Split);
                    break;

                default:
                    this.Vm.Split.Clear();
                    break;
            }
        }
    }
}
