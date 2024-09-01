namespace Store.Data.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public int ProductId { get; set; } // Внешний ключ к товару
        public Product Product { get; set; } // Навигационное свойство
        public string Key { get; set; } // Ключ детали (например, "Поверхность")
        public string Value { get; set; } // Значение детали (например, "Кристалл")
    }
}
