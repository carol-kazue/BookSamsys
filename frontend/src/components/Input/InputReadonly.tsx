import {InputProps} from "./Input.types"
export const InputReadonly =({placeholder, label, type,id,value, onChange}:InputProps): JSX.Element =>{
    return <div className="input-group-sm mb-3">
        <label className={`form-label`} htmlFor="validation" >{label}</label>
        <input readOnly onChange={onChange} value={value} type={type} className={`form-control`} placeholder={placeholder as string} id={id} required></input>
        </div>
}