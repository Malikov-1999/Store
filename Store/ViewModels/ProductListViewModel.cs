using Store.Data.Models;

namespace Store.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public Dictionary<int, Variation> SelectedVariations { get; set; } = new Dictionary<int, Variation>();
        public Product SelectedProduct { get; set; }
        public Category SelectedCategory { get; set; }

        // Дополнительные свойства для создания и редактирования
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        // Новые свойства для выбора размера и продукта
        public int? SelectedProductId { get; set; }
        public string SelectedSize { get; set; }

        // Инициализируем коллекции, чтобы они не были null
        public List<string> Materials { get; set; } = new List<string>();
        public List<string> Countries { get; set; } = new List<string>();

        // Дополнительные свойства для фильтров
        public int? SelectedCategoryId { get; set; }
        public string SelectedProductType { get; set; }
        public string SelectedMaterial { get; set; }
        public string SelectedCountry { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
    }
}
