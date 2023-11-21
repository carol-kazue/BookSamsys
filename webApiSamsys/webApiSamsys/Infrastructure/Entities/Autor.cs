using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webApiSamsys.Infrastructure.Entities
{
    public class Autor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
            public int IdAutor { get; set; }

            [Column(TypeName = "varchar (50)")]
            public string Nome { get; set; }

        
    }
}
