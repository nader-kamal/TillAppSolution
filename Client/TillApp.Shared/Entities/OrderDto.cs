namespace TillApp.Shared.Entities
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public string OrderName { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }

        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
}
