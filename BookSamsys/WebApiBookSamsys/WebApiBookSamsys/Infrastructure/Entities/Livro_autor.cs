using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WepApiBookSamsys.Infrastructure.Entities
{
    public class Livro_autor
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Livro")]
        public int ISBN { get; set;}
        [ForeignKey("Autor")]
        public int IdAutor { get; set; }
    }
}