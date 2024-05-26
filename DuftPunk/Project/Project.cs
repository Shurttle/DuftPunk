using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuftPunk.Project
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } 
    }

    // Модель данных для проекта Gantt Chart
    public class GanttChartProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Модель данных для проекта Kanban Board
    public class KanbanBoardProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Модель данных для проекта Scrum
    public class ScrumProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }   

    //public class ProjectContext : DbContext
    //{
    //    public ProjectContext() : base("name=ProjectDBConnectionString")
    //    {
    //    }
    //    public DbSet<GanttChartProject> GanttChartProjects { get; set; }
    //    public DbSet<KanbanBoardProject> KanbanBoardProjects { get; set; }
    //    public DbSet<ScrumProject> ScrumProjects { get; set; }
    //}
}
