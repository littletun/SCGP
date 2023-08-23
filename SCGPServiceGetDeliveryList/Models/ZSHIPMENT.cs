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
        public string SHIPMENT_NUMBER { get; set; }
        [Required]
        public string SHIPMENT_TYPE { get; set; }
        [Required]
        public string SHIPPING_TYPE { get; set; }
        [Required]
        public string FWD_ID { get; set; }
        [Required]
        public string VEHICLE_ID { get; set; }
        [Required]
        public string END_PLAN_DATE { get; set; }
        [Required]
        public string END_PLAN_TIME { get; set; }

    }
}
