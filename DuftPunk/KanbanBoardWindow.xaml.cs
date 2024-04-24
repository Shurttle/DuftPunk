using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для KanbanBoardWindow.xaml
    /// </summary>
    public partial class KanbanBoardWindow : Window
    {
        public ObservableCollection<string> ToDoTasks { get; set; }
        public ObservableCollection<string> InProgressTasks { get; set; }
        public ObservableCollection<string> DoneTasks { get; set; }

        public KanbanBoardWindow()
        {
            InitializeComponent();

            DataContext = new KanbanBoardViewModel();
        }

        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && e.OriginalSource is FrameworkElement source)
            {
                if (element.DataContext is KanbanBoardViewModel viewModel && source.DataContext is string task)
                {
                    DragDrop.DoDragDrop(element, task, DragDropEffects.Move);
                    viewModel.RemoveTask(task);
                }
            }
        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            if (sender is ListBox destinationListBox)
            {
                if (e.Data.GetData(typeof(string)) is string task)
                {

                    if (ToDoTasks.Contains(task))
                    {
                        ToDoTasks.Remove(task);
                        InProgressTasks.Add(task);
                    }
                    else if (InProgressTasks.Contains(task))
                    {
                        InProgressTasks.Remove(task);
                        DoneTasks.Add(task);
                    }
                }
            }
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBox listBox && listBox.SelectedItem is string task)
            {
                var newTaskName = Microsoft.VisualBasic.Interaction.InputBox("Введите новое название задачи", "Редактировать задачу", task);
                if (!string.IsNullOrEmpty(newTaskName))
                {
                    var viewModel = DataContext as KanbanBoardViewModel;
                    viewModel?.EditTask(task, newTaskName);
                }
            }
        }
    }

    public class KanbanBoardViewModel : ViewModelBase
    {
        public ObservableCollection<string> ToDoTasks { get; set; }
        public ObservableCollection<string> InProgressTasks { get; set; }
        public ObservableCollection<string> DoneTasks { get; set; }

        public ICommand AddTaskCommand { get; private set; }

        public KanbanBoardViewModel()
        {
            ToDoTasks = new ObservableCollection<string>();
            InProgressTasks = new ObservableCollection<string>();
            DoneTasks = new ObservableCollection<string>();

            AddTaskCommand = new RelayCommand(AddTask);
        }

        public void AddTask()
        {
            var task = Microsoft.VisualBasic.Interaction.InputBox("Введите название задачи", "Добавить задачу", "Новая задача");
            if (!string.IsNullOrEmpty(task))
            {
                ToDoTasks.Add(task);
            }
        }

        public void RemoveTask(string task)
        {
            ToDoTasks.Remove(task);
            InProgressTasks.Remove(task);
            DoneTasks.Remove(task);
        }

        public void AddTask(string task)
        {
            InProgressTasks.Add(task);
        }

        public void EditTask(string oldTask, string newTask)
        {
            if (ToDoTasks.Contains(oldTask))
            {
                ToDoTasks.Remove(oldTask);
                ToDoTasks.Add(newTask);
            }
            else if (InProgressTasks.Contains(oldTask))
            {
                InProgressTasks.Remove(oldTask);
                InProgressTasks.Add(newTask);
            }
            else if (DoneTasks.Contains(oldTask))
            {
                DoneTasks.Remove(oldTask);
                DoneTasks.Add(newTask);
            }
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public interface INotifyPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;
    }
}