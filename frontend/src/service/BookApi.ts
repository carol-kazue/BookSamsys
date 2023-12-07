import { API_BASE_PATH, API_BOOK_PATH } from "./constants";
import axios from 'axios';
export const fetchBooks = async () => {
    try {
      const response = await axios.get(`${API_BASE_PATH}/${API_BOOK_PATH}`);
      //console.log(response)
      return response.data;
    } catch (error) {
      console.error('Erro ao buscar dados da API:', error);
    } finally {
    }
  };

  export const fetchBook =async (bookIsbn:string | undefined) => {
    try {
      const response = await axios.get(`${API_BASE_PATH}/${API_BOOK_PATH}/${bookIsbn}`)
      //console.log(response)
      return response.data;
    } catch (error) {
      console.log('Erro ao buscar livro da API:', error)
    }
  }

  export const deleteBook =async (bookIsbn: string) => {
    try {
      const response = await axios.delete(`${API_BASE_PATH}/${API_BOOK_PATH}/${bookIsbn}`)
      return response.data
    } catch (error) {
      console.log("Erro ao apagar o livro")
    }
  };
  export const postBook = async (book: {}) => {
    try {
      const response = await axios.post(`${API_BASE_PATH}/${API_BOOK_PATH}`, book);
      //console.log(response)
      return response.data;
    } catch (error) {
      console.error('Erro ao criar livro na API:', error);
    } finally {
    }
  };

  export const editBook =async (bookIsbn:string, book: {}) => {
    try {
      const response = await axios.put(`${API_BASE_PATH}/${API_BOOK_PATH}/${bookIsbn}`, book)
      console.log(response)
      return response.data;
    } catch (error) {
      console.error('Erro ao editar livro na API:', error);
    }
  }
