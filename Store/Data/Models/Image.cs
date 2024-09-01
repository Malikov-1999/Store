namespace Store.Data.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int ProductId { get; set; } // Внешний ключ к товару
        public Product Product { get; set; } // Навигационное свойство
        public string Url { get; set; } // Ссылка на изображение
    }
}
