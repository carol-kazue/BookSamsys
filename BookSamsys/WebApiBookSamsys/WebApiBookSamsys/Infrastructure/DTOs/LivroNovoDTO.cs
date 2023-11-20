using WepApiBookSamsys.Infrastructure.Entities;

namespace WebApiBookSamsys.Infrastructure.DTOs
{
    public class LivroNovoDTO   
    {
        public int ISBN { get; set; }
        public string Nome { get; set; }
        public ICollection<AutorDTO> Autores { get; set; }
        public decimal Preco { get; set; }
    }
}
