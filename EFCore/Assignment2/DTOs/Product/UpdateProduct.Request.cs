namespace Assignment2.DTOs.Product
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string Manufacture { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}