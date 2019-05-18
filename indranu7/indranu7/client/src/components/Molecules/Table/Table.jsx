import React from "react";
import './Table.scss';

export const Table = ({ fields }) => (
  <table>
    <tbody>
        {fields.map(field => (
          <tr key={field.name}>
            <th> {field.label} </th>
            <td> {`${field.value} ${field.unit}`} </td>
          </tr>
        ))}
    </tbody>
  </table>
);

export const CostTable = ({ costFields }) => (
  <table>
    <tbody>
      <tr>
        <th> </th>
        <th> Daudzums </th>
        <th> Maksa </th>
      </tr>
        {costFields.map(costField => (
          <tr key={costField.amountField.name}>
            <th>{costField.amountField.label}</th>
            <td>{`${costField.amountField.value} ${costField.amountField.unit}`}</td>
            <td>{`${costField.costField.value} ${costField.costField.unit}`} </td>
          </tr>
        ))}
    </tbody>
  </table>
);

export default Table;
