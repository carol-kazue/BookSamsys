import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import './index.css';

import Books from './pages/Books/Books';
import BookForm from "./pages/BookForm/BookForm";
import App from "./App";

const rootElement = document.getElementById("root");

const router = createBrowserRouter([
  {
    path: "/",
    element: <App/>,
    children:[
      {
        path: "/",
        element: <Books />,
      },
      {
        path:"livro/:isbn",
        element: <BookForm/>
      },
      {
        path:"livro/",
        element: <BookForm/>
      },
    ]
  }
]);

const root = createRoot(rootElement as HTMLElement);

root.render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>,
);


