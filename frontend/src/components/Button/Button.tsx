import { ButtonProps } from "./Button.types";
import { Button as BootstrapButton } from "bootstrap";

export const Button = ({color,onClick,text}: ButtonProps): JSX.Element => {
    const bgColor = color==="primary"?"bg-primary":"bg-secondary"
    
    return <button className={`btn ${bgColor}`} >{text}</button>
}