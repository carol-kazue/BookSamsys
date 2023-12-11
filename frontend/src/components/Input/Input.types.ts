import {ChangeEvent} from "react";

export type InputProps ={
    placeholder: string |undefined | number ;
    label : string | null | undefined | number;
    type : string;
    id : string;
    value : string | number | undefined
    onChange: (event: ChangeEvent<HTMLInputElement>) => void;
    readonly?: boolean; 
    mask?: NumberMaskOptions
};
export interface NumberMaskOptions {
    prefix: string;
    //suffix: string;
   // includeThousandsSeparator: boolean;
    //thousandsSeparatorSymbol: string;
    allowDecimal: boolean;
    decimalSymbol: string;
    decimalLimit: number;
    requireDecimal: boolean;
    //allowNegative: boolean;
    //allowLeadingZeroes: boolean;
   
}
