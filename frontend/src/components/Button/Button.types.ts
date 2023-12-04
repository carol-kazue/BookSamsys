import {MouseEventHandler} from "react"

export type ButtonProps = {
    onClick: MouseEventHandler;
    text: string;
    color: "primary" | "secondary";
    type: "button" | "submit" | "reset" | undefined
}