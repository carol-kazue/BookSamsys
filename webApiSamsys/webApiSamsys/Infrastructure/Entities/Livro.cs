using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webApiSamsys.Infrastructure.Entities
{
    public class Livro
    {

        [Key]
        [Column(TypeName = "varchar (50)")]
        public string ISBN { get; set; }

        [Column(TypeName = "varchar (50)")]
        public string Nome { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
    }
}
