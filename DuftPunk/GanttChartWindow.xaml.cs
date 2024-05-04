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
    public partial class GanttChartWindow : Window
    {
        public static readonly DependencyProperty TasksProperty =
            DependencyProperty.Register("Tasks", typeof(ObservableCollection<GanttTask>), typeof(GanttChartWindow));

        public ObservableCollection<GanttTask> Tasks
        {
            get { return (ObservableCollection<GanttTask>)GetValue(TasksProperty); }
            set { SetValue(TasksProperty, value); }
        }

        public GanttChartWindow()
        {
            InitializeComponent();
            DataContext = this;
            Tasks = new ObservableCollection<GanttTask>();
        }
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string name = taskNameTextBox.Text;
            DateTime startDate = startDatePicker.SelectedDate ?? DateTime.Today;
            DateTime endDate = endDatePicker.SelectedDate ?? DateTime.Today;
            if (Tasks != null)
            {
                Tasks.Add(new GanttTask { Name = name, StartDate = startDate, EndDate = endDate });
            }
            taskNameTextBox.Text = "Введите название задачи";
            startDatePicker.SelectedDate = DateTime.Today;
            endDatePicker.SelectedDate = DateTime.Today;
        }

        private void TaskCompleted_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.DataContext is GanttTask)
            {
                var task = button.DataContext as GanttTask;
                task.IsCompleted = true;
            }
        }
    }
    
        public class GanttTask
        {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Width => (EndDate - StartDate).TotalDays;
        public double Left => (StartDate - DateTime.Today).TotalDays;
        public double Top { get; set; }
        public bool IsCompleted { get; set; }
    }   
}
