import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import './index.css';

import Books from './pages/Books/Books';
import EditBook from "./pages/EditBook/EditBook";

const rootElement = document.getElementById("root");

const router = createBrowserRouter([
  {
    path: "/",
    element: <Books />,
  },
  {
    path:"editar-livro/:isbn",
    element: <EditBook/>
  }
]);

const root = createRoot(rootElement as HTMLElement);

root.render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>,
);



