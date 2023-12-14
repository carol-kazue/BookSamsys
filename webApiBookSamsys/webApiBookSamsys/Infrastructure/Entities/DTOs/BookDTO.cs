using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webApiBookSamsys.Infrastructure.Entities.DTOs
{
    public class BookDTO
    {
        internal string ErrorMessage;

        public string ISBN { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<long> authorId { get; set; }
    }

    
}


