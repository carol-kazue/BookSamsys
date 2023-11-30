import { Link } from "react-router-dom";
import { Button } from '../../components/Button/Button';
import { Input } from '../../components/Input/Input';

import  "bootstrap/dist/css/bootstrap.min.css";
import { Table, TableIndex } from "../../components/Table/Table";
const books = [
  { isbn: 1, name: 'Item 1', price: 20.99 },
  { isbn: 2, name: 'Item 2', price: 15.99 },
  { isbn: 3, name: 'Item 3', price: 25.99 },
];
const columns = ['isbn', 'name', 'price'];
function Books() {
    return (
      <div className="Books">
        <br />
        <Button text='xxx' type="subimit" onClick={()=>{}} color='secondary'></Button>
        <Input type='livro' id='floatingInput' label="Nome do livro" placeholder='Nome do livro'></Input>
        <Input type='livro' id='floatingInput' label="Preço" placeholder='Preço'></Input>
        <Table data={books} columns={columns} />
        </div>
    );
  }
export default Books;