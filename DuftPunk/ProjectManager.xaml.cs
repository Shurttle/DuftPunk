using DuftPunk.Project;
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
    /// Логика взаимодействия для ProjectManager.xaml
    /// </summary>
    public partial class ProjectManager : Window
    {
        //private ObservableCollection<Project> projects = new ObservableCollection<Project>();
        public ProjectManager()
        {
            InitializeComponent();
            LoadProjects();
        }
        private void LoadProjects()
        {
            //убейте пж
            //projects.Add(new GanttChartProject { Id = 1, Name = "Проект Gantt Chart" });
            //projects.Add(new KanbanBoardProject { Id = 2, Name = "Проект Kanban Board" });
            //projects.Add(new ScrumProject { Id = 3, Name = "Проект Scrum" });
            //projectListBox.ItemsSource = projects;
        }
        private void projectListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Project selectedProject = (Project)projectListBox.SelectedItem;

            //if (selectedProject != null)
            //{
            //    switch (selectedProject)
            //    {
            //        case GanttChartProject _:
            //            GanttChartWindow ganttChartWindow = new GanttChartWindow(selectedProject);
            //            ganttChartWindow.Show();
            //            break;
            //        case KanbanBoardProject _:
            //            KanbanBoardWindow kanbanBoardWindow = new KanbanBoardWindow(selectedProject);
            //            kanbanBoardWindow.Show();
            //            break;
            //        case ScrumProject _:
            //            ScrumWindow scrumWindow = new ScrumWindow(selectedProject);
            //            scrumWindow.Show();
            //            break;
            //    }
            //}
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            ProjectSetupWindow projectSetupWindow = new ProjectSetupWindow();
            projectSetupWindow.ShowDialog();
            this.Close();
        }
    }
}