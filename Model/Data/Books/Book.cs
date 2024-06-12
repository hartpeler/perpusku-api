using perpusku_api.Common.Classes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace perpusku_api.Model.Data.Books
{
    public class Book : TimeStamp
    {
        [Key]
        public string? Id { get; set; }
        public string? Name { get; set; }
        [AllowNull]
        public string Description { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
    }
}
