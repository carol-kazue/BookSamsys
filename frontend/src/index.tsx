import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import './index.css';

import Books from './pages/Books/Books';

const rootElement = document.getElementById("root");

const router = createBrowserRouter([
  {
    path: "/",
    element: <Books />,
  },
]);

const root = createRoot(rootElement as HTMLElement);

root.render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>,
);



