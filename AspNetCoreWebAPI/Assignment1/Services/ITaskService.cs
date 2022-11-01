using Assignment1.Models;
namespace Assignment1.Services;

public interface ITaskService
{
    List<TaskModel> GetAll();
    TaskModel? GetOne(Guid id);
    TaskModel Add(TaskModel task);
    TaskModel? Edit(TaskModel task);
    void Delete(Guid id);
    Task Add(List<TaskModel> tasks);
    Task Delete(List<Guid> ids);
    bool Exist(Guid id);
}