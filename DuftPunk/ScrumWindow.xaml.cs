using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    /// Логика взаимодействия для ScrumWindow.xaml
    /// </summary>
    public partial class ScrumWindow : Window
    {
        public ObservableCollection<Task> ToDoList { get; set; }
        public ObservableCollection<Task> InProgressList { get; set; }
        public ObservableCollection<Task> DoneList { get; set; }

        private ProjectManager project;
        public ScrumWindow(ProjectManager project)
        {
            InitializeComponent();
            InitializeLists();
            this.project = project;
        }

           private void InitializeLists()
        {
            ToDoList = new ObservableCollection<Task>();
            InProgressList = new ObservableCollection<Task>();
            DoneList = new ObservableCollection<Task>();

            todoList.ItemsSource = ToDoList;
            inProgressList.ItemsSource = InProgressList;
            doneList.ItemsSource = DoneList;
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(taskInput.Text))
            {
                ToDoList.Add(new Task { TaskName = taskInput.Text });
                taskInput.Clear();
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as MenuItem).DataContext as Task;
            var list = (sender as MenuItem).Tag as ObservableCollection<Task>;
            if (item != null && list != null)
                list.Remove(item);
        }

        private void MoveTaskInProgress_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as MenuItem).DataContext as Task;
            if (item != null)
            {
                ToDoList.Remove(item);
                InProgressList.Add(item);

            }
        }

        private void MoveTaskDone_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as MenuItem).DataContext as Task;
            if (item != null)
            {
                InProgressList.Remove(item);
                DoneList.Add(item);
            }
        }
    }
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public TaskModel(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
    }

    public class Task
    {
        public string TaskName { get; set; }
        public bool IsTaskDone { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }

    }
}
    

