using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WepApiBookSamsys.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using WebApiBookSamsys.Infrastructure.DTOs;
using static WebApiBookSamsys.Infrastructure.MenssageHelper;
using Microsoft.AspNetCore.Http.HttpResults;
using Azure;

namespace WebApiBookSamsys.Infrastructure.Services
{
    public class LivroService
    {

        private readonly BookSamsysContext _context;

        public LivroService(BookSamsysContext context)
        {
            _context = context;
        }
        /**
         * 
         */
        public async Task<MessageHelper<IEnumerable<Livro>>> GetLivros()
        {
            var response = new MessageHelper<IEnumerable<Livro>>();
            string errorMessage = "Ocorreu um erro enquanto era buscado o dado";
            var livros = await _context.Livros
            .Select(checarLivro => new Livro
             {
                 ISBN = checarLivro.ISBN,
                 Nome = checarLivro.Nome,
                 Preco = checarLivro.Preco,
             })
            .ToListAsync();

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

        public async Task<MessageHelper<IEnumerable<LivroDTO>>> GetLivro(int isbn)
        {
            var response = new MessageHelper<IEnumerable<LivroDTO>>();

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
                var livrosDTO = checarLivros.Select(checarLivro => new LivroDTO
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

        public async Task<MessageHelper<IEnumerable<LivroDTO>>> PostLivro(LivroNovoDTO livro)
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

    }
}
