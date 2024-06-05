using perpusku_api.Common;
using perpusku_api.Depedencies.IServices;
using perpusku_api.Model.DTO;
using perpusku_api.Model.Enum.MasterData;
using System.Reflection;

public class BookServices : IBookServices
{
    public IEnumerable<GenreDTO> GetAllGenres()
    {
        return Enum.GetValues(typeof(BookGenre))
        .Cast<BookGenre>()
                   .Select(e => new GenreDTO { ID = (int)e, Name = e.GetStringValue() });
    }

}