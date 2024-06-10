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
       
        public class KanbanBoardProject
        {
            private static KanbanBoardProject instance;
            private static readonly object lockObject = new object();

            private KanbanBoardProject() { }

            public static KanbanBoardProject Instance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (lockObject)
                        {
                            if (instance == null)
                            {
                                instance = new KanbanBoardProject();
                            }
                        }
                    }
                    return instance;
                }
            }         
        }

        public class ScrumProject
        {
            private static ScrumProject instance;
            private static readonly object lockObject = new object();

            private ScrumProject() { }

            public static ScrumProject Instance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (lockObject)
                        {
                            if (instance == null)
                            {
                                instance = new ScrumProject();
                            }
                        }
                    }
                    return instance;
                }
            }         
        }
    }
}
