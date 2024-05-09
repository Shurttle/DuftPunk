using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для ProjectSetupWindow.xaml
    /// </summary>
    public partial class ProjectSetupWindow : Window
    {
        public ProjectSetupWindow()
        {
            InitializeComponent();
            UpdateMethodologies();
        }

        private void UpdateMethodologies()
        {          
            AddMethodologyButton("Scrum", () => OpenScrumWindow());
            AddMethodologyButton("GanttChartWindow", () => OpenGanttChartWindow());
            AddMethodologyButton("Kanban", () => OpenKanbanWindow());
        }     

        private void AddMethodologyButton(string content, Action clickAction)
        {
            var button = new Button { Content = content, Style = (Style)FindResource("MethodologyButtonStyle") };
            button.Click += (sender, e) => clickAction();      
        }

        private void OpenScrumWindow()
        {
            var scrumWindow = new ScrumWindow();
            scrumWindow.ShowDialog();
            this.Close();
        }

        private void OpenGanttChartWindow()
        {
            var openGanttChartWindow = new GanttChartWindow();
            openGanttChartWindow.ShowDialog();
            this.Close();
        }

        private void OpenKanbanWindow()
        {
            var kanbanWindow = new KanbanBoardWindow();
            kanbanWindow.ShowDialog();
            this.Close();
        }

        private void ScrumButton_Click(object sender, RoutedEventArgs e)
        {
            OpenScrumWindow();
        }

        private void GanttChartButton_Click(object sender, RoutedEventArgs e)
        {
            OpenGanttChartWindow();
        }

        private void KanbanButton_Click(object sender, RoutedEventArgs e)
        {
            OpenKanbanWindow();
        }
    }
}