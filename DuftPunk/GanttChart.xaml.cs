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

namespace DuftPunk
{
    /// <summary>
    /// Логика взаимодействия для GanttChartWindow.xaml
    /// </summary>
    public partial class GanttChart: Window
    {
        public ObservableCollection<GanttTask> Tasks { get; set; }

        public GanttChart(int itemCount)
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
        public class ViewModel
        {
            public ObservableCollection<string> TimePeriods { get; set; }
            public string SelectedTimePeriod { get; set; }
            public ObservableCollection<Task> Tasks { get; set; }

            public ViewModel()
            {
                TimePeriods = new ObservableCollection<string> { "1 month", "2 months", "3 months" };
                SelectedTimePeriod = "1 month";
                Tasks = new ObservableCollection<Task>();
            }
        }

        public class Task
        {
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        public class GanttChart : Control
        {
            static GanttChart()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(GanttChart), new FrameworkPropertyMetadata(typeof(GanttChart)));
            }

            public ObservableCollection<Task> Tasks
            {
                get { return (ObservableCollection<Task>)GetValue(TasksProperty); }
                set { SetValue(TasksProperty, value); }
            }

            public static readonly DependencyProperty TasksProperty =
                DependencyProperty.Register("Tasks", typeof(ObservableCollection<Task>), typeof(GanttChart), new PropertyMetadata(null, OnTasksChanged));

            private static void OnTasksChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var ganttChart = (GanttChart)d;
                ganttChart.InvalidateVisual();
            }
        }
    }
}
