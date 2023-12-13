import { NavLink } from "react-router-dom";
export const Navbar = ()=>{
    return (
      <nav>
        <ul>
          <li>
            <NavLink to="/">
              Lista de Livros
            </NavLink>
          </li>
          <li>
            <NavLink to="/livro/novo">
              Adicionar livro
            </NavLink>
          </li>
        </ul>
      </nav>
    );
  
}