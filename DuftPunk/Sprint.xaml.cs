using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using static DuftPunk.Sprint;

namespace DuftPunk
{
    public partial class Sprint : Window
    {
        private bool isPulseRunning = false;
        private ObservableCollection<string> taskList;
        public Sprint()
        {
            InitializeComponent();
            taskList = new ObservableCollection<string>();     
        }
        private async void StartPulse_Click(object sender, RoutedEventArgs e)
        {
            isPulseRunning = true;
            while (isPulseRunning)
            {
                // Выполнение задачи
                AddTask("Task executed at " + DateTime.Now.ToString("HH:mm:ss"));
                Thread.Sleep(2000); ; // Пауза в 2 секунды
            }
        }

        private void PausePulse_Click(object sender, RoutedEventArgs e)
        {
            isPulseRunning = false;
        }

        private void StopPulse_Click(object sender, RoutedEventArgs e)
        {
            isPulseRunning = false;
            taskList.Clear();
        }

        private void AddTask(string task)
        {
            // Добавление задачи в список
            Application.Current.Dispatcher.Invoke(() =>
            {
                taskList.Add(task);
            });
        }
    }
}