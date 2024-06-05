using perpusku_api.Model.Enum;
using perpusku_api.Model.Enum.MasterData;

namespace perpusku_api.Model.DTO
{
    public class BookListDTO
    {
        public string ID { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public BookGenre GenreID { get; set; }
        public Status Status { get; set; }
    }
}
