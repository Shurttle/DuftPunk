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
    /// Логика взаимодействия для GanttChartWindow.xaml
    /// </summary>
    public partial class GanttChartWindow : Window
    {
        //private List<(string Name, DateTime Start, TimeSpan Duration, double Progress)> tasks = new List<(string, DateTime, TimeSpan, double)>();
        //private int itemCount;

        //public GanttChartWindow(int itemCount)
        //{
        //    InitializeComponent();
        //    DrawGanttChart();
        //}
        //private void DrawGanttChart()
        //{
        //    canvas.Children.Clear();

        //    double taskHeight = 30;
        //    double rowMargin = 10;
        //    double rowHeight = taskHeight + rowMargin;

        //    double marginLeft = 100;
        //    double marginTop = 50;
        //    double chartWidth = 400;
        //    double chartHeight = tasks.Count * rowHeight;

        //    for (int i = 0; i < tasks.Count; i++)
        //    {
        //        Line line = new Line();
        //        line.X1 = marginLeft;
        //        line.Y1 = marginTop + i * rowHeight;
        //        line.X2 = marginLeft + chartWidth;
        //        line.Y2 = marginTop + i * rowHeight;
        //        line.Stroke = Brushes.Black;
        //        canvas.Children.Add(line);
        //    }

        //    foreach (var task in tasks)
        //    {
        //        double x = marginLeft + (task.Start - tasks[0].Start).TotalDays / 10 * chartWidth;
        //        double width = task.Duration.TotalDays / 10 * chartWidth;

        //        Rectangle rect = new Rectangle();
        //        rect.Width = width;
        //        rect.Height = taskHeight;
        //        rect.Fill = Brushes.LightBlue;
        //        Canvas.SetLeft(rect, x);
        //        Canvas.SetTop(rect, marginTop + tasks.IndexOf(task) * rowHeight + (rowMargin / 2));
        //        canvas.Children.Add(rect);

        //        TextBlock textBlock = new TextBlock();
        //        textBlock.Text = task.Name;
        //        textBlock.TextAlignment = TextAlignment.Center;
        //        textBlock.Width = width;
        //        Canvas.SetLeft(textBlock, x);
        //        Canvas.SetTop(textBlock, marginTop + tasks.IndexOf(task) * rowHeight);
        //        canvas.Children.Add(textBlock);

        //        Rectangle progressRect = new Rectangle();
        //        progressRect.Width = width * task.Progress / 100;
        //        progressRect.Height = taskHeight / 2;
        //        progressRect.Fill = Brushes.Green;
        //        Canvas.SetLeft(progressRect, x);
        //        Canvas.SetTop(progressRect, marginTop + tasks.IndexOf(task) * rowHeight + taskHeight / 4);
        //        canvas.Children.Add(progressRect);
        //    }
        //}

        //private void AddTask_Click(object sender, RoutedEventArgs e)
        //{
        //    string name = taskNameTextBox.Text;
        //    DateTime start = startDatePicker.SelectedDate ?? DateTime.Today;
        //    TimeSpan duration = TimeSpan.FromDays(double.Parse(durationTextBox.Text));
        //    double progress = double.Parse(progressTextBox.Text);

        //    tasks.Add((name, start, duration, progress));
        //    DrawGanttChart();
        //}
    }
}
