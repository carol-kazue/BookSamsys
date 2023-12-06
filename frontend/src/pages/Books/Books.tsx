import { Link } from "../../components/Link/Link";
import { Button } from '../../components/Button/Button';
import { Input } from '../../components/Input/Input';
import React, { useState, useEffect } from 'react';

import  "bootstrap/dist/css/bootstrap.min.css";
import { Table} from "../../components/Table/Table";
import { BookType } from "../../Types/Books.types";
import { BookTableDataType } from "./Books.types";
import { ReactNode } from "react";
import {deleteBook, fetchBooks, postBook } from "../../service/BookApi";
/*const books:BookType[] = [
  { isbn: "1", name: 'Item 1', price: 20.99 },
  { isbn: "2", name: 'Item 2', price: 15.99 },
  { isbn: "3", name: 'Item 3', price: 25.99 },
];*/
const ActionCell =({book, onDelete}: {book: BookType, onDelete: (isbn:string)=>void},  ) =>(
  <div>
    <Button 
      onClick={() => {
        console.log(book.name, "deletar");
        onDelete(book.isbn);  // Passa o ID do livro para a função de exclusão
      }} 
      text="Apagar" 
      type="button"
      color="reset"
    />
    <Link href="#" text="Editar" color="primary"/>
  </div>
)

const booksTransformer =(books: BookType[] | null, onDelete:(isbn:string)=>void ): BookTableDataType[] => {
  if(!books){
    return []
  }
  return books.map((book:BookType):BookTableDataType =>({...book,action: (() => (<ActionCell book={book} onDelete={onDelete} />)) as unknown as ReactNode}))
}
const columns = ['isbn', 'name', 'price', 'action'];
function Books() {
  // useState com a lista de livros e useEfect 
  const [books, setBooks] = useState<BookType[] | null>(null);
  const [newBook, setNewBook] = useState<BookType>({ isbn: '', name: '', price: 0 });


  useEffect(() => {
      fetchBooks().then(result=>{
      setBooks(result?.obj)
      })
    }, 
    []);
    const handleDelete = async (bookId:string) => {
      // Chama a função para excluir o livro
      await deleteBook(bookId);
  
      // Atualiza a lista de livros após a exclusão
      const updatedBooks = await fetchBooks();
      setBooks(updatedBooks?.obj);
    };

    const handlePost =async (book:BookType) => {
      await postBook(book);
      console.log(book)
      const updatedBooks = await fetchBooks();
      setNewBook({ isbn: '', name: '', price: 1 })
      setBooks(updatedBooks?.obj);
      
    }
  
    return (
      <div className="container text-center Books">
        <br />
        <div className="col m-5">
          <h1>BookSamsys</h1>
        </div>
        <div className="col">
        <Input 
          type='isbn' 
          id='floatingInput' 
          label="ISBN" 
          placeholder='isbn' 
          value={newBook.isbn} 
          onChange={(e) => setNewBook({ ...newBook, isbn: e.target.value })}
        ></Input>
        <Input 
          type='livro' 
          id='floatingInput' 
          label="Nome do livro" 
          placeholder='Nome do livro' 
          value={newBook.name}
          onChange={(e) => setNewBook({ ...newBook, name: e.target.value })}
        ></Input>
        <Input 
          type='number' 
          id='floatingInput' 
          label="Preço" 
          placeholder='Preço' 
          value={newBook.price}
          onChange={(e) => setNewBook({ ...newBook, price: e.target.valueAsNumber})}
        ></Input>
        <Button text='Adicionar livro' type="submit" onClick={() => handlePost(newBook)} color='submit'></Button>
        
        </div>
        <div className=" m-5">
        <h1>Lista de livros</h1>
        </div>
        <Table data={booksTransformer(books,handleDelete)} columns={columns}/>
        </div>
    );
  }
export default Books;