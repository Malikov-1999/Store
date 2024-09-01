namespace Store.Data.Models
{
    public class Variation
    {
        public int Id { get; set; }
        public int ProductId { get; set; } // Внешний ключ к товару
        public Product Product { get; set; } // Навигационное свойство
        public string Size { get; set; } // Размер
        public decimal Price { get; set; } // Цена
        public decimal? DiscountedPrice { get; set; } // Цена после скидки (может быть null)
    }
}
