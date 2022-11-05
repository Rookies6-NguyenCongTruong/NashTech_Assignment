using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVC_Assignment2.Models;
public class PersonCreateModel
{
    [DisplayName("First Name")]
    [Required(ErrorMessage = "{0} is required!")]
    public string? FirstName { get; set; }

    [DisplayName("Last Name")]
    [Required(ErrorMessage = "{0} is required!")]
    public string? LastName { get; set; }

    [DisplayName("Gender")]
    public string? Gender { get; set; }

    [DisplayName("Date Of Birth")]
    [Required(ErrorMessage = "{0} is required!")]
    public DateTime DateOfBirth { get; set; }

    [DisplayName("Phone Number")]
    [Required(ErrorMessage = "{0} is required!")]
    public string? PhoneNumber { get; set; }

    [DisplayName("Birth Place")]
    [Required(ErrorMessage = "{0} is required!")]
    public string? BirthPlace { get; set; }
}