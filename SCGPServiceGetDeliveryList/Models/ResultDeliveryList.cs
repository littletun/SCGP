using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace SCGPServiceGetDeliveryList.Models
{
    public class ResultDeliveryList
    {
        public ResultDeliveryList(string zKEY, string mESSAGE_ID_SEND, string mESSAGE_ID_BACK, ZRETURN zRETURN)
        {
            ZKEY = zKEY;
            MESSAGE_ID_SEND = mESSAGE_ID_SEND;
            MESSAGE_ID_BACK = mESSAGE_ID_BACK;
            ZRETURN = zRETURN;
        }

        public string ZKEY { get; set; }
        public string MESSAGE_ID_SEND { get; set; }
        public string MESSAGE_ID_BACK { get; set; }
        
        public ZRETURN ZRETURN { get; set; }
    }
}
