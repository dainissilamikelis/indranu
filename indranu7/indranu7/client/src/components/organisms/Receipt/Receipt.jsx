import React from "react";
import "./Receipt.scss";
import { TextField } from "@material-ui/core";
import FieldRow from "../../Molecules/FieldRow/FieldRow";
import CostFieldRow from '../../Molecules/CostFieldRow/CostFieldRow';

function evaluateVisibility(current, value) {
  if (current === value) return false;
  return true;
}

const Receipt = ({ receipt, current }) => {
  return (
    <form hidden={evaluateVisibility(current, receipt.value)}>
      <FieldRow fields={receipt.receiver} title="Maksājuma saņēmējs" />
      <FieldRow fields={receipt.payer} title="Maksātājs" />
      <CostFieldRow fields={receipt.receipt.costFields} title="Komunālie maksājumi" />
      <FieldRow fields={receipt.receipt.fields} title="Rēķins" />
      <FieldRow fields={receipt.receipt.additionalInformation} title="Papildinformācija" sizeType="input-text--part"/>
      <FieldRow fields={receipt.receipt.closingInformation} title="" sizeType="input-text--big"/>
    </form>
  );
};

export default Receipt;
