using SCGPServiceGetDeliveryList.Models;

namespace SCGPServiceGetDeliveryList.Services.Delivery
{
    public interface IDeliveryService
    {
        void ReceiveDelivery(DeliveryList deliveryList);
        DeliveryList GetDelivery(string deliveryKey);
    }
}
