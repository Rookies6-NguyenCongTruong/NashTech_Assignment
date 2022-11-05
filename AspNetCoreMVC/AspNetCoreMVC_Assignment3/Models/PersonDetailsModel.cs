using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVC_Assignment3.Models;
public class PersonDetailsModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public string? BirthPlace { get; set; }
}