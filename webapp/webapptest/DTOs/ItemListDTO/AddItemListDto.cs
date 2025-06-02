namespace webapptest.DTOs.ItemListDTO
{
    public class AddItemListDto
    {

        public string ItemId { get; set; } = null!;

        public double Quantity { get; set; }

        public double Price { get; set; }

        public decimal Amount { get; set; }

        public Guid OrderMasterId { get; set; }
    }
}
