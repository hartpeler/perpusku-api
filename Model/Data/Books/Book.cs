using perpusku_api.Common;
using System.ComponentModel.DataAnnotations;

namespace perpusku_api.Model.Data.Books
{
    public class Book : TimeStamp
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
    }
}
