using Microsoft.EntityFrameworkCore;
using perpusku_api.Common;
using perpusku_api.Common.Classes;
using perpusku_api.Common.Helpers;
using perpusku_api.Depedencies.IServices;
using perpusku_api.Model.Data.Auth;
using perpusku_api.Model.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class UserServices : IUserService
{
    #region initializers
    readonly DataContext _dt;
    readonly JwtService _token;
    #endregion

    #region constructors
    public UserServices(DataContext context, JwtService token)
    {
        _dt = context;
        _token = token;
    }

    #endregion

    private async Task<int> GetUserCount()
    {
        var data = await _dt.Users.CountAsync();
        return data;
    }

    public async Task<MessageClass> SignIn(AuthDTO data)
    {
        var result = new MessageClass();

        try
        {
            var userCount = await GetUserCount();

            if (userCount == 0)
            {
                result.Message = "Invalid Username/Password";
                result.Code = ErrorCodes.NotFound;
                return result;
            }
            else
            {
                var checkUser = await _dt.Users.Where(
                    q =>
                    q.Email.Equals(data.Email)).FirstOrDefaultAsync();
              
                
                if(checkUser == null)
                {
                    result.Message = "User not found";
                    result.Code = ErrorCodes.NotFound;
                    return result;
                }
                else
                {

                    if (PWEncrypt.VerifyPassword(data.Password, checkUser.Password) == false)
                    {
                        result.Message = "Invalid Username/Password";
                        result.Code = ErrorCodes.NotFound;
                        return result;
                    }
                }

                result.Data = _token.GenerateJwtToken(checkUser.ID);
                result.Message = "Auth Success";
                result.Code = ErrorCodes.OK;
            }

           
        }
        catch (Exception err)
        {
            result.Message = err.Message.ToString();
            result.Code = ErrorCodes.Error;
        }

        return result;
    }

    public async Task<MessageClass> CreateAccount(AuthDTOCreate data)
    {
        var result = new MessageClass();
        try
        {
                var checkUser = await _dt.Users.Where(
                   q =>
                   q.Email.Equals(data.Email)).FirstOrDefaultAsync();
                
                if(checkUser != null)
                {
                    result.Message = "Email already exists!";
                    result.Code = ErrorCodes.Forbidden;
                    return result;
                }

                data.Password = PWEncrypt.HashPassword(data.Password);
                data.ID = BookGenreExtensions.GetGuid();
                data.CreatedOn = DateTime.Now;
                data.CreatedBy = data.ID;
                data.LastUpdatedOn = DateTime.Now;
                data.LastUpdatedBy = data.ID;

                _dt.Users.Add(data);
                await _dt.SaveChangesAsync();
                
                data.Token = _token.GenerateJwtToken(data.ID);
                data.Password = "";

                result.Data = data;
                result.Message = "Data Saved";
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

        try
        {
            var userCount = await GetUserCount();

            if (userCount == 0)
            {
                result.Message = "User Not Found!";
                result.Code = ErrorCodes.NotFound;
                return result;
            }
            else
            {
                var checkUser = await _dt.Users.Where(
                    q =>
                    q.Email.Equals(data.Email)).FirstOrDefaultAsync();

                if(checkUser == null )
                {
                    result.Message = "User Not Found!";
                    result.Code = ErrorCodes.NotFound;
                    return result;
                }

                data.Password = PWEncrypt.HashPassword(data.Password);
                data.CreatedOn = DateTime.Now;
                data.CreatedBy = data.ID;
                data.LastUpdatedOn = DateTime.Now;
                data.LastUpdatedBy = data.ID;

                _dt.Users.Update(data);
                await _dt.SaveChangesAsync();

                data.Token = _token.GenerateJwtToken(checkUser.ID);
                data.Password = "";
                result.Data = data;
                result.Message = "Data Updated";
                result.Code = ErrorCodes.OK;



            }
        }
        catch (Exception err)
        {

            result.Message = err.Message.ToString();
            result.Code = ErrorCodes.Error;
        }

        return result;
    }
    public async Task<MessageClass> GetAccountData(string userID)
    {
        var result = new MessageClass();

        try
        {
            var checkUser = await _dt.Users.Where(
            q =>
                q.ID.Equals(userID)).AsNoTracking().FirstOrDefaultAsync();

            var userCount = await GetUserCount();

            if (checkUser == null || userCount == 0)
            {
                result.Message = "User Not Found!";
                result.Code = ErrorCodes.NotFound;
                return result;
            }
            checkUser.Password = "";
            result.Data = checkUser;
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

    public async Task<MessageClass> GetAccountList()
    {
        var result = new MessageClass();

        try
        {
            var checkUser = await _dt.Users.AsNoTracking().ToListAsync();
            
            foreach(var data in checkUser)
            {
                data.Password = "";
            }

            result.Data = checkUser;
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