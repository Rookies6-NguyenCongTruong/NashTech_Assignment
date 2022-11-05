namespace Assignment2.DTOs.Category;

public class UpdateCategoryRequest
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
}