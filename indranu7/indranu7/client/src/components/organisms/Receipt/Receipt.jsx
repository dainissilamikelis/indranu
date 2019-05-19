import React from "react";
import "./Receipt.scss";
import ReceiptBody from "../../Molecules/ReceiptBody/ReceiptBody";
import { Table } from "../../Molecules/Table/Table";

function evaluateVisibility(current, value) {
  if (current === value) return false;
  return true;
}

const Receipt = ({ receipt, current }) => {
  const { payer, receiver, receipt: newReceipt } = receipt;
  console.log(receipt);
  return (
    <div
      className="receipt-table"
      hidden={evaluateVisibility(current, receipt.value)}
    >
      {receipt.id}
      <div className="PersonArea">
        <div className="person">
          <h5> Maksājuma saņēmējs </h5>
          <Table fields={receiver} />
        </div>
        <div className="person">
          <h5> Maksātājs </h5>
          <Table fields={payer} />
        </div>
      </div>
      <ReceiptBody receipt={newReceipt} />
      ___________________________________ Paraksts
      ___________________________________ Paraksts
    </div>
  );
};

export default Receipt;
