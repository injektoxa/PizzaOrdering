namespace Pizza.Model
{
    /// <summary>
    /// User's address
    /// </summary>
    public class Address : Entity
    {
        public string Building { get; set; }
        public string Street { get; set; }
        public string Flat { get; set; }
    }
}