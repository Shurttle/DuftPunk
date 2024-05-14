using DuftPunk.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuftPunk.DBduftpunk
{
    internal class TasksRepository
    {
        public TasksRepository()
        {

        }
        static TasksRepository instance;

        public static TasksRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new TasksRepository();
                return instance;
            }
        }
        public class GanttChartRepository
        {
            private static GanttChartRepository instance;
            private static readonly object lockObject = new object();

            private GanttChartRepository() { }

            public static GanttChartRepository Instance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (lockObject)
                        {
                            if (instance == null)
                            {
                                instance = new GanttChartRepository();
                            }
                        }
                    }
                    return instance;
                }
            }
            //public void SaveProject(GanttChartProject project)
            //{
            //    string connectionString = "server=192.168.200.13;user=student;password=student;database=duftpunk;Character Set=utf8mb4";

            //    using (SQLDB connection = new SQLDB(connectionString))
            //    {
            //        connection.Open();

            //        string sql = "INSERT INTO GanttChartProjects (Name) VALUES (@Name)";

            //        using (SQLDBCommand command = new SQLDBCommand(sql, connection))
            //        {
            //            command.Parameters.AddWithValue("@Name", project.Name);

            //            command.ExecuteNonQuery();
            //        }
            //    }
            //}
        }

        public class KanbanBoardRepository
        {
            private static KanbanBoardRepository instance;
            private static readonly object lockObject = new object();

            private KanbanBoardRepository() { }

            public static KanbanBoardRepository Instance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (lockObject)
                        {
                            if (instance == null)
                            {
                                instance = new KanbanBoardRepository();
                            }
                        }
                    }
                    return instance;
                }
            }
            //public void SaveProject(KanbanBoardProject project)
            //{
            //    string connectionString = "server=192.168.200.13;user=student;password=student;database=duftpunk;Character Set=utf8mb4";

            //    using (SQLDB connection = new SQLDB(connectionString))
            //    {
            //        connection.Open();

            //        string sql = "INSERT INTO KanbanBoardProjects (Name) VALUES (@Name)";

            //        using (SQLDBCommand command = new SQLDBCommand(sql, connection))
            //        {
            //            command.Parameters.AddWithValue("@Name", project.Name);

            //            command.ExecuteNonQuery();
            //        }
            //    }
            //}
        }

        public class ScrumRepository
        {
            private static ScrumRepository instance;
            private static readonly object lockObject = new object();

            private ScrumRepository() { }

            public static ScrumRepository Instance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (lockObject)
                        {
                            if (instance == null)
                            {
                                instance = new ScrumRepository();
                            }
                        }
                    }
                    return instance;
                }
            }
            //public void SaveProject(ScrumProject project)
            //{
            //    string connectionString = "server=192.168.200.13;user=student;password=student;database=duftpunk;Character Set=utf8mb4";

            //    using (SQLDB connection = new SQLDB(connectionString))
            //    {
            //        connection.Open();

            //        string sql = "INSERT INTO ScrumProjects (Name) VALUES (@Name)";

            //        using (SQLDBCommand command = new SQLDBCommand(sql, connection))
            //        {
            //            command.Parameters.AddWithValue("@Name", project.Name);

            //            command.ExecuteNonQuery();
            //        }
            //    }
            //}
        }
    }
}
