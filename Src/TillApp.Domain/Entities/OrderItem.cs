using System.ComponentModel.DataAnnotations.Schema;

namespace TillApp.Domain.Entities
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public string ItemName { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

    }
}
