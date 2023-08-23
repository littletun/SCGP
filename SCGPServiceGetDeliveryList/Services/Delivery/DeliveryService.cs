using SCGPServiceGetDeliveryList.Models;

namespace SCGPServiceGetDeliveryList.Services.Delivery
{
    public class DeliveryService : IDeliveryService
    {
        private static readonly Dictionary<string, DeliveryList> _deliveryDB = new();

        public void ReceiveDelivery(DeliveryList deliveryList)
        {
            _deliveryDB.Add(deliveryList.ZKEY, deliveryList);
        }

        public DeliveryList GetDelivery(string deliveryKey)
        {
            return _deliveryDB[deliveryKey];
        }
    }
}
