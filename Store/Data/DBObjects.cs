using Store.Data.Interfaces;
using Store.Data.Models;
using System.Linq;
using System.Collections.Generic;

namespace Store.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            // Инициализация категорий
            if (!content.Categories.Any())
            {
                content.Categories.AddRange(Categories.Select(c => c.Value));
            }

            // Инициализация продуктов
            if (!content.Products.Any())
            {
                content.AddRange(
                    new Product
                    {
                        Name = "1 Продукт",
                        Price = 222,
                        Material = "Материал",
                        Surface = "Поверхность",
                        Group = "Группа",
                        CountryOfOrigin = "Страна производства",
                        AvailableSizes = new List<string> { "S", "M", "L" },
                        DiscountPrice = 200,
                        ImageUrl = "/img/1.jpg",
                        Description = "Описание продукта",
                        SKU = "12345",
                        IsFavProduct = true,
                        Available = true,
                        CategoryId = Categories["1 Категория"].Id,
                        Category = Categories["1 Категория"],
                        ProductType = ProductType.Accessory
                    },

                    new Product
                    {
                        Name = "1 Продукт",
                        Price = 222,
                        Material = "Материал",
                        Surface = "Поверхность",
                        Group = "Группа",
                        CountryOfOrigin = "Страна производства",
                        AvailableSizes = new List<string> { "S", "M", "L" },
                        DiscountPrice = 200,
                        ImageUrl = "/img/1.jpg",
                        Description = "Описание продукта",
                        SKU = "12345",
                        IsFavProduct = true,
                        Available = true,
                        CategoryId = Categories["1 Категория"].Id,
                        Category = Categories["1 Категория"],
                        ProductType = ProductType.Accessory
                    },

                    new Product
                    {
                        Name = "1 Продукт",
                        Price = 222,
                        Material = "Материал",
                        Surface = "Поверхность",
                        Group = "Группа",
                        CountryOfOrigin = "Страна производства",
                        AvailableSizes = new List<string> { "S", "M", "L" },
                        DiscountPrice = 200,
                        ImageUrl = "/img/1.jpg",
                        Description = "Описание продукта",
                        SKU = "12345",
                        IsFavProduct = true,
                        Available = true,
                        CategoryId = Categories["1 Категория"].Id,
                        Category = Categories["1 Категория"],
                        ProductType = ProductType.Accessory
                    },

                    new Product
                    {
                        Name = "1 Продукт",
                        Price = 222,
                        Material = "Материал",
                        Surface = "Поверхность",
                        Group = "Группа",
                        CountryOfOrigin = "Страна производства",
                        AvailableSizes = new List<string> { "S", "M", "L" },
                        DiscountPrice = 200,
                        ImageUrl = "/img/1.jpg",
                        Description = "Описание продукта",
                        SKU = "12345",
                        IsFavProduct = true,
                        Available = true,
                        CategoryId = Categories["1 Категория"].Id,
                        Category = Categories["1 Категория"],
                        ProductType = ProductType.Accessory
                    },

                    new Product
                    {
                        Name = "1 Продукт",
                        Price = 222,
                        Material = "Материал",
                        Surface = "Поверхность",
                        Group = "Группа",
                        CountryOfOrigin = "Страна производства",
                        AvailableSizes = new List<string> { "S", "M", "L" },
                        DiscountPrice = 200,
                        ImageUrl = "/img/1.jpg",
                        Description = "Описание продукта",
                        SKU = "12345",
                        IsFavProduct = true,
                        Available = true,
                        CategoryId = Categories["1 Категория"].Id,
                        Category = Categories["1 Категория"],
                        ProductType = ProductType.Accessory
                    },

                    new Product
                    {
                        Name = "1 Продукт",
                        Price = 222,
                        Material = "Материал",
                        Surface = "Поверхность",
                        Group = "Группа",
                        CountryOfOrigin = "Страна производства",
                        AvailableSizes = new List<string> { "S", "M", "L" },
                        DiscountPrice = 200,
                        ImageUrl = "/img/1.jpg",
                        Description = "Описание продукта",
                        SKU = "12345",
                        IsFavProduct = true,
                        Available = true,
                        CategoryId = Categories["1 Категория"].Id,
                        Category = Categories["1 Категория"],
                        ProductType = ProductType.Accessory
                    },

                    new Product
                    {
                        Name = "1 Продукт",
                        Price = 222,
                        Material = "Материал",
                        Surface = "Поверхность",
                        Group = "Группа",
                        CountryOfOrigin = "Страна производства",
                        AvailableSizes = new List<string> { "S", "M", "L" },
                        DiscountPrice = 200,
                        ImageUrl = "/img/1.jpg",
                        Description = "Описание продукта",
                        SKU = "12345",
                        IsFavProduct = true,
                        Available = true,
                        CategoryId = Categories["1 Категория"].Id,
                        Category = Categories["1 Категория"],
                        ProductType = ProductType.Accessory
                    }

                );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category>? category;  

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category {Name = "1 Категория"},
                        new Category {Name = "2 Категория"},
                        new Category {Name = "3 Категория"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        category.Add(el.Name, el);
                    }
                }

                return category;
            }
        }
    }
}
