using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using perpusku_api.Common.Classes;
using perpusku_api.Depedencies.IServices;
using perpusku_api.Model.DTO;

[ApiController]
[Route("api/v1/[controller]")]
public class Users : ControllerBase
{
    private readonly IUserService _userService;

    public Users(IUserService userService)
    {
        _userService = userService;
    }

    #region get section

    [HttpGet("")]
    [Authorize]
    public async Task<IActionResult> GetAccountData([FromQuery] string userID)
    {
        var result = await _userService.GetAccountData(userID);
        return Ok(result);
    }
    [HttpGet("/list")]
    [Authorize]
    public async Task<IActionResult> GetAccountList()
    {
        var result = await _userService.GetAccountList();
        return Ok(result);
    }

    #endregion

    #region post section

    [HttpPost("")]
    public async Task<IActionResult> SignIn(AuthDTO data)
    {
        var result = await _userService.SignIn(data);
        return Ok(result);
    }

    [HttpPost("/create")]
    public async Task<IActionResult> CreateAccount([FromBody] AuthDTOCreate data)
    {
        var result = await _userService.CreateAccount(data);
        return Ok(result);
    }

    #endregion

    #region put section
    [HttpPut("")]
    [Authorize]
    public async Task<IActionResult> UpdateAccount(AuthDTOCreate data)
    {
        var result = await _userService.UpdateAccount(data);
        return Ok(result);
    }
    #endregion

    #region delete section
    #endregion
}
