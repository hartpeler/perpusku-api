using perpusku_api.Model.DTO;

namespace perpusku_api.Depedencies.IServices
{
    public interface IBookServices
    {
        IEnumerable<GenreDTO> GetAllGenres();
    }

}
