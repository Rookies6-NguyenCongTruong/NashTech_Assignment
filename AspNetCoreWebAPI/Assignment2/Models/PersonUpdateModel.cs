using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models;

public class PersonUpdateModel
{
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    public string Gender { get; set; } = null!;
    [Required]
    public string BirthPlace { get; set; } = null!;
}