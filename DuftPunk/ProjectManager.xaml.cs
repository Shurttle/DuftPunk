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
        //public class Project
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public string Type { get; set; }
        //}
        public ProjectManager()
        {
            InitializeComponent();
            //LoadProjects();
        }

        //private void OpenScrumWindow(object sender, RoutedEventArgs e)
        //{
        //    var scrumProject = new Project { Name = "Scrum Project", Type = "Scrum" };
        //    SaveProjectToDatabase(scrumProject);
        //    var window = new ScrumWindow(scrumProject);
        //    window.Show();
        //    this.Close();
        //}

        //private void OpenGanttChartWindow(object sender, RoutedEventArgs e)
        //{
        //    var ganttProject = new Project { Name = "Gantt Chart Project", Type = "Gantt" };
        //    SaveProjectToDatabase(ganttProject);
        //    var window = new GanttChartWindow(ganttProject);
        //    window.Show();
        //    this.Close();
        //}

        //private void OpenKanbanBoardWindow(object sender, RoutedEventArgs e)
        //{
        //    var kanbanProject = new Project { Name = "Kanban Board Project", Type = "Kanban" };
        //    SaveProjectToDatabase(kanbanProject);
        //    var window = new KanbanBoardWindow(kanbanProject);
        //    window.Show();
        //    this.Close();
        //}

        //private void AddTask_Click(object sender, RoutedEventArgs e)
        //{
        //    ProjectSetupWindow projectSetupWindow = new ProjectSetupWindow();
        //    projectSetupWindow.ShowDialog();
        //}

        //private void SaveProjectToDatabase(Project project)
        //{
        //    var connectionString = "your_connection_string"; // Укажите вашу строку подключения к БД
        //    using (var connection = new MySqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = "INSERT INTO Projects (Name, Type) VALUES (@Name, @Type)";
        //        using (var command = new MySqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@Name", project.Name);
        //            command.Parameters.AddWithValue("@Type", project.Type);
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

    }
}