namespace Pizza.Model
{
    /// <summary>
    /// Describe products
    /// </summary>
    public class Product : Entity
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}