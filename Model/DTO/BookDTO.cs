using perpusku_api.Model.Data.Books;

namespace perpusku_api.Model.DTO
{
    public class BookDTO : Book
    {
        public required string ID { get; set; }
    }
}
