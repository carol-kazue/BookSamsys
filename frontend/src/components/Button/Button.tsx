import { ButtonProps } from "./Button.types";

export const Button = ({color,onClick,text, type}: ButtonProps): JSX.Element => {
    const bgColor = color==="primary"?"bg-primary":"bg-secondary"
    return <button onClick={onClick} className={`btn ${bgColor}`} type={type} >{text}</button>
}