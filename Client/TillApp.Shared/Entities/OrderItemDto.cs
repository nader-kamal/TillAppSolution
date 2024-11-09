namespace TillApp.Shared.Entities
{
    public class OrderItemDto
    {
        public int OrderItemID { get; set; } 
        public int OrderID { get; set; } 
        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }
}
