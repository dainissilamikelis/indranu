import React from "react";
import "./Receipt.scss";
import ReceiptPerson from "../../Molecules/ReceiptPerson/ReceiptPerson";
import ReceiptBody from "../../Molecules/ReceiptBody/ReceiptBody";

function evaluateVisibility(current, value) {
  if (current === value) return false;
  return true;
}

function handleSave() {
  
}

const Receipt = ({ receipt, current }) => {
  console.log(receipt);
  return (
    <div className="receipt-table" hidden={evaluateVisibility(current, receipt.value)}>
    <h5> Maksājuma saņēmējs </h5>
    <ReceiptPerson />
    <h5> Maksātājs </h5>
    <ReceiptPerson />
    <h5> Rēķins </h5> 
    <ReceiptBody />
    </div>
  );
};

export default Receipt;
