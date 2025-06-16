namespace MothAphotheaShopAPI
{
    public class PurchaseDTO
    {
        public Guid UserId { get; set; }

        public Guid PaymentMethodId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal TotalAmount { get; set; }

        public List<Guid> ProductIds { get; set; } = new List<Guid>();
    }
}
