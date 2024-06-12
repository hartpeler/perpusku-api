using perpusku_api.Common.Classes;
using perpusku_api.Model.Data.Books;
using perpusku_api.Model.DTO;

namespace perpusku_api.Depedencies.IServices
{
    public interface IBookServices
    {
        IEnumerable<GenreDTO> GetAllGenres();
        Task<MessageClass> SaveData(BookDTO data);
        Task<MessageClass> GetBookList();
        Task<MessageClass> EditData(BookDTO data);
    }

}
