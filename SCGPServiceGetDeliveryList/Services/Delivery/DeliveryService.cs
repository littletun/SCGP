using SCGPServiceGetDeliveryList.Models;

namespace SCGPServiceGetDeliveryList.Services.Delivery
{
    public class DeliveryService : IDeliveryService
    {
        private static readonly Dictionary<Guid, DeliveryList> _deliveryDB = new();

        public void ReceiveDelivery(DeliveryList deliveryList)
        {
            _deliveryDB.Add(Guid.NewGuid(), deliveryList);
        }

        public DeliveryList GetDelivery(Guid deliveryKey)
        {
            return _deliveryDB[deliveryKey];
        }
    }
}
