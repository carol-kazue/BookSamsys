using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<MessangingHelper<IEnumerable<Livro>>> GetBooks()  
        {
            MessangingHelper<IEnumerable<Livro>> response = new();
            string errorMessage = "Ocorreu um erro enquanto era buscado o livro";
            try
            {
                var livros = await _livroRepository.GetAllBook();

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
            catch (Exception)
            {
                response.Success = false;
                response.Message = errorMessage;
                return response;
                throw;
            }
        }
        
        public async Task<MessangingHelper<IEnumerable<Livro>>> GetBook(int isbn)       
        {
            MessangingHelper<IEnumerable<Livro>> response = new();
            string livroEncontrado = "Livro encontrado";
            string livroNaoEncontrado = "Livro não encontrado";
            string listaVazia = "Lista de livros vazia";
            try
            {
                if(isbn.ToString().Length != 13)
                {
                   response.Message= "Isbn precisa ter 13 caracteres";
                   return response;
                }

                var livroObj = await _livroRepository.GetBookById(isbn);
                if (livroObj != null)
                {
                    response.Obj = livroObj;
                    response.Success = true;
                    response.Message = livroEncontrado;
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = listaVazia;
                    return response;
                }
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = listaVazia;
                return response;
                throw;
            }
        }
        
        public async Task<MessangingHelper<Livro>>AddBook(Livro novoLivro)     
        {
            MessangingHelper<Livro> response = new();


            if (novoLivro.ISBN.ToString().Length == 13 || novoLivro.Preco >0 || novoLivro.Nome.Length > 0 || novoLivro != null)
            {
                var checarSeExiste = _livroRepository.GetBookById(novoLivro.ISBN);
                if(checarSeExiste == null)
                {
                    response.Success = true;
                    response.Message = "Livro adicionado com sucesso";
                    await _livroRepository.AddOneBook(novoLivro);
                    return response;
                }
                else
                {

                    response.Success = false;
                    response.Message = "livro já existe";
                    return response;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Os campos precisam ser escritos corretamente";
                return response;
            }
        }
        
    }
}
