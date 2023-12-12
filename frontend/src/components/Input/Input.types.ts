import {ChangeEvent} from "react";

export type InputProps ={
    placeholder?: string |undefined | number ;
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
    allowDecimal: boolean;
    decimalSymbol: string;
    decimalLimit: number;
    requireDecimal: boolean;
    //allowNegative: boolean;
    //allowLeadingZeroes: boolean;
    //suffix: string;
    // includeThousandsSeparator: boolean;
    //thousandsSeparatorSymbol: string;
   
}
