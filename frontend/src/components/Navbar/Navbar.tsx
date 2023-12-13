import { NavLink } from "react-router-dom";
export const Navbar = ()=>{
    return ( <nav className="navbar navbar-expand-lg navbar-light bg-light row mb-5">
  <div className="container">
    <a className="navbar-brand col-4">BookSamsys</a>
    <div className="navbar gap-4 col-6 d-flex align-items-center justify-content-center" id="navbarNavAltMarkup">
        <NavLink className="nav-link  p-2 " to="/">
          Livros
        </NavLink>
        <NavLink className="nav-link p-2" to="/">
          Autores
        </NavLink>
    </div>
  </div>
</nav>
  );
}