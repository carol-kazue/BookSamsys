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
import { Tabs } from "../../components/Tabs/Tabs";

const ActionCell =({book, onDelete}: {book: BookType, onDelete: (isbn:string)=>void, /*onBookByIsbn: (isbn:string)=>void*/} ) =>(
  <div>
    <Button 
      onClick={() => {
        console.log(book.name, "deletar");
        onDelete(book.isbn);  // Passa o isbn do livro para a função de exclusão
      }} 
      text="Apagar" 
      type="button"
      color="reset"
    />
    <Link href={`editar-livro/${book.isbn}`}
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
        <Tabs active></Tabs>
        <br />
        <div className=" m-5">
        <h1>Lista de livros</h1>
        </div>
        <Table data={booksTransformer(books,handleDelete)} columns={columns}/>
        </div>
    );
  }
export default Books;