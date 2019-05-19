import React from "react";
import "./Info.scss";
import { sumDecimals, getColumnSum } from "../../../utils/utils";

const ColumnSum = columns => {
  const sums = getColumnSum(columns);
  debugger;
  return (
    <tr style={{ backgroundColor: "red" }}>
      <th />
      <th>{sums.get("area")}</th>
      <th>{sums.get("tenantCount")}</th>
      <th>{sums.get("declaredTenants")}</th>
      <th>{sums.get("rent")}</th>
      <th>{sums.get("parking")}</th>
      <th>{sums.get("tax")}</th>
      <th>{sums.get("wasteCost")}</th>
      <th>{sums.get("rentTOTAL")}</th>
      <th>{sums.get("heating")}</th>
      <th>{sums.get("heatingCost")}</th>
      <th>{sums.get("hotWaterLoss")}</th>
      <th>{sums.get("hotWaterLossCost")}</th>
      <th>{sums.get("hotWater")}</th>
      <th>{sums.get("hotWaterCost")}</th>
      <th>{sums.get("hotWaterTOTAL")}</th>
      <th>{sums.get("coldWater")}</th>
      <th>{sums.get("coldWaterCost")}</th>
      <th>{sums.get("coldWaterLoss")}</th>
      <th>{sums.get("coldWaterLossCost")}</th>
      <th>{sums.get("upkeep")}</th>
      <th>{sums.get("upkeepCost")}</th>
      <th>{sums.get("total")}</th>
    </tr>
  );
};

const Info = ({ info }) => {
  return (
    <div>
      <table style={{ maxWidth: "90%" }}>
        <tbody>
          <tr>
            <th>Nr.</th>
            <th>Laukums, m2</th>
            <th style={{ backgroundColor: "lightBlue" }}>
              Iedzīvotāju skaits{" "}
            </th>
            <th>Deklr. skaits </th>
            <th>Īre, EUR</th>
            <th>Stāvieta</th>
            <th>Nodoklis, EUR</th>
            <th>Atkritumu izvešana, EUR</th>
            <th>Kopā, EUR</th>
            <th>Apkure, MWh</th>
            <th>Maksa, EUR</th>
            <th>Cirkulācija, MWh</th>
            <th>Maksa, EUR</th>
            <th>Siltais ūdens, MWh </th>
            <th>Maksa, EUR</th>
            <th>Kopā, EUR </th>
            <th>Aukstais ūdens, m3</th>
            <th>Kopā, EUR</th>
            <th>Aukstā ūdens zudumi, m3</th>
            <th>Kopā, EUR</th>
            <th>Elektroapgāde, kWh</th>
            <th>Maksa, EUR</th>
            <th>Rēķina summa, EUR</th>
          </tr>
          {info.map(row => (
            <tr key={row.apartmentNo}>
              <td>{row.apartmentNo}</td>
              <td>{row.area}</td>
              <td style={{ backgroundColor: "lightBlue" }}>
                {row.tenantCount}
              </td>
              <td>{row.declaredTenants}</td>
              <td>{row.rent}</td>
              <td>{row.parking}</td>
              <td>{row.tax}</td>
              <td>{row.wasteCost}</td>
              <td style={{ fontWeight: "bold" }}>
                {sumDecimals([row.tax, row.rent, row.wasteCost, row.parking])}
              </td>
              <td>{row.heating}</td>
              <td style={{ backgroundColor: "lightBlue" }}>
                {row.heatingCost}
              </td>
              <td>{row.hotWaterLoss}</td>
              <td style={{ backgroundColor: "lightBlue" }}>
                {row.hotWaterLossCost}
              </td>
              <td>{row.hotWater}</td>
              <td style={{ backgroundColor: "lightBlue" }}>
                {row.hotWaterCost}
              </td>
              <td style={{ fontWeight: "bold" }}>
                {sumDecimals([
                  row.heatingCost,
                  row.hotWaterCost,
                  row.hotWaterLossCost
                ])}
              </td>
              <td>{row.coldWater}</td>
              <td style={{ backgroundColor: "lightBlue" }}>
                {row.coldWaterCost}
              </td>
              <td>{row.coldWaterLoss}</td>
              <td style={{ backgroundColor: "lightBlue" }}>
                {row.coldWaterLossCost}
              </td>
              <td>{row.upkeep} </td>
              <td style={{ backgroundColor: "lightBlue" }}>{row.upkeepCost}</td>
              <td style={{ fontWeight: "bold" }}>{row.total}</td>
            </tr>
          ))}
          {ColumnSum(info)}
        </tbody>
      </table>
    </div>
  );
};

export default Info;
