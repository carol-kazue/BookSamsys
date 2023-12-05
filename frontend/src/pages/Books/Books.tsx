import { Link } from "../../components/Link/Link";
import { Button } from '../../components/Button/Button';
import { Input } from '../../components/Input/Input';

import  "bootstrap/dist/css/bootstrap.min.css";
import { Table, TableIndex } from "../../components/Table/Table";
import { BookType } from "../../Types/Books.types";
import { BookTableDataType } from "./Books.types";
import { ReactNode } from "react";
const books:BookType[] = [
  { isbn: "1", name: 'Item 1', price: 20.99 },
  { isbn: "2", name: 'Item 2', price: 15.99 },
  { isbn: "3", name: 'Item 3', price: 25.99 },
];
const ActionCell =({book}: {book: BookType}) =>(
  <div>
    <Button 
      onClick={()=>(console.log(book.name, "deletar"))} 
      text="delete" 
      type="button"
      color="reset"
    />
    <Link href="#" text="Edit" color="secondary"/>
  </div>
)

const booksTransformer =(books: BookType[]): BookTableDataType[] => {
  return books.map((book:BookType):BookTableDataType =>({...book,action: (() => (<ActionCell book={book} />)) as unknown as ReactNode}))
}
const columns = ['isbn', 'name', 'price', 'action'];
function Books() {
    return (
      <div className="Books">
        <br />
        <Button text='xxx' type="submit" onClick={()=>{}} color='reset'></Button>
        <Input type='livro' id='floatingInput' label="Nome do livro" placeholder='Nome do livro'></Input>
        <Input type='livro' id='floatingInput' label="Preço" placeholder='Preço'></Input>
        <Table data={booksTransformer(books)} columns={columns}   />
        </div>
    );
  }
export default Books;