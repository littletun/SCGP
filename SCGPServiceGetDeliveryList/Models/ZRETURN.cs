using System.ComponentModel.DataAnnotations;

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
