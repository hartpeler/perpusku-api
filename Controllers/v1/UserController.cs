using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        return Ok(genres); // Returns JSON array of GenreDto objects
    }

    #endregion

    #region post section
    #endregion

    #region put section
    #endregion

    #region delete section
    #endregion
}
