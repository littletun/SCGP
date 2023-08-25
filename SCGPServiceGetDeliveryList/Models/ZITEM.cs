using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace SCGPServiceGetDeliveryList.Models
{
    public class ZITEM
    {
        public ZITEM(XmlNode itemNode)
        {
            DELIVERY_ITEM_NO = itemNode["DELIVERY_ITEM_NO"].InnerText;
            MATERIAL_NUMBER = itemNode["MATERIAL_NUMBER"].InnerText;
            BATCH_NUMBER = itemNode["BATCH_NUMBER"].InnerText;
            DELIVERY_QTY = itemNode["DELIVERY_QTY"].InnerText;
            DELIVERY_UNIT = itemNode["DELIVERY_UNIT"].InnerText;
        }

        [Required]
        [StringLength(20)]
        public string? DELIVERY_ITEM_NO { get; set; }

        [Required]
        [StringLength(20)]
        public string? MATERIAL_NUMBER { get; set; }

        [Required]
        [StringLength(20)]
        public string? BATCH_NUMBER { get; set; }

        [Required]
        [StringLength(20)]
        public string? DELIVERY_QTY { get; set; }

        [Required]
        [StringLength(20)]
        public string? DELIVERY_UNIT { get; set; }

    }
}
