using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksServer.Models;

namespace TasksServer.DBAccess.Task
{
    public interface TaskRepository
    {
        void AddTask(Tasks task);
        void UpdateTask(Tasks task);
        void DeleteTaskd(int id);
        Tasks GetTaskDetail(int id);
        List<Tasks> GetTasks();
    }
}
