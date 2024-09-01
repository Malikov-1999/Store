using Store.Data.Models;

namespace Store.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent context)
        {
            context.Database.EnsureCreated();


            // Удаляем все данные из таблиц (осторожно с этим в продакшене!)
            context.Products.RemoveRange(context.Products);
            context.Variations.RemoveRange(context.Variations);
            context.Categories.RemoveRange(context.Categories);
            context.Details.RemoveRange(context.Details);
            context.Images.RemoveRange(context.Images);
            context.SaveChanges();

            // Проверяем и добавляем категории
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
                context.SaveChanges();
            }

            // Получаем категории из базы данных
            var categoryKedrK1 = context.Categories.FirstOrDefault(c => c.Name == "Кедр к1");
            var categoryFurnitura = context.Categories.FirstOrDefault(c => c.Name == "Фурнитура для плинтуса KORNER 37-38 мм");

            // Проверяем и добавляем продукты
            if (!context.Products.Any())
            {
                // Продукт 1: 70008/S Тис
                var product1 = new Product
                {
                    Name = "70008/S Тис",
                    SKU = "70008/S",
                    Description = "Столешницы от фабрики Кедр из высококачественной и влагостойкой ДСП. Качественный пластик HPL. Возможны нестандартные размеры столешниц шириной от 600 до 1200 мм с шагом 100 мм, толщиной от 25 мм до 54 мм.",
                    Category = categoryKedrK1,
                    ProductTypeTypes = ProductType.Основной,
                    Group = "1",
                    Material = "ДСП",
                    Country = "Россия",
                    Variations = new List<Variation>
                    {
                        new Variation { Size = "3050х1200х26 мм", Price = 16500.00M, DiscountedPrice = 13500.00M },
                        new Variation { Size = "3050х1200х38 мм", Price = 19500.00M, DiscountedPrice = 17500.00M },
                        new Variation { Size = "3050х600х25 мм", Price = 4850.00M, DiscountedPrice = 4250.00M },
                        new Variation { Size = "3050х600х38 мм", Price = 6850.00M, DiscountedPrice = 6250.00M },
                        new Variation { Size = "3050х800х26 мм", Price = 10500.00M },
                        new Variation { Size = "3050х800х38 мм", Price = 16500.00M, DiscountedPrice = 14500.00M },
                        new Variation { Size = "4100х600х38 мм", Price = 10500.00M, DiscountedPrice = 9500.00M }
                    },
                    Details = new List<Detail>
                    {
                        new Detail { Key = "Поверхность", Value = "Кристалл" }
                    },
                    Images = new List<Image>
                    {
                        new Image { Url ="/img/1.jpg" }
                    }
                };

                // Продукт 2: 70003/S Содалит
                var product2 = new Product
                {
                    Name = "70003/S Содалит",
                    SKU = "70003/S",
                    Description = "Столешницы от фабрики Кедр из высококачественной и влагостойкой ДСП. Качественный пластик HPL. Возможны нестандартные размеры столешниц шириной от 600 до 1200 мм с шагом 100 мм, толщиной от 25 мм до 54 мм.",
                    Category = categoryKedrK1,
                    ProductTypeTypes = ProductType.Основной,
                    Group = "1",
                    Material = "ДСП",
                    Country = "Россия",
                    Variations = new List<Variation>
                    {
                        new Variation { Size = "3050х1200х26 мм", Price = 16500.00M, DiscountedPrice = 13500.00M },
                        new Variation { Size = "3050х1200х38 мм", Price = 19500.00M, DiscountedPrice = 17500.00M },
                        new Variation { Size = "3050х600х25 мм", Price = 4850.00M, DiscountedPrice = 4250.00M },
                        new Variation { Size = "3050х600х38 мм", Price = 6850.00M, DiscountedPrice = 6250.00M },
                        new Variation { Size = "3050х800х26 мм", Price = 10500.00M },
                        new Variation { Size = "3050х800х38 мм", Price = 16500.00M, DiscountedPrice = 14500.00M },
                        new Variation { Size = "4100х600х38 мм", Price = 10500.00M, DiscountedPrice = 9500.00M }
                    },
                    Details = new List<Detail>
                    {
                        new Detail { Key = "Поверхность", Value = "Кристалл" }
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "/img/2.jpg" }
                    }
                };

                // Продукт 3: 3027/S Гранит белый
                var product3 = new Product
                {
                    Name = "3027/S Гранит белый",
                    SKU = "3027/S",
                    Description = "Столешницы от фабрики Кедр из высококачественной и влагостойкой ДСП. Качественный пластик CPL. Возможны нестандартные размеры столешниц шириной от 600 до 1200 мм с шагом 100 мм, толщиной от 25 мм до 54 мм.",
                    Category = categoryKedrK1,
                    ProductTypeTypes = ProductType.Основной,
                    Material = "ДСП",
                    Country = "Россия",
                    Variations = new List<Variation>
                    {
                        new Variation { Size = "3050х1200х26 мм", Price = 12500.00M },
                        new Variation { Size = "3050х1200х38 мм", Price = 15500.00M },
                        new Variation { Size = "3050х600х25 мм", Price = 3800.00M },
                        new Variation { Size = "3050х600х38 мм", Price = 5250.00M },
                        new Variation { Size = "3050х800х26 мм", Price = 8500.00M },
                        new Variation { Size = "3050х800х38 мм", Price = 12500.00M },
                        new Variation { Size = "4100х600х38 мм", Price = 7280.00M }
                    },
                    Details = new List<Detail>
                    {
                        new Detail { Key = "Поверхность", Value = "Матовая" }
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "/img/3.1.jpg" },
                        new Image { Url = "/img/3.2.jpg" },
                        new Image { Url = "/img/3.3.jpg" },
                        new Image { Url = "/img/3.4.jpg" },
                        new Image { Url = "/img/3.5.jpg" }
                    }
                };

                // Продукт 4: LB 37 Индийское дерево 6140
                var product4 = new Product
                {
                    Name = "LB 37 Индийское дерево 6140",
                    SKU = "1018081",
                    Description = "Комплект аксессуаров для плинтуса Korner LB37. Аксессуары для торца плинтуса и мест соединения. В комплекте: внешний уголок, внутренний уголок, заглушка левая, заглушка правая. Цвет аксессуаров будет подходить под цвет плинтуса или столешницы.",
                    Category = categoryFurnitura,
                    ProductTypeTypes = ProductType.Комплектующие,
                    Material = "ПВХ",
                    Country = "Польша",
                    Group = "Овальный",
                    Variations = new List<Variation>
                    {
                        new Variation { Size = "37 мм", Price = 200.00M }
                    },
                    Details = new List<Detail>
                    {
                        new Detail { Key = "Единица измерения", Value = "комплект" },
                        new Detail { Key = "Масса 1 ед. (кг)", Value = "0.02" },
                        new Detail { Key = "Объем 1 ед. (м³)", Value = "0.00026752" }
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "/img/4.jpg" }
                    }
                };

                // Добавляем продукты в контекст
                context.Products.AddRange(product1, product2, product3, product4);

                // Сохраняем изменения
                context.SaveChanges();
            }
        }

        // Метод для создания списка категорий
        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var list = new Category[]
                    {
                        new Category { Name = "Кедр к1" },
                        new Category { Name = "Фурнитура для плинтуса KORNER 37-38 мм" }
                    };
                    categories = list.ToDictionary(c => c.Name, c => c);
                }
                return categories;
            }
        }
    }
}
