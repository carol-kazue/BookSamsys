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

const ActionCell =({book, onDelete}: {book: BookType, onDelete: (isbn:string)=>void, /*onBookByIsbn: (isbn:string)=>void*/} ) =>(
  <div className="text-center">
    <Button 
      onClick={() => {
        onDelete(book.isbn);  // Passa o isbn do livro para a função de exclusão
      }} 
      text="Apagar" 
      type="button"
      color="reset"
    />
    <Link to={`livro/${book.isbn}`}
     text="Editar" color="primary"/>
  </div>
)

const booksTransformer =(books: BookType[] | null, onDelete:(isbn:string)=>void): BookTableDataType[] => {
  if(!books){
    return []
  }
  return books.map((book:BookType):BookTableDataType =>({...book,action: (() => (<ActionCell book={book} onDelete={onDelete}/>)) as unknown as ReactNode}))
}
const columns = ['isbn', 'name', 'price', 'action'];

function Books() {
  const [books, setBooks] = useState<BookType[] | null>(null);
 

  useEffect(() => {
      fetchBooks().then(result=>{
      setBooks(result?.obj)
      })
    }, 
    []);
    const handleDelete = async (bookIsbn:string) => {
      // Chama a função para excluir o livro
      await deleteBook(bookIsbn);
      // Atualiza a lista de livros após a exclusão
      const updatedBooks = await fetchBooks();
      setBooks(updatedBooks?.obj);
    };

    return (
      
      <div className="container mb-2 Books">
       
        <br/>
        <div className="d-flex align-items-center justify-content-center row">
            <h1 className="text-center">Lista de livros</h1>
        </div>
          <div className="search container d-flex align-items-center justify-content-center row">
            <div className="col-6 ">
              <Input type="text" id="form-control" value={""} onChange={()=>{}} ></Input>
            </div>
            <div className="button-search text-center mt-2 col-2">
              <Button text="Pesquisar" type="submit" onClick={()=>{}} color="submit"></Button>
            </div>
          </div>
        <Table data={booksTransformer(books,handleDelete)} columns={columns}/>
        </div>
    );
  }
export default Books;