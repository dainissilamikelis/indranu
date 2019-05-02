import React from "react";
import "./Receipt.scss";
import { TextField } from "@material-ui/core";
import FieldRow from "../../Molecules/FieldRow/FieldRow";

function evaluateVisibility(current, value) {
  if (current === value) return false;
  return true;
}

const Receipt = ({ receipt, current }) => {
  return (
    <form hidden={evaluateVisibility(current, receipt.value)}>
      <FieldRow fields={receipt.receiver} title="Maksājuma saņēmējs" />
      <FieldRow fields={receipt.payer} title="Maksātājs" />
      <FieldRow fields={receipt.receipt.fields} title="Rēķins" />
      <FieldRow fields={receipt.receipt.costFields} title="" />
      <FieldRow fields={receipt.receipt.additionalInformation} title="Papildinformācija" />
      <FieldRow fields={receipt.receipt.closingInformation} title="" />
    </form>
  );
};

export default Receipt;
