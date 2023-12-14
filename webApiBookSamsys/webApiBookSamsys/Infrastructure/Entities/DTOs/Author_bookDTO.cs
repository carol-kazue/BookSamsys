using System.ComponentModel.DataAnnotations.Schema;

namespace webApiBookSamsys.Infrastructure.Entities.DTOs
{
    public class Author_bookDTO
    {
        public string ISBN { get; set; }

        public long IdAuthor { get; set; }
    }
}
