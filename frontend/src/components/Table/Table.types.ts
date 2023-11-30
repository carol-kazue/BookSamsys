import { string } from "prop-types"


export type TabbleProps ={
    data: Array<Record<string, any>>;
    columns: string[];
}

export type TabbleIndexProps ={
    scopeIndex : string;
    text: string;
}
