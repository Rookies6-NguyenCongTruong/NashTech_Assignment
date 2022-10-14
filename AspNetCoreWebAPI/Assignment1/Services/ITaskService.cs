using Assignment1.Models;
namespace Assignment1.Services;

public interface ITaskService
{
    public List<TaskModel> GetAll();
    public TaskModel? GetOne(Guid id);
    public TaskModel Add(TaskModel task);
    public TaskModel? Edit(TaskModel task);
    public void Delete(Guid id);
    public List<TaskModel> Add(List<TaskModel> tasks);
    public void Delete(List<Guid> ids);
    public bool Exist(Guid id);
}
