namespace Assignment2
{
    public class Member
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }
        public Boolean IsGraduated { get; set; }
        public string Info
        {
            get
            {
                string isGraduated = (IsGraduated) ? "Graduated" : "Not Graduated";

                return "FirstName: " + FirstName + ", LastName: " + LastName
                + ", Gender: " + Gender + ", DateOfBirth: " + DateOfBirth
                + ", PhoneNumber: " + PhoneNumber + ", BirthPlace: " + BirthPlace
                + ", Age: " + Age + ", IsGraduated: " + isGraduated;
            }
        }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}