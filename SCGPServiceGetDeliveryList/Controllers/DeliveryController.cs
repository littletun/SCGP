using Microsoft.AspNetCore.Mvc;
using SCGPServiceGetDeliveryList.Models;
using SCGPServiceGetDeliveryList.Services.Delivery;
using System.Collections.Generic;
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
        
        [HttpPost("SDI01 Delivery List")]
        public IActionResult ReceiveDeliveryLists(List<IFormFile> files)
        {
            if (files.Count <= 0)
            {                
                return BadRequest("Please Upload File.");
            }

            List<ResultDeliveryList> respondDeli = FilesToDeliveryListModals(files);

            if (!ModelState.IsValid)
            {
                return BadRequest(respondDeli);
            }

            return Ok(respondDeli);
        }

        [HttpPost("SDO02 Result for Delivery List")]
        public IActionResult RespondDeliveryLists(List<IFormFile> files)
        {
            if (files.Count <= 0)
            {
                return BadRequest("Please Upload File.");
            }

            var respondDeli = FilesToResultDeliveryModals(files);

            if (!ModelState.IsValid)
            {
                return BadRequest(respondDeli);
            }

            return Ok(respondDeli);
        }

        [HttpPost("SDO01 - Post Goods Issue Delivery")]
        public IActionResult PostGoodsIssueDelivery(List<IFormFile> files)
        {
            if (files.Count <= 0)
            {
                return BadRequest("Please Upload File.");
            }

            var goodsIssueDeliveryList = FilesToGoodsIssueModals(files);

            if (!ModelState.IsValid)
            {
                return BadRequest(goodsIssueDeliveryList);
            }

            return Ok(goodsIssueDeliveryList);
        }

        protected List<ResultDeliveryList> FilesToDeliveryListModals(List<IFormFile> files)
        {
            List<ResultDeliveryList> returnList = new List<ResultDeliveryList>();

            foreach (var file in files)
            {
                XmlDocument document = new XmlDocument();
                var streamFile = FileToString(file);
                document.LoadXml(streamFile);
                AddDeliveryList(document);
                AddReturnList(returnList, document, false);
            }

            return returnList;
        }

        protected List<ResultDeliveryList> FilesToResultDeliveryModals(List<IFormFile> files)
        {
            List<ResultDeliveryList> returnList = new List<ResultDeliveryList>();

            foreach (var file in files)
            {
                XmlDocument document = new XmlDocument();
                var streamFile = FileToString(file);
                document.LoadXml(streamFile);
                AddReturnList(returnList, document, true);
            }

            return returnList;
        }

        protected List<GoodsIssueDeliveryOutput> FilesToGoodsIssueModals(List<IFormFile> files)
        {
            var goodsList = new List<GoodsIssueDeliveryOutput>();

            foreach (var file in files)
            {
                XmlDocument document = new XmlDocument();
                var streamFile = FileToString(file);
                document.LoadXml(streamFile);
                AddGoodsIssueDeliveryList(goodsList, document);
            }

            return goodsList;
        }

        protected void AddDeliveryList(XmlDocument doc)
        {
            List <DeliveryList> list = new List<DeliveryList>();
            List<ZDELIVERY> deliList = new List<ZDELIVERY>();
            DeliveryList deliveryList = new DeliveryList();
            var rootNode = "/root";
            var deliNode = "/ZDELIVERY/item";

            ExtractShipment(deliveryList, doc, rootNode);

            foreach (XmlNode deliveryNode in doc.SelectNodes(rootNode + deliNode))
            {
                ZDELIVERY deliveryItem = new ZDELIVERY(deliveryNode);
                deliList.Add(deliveryItem);
            }

            deliveryList.ZDELIVERY = deliList;
            deliveryList.DeliveryId = new Guid();
            ExtractKeyInput(deliveryList, doc, rootNode);
            _deliveryService.ReceiveDelivery(deliveryList);

            list.Add(deliveryList);
        }

        protected void AddReturnList(List<ResultDeliveryList> returnList, XmlDocument doc, bool returnDoc)
        {

            ResultDeliveryList resultDeliveryList = new ResultDeliveryList();
            List<ZRETURN> returnDeli = new List<ZRETURN>();
            var rootNode = "/root";
            var deliNode = (returnDoc) ? "/ZRETURN/item" : "/ZDELIVERY/item";

            ExtractKeyInputReturn(resultDeliveryList, doc, rootNode, returnDoc);

            foreach (XmlNode deliveryNode in doc.SelectNodes(rootNode + deliNode))
            {
                if (returnDoc)
                {
                    ZRETURN returnItem = new ZRETURN(deliveryNode, doc);
                    returnDeli.Add(returnItem);
                }
                else
                {
                    ZRETURN returnItem = new ZRETURN(deliveryNode);
                    returnDeli.Add(returnItem);
                }
            }

            resultDeliveryList.ZRETURN = returnDeli;
            returnList.Add(resultDeliveryList);
        }

        protected void AddGoodsIssueDeliveryList(List<GoodsIssueDeliveryOutput> goodsList, XmlDocument doc)
        {

            var rootNode = "/root";
            var deliNode = "/ZITEM/item";

            GoodsIssueDeliveryInput goodsIssueDeliveryInput = new GoodsIssueDeliveryInput();

            GoodsIssueDeliveryOutput goodsIssueDeliveryOutput = new GoodsIssueDeliveryOutput();

            foreach (XmlNode itemNode in doc.SelectNodes(rootNode + deliNode))
            {
                ZITEM item = new ZITEM(itemNode);
                goodsIssueDeliveryInput.ZITEM = item;
            }

            ExtractKeyGoodsIssue(goodsIssueDeliveryInput, doc, rootNode);

            /*goodsIssueDeliveryOutput

            goodsList.Add();*/
        }

        protected static void ExtractKeyInput(DeliveryList delivery, XmlDocument doc, string rootNode)
        {
            foreach (XmlNode inputNode in doc.SelectNodes(rootNode))
            {
                delivery.ZKEY = inputNode["ZKEY"].InnerText;
                delivery.MESSAGE_ID = inputNode["MESSAGE_ID"].InnerText;
            }
        }

        protected static void ExtractKeyInputReturn(ResultDeliveryList result, XmlDocument doc, string rootNode, bool returnDoc)
        {
            foreach (XmlNode inputNode in doc.SelectNodes(rootNode))
            {
                result.ZKEY = inputNode["ZKEY"].InnerText;

                if (returnDoc)
                {
                    result.MESSAGE_ID_SEND = inputNode["MESSAGE_ID_SEND"].InnerText;
                    result.MESSAGE_ID_BACK = inputNode["MESSAGE_ID_BACK"].InnerText;
                }
                else
                {
                    result.MESSAGE_ID_SEND = inputNode["MESSAGE_ID"].InnerText;
                }
            }
        }

        protected static void ExtractKeyGoodsIssue(GoodsIssueDeliveryInput goodsIssueInput, XmlDocument doc, string rootNode)
        {
            foreach (XmlNode inputNode in doc.SelectNodes(rootNode))
            {
                goodsIssueInput.IM_VENDOR = inputNode["IM_VENDOR"].InnerText;
                goodsIssueInput.DELIVERY_NUMBER = inputNode["DELIVERY_NUMBER"].InnerText;
                goodsIssueInput.GOODS_ISSUE_DATE = inputNode["GOODS_ISSUE_DATE"].InnerText;
                goodsIssueInput.GOODS_ISSUE_TIME = inputNode["GOODS_ISSUE_TIME"].InnerText;
            }
        }

        protected void ExtractShipment(DeliveryList delivery, XmlDocument doc, string rootNode)
        {
            var shipNode = "/ZSHIPMENT/item";

            foreach (XmlNode shipmentNode in doc.SelectNodes(rootNode + shipNode))
            {
                ZSHIPMENT deliveryShipment = new ZSHIPMENT(shipmentNode);
                delivery.ZSHIPMENT = deliveryShipment;
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