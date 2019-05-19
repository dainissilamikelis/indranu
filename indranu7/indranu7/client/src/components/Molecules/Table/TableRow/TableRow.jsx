import React from "react";

const TabRow = ({ fieldRow }) => {
  const { amountField, costField } = fieldRow;
  const { label } = amountField;
  if (costField.value === "0.00") return null;
  if (label === "Kopā")
    return (
      <>
        <th>{amountField.label}</th>
        <td
          colSpan="2"
          style={{
            textAlign: "right",
            fontWeight: "bold",
            paddingRight: "100px"
          }}
        >{`${costField.value} ${costField.unit}`}</td>
      </>
    );

  return (
    <>
      <th>{amountField.label}</th>
      <td style={{ textAlign: "center" }}>{`${amountField.value} ${
        amountField.unit
      }`}</td>
      <td style={{ textAlign: "center" }}>
        {`${costField.value} ${costField.unit}`}
      </td>
    </>
  );
};

export default TabRow;
