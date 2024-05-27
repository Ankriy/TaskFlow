using business.Logic.DataContracts.Repositories.Task;
using business.Logic.Domain.Models.Tasks;
using Task = business.Logic.Domain.Models.Tasks.Task;

namespace business.Logic.Services
{
    public class TaskService
    {
        private ITaskRepository _taskRepository;
        private ISubTaskRepository _subtaskRepository;

        public TaskService(ITaskRepository taskRepository, ISubTaskRepository subtaskRepository)
        {
            _taskRepository = taskRepository;
            _subtaskRepository = subtaskRepository;
        }
        public int GetAllTaskCount(int userid)
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
        public List<Task> GetTaskList(int userId)
        {
            var result = new List<Task>();

            result = _taskRepository
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



        public int GetAllSubTaskCount(int userid)
        {
            return _subtaskRepository.Count(userid);
        }

        public int AddSubTask(SubTask subtask)
        {
            _subtaskRepository.Create(subtask);
            return subtask.Id;
        }
        public SubTask GetSubTask(int id)
        {
            var subtask = _subtaskRepository.Get(id);
            return subtask;
        }
        public List<SubTask> GetSubTaskList(int taskId)
        {
            var result = new List<SubTask>();

            result = _subtaskRepository
                .GetByTaskId(taskId)
                .Select(x => new SubTask()
                {
                    Id = x.Id,
                    TaskId = x.TaskId,
                    Name = x.Name,
                    IsDone = x.IsDone,
                    Date = x.Date,
                    Priority = x.Priority
                }).ToList();
            return result;
        }
        public object EditSubTask(SubTask subtask)
        {
            _subtaskRepository.Update(subtask);
            return subtask.Id;
        }
        public void DeleteSubTask(int idsubTask)
        {
            _subtaskRepository.Delete(idsubTask);
        }

    }
}