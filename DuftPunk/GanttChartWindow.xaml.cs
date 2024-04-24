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
    public partial class GanttChartWindow : Window
    {
        //    public ObservableCollection<GanttTask> Tasks { get; set; }

        //    public GanttChartWindow(int itemCount)
        //    {
        //        InitializeComponent();
        //        Tasks = new ObservableCollection<GanttTask>();

        //        TaskListBox.ItemsSource = Tasks;

        //        for (int i = 0; i < itemCount; i++)
        //        {
        //            AddTask($"Task {i + 1}");
        //        }
        //    }
        //    private void AddTask(string taskName)
        //    {
        //        Tasks.Add(new GanttTask { TaskName = taskName });
        //    }

        //    private void TaskDoneCheckBox_Click(object sender, RoutedEventArgs e)
        //    {
        //        CheckBox checkBox = sender as CheckBox;
        //        GanttTask task = checkBox.DataContext as GanttTask;
        //        if (task != null)
        //        {
        //            task.IsTaskDone = checkBox.IsChecked ?? false;
        //        }
        //    }
        //}

        //public class GanttTask
        //{
        //    public string TaskName { get; set; }
        //    public bool IsTaskDone { get; set; }
    }
}
