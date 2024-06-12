using Microsoft.EntityFrameworkCore;
using perpusku_api.Common;
using perpusku_api.Common.Classes;
using perpusku_api.Common.Helpers;
using perpusku_api.Depedencies.IServices;
using perpusku_api.Model.Data.Books;
using perpusku_api.Model.DTO;
using perpusku_api.Model.Enum.MasterData;

public class BookServices : IBookServices
{
    #region initializers
    readonly DataContext _dt;
    #endregion
    public BookServices(DataContext context)
    {
        _dt = context;
    }

    public IEnumerable<GenreDTO> GetAllGenres()
    {
        return Enum.GetValues(typeof(BookGenre))
        .Cast<BookGenre>()
                   .Select(e => new GenreDTO { ID = (int)e, Name = e.GetStringValue() });
    }
    public async Task<MessageClass> GetBookList()
    {   
        var result = new MessageClass();
        var bookData = new List<BookListDTO>();

        foreach (var data in await _dt.Books.ToListAsync())
        {
            bookData.Add(new BookListDTO
            {
                ID = data.Id,
                Author = data.Author,
                Description = data.Description,
                GenreID = (BookGenre)Enum.Parse(typeof(BookGenre), data.Genre),
                Genre = ((BookGenre)Enum.Parse(typeof(BookGenre), data.Genre)).ToString(),
                Name = data.Name
            });
        };

        result.Code = ErrorCodes.OK;
        result.Message = "Data loaded successfully";
        result.Data = bookData;
        return result;
    }
    public async Task<MessageClass> SaveData(BookDTO data)
    {
        var result = new MessageClass();

        try
        {
            data.Id = BookGenreExtensions.GetGuid();
            _dt.Books.Add(data);

            await _dt.SaveChangesAsync();

            result.Code = ErrorCodes.OK;
            result.Message = "Data Saved Successfully";

        }
        catch(Exception err)
        {

            result.Code = ErrorCodes.Error;
            result.Message = err.Message;

        }

        return result;
    }
    public async Task<MessageClass> EditData(BookDTO data)
    {
        var result = new MessageClass();

        try
        {
            data.Id = BookGenreExtensions.GetGuid();
            _dt.Books.Add(data);

            await _dt.SaveChangesAsync();

            result.Code = ErrorCodes.OK;
            result.Message = "Data Saved Successfully";

        }
        catch (Exception err)
        {

            result.Code = ErrorCodes.Error;
            result.Message = err.Message;

        }

        return result;
    }
}