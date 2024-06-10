using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;


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

        public ScrumWindow()
        {
            InitializeComponent();
            InitializeLists();

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
            else
            {
                MessageBox.Show("Пожалуйста, введите название задачи.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            var item = menuItem.DataContext as Task;
            var list = GetParentListBox(menuItem);
            if (item != null && list != null)
            {
                list.Remove(item);
            }
        }

        private void MoveTaskInProgress_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            var item = menuItem.DataContext as Task;
            if (item != null)
            {
                ToDoList.Remove(item);
                InProgressList.Add(item);
            }
        }

        private void MoveTaskDone_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            var item = menuItem.DataContext as Task;
            if (item != null)
            {
                InProgressList.Remove(item);
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



