using perpusku_api.Common.Classes;
using perpusku_api.Model.DTO;

namespace perpusku_api.Depedencies.IServices
{
    public interface IUserService
    {
        Task<MessageClass> SignIn(AuthDTO data);
        Task<MessageClass> CreateAccount(AuthDTOCreate data);
        Task<MessageClass> UpdateAccount(AuthDTOCreate data);
        Task<MessageClass> GetAccountData(string userID);
        Task<MessageClass> GetAccountList();
    }
}
