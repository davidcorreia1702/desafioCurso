using api.Features.CreateOrder.Enum;
using api.Shared;

namespace api.Domain
{
    public class OrderPayment
    {
        public PaymentType PaymentType { get; private set; }

        public int Installments { get; private set; }

        public bool Refunded { get; private set; }

        private OrderPayment(PaymentType paymentType, int installments)
        {
            PaymentType = paymentType;
            Installments = installments;
        }

        public static decimal ApplyDiscountForPix(decimal totalOrder)
        {
            var discountPercentage = 0.05m;
            var discount = totalOrder * discountPercentage;

            return totalOrder - discount;
        }

        public void MarkOrderAsRefunded()
        {
            Refunded = true;
        }
    }
}
