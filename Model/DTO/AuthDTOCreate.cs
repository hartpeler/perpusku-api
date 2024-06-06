using perpusku_api.Model.Data.Auth;

namespace perpusku_api.Model.DTO
{
    public class AuthDTOCreate : User
    {
        public string? Token { get;set; }
    }
}
