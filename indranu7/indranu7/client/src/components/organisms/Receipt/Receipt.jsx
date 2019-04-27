import React from "react";
import "./Receipt.scss";
import { TextField } from "@material-ui/core";
import FieldRow from "../../Molecules/FieldRow/FieldRow";

function evaluateVisibility(current, value) {
  if (current === value) return false;

  return true;
}

const fields1 = [
  { label: "Vārds", inputType: "text", value: "Inese" },
  { label: "Uzvārds", inputType: "text", value: "Silamiķele" },
  { label: "Personas kods", inputType: "text", value: "220263-10101" },
  { label: "Dzīves vieta", inputType: "text", value: "Selgas iela 14-1" }
];

const fields2 = [
  { label: "Vārds", inputType: "text", value: "Anda" },
  { label: "Uzvārds", inputType: "text", value: "Masējeva" },
  { label: "Personas kods", inputType: "text", value: "220263-10101" },
  { label: "Dzīves vieta", inputType: "text", value: "Selgas iela 14-1" }
];

const fields3 = [
  { label: "Īre", inputType: "text", value: "Anda", unit: "EUR/m2" },
  { label: "Apkure", inputType: "text", value: "Masējeva", unit: "EUR/m2" },
  {
    label: "Personas kods",
    inputType: "text",
    value: "220263-10101",
    unit: "EUR/m2"
  },
  {
    label: "Dzīves vieta",
    inputType: "text",
    value: "Selgas iela 14-1",
    unit: "EUR/m2"
  },
  { label: "Īre", inputType: "text", value: "Anda", unit: "EUR/m2" },
  { label: "Apkure", inputType: "text", value: "Masējeva", unit: "EUR/m2" },
  {
    label: "Personas kods",
    inputType: "text",
    value: "220263-10101",
    unit: "EUR/m2"
  },
  {
    label: "Dzīves vieta",
    inputType: "text",
    value: "Selgas iela 14-1",
    unit: "EUR/m2"
  },
  { label: "Īre", inputType: "text", value: "Anda", unit: "EUR/m2" },
  { label: "Apkure", inputType: "text", value: "Masējeva", unit: "EUR/m2" },
  { label: "Summa", inputType: "text", value: "Anda", unit: "EUR" },
  { label: "Summa vārdos", inputType: "text", value: "Masējeva" }
];

const Receipt = ({ receipt, current }) => {
  return (
    <form hidden={evaluateVisibility(current, receipt.value)}>
      <FieldRow fields={fields1} title="Maksājuma saņēmējs" />
      <FieldRow fields={fields2} title="Maksātājs" disabled />
      <FieldRow fields={fields3} title="Rēķina informācija" disabled />
      <TextField
        style={{ marginRight: "20px", minWidth: "550px" }}
        defaultValue="11.32"
        className="input-text"
        type="text"
        label="Papildinformācija"
        margin="normal"
        variant="outlined"
        multiline
        rows={2}
        rowsMax={4}
      />
    </form>
  );
};

export default Receipt;
