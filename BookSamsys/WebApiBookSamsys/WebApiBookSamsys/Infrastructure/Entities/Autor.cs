using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WepApiBookSamsys.Infrastructure.Entities
{
    public class Autor
    {
        [Key]
        public int IdAutor  { get; set; }

        [Column(TypeName = "varchar (50)")]
        public string Nome { get; set; }

    }
}