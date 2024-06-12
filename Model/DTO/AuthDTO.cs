using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace perpusku_api.Model.DTO
{
    public class AuthDTO
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
