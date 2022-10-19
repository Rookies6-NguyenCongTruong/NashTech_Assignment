using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models;
public class Student : BaseEntity<int>
{
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public string City { get; set; } = null!;
    [Required]
    public string State { get; set; } = null!;
}