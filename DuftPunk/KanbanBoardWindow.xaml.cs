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

            ToDoTasks = new ObservableCollection<string>();
            InProgressTasks = new ObservableCollection<string>();
            DoneTasks = new ObservableCollection<string>();

            DataContext = this;
            AddTaskButton.Click += AddTaskButton_Click;
        }

        private void TodoList_Drop(object sender, DragEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox != null)
            {
                ListBoxItem droppedItem = e.Data.GetData(typeof(ListBoxItem)) as ListBoxItem;
                if (droppedItem != null)
                {
                    string task = droppedItem.Content.ToString();
                    if (InProgressTasks.Contains(task) || DoneTasks.Contains(task))
                    {
                        InProgressTasks.Remove(task);
                        DoneTasks.Remove(task);
                    }
                    ToDoTasks.Add(task);
                }
            }
        }

        private void InProgressList_Drop(object sender, DragEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox != null)
            {
                ListBoxItem droppedItem = e.Data.GetData(typeof(ListBoxItem)) as ListBoxItem;
                if (droppedItem != null)
                {
                    string task = droppedItem.Content.ToString();
                    if (ToDoTasks.Contains(task) || DoneTasks.Contains(task))
                    {
                        ToDoTasks.Remove(task);
                        DoneTasks.Remove(task);
                    }
                    InProgressTasks.Add(task);
                }
            }
        }

        private void DoneList_Drop(object sender, DragEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox != null)
            {
                ListBoxItem droppedItem = e.Data.GetData(typeof(ListBoxItem)) as ListBoxItem;
                if (droppedItem != null)
                {
                    string task = droppedItem.Content.ToString();
                    if (ToDoTasks.Contains(task) || InProgressTasks.Contains(task))
                    {
                        ToDoTasks.Remove(task);
                        InProgressTasks.Remove(task);
                    }
                    DoneTasks.Add(task);
                }
            }
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string task = "New Task";
            ToDoTasks.Add(task);
        }

        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox != null)
            {
                ListBoxItem draggedItem = FindVisualParent<ListBoxItem>((DependencyObject)e.OriginalSource);
                if (draggedItem != null)
                {
                    draggedItem.IsSelected = true;
                    DragDrop.DoDragDrop(listBox, draggedItem, DragDropEffects.Move);
                }
            }
        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox != null)
            {
                ListBoxItem droppedItem = e.Data.GetData(typeof(ListBoxItem)) as ListBoxItem;
                if (droppedItem != null)
                {
                    string task = droppedItem.Content.ToString();
                    ObservableCollection<string> sourceTasks = null;
                    ObservableCollection<string> destinationTasks = null;

                    switch (listBox.Name)
                    {
                        case "todoList":
                            sourceTasks = ToDoTasks;
                            destinationTasks = InProgressTasks;
                            break;
                        case "inProgressList":
                            sourceTasks = InProgressTasks;
                            destinationTasks = DoneTasks;
                            break;
                        case "doneList":                       
                            return;
                    }

                    if (sourceTasks != null && destinationTasks != null && !destinationTasks.Contains(task))
                    {
                        sourceTasks.Remove(task);
                        destinationTasks.Add(task);
                    }
                }
            }
        }

        private T FindVisualParent<T>(DependencyObject obj) where T : DependencyObject
        {
            while (obj != null)
            {
                T parent = obj as T;
                if (parent != null)
                {
                    return parent;
                }
                obj = VisualTreeHelper.GetParent(obj);
            }
            return null;
        }
    }
}
