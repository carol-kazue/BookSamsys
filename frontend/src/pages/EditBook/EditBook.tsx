import { useEffect, useState } from "react";
import { Button } from "../../components/Button/Button";
import { Input } from "../../components/Input/Input";
import { BookType } from "../../Types/Books.types";
import { editBook, fetchBook, postBook} from "../../service/BookApi";
import { useParams, useNavigate } from "react-router-dom";
import { NumberMaskOptions } from "../../components/Input/Input.types";
const numberMaskConfig: NumberMaskOptions = {
  allowDecimal: true, 
  decimalSymbol: ".",
  decimalLimit: 2,
  requireDecimal: false, 
  prefix: ""
}
function EditBook(){
  const [book, setBook]= useState<BookType| null>(null);
  //const [newBook, setNewBook] = useState<BookType>({ isbn: '', name: '', price: ''});
  
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
    setBook({ isbn: '', name: '', price: ''})
  }
  // chama o get livro espífico para mostar nas labals os dados do livro e atualiza o estado do objeto 
  useEffect(() => {
    fetchBook(isbn).then(result=>{
      console.log(result.obj)
      setBook(result?.obj)
    })
  }, 
  []);

  return(
    <div className="container col-5 EditBook">
        {
          isbn? <div className="col mt-5 mb-5 edit">
            <h1>Edite o seu livro aqui</h1>
            </div> 
            : 
            <div className="col m-5 post">
            <h1>Adicione um novo livro</h1>
            </div>
            }
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
            <Button text='Salvar' type="submit" onClick={() => {
              if(!isbn){
                handlePost(book as BookType)
              }else{
                handlePut(
                  book?.isbn??'',book as BookType)}
              }
            }  color='submit'></Button>
          </div>
        </div> 
);
}
export default EditBook;