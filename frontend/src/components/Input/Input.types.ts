import {ChangeEvent} from "react";

export type InputProps ={
    placeholder: string;
    label : string;
    type : string;
    id : string;
    value : string | number
    onChange: (event: ChangeEvent<HTMLInputElement>) => void;

};
