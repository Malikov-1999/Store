using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;

namespace Store.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public List<string>? AvailableSizes { get; set; } = new List<string>();
        public string? SKU { get; set; }
        public Category? Category { get; set; }
        public string? Description { get; set; }
        public string? Surface { get; set; }
        public string? Group { get; set; }
        public string? Material { get; set; }
        public string? CountryOfOrigin { get; set; }
        public bool IsFavProduct { get; set; }
        public bool Available { get; set; }
        public int CategoryId { get; set; }
        public ProductType ProductType { get; set; }

        public ICollection<ProductSizePrice> SizePrices { get; set; } = new List<ProductSizePrice>();
    }
}
