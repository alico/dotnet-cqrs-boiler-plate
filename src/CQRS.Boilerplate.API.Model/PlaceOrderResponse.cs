namespace CQRS.Boilerplate.API.Model
{
    public record PlaceOrderResponse
    {
        public Guid OrderId { get; set; }

    }
}