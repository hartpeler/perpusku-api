using perpusku_api.Common.Classes;
using perpusku_api.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace perpusku_api.Model.Data.Auth
{
    public class User : TimeStamp
    {
        [Key]
        public required string ID { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public Roles Roles { get; set; }
    }
}
