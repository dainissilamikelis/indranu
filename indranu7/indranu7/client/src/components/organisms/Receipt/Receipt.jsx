import React from "react";
import "./Receipt.scss";
import { PDFViewer, ReactPDF } from 'react-pdf';
import MyDocument from '../../Templates/PrintReceipt/PrintReceipt';

function evaluateVisibility(current, value) {
  if (current === value) return false;
  return true;
}

function handleSave() {
  
}


const Receipt = ({ receipt, current }) => {
  return (
    <div hidden={evaluateVisibility(current, receipt.value)}>
    <button onClick={handleSave}> save </button>
      <PDFViewer>
        <MyDocument />
      </PDFViewer>
    </div>
  );
};

export default Receipt;
