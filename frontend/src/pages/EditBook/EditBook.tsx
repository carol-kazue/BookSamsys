import { useEffect, useState } from "react";
import { Button } from "../../components/Button/Button";
import { Input } from "../../components/Input/Input";
import { BookType } from "../../Types/Books.types";
import { editBook, fetchBook} from "../../service/BookApi";
import { useParams } from "react-router-dom";

function EditBook(){
  const [bookEdit, setBookEdit]= useState<BookType>({ isbn: '' , name: '', price: 0})
  const [book, setBook]= useState<BookType| null>(null);
  const {isbn} = useParams();

  const handlePut =async (bookIsbn:string, bookEdit: BookType) => {
    await editBook(bookIsbn,bookEdit)
    //console.log(bookEdit)
    setBookEdit({ isbn: '', name: '', price: 1 });
  }
  /*
  const handleGetByIsbn =async (bookIsbn:string) => {
    try {
      const book = await fetchBook(bookIsbn);
      setBook(book?.obj)
      console.log(book)
    } catch (error) {
      
    }
  }*/
  useEffect(() => {
    fetchBook(isbn).then(result=>{
      console.log(result.obj)
      setBook(result?.obj)
    })
  }, 
  []);

  return(
    <div className="container text-center EditBook">
        <div className="col m-5">
          <h1>Edite o seu livro aqui</h1>
        </div>
        <div className="col">
        <Input
          type='isbn' 
          id='floatingInput' 
          label="ISBN"
          placeholder='isbn' 
          value={book?.isbn} 
          onChange={(e) => setBookEdit({...bookEdit, isbn: e.target.value})}
        ></Input>
        <Input 
          type='livro' 
          id='floatingInput' 
          label={book?.name}  
          placeholder='Nome do livro' 
          value={bookEdit.name} 
          onChange={(e) => setBookEdit({...bookEdit, name: e.target.value})}
        ></Input>
        <Input 
          type='number' 
          id='floatingInput' 
          label='Preço'
          placeholder='Preço' 
          value={bookEdit.price} 
          onChange={(e) => setBookEdit({...bookEdit, price: e.target.valueAsNumber})}
        ></Input>
        <Button text='Editar livro' type="submit" onClick={() => handlePut(bookEdit.isbn,bookEdit)} color='submit'></Button>
        </div>
    </div>
);
}
export default EditBook;