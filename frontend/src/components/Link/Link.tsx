import { LinkProps } from "./Link.types"
import {Link as LinkRoute} from "react-router-dom"

export const Link = ({color,href,text}: LinkProps): JSX.Element => {
    const bgColor = color==="primary"?"bg-primary":"bg-secondary"
    return <LinkRoute to={href} className={`btn ${bgColor}`} >{text}</LinkRoute>
}