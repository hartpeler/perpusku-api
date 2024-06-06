using Microsoft.EntityFrameworkCore;
using perpusku_api.Common;
using perpusku_api.Common.Classes;
using perpusku_api.Common.Helpers;
using perpusku_api.Depedencies.IServices;
using perpusku_api.Model.Data.Auth;
using perpusku_api.Model.DTO;

public class UserServices : IUserService
{
    #region initializers
    readonly DataContext _dt;
    readonly JwtService _token;
    #endregion
    public async Task<MessageClass> SignIn(AuthDTO data)
    {
        var result = new MessageClass();

        try
        {
            var checkUser = await _dt.Users.Where(
                q =>
                q.Email.Equals(data.Email) &&
                PWEncrypt.VerifyPassword(data.Password, q.Password) == true).FirstOrDefaultAsync();
            
            if (checkUser == null)
            {
                result.Message = "Invalid Username/Password";
                result.Code = ErrorCodes.NotFound;
                return result;
            }

            result.Data = _token.GenerateJwtToken(checkUser.ID);
            result.Message = "Auth Success";
            result.Code = ErrorCodes.OK;
        }
        catch(Exception err)
        {

            result.Message = err.Message.ToString();
            result.Code = ErrorCodes.Error;
        }

        return result;
    }

    public async Task<MessageClass> CreateAccount(AuthDTOCreate data)
    {
        var result = new MessageClass();
        var output = new AuthDTOCreate();
        try
        {
            var checkUser = await _dt.Users.Where(
                q =>
                q.Email.Equals(data.Email)).FirstOrDefaultAsync();

            if (checkUser != null)
            {
                result.Message = "Email already exists!";
                result.Code = ErrorCodes.Forbidden;
                return result;
            }

            data.ID = BookGenreExtensions.GetGuid();
            data.CreatedOn = DateTime.Now;
            data.CreatedBy = data.ID;
            data.LastUpdatedOn = DateTime.Now;
            data.LastUpdatedBy = data.ID;

            _dt.Users.Add(data);

            data.Token = _token.GenerateJwtToken(checkUser.ID);
            data.Password = null;

            result.Data = data;
            result.Message = "Auth Success";
            result.Code = ErrorCodes.OK;
        }
        catch (Exception err)
        {

            result.Message = err.Message.ToString();
            result.Code = ErrorCodes.Error;
        }

        return result;
    }

    public async Task<MessageClass> UpdateAccount(AuthDTOCreate data)
    {
        var result = new MessageClass();
        var output = new AuthDTOCreate();

        try
        {
            var checkUser = await _dt.Users.Where(
                q =>
                q.Email.Equals(data.Email)).FirstOrDefaultAsync();

            if (checkUser == null)
            {
                result.Message = "User Not Found!";
                result.Code = ErrorCodes.NotFound;
                return result;
            }

            data.ID = BookGenreExtensions.GetGuid();
            data.CreatedOn = DateTime.Now;
            data.CreatedBy = data.ID;
            data.LastUpdatedOn = DateTime.Now;
            data.LastUpdatedBy = data.ID;

            _dt.Users.Add(data);

            data.Token = _token.GenerateJwtToken(checkUser.ID);

            result.Data = data;
            result.Message = "Auth Success";
            result.Code = ErrorCodes.OK;
        }
        catch (Exception err)
        {

            result.Message = err.Message.ToString();
            result.Code = ErrorCodes.Error;
        }

        return result;
    }
}