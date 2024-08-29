using System.Collections.Generic;
using Store.Data.Models;

namespace Store.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> AllProducts { get; set; }
        public string CurrCategory { get; set; }

        // Свойства для фильтрации
        public IEnumerable<Category> Categories { get; set; }
        public int? SelectedCategoryId { get; set; }

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public string CountryOfOrigin { get; set; }
        public IEnumerable<string> Countries { get; set; } // Новый список стран

        public bool? IsAvailable { get; set; }

        public ProductType? ProductType { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; } // Новый список типов продуктов

        public string Surface { get; set; }
        public IEnumerable<string> Surfaces { get; set; } // Новый список поверхностей

        public string Material { get; set; }
        public IEnumerable<string> Materials { get; set; } // Новый список материалов
    }
}