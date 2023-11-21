using webApiSamsys.Infrastructure.Entities;
using webApiSamsys.Infrastructure.Repository;
using static webApiSamsys.Infrastructure.MessengerHelper.MessengerHelper;

namespace webApiSamsys.Infrastructure.Services
{
    public class LivroService
    {
        private readonly LivroRepository _livroRepository;  

        public LivroService(LivroRepository livroRepository)    
        {
            _livroRepository = livroRepository;
        }
        /**
         * 
         */
        public async Task<MessangingHelper<IEnumerable<Livro>>> GetLivros()
        {
            var response = new MessangingHelper<IEnumerable<Livro>>();
            string errorMessage = "Ocorreu um erro enquanto era buscado o dado";
            var livros = await _livroRepository.GetLivros();

            if (livros != null)
            {
                response.Obj = livros;
                response.Success = true;
                return response;

            }
            response.Success = false;
            response.Message = errorMessage;
            return response;
        }
        /*
        public async Task<MessangingHelper<IEnumerable<Livro>>> GetLivro(int isbn)
        {
            var response = new MessangingHelper<IEnumerable<Livro>>();

            string livroEncontrado = "Livro encontrado";
            string livroNaoEncontrado = " Livro não encontrado";
            string listaVazia = "Lista de livros vazia";

            // métodos de busca do ef framework diretamente da tabela;
            var checarLivros = await _context.Livros
                .Where(livro => livro.ISBN == isbn)
                .ToListAsync();

            if (checarLivros.Any())
            {
                // Mapeia os livros encontrados para DTOs
                var livrosDTO = checarLivros.Select(checarLivro => new Livro
                {
                    ISBN = checarLivro.ISBN,
                    Nome = checarLivro.Nome,
                    Preco = checarLivro.Preco
                }).ToList();

                response.Obj = livrosDTO;
                response.Success = true;
                return response;
            }
            else
            {
                response.Success = false;
                response.Message = listaVazia;
                return response;
            }
        }

        public async Task<MessangingHelper<IEnumerable<Livro>>> PostLivro(livro livro)
        {
            var checarAutor = await _context.Autores
            .Where(autor => autor.Nome == livro.Autores)
            .ToListAsync();

            if (checarAutor.Any())
            {
                var novoLivro = new Livro()
                {
                    ISBN = livro.ISBN,
                    Nome = livro.Nome,
                    Preco = livro.Preco
                };
            }
        }
        */
    }
}
