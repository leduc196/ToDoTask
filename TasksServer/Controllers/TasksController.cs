using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksServer.DBAccess.Task;
using TasksServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TasksServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskRepository _taskRepository;

        public TasksController(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        // GET: api/<TasksController>
        [HttpGet]
        public IEnumerable<Tasks> Get()
        {
            return _taskRepository.GetTasks();
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public Tasks Get(int id)
        {
            return _taskRepository.GetTaskDetail(id);
        }

        // POST api/<TasksController>
        [HttpPost]
        public IActionResult Post([FromBody] Tasks task)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                _taskRepository.AddTask(task);
                return Ok(task);
            }
            return BadRequest();
        }

        // PUT api/<TasksController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Tasks task)
        {
            _taskRepository.UpdateTask(task);
            return Ok(task);

        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _taskRepository.GetTaskDetail(id);
            if (data == null)
            {
                return NotFound();
            }
            _taskRepository.DeleteTaskd(id);
            return Ok("Đã xóa");
        }
    }
}
