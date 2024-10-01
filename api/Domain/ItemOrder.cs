using api.Shared;

namespace api.Domain
{
    public class ItemOrder
    {
        public int OrderId { get; private set; }

        public int ProductId { get; private set; }

        public int Count { get; private set; }

        public decimal Price { get; private set; }

        public ItemOrder(int productId, int count, decimal price)
        {
            ProductId = productId;
            Price = price;
            Count = count;
        }

        public decimal CalculateTotal()
        {
            decimal total = Count * Price;

            if (Count >= 5 && total > 10)
                return total - 10;

            if (Count >= 10 && total > 15)
                return total - 15;

            return 0;
        }

        public decimal CalculateSeasonalDiscount(DateTime date)
        {
            decimal total = Price * Count;

            if (date.Month == 7)
                return total * 0.1m;

            if (date.DayOfWeek == DayOfWeek.Wednesday || date.DayOfWeek == DayOfWeek.Thursday)
                return total * 0.05m;

            return 0;
        }
    }
}
