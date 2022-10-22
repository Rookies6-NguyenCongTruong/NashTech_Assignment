namespace Assignment2.Models;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; } = null!;
    public string Manufacture { get; set; } = null!;
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
}