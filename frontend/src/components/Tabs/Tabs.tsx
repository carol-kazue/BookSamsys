import { TabsProps } from "./Tabs.types"


export const Tabs = ({active}:TabsProps): JSX.Element=>{
    return <ul className="nav nav-tabs">
    <li className="nav-item">
      <a className={`nav-link ${active}`}  aria-current="page" href="/">Lista de Livros</a>
    </li>
    <li className="nav-item">
      <a className={`nav-link`} href="#">Adicionar Livro</a>
    </li>
  </ul>
}