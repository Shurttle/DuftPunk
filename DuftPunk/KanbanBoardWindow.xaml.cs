using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace DuftPunk
{
    /// <summary>
    /// Логика взаимодействия для KanbanBoardWindow.xaml
    /// </summary>
    public partial class KanbanBoardWindow : Window
    {
        private readonly KanbanBoardViewModel viewModel;
        private ProjectManager project;
        public KanbanBoardWindow(ProjectManager project)
        {
            InitializeComponent();
            viewModel = new KanbanBoardViewModel();
            DataContext = viewModel;
            this.project = project;
        }

        public KanbanBoardWindow(ProjectManager.Project kanbanProject)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddTask();
        }

        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBox listBox && e.OriginalSource is FrameworkElement source && source.DataContext is string task)
            {
                DragDrop.DoDragDrop(listBox, task, DragDropEffects.Move);
            }
        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            if (sender is ListBox destinationListBox && e.Data.GetData(typeof(string)) is string task)
            {
                if (destinationListBox == doneListBox)
                    viewModel.MoveToDone(task);
                else if (destinationListBox == InProgressListBox)
                    viewModel.MoveToInProgress(task);
            }
        }
    }

    public class KanbanBoardViewModel: ViewModelBase
    {
        public ObservableCollection<string> ToDoTasks { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> InProgressTasks { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> DoneTasks { get; } = new ObservableCollection<string>();

        public ICommand AddTaskCommand { get; }

        public KanbanBoardViewModel()
        {
            AddTaskCommand = new RelayCommand(AddTask);
        }

        public void AddTask()
        {
            var task = Microsoft.VisualBasic.Interaction.InputBox("Enter task name", "Add Task", "New Task");
            if (!string.IsNullOrEmpty(task))
            {
                ToDoTasks.Add(task);
            }
        }

        public void MoveToInProgress(string task)
        {
            ToDoTasks.Remove(task);
            InProgressTasks.Add(task);
        }

        public void MoveToDone(string task)
        {
            InProgressTasks.Remove(task);
            DoneTasks.Add(task);
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action execute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => execute();
    }
}