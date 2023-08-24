using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.ComponentModel.DataAnnotations;

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

        [StringLength(24)]
        public string? ZKEY { get; set; }
        [StringLength(40)]
        public string MESSAGE_ID_SEND { get; set; }
        [StringLength(40)]
        public string MESSAGE_ID_BACK { get; set; }

        [Required]
        public ZRETURN? ZRETURN { get; set; }
    }
}
