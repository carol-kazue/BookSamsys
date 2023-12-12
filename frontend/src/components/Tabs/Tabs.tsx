import { NavLink } from "react-router-dom";
import { TabsProps } from "./Tabs.types"


export const Tabs = ()=>{
    return (
      <nav>
        <ul>
          <li>
            <NavLink to="/" className="active">
              Lista de Livros
            </NavLink>
          </li>
          <li>
            <NavLink to="/livro" className="active">
              Adicionar livro
            </NavLink>
          </li>
        </ul>
      </nav>
    );
  
}