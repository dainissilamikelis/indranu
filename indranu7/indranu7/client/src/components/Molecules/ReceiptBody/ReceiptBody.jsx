import React from "react";
import { Table, CostTable } from "../Table/Table";

const ReceiptBody = ({ receipt }) => {
  const {
    additionalInformation,
    closingInformation,
    costFields,
    fields
  } = receipt;
  return (
    <div>
      <h5> Maksājumi </h5>
      <Table fields={fields} />
      <h5> Maksājumi </h5>
      <CostTable costFields={costFields} />
      <h5> Maksājumi </h5>
      <Table fields={additionalInformation} />
      <h5> Maksājumi </h5>
      <Table fields={closingInformation} />
    </div>
  );
};
export default ReceiptBody;
