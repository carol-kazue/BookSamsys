using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webApiSamsys.Infrastructure.Entities
{
    public class Autor_livro
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Livro")]
        public string ISBN { get; set; }
        [ForeignKey("Autor")]
        public int IdAutor { get; set; }
    }
}
