using System.Text.Json.Serialization;

namespace MothAphotheaShopAPI
{
    public class Purchase
    {
        public Guid Id { get; set; } = new Guid();

        public int UserId { get; set; }


        [JsonIgnore]
        public PaymentMethod PaymentMethod { get; set; }

        public DateTime PurchaseDate { get; set; }

        public double TotalAmount { get; set; }

        [JsonIgnore]
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public void CalculateTotalAmount()
        {
            TotalAmount = Products.Sum(p => p.Price);
        }

    }
}
