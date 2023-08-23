using Microsoft.AspNetCore.Mvc;
using SCGPServiceGetDeliveryList.Models;
using SCGPServiceGetDeliveryList.Services.Delivery;
using System.Xml;

namespace SCGPServiceGetDeliveryList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly ILogger<DeliveryController> _logger;

        private readonly IDeliveryService _deliveryService;

        public DeliveryController(ILogger<DeliveryController> logger, IDeliveryService deliveryService)
        {
            _logger = logger;
            _deliveryService = deliveryService;
        }
        
        [HttpPost()]
        public IActionResult ReceiveDeliveryLists(List<IFormFile> files)
        {

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;

            if (files.Count <= 0)
            {
                return BadRequest("Please Upload File.");
            }

            List<DeliveryList> deliveryList = FilesToModals(files);

            return Ok(deliveryList);
        }

        [HttpGet("{deliveryId}")]
        public IActionResult RespondDeliveryLists(string deliveryId)
        {
            DeliveryList delivery = _deliveryService.GetDelivery(deliveryId);

            ZRETURN returnResult = new ZRETURN(
                delivery.ZDELIVERY.DELIVERY_NUMBER,
                delivery.ZDELIVERY.DELIVERY_ITEM_NO,
                "S",
                "",
                ""
                ) ;

            ResultDeliveryList respond = new ResultDeliveryList(
                delivery.ZKEY,
                delivery.MESSAGE_ID,
                "",
                returnResult
             );

            return Ok(delivery);
        }

        protected List<DeliveryList> FilesToModals(List<IFormFile> files)
        {
            var list = new List<DeliveryList>();

            foreach (var file in files)
            {
                XmlDocument deliveryDocument = new XmlDocument();
                var streamFile = FileToString(file);
                deliveryDocument.LoadXml(streamFile);
                AddDeliveryList(list, deliveryDocument);
            }

            return list;
        }

        protected void AddDeliveryList(List<DeliveryList> list, XmlDocument deliveryDocument)
        {
            var rootNode = "/root";
            var deliNode = "/ZDELIVERY/item";

            foreach (XmlNode deliveryNode in deliveryDocument.SelectNodes(rootNode + deliNode))
            {
                DeliveryList deliveryList = new DeliveryList();
                ZDELIVERY deliveryItem = new ZDELIVERY(deliveryNode);

                deliveryList.ZDELIVERY = deliveryItem;
                ExtractShipment(deliveryList, deliveryDocument, rootNode);
                ExtractKeyInput(deliveryList, deliveryDocument, rootNode);

                list.Add(deliveryList);
            }
        }

        protected static void ExtractKeyInput(DeliveryList deliveryList, XmlDocument deliveryDocument, string rootNode)
        {
            foreach (XmlNode inputNode in deliveryDocument.SelectNodes(rootNode))
            {
                deliveryList.ZKEY = inputNode["ZKEY"].InnerText;
                deliveryList.MESSAGE_ID = inputNode["MESSAGE_ID"].InnerText;
            }
        }

        protected void ExtractShipment(DeliveryList deliveryList, XmlDocument deliveryDocument, string rootNode)
        {
            var shipNode = "/ZSHIPMENT/item";

            foreach (XmlNode shipmentNode in deliveryDocument.SelectNodes(rootNode + shipNode))
            {
                ZSHIPMENT deliveryShipment = new ZSHIPMENT(shipmentNode);
                deliveryList.ZSHIPMENT = deliveryShipment;
            }
        }

        protected string FileToString(IFormFile file)
        {
            var result = "<root>";
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result += reader.ReadLine();
            }
            result += "</root>";

            return result;
        }
    }
}