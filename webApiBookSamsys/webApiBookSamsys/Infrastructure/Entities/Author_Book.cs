using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace webApiBookSamsys.Infrastructure.Entities
{
    public class Author_Book
    {
        [Key]
        public long id { get; set; }    

        [ForeignKey("Book")]
        public string ISBN { get; set; }    

        [ForeignKey("Author")]
        public long IdAuthor { get; set; }  
        
    }
}