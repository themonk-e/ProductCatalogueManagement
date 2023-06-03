namespace Models
{
    public class Product_m
    {
        public string ProductId { get; set; } = null!;

        public string? ProductName { get; set; }

        public double ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

        public string ProductBrand { get; set; } = null!;

        public string CategoryId { get; set; } = null!;



    }
}