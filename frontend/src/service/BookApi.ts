import { API_BASE_PATH, API_BOOK_PATH } from "./constants";

const fetchBook = async () => {
    try {
      const response = await fetch(`${API_BASE_PATH}${API_BOOK_PATH}`);
      return await response.json();
    } catch (error) {
      console.error('Erro ao buscar dados da API:', error);
    } finally {
    }
  };