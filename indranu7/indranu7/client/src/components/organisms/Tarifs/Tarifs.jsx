import React from "react";

const Tarifs = ({ tarifs }) => {
  return (
    <table style={{ maxWidth: "90%" }}>
      <tbody>
        <tr>
          <th>Ūdens, EUR/m3</th>
          <th>Apkure, EUR/MWh</th>
          <th>Elektrība, EUR/kWh</th>
        </tr>
        <tr>
          {tarifs.map(row => (
            <td key={row.tarifName}>{row.tarif}</td>
          ))}
        </tr>
      </tbody>
    </table>
  );
};

export default Tarifs;
