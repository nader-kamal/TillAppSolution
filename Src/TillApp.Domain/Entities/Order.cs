using System.ComponentModel.DataAnnotations.Schema;

namespace TillApp.Domain.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderName { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
