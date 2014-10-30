namespace Pizza.Model
{
    /// <summary>
    /// Describes order status
    /// </summary>
    public class OrderStatus
    {
        public bool Accepted { set; get; }
        public bool InProgress { set; get; }
        public bool Finished { set; get; }
    }
}