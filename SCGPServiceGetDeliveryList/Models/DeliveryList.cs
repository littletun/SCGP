using System.ComponentModel.DataAnnotations;

namespace SCGPServiceGetDeliveryList.Models
{
    public class DeliveryList
    {
        public string ZKEY { get; set; }

        [Required]
        public string MESSAGE_ID { get; set; }
        [Required]
        public ZDELIVERY ZDELIVERY { get; set; }
        [Required]
        public ZSHIPMENT ZSHIPMENT { get; set; }
        
    }
}
