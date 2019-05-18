import React from "react";
import { Table, CostTable } from "../Table/Table";
import './ReceiptBody.scss';

const ReceiptBody = ({ receipt }) => {
  const {
    additionalInformation,
    closingInformation,
    costFields,
    fields
  } = receipt;
  return (
    <div>
      <h5> Rēķins </h5>
      <div className="fields">
        <Table fields={fields} />
      </div>
      <div className="costFields">
        <CostTable costFields={costFields} />
      </div>
      <div className="additionalInformation">
        <h5> Papildinformācija </h5>
        <Table fields={additionalInformation} />
      </div>
      <div className="closingInformation">
        <Table fields={closingInformation} />
      </div>
    </div>
  );
};
export default ReceiptBody;
