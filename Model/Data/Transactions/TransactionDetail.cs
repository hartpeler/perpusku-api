using perpusku_api.Common;
using perpusku_api.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace perpusku_api.Model.Data.Transactions
{
    public class TransactionDetail :TimeStamp
    {
        [Key]
        public string? ID { get;set; }
        public string? TransactionID { get;set; }
        public string? BookID { get;set; }
        public Status Status { get; set; }

    }
}
