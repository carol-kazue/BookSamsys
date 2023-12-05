import { ButtonProps } from "./Button.types";

export const Button = ({color,onClick,text, type}: ButtonProps): JSX.Element => {
    const btnCustomStyle = {
        color: "#fff",  
        backgroundColor: color === "submit" ? "#FDB901" : "#FD0101",  
        borderColor: color === "submit" ? "#FDB901" : "#FD0101",  
    };
    return <button onClick={onClick} className={`btn btn-custom`} style={btnCustomStyle} type={type} >{text}</button> 
}