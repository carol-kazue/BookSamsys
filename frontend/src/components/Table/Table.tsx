import { TabbleProps , TabbleIndexProps } from "./Table.types";
export const TableIndex  = ({scopeIndex,text}:TabbleIndexProps): JSX.Element =>{
    return  <th scope={scopeIndex}>{text}</th>
}
export const Table = ({data, columns}:TabbleProps): JSX.Element =>{
    return   <table className="table table-hover">
    <thead>
      <tr>
      {columns.map((column, index) => (
            <th key={index}>{column}</th>
          ))}
      </tr>
    </thead>
    <tbody>
    {data.map((row, rowIndex) => (
          <tr key={rowIndex}>
            {columns.map((column, colIndex) => (
              <td key={colIndex}>{row[column]}</td>
            ))}
          </tr>
        ))}
    </tbody>
  </table>

}

