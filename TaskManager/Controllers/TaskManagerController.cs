using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Dto;
using TaskManager.Model;
using TaskManager.Repository.IRepository;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskManagerController:ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskManagerController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetTask()
        {
            var tasks = await _taskRepository.GetAll();
            return Ok(tasks);
        }
        [HttpGet("Id")]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTaskById(int id)
        {
            var taskId=await _taskRepository.GetById(id);
            return taskId ==null ? NotFound() : Ok(taskId);
        }
        [HttpPost]
        public async Task<ActionResult<Tasks>>CreateTask(TaskItemDto task)
        {
            var dupliCate = _taskRepository.IsRecordExsist(task.TaskName);
            var tas = new Tasks();
            await _taskRepository.Create(tas);
            return CreatedAtAction(nameof(GetTask), new {id=task.TaskName},task);
            
        }
        [HttpPut("Id")]
        public  async Task<ActionResult<Tasks>>UpdateTask(int id,Tasks task)
        {
             await  _taskRepository.Update(task);
            return NoContent();
        }
        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var del = await _taskRepository.GetById(id);
             await _taskRepository.Delete(del);
            return Ok();

        }
    }
}