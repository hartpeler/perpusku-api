using perpusku_api.Model.Enum;
using perpusku_api.Model.Enum.MasterData;
using System.Diagnostics.CodeAnalysis;

namespace perpusku_api.Model.DTO
{
    public class BookListDTO
    {
        public string? ID { get; set; }
        [AllowNull]
        public string Name { get; set; }
        [AllowNull]
        public string Description { get; set; }
        [AllowNull]
        public string Author { get; set; }
        [AllowNull]
        public string Genre { get; set; }
        public BookGenre GenreID { get; set; }
        public Status Status { get; set; }
    }
}
