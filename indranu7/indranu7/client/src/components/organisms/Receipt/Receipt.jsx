import React from "react";
import "./Receipt.scss";
import ReceiptBody from "../../Molecules/ReceiptBody/ReceiptBody";
import { Table } from "../../Molecules/Table/Table";

function evaluateVisibility(current, value) {
  if (current === value) return false;
  return true;
}

function handleSave() {}

const Receipt = ({ receipt, current }) => {
  const { payer, receiver, receipt: newReceipt } = receipt;
  console.log(payer);
  return (
    <div
      className="receipt-table"
      hidden={evaluateVisibility(current, receipt.value)}
    >
      <h5> Maksājuma saņēmējs </h5>
      <Table fields={receiver} />
      <h5> Maksātājs </h5>
      <Table fields={payer} />
      <h5> Rēķins </h5>
      <ReceiptBody receipt={newReceipt} />
    </div>
  );
};

export default Receipt;
