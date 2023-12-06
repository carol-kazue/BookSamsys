import { ReactNode } from "react";
import { BookType } from "../../Types/Books.types";

export type BookTableDataType = BookType & {
    //ReactNode recebe qualquer tipo 
    action : ReactNode
}