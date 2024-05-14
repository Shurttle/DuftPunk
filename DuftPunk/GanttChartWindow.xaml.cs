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
using System.Drawing;

namespace DuftPunk
{
    /// <summary>
    /// Логика взаимодействия для GanttChartWindow.xaml
    /// </summary>
    public partial class GanttChartWindow : Window
    {
     
        public GanttChartWindow()
        {
            InitializeComponent();
            //DrawGanttChart();
        }
        //private void DrawGanttChart()
        //{
        //    GanttTask[] tasks = new GanttTask[]
        //    {
        //        new GanttTask { Name = "Task 1", StartDate = new DateTime(2024, 5, 1), Duration = 5 },
        //        new GanttTask { Name = "Task 2", StartDate = new DateTime(2024, 5, 3), Duration = 3 },
        //        new GanttTask { Name = "Task 3", StartDate = new DateTime(2024, 5, 6), Duration = 4 }
        //    };

        //    double taskHeight = 30;
        //    double startX = 50;
        //    double startY = 50;
        //    double lineHeight = 40;

        //    foreach (var task in tasks)
        //    {
        //        double width = task.Duration * 50;

        //        Rectangle rect = new Rectangle
        //        {
        //            Width = width,
        //            Height = taskHeight,
        //            Fill = Brushes.LightBlue,
        //            Stroke = Brushes.Black,
        //            StrokeThickness = 1,
        //        };

        //        Canvas.SetLeft(rect, startX + (task.StartDate - tasks[0].StartDate).TotalDays * 50);
        //        Canvas.SetTop(rect, startY + (Array.IndexOf(tasks, task) * lineHeight));

        //        canvas.Children.Add(rect);

        //        TextBlock textBlock = new TextBlock
        //        {
        //            Text = task.Name,
        //            TextWrapping = TextWrapping.Wrap,
        //            Width = width,
        //            TextAlignment = TextAlignment.Center
        //        };

        //        Canvas.SetLeft(textBlock, startX + (task.StartDate - tasks[0].StartDate).TotalDays * 50);
        //        Canvas.SetTop(textBlock, startY + (Array.IndexOf(tasks, task) * lineHeight) + 5);

        //        canvas.Children.Add(textBlock);
        //    }
        //}


        //public class GanttTask
        //{
        //    public string Name { get; set; }
        //    public DateTime StartDate { get; set; }
        //    public int Duration { get; set; }
        //}
    }
}
    

  