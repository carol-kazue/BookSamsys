using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WepApiBookSamsys.Infrastructure.Entities
{
    public class Livro
    {
        [Key]
        public int ISBN { get; set; }

        [Column(TypeName = "varchar (50)")]
        public string Nome { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        
    }
}