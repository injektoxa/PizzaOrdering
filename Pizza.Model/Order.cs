using System;
using System.Collections.Generic;

namespace Pizza.Model
{
    /// <summary>
    /// This class allows you to make an order
    /// </summary>
    public class Order : Entity
    {
        public User User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime RecivedDate { get; set; }
        public double TotalPrice { get; set; }
        public string Comment { get; set; }
    }
}