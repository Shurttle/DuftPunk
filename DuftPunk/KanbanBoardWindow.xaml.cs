using System;
using System.Collections.Generic;
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

        private List<string> todoTasks = new List<string>();
        private List<string> inProgressTasks = new List<string>();
        private List<string> doneTasks = new List<string>();

        public KanbanBoardWindow()
        {
            InitializeComponent();
        }


        private void ListBox_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox != null)
            {
                ListBoxItem draggedItem = FindVisualParent<ListBoxItem>((DependencyObject)e.OriginalSource);
                if (draggedItem != null)
                {
                    DragDrop.DoDragDrop(listBox, draggedItem, System.Windows.DragDropEffects.Move);
                }
            }
        }

        private T FindVisualParent<T>(DependencyObject obj) where T : DependencyObject
        {
            while (obj != null)
            {
                if (obj is T parent)
                {
                    return parent;
                }
                obj = VisualTreeHelper.GetParent(obj);
            }
            return null;
        }

        private void TodoList_Drop(object sender, System.Windows.DragEventArgs e)
        {
            HandleDrop(sender, e, todoList, todoTasks);
        }

        private void InProgressList_Drop(object sender, System.Windows.DragEventArgs e)
        {
            HandleDrop(sender, e, inProgressList, inProgressTasks);
        }

        private void DoneList_Drop(object sender, System.Windows.DragEventArgs e)
        {
            HandleDrop(sender, e, doneList, doneTasks);
        }

        private void HandleDrop(object sender, System.Windows.DragEventArgs e, ListBox listBox, List<string> taskList)
        {
            if (e.Data.GetDataPresent(typeof(ListBoxItem)))
            {
                ListBoxItem droppedItem = (ListBoxItem)e.Data.GetData(typeof(ListBoxItem));
                if (droppedItem != null)
                {
                    string task = droppedItem.Content.ToString();
                    if (!taskList.Contains(task))
                    {
                        taskList.Add(task);
                        listBox.Items.Add(task);
                    }
                }
            }
        }
    }
}
