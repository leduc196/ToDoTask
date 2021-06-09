using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksServer.Models;

namespace TasksServer.DBAccess.Task
{
    public class TaskService : TaskRepository
    {
        private readonly SQLServerContext _context;
        public TaskService(SQLServerContext context)
        {
            _context = context;
        }
        public void AddTask(Tasks task)
        {
            Tasks oldTask = _context.Tasks.AsNoTracking().FirstOrDefault(t => t.taskid == task.taskid);
            if(oldTask == null)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
            }
        }

        public void UpdateTask(Tasks task)
        {
            Tasks oldTask = _context.Tasks.AsNoTracking().FirstOrDefault(t => t.taskid == task.taskid);
            if(oldTask != null)
            {
                oldTask = task;
                _context.Tasks.Update(oldTask);
                _context.SaveChanges();
            }
        }

        public void DeleteTaskd(int id)
        {
            var entity = _context.Tasks.FirstOrDefault(t => t.taskid == id);
            _context.Tasks.Remove(entity);
            _context.SaveChanges();
        }

        public List<Tasks> GetTasks()
        {
            return _context.Tasks.AsNoTracking().ToList();
        }

        public Tasks GetTaskDetail(int id)
        {
            return _context.Tasks.AsNoTracking().FirstOrDefault(t => t.taskid == id);
        }
    }
}
