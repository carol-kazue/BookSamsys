import {InputProps} from "./Input.types"


export const Input =({placeholder, label, type,id,value, onChange}:InputProps): JSX.Element =>{
    return <div className="form-floating input-group-sm mb-3">
        <input  onChange={onChange} value={value} type={type} className={`form-control`} placeholder={placeholder} id={id}></input>
        <label htmlFor="floatingInput" >{label}</label>
        </div>
}

