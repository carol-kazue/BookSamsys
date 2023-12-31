import { LinkProps } from "./Link.types"
import {Link as LinkRoute} from "react-router-dom"

export const Link = ({color,to,text}: LinkProps): JSX.Element => {
    const btnCustomStyle = {
        color: "#fff",  
        backgroundColor: color === "primary" ? "#FDB901" : "#F47E00", 
        borderColor: color === "primary" ? "#FDB901" : "#F47E00", 
    };
    return <LinkRoute  to={to} className={`btn btn-custom m-1 `} style={btnCustomStyle}>{text}</LinkRoute>
}