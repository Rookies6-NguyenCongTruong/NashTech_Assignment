namespace AspNetCoreMVC_Assignment3.Models;

public class PersonModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public string? BirthPlace { get; set; }
    public Boolean IsGraduated { get; set; }
    public int Age
    {
        get
        {
            return DateTime.Now.Year - DateOfBirth.Year;
        }
    }
    public string FullName
    {
        get
        {
            return $"{LastName} {FirstName}";
        }
    }
}