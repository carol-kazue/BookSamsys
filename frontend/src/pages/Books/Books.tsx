import { Link } from "react-router-dom";
import { Button } from '../../components/Button/Button';
import { Input } from '../../components/Input/Input';

import  "bootstrap/dist/css/bootstrap.min.css";

function Books() {
    return (
      <div className="Books">
        <br />
        <Button text='xxx' onClick={()=>{}} color='secondary'></Button>
      <Input type='livro' id='floatingInput' label="Nome do livro" placeholder='Nome do livro'></Input>
      </div>
    );
  }
export default Books;