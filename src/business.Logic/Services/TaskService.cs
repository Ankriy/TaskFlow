using business.Logic.DataContracts.Repositories.Task;
using business.Logic.Domain.Models.Tasks;
using Task = business.Logic.Domain.Models.Tasks.Task;

namespace business.Logic.Services
{
    public class TaskService
    {
        private ITasksRepository _taskRepository;

        public TaskService(ITasksRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public int GetAllCount(int userid)
        {
            return _taskRepository.Count(userid);
        }
        
        public int AddTask(Task task)
        {
            _taskRepository.Create(task);
            return task.Id;
        }
        public Task GetTask(int id)
        {
            var task = _taskRepository.Get(id);
            return task;
        }
        public TaskList GetTaskList(int userId)
        {
            var result = new TaskList();

            result.Tasks = _taskRepository
                .GetByUserId(userId)
                .Select(x => new Task()
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Name = x.Name,
                    Description = x.Description,
                    Color = x.Color
                }).ToList();
            return result;
        }
        public object EditTask(Task task)
        {
            _taskRepository.Update(task);
            return task.Id;
        }
        public void DeleteTask(int idTask)
        {
            _taskRepository.Delete(idTask);
        }
        
    }
}