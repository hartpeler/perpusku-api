using perpusku_api.Common;
using perpusku_api.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace perpusku_api.Model.Data.Auth
{
    public class User : TimeStamp
    {
        [Key]
        public string? ID { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Roles Roles { get; set; }
    }
}
