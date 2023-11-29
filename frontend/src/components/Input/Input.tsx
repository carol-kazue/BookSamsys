import {InputProps} from "./Input.types"


export const Input =({placeholder, label, type,id}:InputProps): JSX.Element =>{
    return <div className="form-floating mb-3">
        <input type={type} className={`form-control`} placeholder={placeholder} id={id}></input>
        <label htmlFor="floatingInput" >{label}</label>
        </div>
}

