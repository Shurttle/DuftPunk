using System;
using System.Collections.Generic;
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
        public ScrumWindow()
        {
            InitializeComponent();
        }

        public class TaskItem
        {
            public string Title { get; set; }
            public string Status { get; set; }
        }



        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string taskTitle = taskInput.Text;
            if (string.IsNullOrWhiteSpace(taskTitle))
            {
                MessageBox.Show("Пожалуйста, введите название задачи.");
            }
            else
            {
                ListBoxItem taskItem = new ListBoxItem();
                taskItem.Content = taskTitle;
                todoList.Items.Add(taskItem);
                taskInput.Text = "";
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            ContextMenu menu = (ContextMenu)menuItem.Parent;
            ListBox listBox = (ListBox)menu.PlacementTarget;
            if (listBox.SelectedItem is ListBoxItem selectedItem)
            {
                listBox.Items.Remove(selectedItem);
            }
        }

        private void MoveTaskInProgress_Click(object sender, RoutedEventArgs e)
        {
            MoveTask(todoList, inProgressList);
        }

        private void MoveTaskDone_Click(object sender, RoutedEventArgs e)
        {
            MoveTask(inProgressList, doneList);
        }

        private void MoveTask(ListBox fromList, ListBox toList)
        {
            if (fromList.SelectedItem is ListBoxItem selectedItem)
            {
                fromList.Items.Remove(selectedItem);
                toList.Items.Add(selectedItem);
            }
        }

        private void TaskInput_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Введите название задачи...")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void TaskInput_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Введите название задачи...";
                textBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        public class StringEmptyToVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var text = value as string;
                return string.IsNullOrEmpty(text) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
