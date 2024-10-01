namespace api.Features.CreateOrder.Enum
{
    public enum OrderStatus
    {
        ProcessingPayment,
        AwaitingProcessing,
        PaymentCompleted,
        Canceled
    }
}
