using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace SCGPServiceGetDeliveryList.Models
{
    public class ZSHIPMENT
    {
        public ZSHIPMENT(XmlNode shipment) 
        {
            SHIPMENT_NUMBER = shipment["SHIPMENT_NUMBER"].InnerText;
            SHIPMENT_TYPE = shipment["SHIPMENT_TYPE"].InnerText;
            SHIPPING_TYPE = shipment["SHIPPING_TYPE"].InnerText;
            FWD_ID = shipment["FWD_ID"].InnerText;
            VEHICLE_ID = shipment["VEHICLE_ID"].InnerText;
            END_PLAN_DATE = shipment["END_PLAN_DATE"].InnerText;
            END_PLAN_TIME = shipment["END_PLAN_TIME"].InnerText;
        }

        [Required]
        [StringLength(10)]
        public string? SHIPMENT_NUMBER { get; set; }
        [Required]
        [StringLength(4)]
        public string? SHIPMENT_TYPE { get; set; }
        [Required]
        [StringLength(2)]
        public string? SHIPPING_TYPE { get; set; }
        [Required]
        [StringLength(10)]
        public string? FWD_ID { get; set; }
        [Required]
        [StringLength(20)]
        public string? VEHICLE_ID { get; set; }
        [Required]
        [StringLength(10)]
        public string? END_PLAN_DATE { get; set; }
        [Required]
        [StringLength(8)]
        public string? END_PLAN_TIME { get; set; }

    }
}
