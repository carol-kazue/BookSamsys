import { useEffect, useState } from "react";
import { Button } from "../../components/Button/Button";
import { Input } from "../../components/Input/Input";
import { BookType } from "../../Types/Books.types";
import { editBook, fetchBook, postBook} from "../../service/BookApi";
import { useParams, useNavigate } from "react-router-dom";
import { NumberMaskOptions } from "../../components/Input/Input.types";
import { Tabs } from "../../components/Tabs/Tabs";

const numberMaskConfig: NumberMaskOptions = {
  allowDecimal: true, 
  decimalSymbol: ".",
  decimalLimit: 2,
  requireDecimal: false, 
  prefix: ""
}
function EditBook(){
  const [book, setBook]= useState<BookType| null>(null);
  const [newBook, setNewBook] = useState<BookType>({ isbn: '', name: '', price: ''});
  
  const {isbn} = useParams();
 
  const history = useNavigate();

  const handlePut =async (bookIsbn:string, bookEdit: BookType) => {
    await editBook(bookIsbn,bookEdit)
    // setBook faria sentido aqui se for da vontatde mostrar novamente o os campos do objeto livro (os inputs)
    //setBook({ isbn: '', name: '', price: '' });
    history(-1)
  }
  const handlePost =async (book:BookType) => {
    await postBook(book);
    //console.log(book)
    //const updatedBooks = await fetchBooks();
    setNewBook({ isbn: '', name: '', price: ''})
    //setBooks(updatedBooks?.obj);
  }
  // chama o get livro espeífico para mostar nas labals os dados do livro e atualiza o estado do objeto 
  useEffect(() => {
    fetchBook(isbn).then(result=>{
      console.log(result.obj)
      setBook(result?.obj)
    })
  }, 
  []);

  return(
    <div className="container col-5 EditBook">
        <Tabs/>
        {
          isbn? <div>
          <div className="col mt-5 mb-5">
            <h1>Edite o seu livro aqui</h1>
          </div>
          <div className="col">
          <Input
            readonly
            type='text' 
            id='validation' 
            label="ISBN"
            placeholder={book?.isbn}
            value= {book?.isbn}
            onChange={(e) => setBook({...book, isbn: e.target.value} as BookType)}
          ></Input>
          <Input 
            type='text' 
            id='validation' 
            label='Nome do livro'
            placeholder= {book?.name}  
            value={book?.name} 
            onChange={(e) => setBook({...book, name: e.target.value} as BookType)}
          ></Input>
          <Input 
            type='text' 
            id='validation' 
            label='Preço'
            placeholder={book?.price}
            value={book?.price} 
            onChange={(e) => setBook({...book, price: e.target.value} as BookType)}
            mask={numberMaskConfig}
          ></Input>
          <Button text='Editar livro' type="submit" onClick={() => handlePut(
            book?.isbn??'',book as BookType)} color='submit'></Button>
          </div>
        </div> :
        <div>
        <div className="col m-5">
          <h1>BookSamsys</h1>
        </div>
        <div className=" container col">
          <Input 
            type='isbn' 
            id='floatingInput' 
            label="ISBN" 
            value={newBook.isbn} 
            onChange={(e) => setNewBook({ ...newBook, isbn: e.target.value })}
          ></Input>
          <Input 
            type='livro' 
            id='floatingInput' 
            label="Nome do livro" 
            value={newBook.name}
            onChange={(e) => setNewBook({ ...newBook, name: e.target.value })}
          ></Input>
          <Input 
            type='text' 
            id='floatingInput' 
            label="Preço" 
            value={newBook.price}
            onChange={(e) => setNewBook({ ...newBook, price: e.target.value})}
          ></Input>
          <Button text='Adicionar livro' type="submit" onClick={() => handlePost(newBook)} color='submit'></Button>
        </div>
        </div>
        }
        
        
    </div>
);
}
export default EditBook;