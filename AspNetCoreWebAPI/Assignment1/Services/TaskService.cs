using Assignment1.Models;

namespace Assignment1.Services;

public class TaskService : ITaskService
{
    private static List<TaskModel> _taskList = new List<TaskModel>(){
        new TaskModel{
            Title = "Task 01",
            IsCompleted = true
        },
        new TaskModel{
            Title = "Task 02",
            IsCompleted = false
        },
        new TaskModel{
            Title = "Task 03",
            IsCompleted = true
        }
    };

    public TaskModel Add(TaskModel task)
    {
        _taskList.Add(task);
        return task;
    }

    public List<TaskModel> Add(List<TaskModel> tasks)
    {
        _taskList.AddRange(tasks);
        return tasks;
    }

    public void Delete(Guid id)
    {
        var result = _taskList.FirstOrDefault(d => d.Id == id);
        if (result != null)
        {
            _taskList.Remove(result);
        }
    }

    public void Delete(List<Guid> ids)
    {
        _taskList.RemoveAll(t => ids.Contains(t.Id));
    }

    public TaskModel? Edit(TaskModel task)
    {
        var result = _taskList.FirstOrDefault(t => t.Id == task.Id);
        if (result != null)
        {
            result.Title = task.Title;
            result.IsCompleted = task.IsCompleted;

            return result;
        }
        return null;
    }

    public bool Exist(Guid id)
    {
        return _taskList.Any(t => t.Id == id);
    }

    public List<TaskModel> GetAll()
    {
        return _taskList;
    }

    public TaskModel? GetOne(Guid id)
    {
        return _taskList.FirstOrDefault(t => t.Id == id);
    }
}
