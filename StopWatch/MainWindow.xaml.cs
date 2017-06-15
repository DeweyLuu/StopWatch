using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace StopWatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.watchOne.TimeChanged += WatchOne_returnTime;
        }

        private void WatchOne_returnTime(object sender, TimeSpan e)
        {
            var elapsedTime = editTime(e);
            this.Dispatcher.Invoke(() => this.textBlock.Text = elapsedTime);
        }

        StopwatchEvent watchOne = new StopwatchEvent(10);

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.watchOne.Start();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            watchOne.Stop();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            watchOne.Reset();
        }

        private void button3_Click_1(object sender, RoutedEventArgs e)
        {
            var result = this.watchOne.Split;
            this.textBlock1.Text = editTime(result);
        }

        public string editTime(TimeSpan ts)
        {
            return String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        }
    }
}
