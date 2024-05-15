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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DuftPunk
{
    /// <summary>
    /// Логика взаимодействия для GanttChartWindow.xaml
    /// </summary>
    public partial class GanttChartWindow : Window
    {
        ObservableCollection<GanttTask> tasks = new ObservableCollection<GanttTask>();

        public GanttChartWindow()
        {
            InitializeComponent();
            taskListView.ItemsSource = tasks;

            for (int i = 1; i <= 5; i++)
            {
                tasks.Add(new GanttTask { Name = "Task " + i, Duration = 5 });
            }
            taskListView.AddHandler(Slider.ValueChangedEvent, new RoutedEventHandler(DurationSlider_ValueChanged));
            //Loaded += GanttChartWindow_Loaded;
        }
        //private void GanttChartWindow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < 14; i++)
        //    {
        //        Line line = new Line
        //        {
        //            X1 = i * 50,
        //            Y1 = 0,
        //            X2 = i * 50,
        //            Y2 = canvas.ActualHeight,
        //            Stroke = System.Windows.Media.Brushes.Black,
        //            StrokeThickness = 1
        //        };
        //        canvas.Children.Add(line);
        //    }
        //}
        private void DrawGanttChart()
        {
            canvas.Children.Clear();

            double taskHeight = 30;
            double startX = 50;
            double startY = 50;
            double lineHeight = 40;

            foreach (var task in tasks)
            {
                double width = task.Duration * 20;

                System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle
                {
                    Width = width,
                    Height = taskHeight,
                    Fill = System.Windows.Media.Brushes.LightBlue,
                    Stroke = System.Windows.Media.Brushes.Black,
                    StrokeThickness = 1,
                };

                Canvas.SetLeft(rect, startX);
                Canvas.SetTop(rect, startY + (tasks.IndexOf(task) * lineHeight));

                canvas.Children.Add(rect);

                TextBlock textBlock = new TextBlock
                {
                    Text = task.Name,
                    TextWrapping = TextWrapping.Wrap,
                    Width = width,
                    TextAlignment = TextAlignment.Center
                };

                Canvas.SetLeft(textBlock, startX);
                Canvas.SetTop(textBlock, startY + (tasks.IndexOf(task) * lineHeight) + 5);

                canvas.Children.Add(textBlock);
            }
        }

        private void DurationSlider_ValueChanged(object sender, RoutedEventArgs e)
        {

            Slider slider = (Slider)e.OriginalSource;
            GanttTask task = (GanttTask)slider.DataContext;
            task.Duration = (int)slider.Value;

            DrawGanttChart();
        }

        public class GanttTask : INotifyPropertyChanged
        {
            private string name;
            public string Name
            {
                get { return name; }
                set
                {
                    if (name != value)
                    {
                        name = value;
                        NotifyPropertyChanged("Name");
                    }
                }
            }

            private int duration;
            public int Duration
            {
                get { return duration; }
                set
                {
                    if (duration != value)
                    {
                        duration = value;
                        NotifyPropertyChanged("Duration");
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}



