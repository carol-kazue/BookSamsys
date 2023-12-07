import {ChangeEvent} from "react";

export type InputProps ={
    placeholder: string | undefined;
    label : string | null | undefined | number;
    type : string;
    id : string;
    value : string | number | undefined
    onChange: (event: ChangeEvent<HTMLInputElement>) => void;

};
