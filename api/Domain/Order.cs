using api.Features.CreateOrder.Enum;

namespace api.Domain
{
    public class Order
    {
        public string Client { get; private set; }

        public DateTime Date { get; private set; }

        public decimal Total { get; private set; } = 0;

        public int Count { get; private set; } = 0;

        public OrderStatus StatusOrder { get; private set; }

        public OrderPayment PayOrder { get; private set; }

        public List<ItemOrder> ItemOrders { get; set; } = new List<ItemOrder>();

        public Order(string client)
        {
            Client = client;
            StatusOrder = OrderStatus.AwaitingProcessing;
            Date = DateTime.Now;
        }

        public void AddItem(ItemOrder item)
        {
            ItemOrders.Add(item);
        }

        public void CalculateTotal()
        {
            decimal subtotal = ItemOrders.Sum(item => item.CalculateTotal());
            decimal seasonalDiscount = ItemOrders.Sum(item => item.CalculateSeasonalDiscount(Date));

            Total = subtotal - seasonalDiscount;
        }
    }
}
