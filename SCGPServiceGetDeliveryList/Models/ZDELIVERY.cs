using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace SCGPServiceGetDeliveryList.Models
{
    public class ZDELIVERY
    {
        public ZDELIVERY(XmlNode deliveryNode)
        {
            DELIVERY_NUMBER = deliveryNode["DELIVERY_NUMBER"].InnerText;
            DELIVERY_DATE = deliveryNode["DELIVERY_DATE"].InnerText;
            DELIVERY_CREATE = deliveryNode["DELIVERY_CREATE"].InnerText;
            DELIVERY_TIME = deliveryNode["DELIVERY_TIME"].InnerText;
            DELIVERY_ITEM_NO = deliveryNode["DELIVERY_ITEM_NO"].InnerText;
            SHIPTO_ID = deliveryNode["SHIPTO_ID"].InnerText;
            SOLDTO_ID = deliveryNode["SOLDTO_ID"].InnerText;
            SHIPTO_NAME = deliveryNode["SHIPTO_NAME"].InnerText;
            SOLDTO_NAME = deliveryNode["SOLDTO_NAME"].InnerText;
            MATERIAL_NUMBER = deliveryNode["MATERIAL_NUMBER"].InnerText;
            MATERIAL_DES = deliveryNode["MATERIAL_DES"].InnerText;
            STORAGE = deliveryNode["STORAGE"].InnerText;
            GRADE = deliveryNode["GRADE"].InnerText;
            NET_WEIGHT = deliveryNode["NET_WEIGHT"].InnerText;
            GROSS_WEIGHT = deliveryNode["GROSS_WEIGHT"].InnerText;
            WEIGHT_UNIT = deliveryNode["WEIGHT_UNIT"].InnerText;
            PLANT = deliveryNode["PLANT"].InnerText;
            SHIPPING_POINT = deliveryNode["SHIPPING_POINT"].InnerText;
            DN_ITEM_QTY = deliveryNode["DN_ITEM_QTY"].InnerText;
            PI_NUMBER = deliveryNode["PI_NUMBER"].InnerText;
            SALES_DOCUMENT_NO = deliveryNode["SALES_DOCUMENT_NO"].InnerText;
            PO_NUMBER = deliveryNode["PO_NUMBER"].InnerText;
            SALES_ITEM_NO = deliveryNode["SALES_ITEM_NO"].InnerText;
            BASE_UNIT = deliveryNode["BASE_UNIT"].InnerText;
            SALES_UNIT = deliveryNode["SALES_UNIT"].InnerText;
            NUM_OF_PALLET = deliveryNode["NUM_OF_PALLET"].InnerText;
            WMS_DELIVERY_NO = deliveryNode["WMS_DELIVERY_NO"].InnerText;
            IC_TO_LOGISTIC = deliveryNode["IC_TO_LOGISTIC"].InnerText;
            IC_TO_WAREHOUSE = deliveryNode["IC_TO_WAREHOUSE"].InnerText;
        }

        [Required]
        public string DELIVERY_NUMBER { get; set; }
        [Required]
        public string DELIVERY_DATE { get; set; }
        [Required]
        public string DELIVERY_CREATE { get; set; }
        [Required]
        public string DELIVERY_TIME { get; set; }
        [Required]
        public string DELIVERY_ITEM_NO { get; set; }
        [Required]
        public string SHIPTO_ID { get; set; }
        [Required]
        public string SOLDTO_ID { get; set; }
        [Required]
        public string SHIPTO_NAME { get; set; }
        [Required]
        public string SOLDTO_NAME { get; set; }
        [Required]
        public string MATERIAL_NUMBER { get; set; }
        [Required]
        public string MATERIAL_DES { get; set; }
        [Required]
        public string STORAGE { get; set; }
        [Required]
        public string GRADE { get; set; }
        [Required]
        public string NET_WEIGHT { get; set; }
        [Required]
        public string GROSS_WEIGHT { get; set; }
        [Required]
        public string WEIGHT_UNIT { get; set; }
        [Required]
        public string PLANT { get; set; }
        [Required]
        public string SHIPPING_POINT { get; set; }
        [Required]
        public string DN_ITEM_QTY { get; set; }
        [Required]
        public string PI_NUMBER { get; set; }
        [Required]
        public string SALES_DOCUMENT_NO { get; set; }
        public string? PO_NUMBER { get; set; }
        [Required]
        public string SALES_ITEM_NO { get; set; }
        [Required]
        public string BASE_UNIT { get; set; }
        [Required]
        public string SALES_UNIT { get; set; }


        public string? NUM_OF_PALLET { get; set; }
        public string? WMS_DELIVERY_NO { get; set; }
        public string? IC_TO_LOGISTIC { get; set; }
        public string? IC_TO_WAREHOUSE { get; set; }

    }
}
