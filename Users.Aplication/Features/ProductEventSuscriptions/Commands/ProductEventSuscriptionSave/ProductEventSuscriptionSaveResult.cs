namespace Users.Application.Features.ProductEventSuscriptions.Commands.ProductEventSuscriptionSave ;

    public class ProductEventSuscriptionSaveResult
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public bool Suscribed { get; set; }
    }
