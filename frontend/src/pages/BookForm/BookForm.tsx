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
function BookForm(){
  const [book, setBook]= useState<BookType>({ isbn: '', name: '', price: ''});
  const [isEdit, setIsEdit] = useState (false)
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
    history(-1)
  }
  const handleChange =(e:{target: any}) => {
    const {name, value} =e.target;
    setBook({...book, [name]:value})
  }

  useEffect(() => {
    if(isbn !== "novo"){
      fetchBook(isbn).then(result=>{
        console.log(result.obj)
        setIsEdit(true)
        setBook(result?.obj)
      })
    }else{
      setIsEdit(false)
      setBook({ isbn: '', name: '', price: ''})
    }
  }, 
  [isbn]);

  return(
    <div className="container col-5 EditBook">
        {
          isEdit? <div className="col mt-5 mb-5 edit">
            <h1>Edite o seu livro aqui</h1>
            </div> 
            : 
            <div className="col m-5 post">
            <h1>Adicione um novo livro</h1>
            </div>
            }
          <div className="col">
            <Input
              readonly = {isEdit}
              type='text' 
              id='isbn' 
              label="ISBN"
              placeholder={book?.isbn}
              value= {book?.isbn}
              name="isbn"
              onChange={handleChange}
            ></Input>
            <Input 
              type='text' 
              id='name' 
              label='Nome do livro'
              placeholder= {book?.name}  
              value={book?.name} 
              name="name"
              onChange={handleChange}
            ></Input>
            <Input 
              type='text' 
              id='price' 
              label='Preço'
              placeholder={book?.price}
              value={book?.price} 
              name="price"
              onChange={handleChange}
              mask={numberMaskConfig}
            ></Input>
            <Button text='Salvar' type="submit" onClick={() => {
              if(!isEdit){
                handlePost(book)
              }else{
                handlePut(
                  book?.isbn??'',book)}
              }
            }  color='submit'></Button>
          </div>
        </div> 
);
}
export default BookForm;