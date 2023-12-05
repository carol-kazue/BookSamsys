import {MouseEventHandler} from "react"

export type ButtonProps = {
    onClick: MouseEventHandler;
    text: string;
    color: "submit" | "reset";
    type: "button" | "submit" | "reset" | undefined
}