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
       //плак плак :((((((
    }
}