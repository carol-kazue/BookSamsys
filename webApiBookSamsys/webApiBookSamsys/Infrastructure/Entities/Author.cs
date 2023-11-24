using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace webApiBookSamsys.Infrastructure.Entities
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdAuthor { get; set; }  

        [Column(TypeName = "varchar (50)")]
        public string Name { get; set; }    
    }
}