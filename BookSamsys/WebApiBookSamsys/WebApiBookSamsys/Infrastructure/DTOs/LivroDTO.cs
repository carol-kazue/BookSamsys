using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiBookSamsys.Infrastructure.DTOs
{
    public class LivroDTO
    {
        public int ISBN { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

    }
}
