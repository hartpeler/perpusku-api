using perpusku_api.Common;
using System.ComponentModel.DataAnnotations;

namespace perpusku_api.Model.Data.Transactions
{
    public class Transactioncs :TimeStamp
    {
        [Key]
        public string? ID { get;set; }
        public string? UserID { get; set; }

    }
}
