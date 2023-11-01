namespace AnkaraLab_BackEnd.WebAPI.Domain
{
    public class Order
    {
        public int OrderId { get; }
        public string DeliveryAddress { get; set; }

        public string InvoiceAddress { get; set; }

        public string PaymentMethod { get; set; }

        public string PaymentStatus { get; set; }

        public Order(int orderId, string deliveryAddress, string invoiceAddress, string paymentMethod, string paymentStatus)
        {
            OrderId = orderId;
            DeliveryAddress = deliveryAddress;
            PaymentMethod = paymentMethod;
            PaymentStatus = paymentStatus;
            InvoiceAddress = invoiceAddress;
        }
    }

}
