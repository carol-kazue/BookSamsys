import { TabbleProps , TabbleIndexProps } from "./Table.types";
export const TableIndex  = ({scopeIndex,text}:TabbleIndexProps): JSX.Element =>{
    return  <th scope={scopeIndex}>{text}</th>
}
export const Table = ({data, columns}:TabbleProps): JSX.Element =>{


    return <div className="container col-8">
            <table className="table table-hover align-middle">
              <thead>
                <tr className="text-center">
                  {columns.map((column, index) => (
                      <th key={index}>{column}</th>
                  ))}
                </tr>
              </thead>
              <tbody className="text-center">
                {data.map((row, rowIndex) => (
                <tr key={rowIndex}>
                {columns.map((column, colIndex) => (
                  <td key={colIndex}>
                  {(typeof row[column] === "function") ? row[column]() :row[column]}
                  </td>
                  ))}
                </tr>
                  ))}
              </tbody>
            </table>
    </div> 

}

