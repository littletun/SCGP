namespace SCGPServiceGetDeliveryList.Models
{
    public class ZRETURN
    {
        public ZRETURN(string dELIVERY_NUMBER, string dELIVERY_ITEM_NO, string sTATUS_TYPE, string eRROR_CODE, string eRROR_MESSAGE)
        {
            DELIVERY_NUMBER = dELIVERY_NUMBER;
            DELIVERY_ITEM_NO = dELIVERY_ITEM_NO;
            STATUS_TYPE = sTATUS_TYPE;
            ERROR_CODE = eRROR_CODE;
            ERROR_MESSAGE = eRROR_MESSAGE;
        }

        public string DELIVERY_NUMBER { get; set; }
        public string DELIVERY_ITEM_NO { get; set; }
        public string STATUS_TYPE { get; set; }
        public string ERROR_CODE { get; set; }
        public string ERROR_MESSAGE { get; set; }
    }
}
