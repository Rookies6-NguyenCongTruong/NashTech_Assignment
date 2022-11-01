using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models;

public class TaskModel
{
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public bool IsCompleted { get; set; }
}