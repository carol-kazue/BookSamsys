import {InputProps, NumberMaskOptions} from "./Input.types"
import MaskedInput from 'react-text-mask'
import {createNumberMask} from 'text-mask-addons'

export const Input =({placeholder, label, type,id,value, onChange, readonly, mask}:InputProps): JSX.Element =>{
    return <div className="mb-3">
        <label className={`form-label`} htmlFor="validation" >{label}</label>
        { mask ?
            <MaskedInput 
            onChange={onChange} 
            value={value} 
            type={type} 
            className={`form-control`} 
            placeholder={placeholder as string} 
            id={id} 
            readOnly={readonly}
            mask={createNumberMask(mask)}
        /> : 
            <input 
            onChange={onChange} 
            value={value} 
            type={type} 
            className={`form-control`} 
            placeholder={placeholder as string} 
            id={id} 
            readOnly={readonly}
        /> }
        </div>
}
