namespace Store.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } // Название категории
        public ICollection<Product> Products { get; set; } // Список товаров в категории

        public Category()
        {
            Products = [];
        }
    }
}
