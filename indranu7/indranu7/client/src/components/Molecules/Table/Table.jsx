import React from "react";

export const Table = ({ fields }) => (
  <table>
    <tbody>
      <tr>
        {fields.map(field => (
          <th key={field.name}> {field.label} </th>
        ))}
      </tr>
      <tr>
        {fields.map(field => (
          <td key={field.name}> {field.value} </td>
        ))}
      </tr>
    </tbody>
  </table>
);

export const CostTable = ({ costFields }) => (
  <table>
    <tbody>
      <td>
          <th> Pakalpojums </th>
        {costFields.map(costField => (
          <tr key={costField.amountField.name}>
            <th>{costField.amountField.label}</th>
          </tr>
        ))}
      </td>
      <td>
          <th> Maksa </th>
        {costFields.map(costField => (
          <tr>
            <td key={costField.costField.name}>{costField.costField.value}</td>
          </tr>
        ))}
      </td>
    </tbody>
  </table>
);

export default Table;
