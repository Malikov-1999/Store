using Store.Data.Models;
using System.Collections.Generic;

namespace Store.ViewModels
{
    public class ProductListViewModel
    {
        // Список продуктов для отображения
        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        // Список категорий для фильтрации
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        // Выбранные вариации продуктов
        public Dictionary<int, Variation> SelectedVariations { get; set; } = new Dictionary<int, Variation>();

        // Для выбранного продукта
        public Product SelectedProduct { get; set; }

        // Для выбранной категории (если нужно)
        public Category SelectedCategory { get; set; }

        // Фильтры, используемые для получения данных из БД
        public int? SelectedCategoryId { get; set; }  // Фильтр по категории
        public string SelectedProductType { get; set; }  // Фильтр по типу продукта
        public string SelectedMaterial { get; set; }  // Фильтр по материалу
        public string SelectedCountry { get; set; }  // Фильтр по стране
        public decimal? PriceMin { get; set; }  // Минимальная цена
        public decimal? PriceMax { get; set; }  // Максимальная цена

        // Для сортировки продуктов (по цене)
        public string SortOrder { get; set; }

        // Списки для выбора фильтров (заполняются из БД)
        public IEnumerable<string> Materials { get; set; } = new List<string>();  // Список всех материалов
        public IEnumerable<string> Countries { get; set; } = new List<string>();  // Список всех стран

        // Поля для создания и редактирования продуктов (если нужно)
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        // Для выбранного размера продукта
        public int? SelectedProductId { get; set; }
        public string SelectedSize { get; set; }

        public string SearchTerm { get; set; }
        public string SelectedGroup { get; set; }

        public IEnumerable<string> Groups { get; set; } = new List<string>();
    }
}