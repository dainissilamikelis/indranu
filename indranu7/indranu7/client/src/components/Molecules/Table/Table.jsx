import React from "react";
import "./Table.scss";
import TabRow from "./TableRow/TableRow";

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
        <tr key={costField.costField.name}>
          <TabRow fieldRow={costField} />
        </tr>
      ))}
    </tbody>
  </table>
);

export default Table;
