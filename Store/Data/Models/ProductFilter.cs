namespace Store.Data.Models
{
    public class ProductFilter
    {
        public int? CategoryId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string CountryOfOrigin { get; set; }
        public ProductType? ProductType { get; set; }
        public string Surface { get; set; }
        public string Material { get; set; }
    }
}


