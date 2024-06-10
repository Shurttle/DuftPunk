using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace DuftPunk
{
    /// <summary>
    /// Логика взаимодействия для ScrumWindow.xaml
    /// </summary>
    public partial class ScrumWindow : Window
    {
        public ObservableCollection<Task> ToDoList { get; set; }
        public ObservableCollection<Task> ProgressList { get; set; }
        public ObservableCollection<Task> DoneList { get; set; }

        public Task ToDoItem { get;set;}
        public Task ProgressItem { get; set; }
        public Task DoneItem { get; set; }

        public ScrumWindow()
        {
            InitializeComponent();
            DataContext = this;
            InitializeLists();
        }

        private void InitializeLists()
        {
            ToDoList = new ObservableCollection<Task>();
            ProgressList = new ObservableCollection<Task>();
            DoneList = new ObservableCollection<Task>();

            todoList.SetBinding(ListView.ItemsSourceProperty, "ToDoList");
            inProgressList.SetBinding(ListView.ItemsSourceProperty, "ProgressList");
            doneList.SetBinding(ListView.ItemsSourceProperty, "DoneList");
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(taskInput.Text))
            {
                ToDoList.Add(new Task { TaskName = taskInput.Text });
                taskInput.Clear();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите название задачи.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            string tag = ((MenuItem)sender).Tag.ToString();
            if (tag == "todo" && ToDoItem != null)
                ToDoList.Remove(ToDoItem);
            else if (tag == "progress" && ProgressItem != null)
                ProgressList.Remove(ProgressItem);
            else if (tag == "done" && DoneItem != null)
                DoneList.Remove(DoneItem);
            /*   var menuItem = sender as MenuItem;
               var item = menuItem.DataContext as Task;
               var list = GetParentListBox(menuItem);
               if (DoneItem != null && list != null)
               {
                   list.Remove(item);
               }*/
        }

        private void MoveTaskInProgress_Click(object sender, RoutedEventArgs e)
        {
            if (ToDoItem != null)
            {
                var item = ToDoItem;
                ToDoList.Remove(item);
                ProgressList.Add(item);
            }
        }

        private void MoveTaskDone_Click(object sender, RoutedEventArgs e)
        {
            if (ProgressItem != null)
            {
                var item = ProgressItem;
                ProgressList.Remove(item);
                DoneList.Add(item);
            }
        }

        private ObservableCollection<Task> GetParentListBox(MenuItem menuItem)
        {
            var contextMenu = menuItem.Parent as ContextMenu;
            var listBox = contextMenu.PlacementTarget as ListBox;
            return listBox.ItemsSource as ObservableCollection<Task>;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectSetupWindow projectSetupWindow = new ProjectSetupWindow();
            projectSetupWindow.Show();
            this.Close();
        }
    }

    public class Task
    {
        public string TaskName { get; set; }
        public bool IsTaskDone { get; set; }
    }
}



