using System.ComponentModel.DataAnnotations;

namespace Store.Data.Models
{
    public class Accessory
    {
        public int Id { get; set; }
        public string? Name { get; set; } // Название комплектующего

        public string? Description { get; set; } // Описание комплектующего

        public decimal Price { get; set; } // Цена комплектующего

        public string? SKU { get; set; } // Артикул комплектующего

        public string? ImageUrl { get; set; } // Изображение комплектующего

        public string? UnitOfMeasurement { get; set; } // Единица измерения, например, "шт"

        public string? Material { get; set; } // Материал

        public string? CountryOfOrigin { get; set; } // Страна производства

        public string? Size { get; set; } // Размер

        public decimal Weight { get; set; } // Масса

        public decimal Volume { get; set; } // Объем

        public int ProductId { get; set; } // ID основного продукта
        public required Product Product { get; set; } // Основной продукт, к которому относится комплектующее
    }
}
