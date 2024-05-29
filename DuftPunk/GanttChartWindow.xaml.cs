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
using System.Windows.Shapes;
using System.Drawing;
using System.Collections.ObjectModel;
using System.ComponentModel;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace DuftPunk
{
    /// <summary>
    /// Логика взаимодействия для GanttChartWindow.xaml
    /// </summary>
    public partial class GanttChartWindow : Window
    {
        ObservableCollection<Taskg> tasks = new ObservableCollection<Taskg>();
        //private ProjectManager project;
        public GanttChartWindow(/*ProjectManager project*/)
        {
            InitializeComponent();
            LoadGanttChart();
            //this.project = project;
            //var tasks = new List<Taskg>
            //{
            //   new Taskg { Name = "", StartDate = new DateTime(), EndDate = new DateTime() },
            //};
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectSetupWindow projectSetupWindow = new ProjectSetupWindow();
            projectSetupWindow.Show();
            Close();
        }

        private void LoadGanttChart()
        {
            UpdateGanttChart();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParse(StartDateTextBox.Text, out DateTime startDate) &&
                DateTime.TryParse(EndDateTextBox.Text, out DateTime endDate) &&
                !string.IsNullOrWhiteSpace(TaskNameTextBox.Text))
            {
                var newTask = new Taskg
                {
                    Name = TaskNameTextBox.Text,
                    StartDate = startDate,
                    EndDate = endDate
                };
                tasks.Add(newTask);
                AddTaskToChart(newTask);
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные данные задачи.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateGanttChart()
        {
            var series = new SeriesCollection();

            foreach (var task in tasks)
            {
                AddTaskToChart(task);
            }

            GanttChart.Series = series;
            GanttChart.AxisY[0].Labels = tasks.Select(t => t.Name).ToArray();
        }

        private void AddTaskToChart(Taskg task)
        {
            var taskSeries = new RowSeries
            {
                Title = task.Name,
                Values = new ChartValues<DateTimePoint>
            {
                new DateTimePoint(task.StartDate, tasks.IndexOf(task)),
                new DateTimePoint(task.EndDate, tasks.IndexOf(task))
            }
            };
            GanttChart.Series.Add(taskSeries);
        }

        public class Taskg
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
    }
}