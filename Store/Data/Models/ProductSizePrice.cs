namespace Store.Data.Models
{
    public class ProductSizePrice
    {
        public int Id { get; set; }

        public string? Size { get; set; } // Размер

        public decimal Price { get; set; } // Цена

        public decimal? DiscountPrice { get; set; } // Цена со скидкой, если есть

        public int ProductId { get; set; }

        public required Product Product { get; set; }
    }
}
