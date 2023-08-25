using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace SCGPServiceGetDeliveryList.Models
{
    public class ZRETURN
    {
        public ZRETURN(XmlNode deliveryNode)
        {
            DELIVERY_NUMBER = deliveryNode["DELIVERY_NUMBER"].InnerText;
            DELIVERY_ITEM_NO = deliveryNode["DELIVERY_ITEM_NO"].InnerText;
            STATUS_TYPE = (DELIVERY_NUMBER.Length > 0) && (DELIVERY_ITEM_NO.Length > 0) ? "S" : "E";
            ERROR_CODE = (STATUS_TYPE == "S") ? "" : "Error";
            ERROR_MESSAGE = (STATUS_TYPE == "S") ? "Received delivery successfully" : "Failed delivery";
        }

        public ZRETURN(XmlNode deliveryNode, XmlDocument document)
        {
            DELIVERY_NUMBER = deliveryNode["DELIVERY_NUMBER"].InnerText;
            DELIVERY_ITEM_NO = deliveryNode["DELIVERY_ITEM_NO"].InnerText;
            STATUS_TYPE = deliveryNode["STATUS_TYPE"].InnerText;
            ERROR_CODE = deliveryNode["ERROR_CODE"].InnerText;
            ERROR_MESSAGE = deliveryNode["ERROR_MESSAGE"].InnerText;
        }

        [Required]
        [StringLength(10)]
        public string? DELIVERY_NUMBER { get; set; }
        [Required]
        [StringLength(6)]
        public string? DELIVERY_ITEM_NO { get; set; }
        [Required]
        [StringLength(1)]
        public string? STATUS_TYPE { get; set; }
        [Required]
        [StringLength(3)]
        public string? ERROR_CODE { get; set; }
        [Required]
        [StringLength(255)]
        public string? ERROR_MESSAGE { get; set; }
    }
}
