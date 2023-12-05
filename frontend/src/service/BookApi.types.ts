import { BookType } from "../Types/Books.types";

export interface BaseResponse {
    success: boolean,
    message: string
}
export interface BooksResponse extends BaseResponse {
    obj:BookType[]
}

export interface BookResponse extends BaseResponse {
    obj:BookType
}
