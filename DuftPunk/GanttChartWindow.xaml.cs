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
        ObservableCollection<Task> tasks = new ObservableCollection<Task>();
        private ProjectManager project;
        public GanttChartWindow(ProjectManager project)
        {
            InitializeComponent();
            LoadGanttChart();
            this.project = project;
        }
        private void LoadGanttChart()
        {
            var tasks = new List<Task>
            {
                new Task { Name = "Организационное собрание", StartDate = new DateTime(2023, 6, 17), EndDate = new DateTime(2023, 6, 24) },
                new Task { Name = "Разработка документации", StartDate = new DateTime(2023, 6, 24), EndDate = new DateTime(2023, 7, 1) },
                new Task { Name = "Общая схема", StartDate = new DateTime(2023, 7, 1), EndDate = new DateTime(2023, 12, 1) },
                new Task { Name = "Разработка модуля 1", StartDate = new DateTime(2023, 12, 1), EndDate = new DateTime(2024, 1, 5) },
                new Task { Name = "Разработка модуля 2", StartDate = new DateTime(2024, 1, 5), EndDate = new DateTime(2024, 2, 2) },
                new Task { Name = "Разработка модуля 3", StartDate = new DateTime(2024, 2, 2), EndDate = new DateTime(2024, 3, 9) },
                new Task { Name = "Ввод данных", StartDate = new DateTime(2024, 3, 9), EndDate = new DateTime(2024, 3, 16) },
                new Task { Name = "Анализ данных", StartDate = new DateTime(2024, 3, 16), EndDate = new DateTime(2024, 3, 23) },
                new Task { Name = "Отчет по разработке", StartDate = new DateTime(2024, 3, 23), EndDate = new DateTime(2024, 3, 30) },
                new Task { Name = "Внедрение", StartDate = new DateTime(2024, 3, 30), EndDate = new DateTime(2024, 4, 6) },
                new Task { Name = "Итоговый отчет", StartDate = new DateTime(2024, 4, 6), EndDate = new DateTime(2024, 4, 13) },
                new Task { Name = "Итоговое собрание", StartDate = new DateTime(2024, 4, 13), EndDate = new DateTime(2024, 4, 20) }
            };

            var series = new SeriesCollection();

            foreach (var task in tasks)
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
                series.Add(taskSeries);
            }

            GanttChart.Series = series;

            GanttChart.AxisX[0].LabelFormatter = value => new DateTime((long)value).ToString("dd MMM");
            GanttChart.AxisY[0].Labels = tasks.Select(t => t.Name).ToArray();
        }
    }
}