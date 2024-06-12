using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using perpusku_api.Common.Classes;
using perpusku_api.Depedencies.IServices;
using perpusku_api.Model.DTO;

[ApiController]
[Route("api/v1/[controller]")]
public class Books : ControllerBase
{
    private readonly IBookServices _bookGenreService;

    public Books(IBookServices bookGenreService)
    {
        _bookGenreService = bookGenreService;
    }

    #region get section

    [HttpGet("genres")]
    [Authorize]
    public IActionResult GetGenres()
    {
        IEnumerable<GenreDTO> genres = _bookGenreService.GetAllGenres();
        return Ok(genres);
    }


    [HttpGet("")]
    [Authorize]
    public async Task<MessageClass> GetBookList()
    {
        MessageClass list = await _bookGenreService.GetBookList();
        return list;
    }
    #endregion

    #region post section
    [HttpPost()]
    [Authorize]
    public async Task<MessageClass> PostBooks([FromBody] BookDTO request)
    {
        MessageClass submit = await _bookGenreService.SaveData(request);
        return submit;
    }
    #endregion

    #region put section
    [HttpPut()]
    [Authorize]
    public async Task<MessageClass> PutBooks([FromBody] BookDTO request)
    {
        MessageClass submit = await _bookGenreService.EditData(request);
        return submit;
    }
    #endregion

    #region delete section
    #endregion
}
