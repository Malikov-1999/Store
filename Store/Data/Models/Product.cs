namespace Store.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public ICollection<Image> Images { get; set; } // Список изображений
        public string Name { get; set; } // Название товара
        public string SKU { get; set; } // Артикул
        public string Description { get; set; } // Описание
        public ProductType ProductTypeTypes { get; set; } // Тип товара        
        public int CategoryId { get; set; } // Внешний ключ к категории
        public Category Category { get; set; } // Навигационное свойство
        public ICollection<Variation> Variations { get; set; } // Список вариаций
        public ICollection<Detail> Details { get; set; } // Список деталей

        // Новые свойства
        public string? Group { get; set; } // Группа
        public string? Material { get; set; } // Материал
        public string? Country { get; set; } // Страна

        public Product()
        {
            Variations = new List<Variation>();
            Details = new List<Detail>();
            Images = new List<Image>();
        }
    }
}