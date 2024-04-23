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
            todoList.Drop += ListBox_Drop;
            inProgressList.Drop += ListBox_Drop;
            doneList.Drop += ListBox_Drop;

            AddTaskButton.Click += AddTaskButton_Click;
            todoList.MouseDoubleClick += ListBox_MouseDoubleClick;
            inProgressList.MouseDoubleClick += ListBox_MouseDoubleClick;
            doneList.MouseDoubleClick += ListBox_MouseDoubleClick;
            todoList.PreviewMouseLeftButtonDown += ListBox_PreviewMouseLeftButtonDown;
            inProgressList.PreviewMouseLeftButtonDown += ListBox_PreviewMouseLeftButtonDown;
            doneList.PreviewMouseLeftButtonDown += ListBox_PreviewMouseLeftButtonDown;

        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string task = "Новая задача";
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

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox != null)
            {
                string task = (string)listBox.SelectedItem;
                if (task != null)
                {
                    int index = listBox.Items.IndexOf(task);
                    if (index != -1)
                    {
                        string newTaskName = Microsoft.VisualBasic.Interaction.InputBox("Введите новое название задачи", "Редактировать задачу", task);
                        if (!string.IsNullOrEmpty(newTaskName))
                        {
                            listBox.Items.RemoveAt(index);
                            listBox.Items.Insert(index, newTaskName);
                        }
                    }
                }
            }
        }
    }
}