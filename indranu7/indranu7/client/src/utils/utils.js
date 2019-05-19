import React from "react";

export function formatReceiptForm(receiptForm) {
  receiptForm.formFields.forEach(field => {
    field.ref = React.createRef();
  });
  receiptForm.apartmentFields.forEach(apartment => {
    apartment.fields.forEach(field => {
      field.ref = React.createRef();
    });
  });
  return receiptForm;
}

function getFieldValue(field) {
  if (field.ref) return field.ref.current.props.value;
  return null;
}

export function getApartmentFieldValues(apartments) {
  var newApartments = apartments;
  apartments.forEach(apartment => {
    apartment.fields = getInputValues(apartment.fields);
  });

  return newApartments;
}

function refMaker(fields) {
  fields.forEach(field => {
    field.ref = React.createRef();
  });
}

export function getInputValues(fields) {
  const valueFields = [];
  fields.forEach(field => {
    const value = getFieldValue(field);
    valueFields.push({
      name: field.name,
      value,
      type: field.type,
      unit: field.unit
    });
  });
  return valueFields;
}

export function setFieldValue(fields) {
  fields.forEach(field => {
    field.value = getFieldValue(field);
  });
}
function costFieldRefMaker(costFields) {
  costFields.forEach(field => {
    const { costField, amountField } = field;
    costField.ref = React.createRef();
    amountField.ref = React.createRef();
  });
}

export function formatReceipts(data) {
  const newReceipts = {
    info: [],
    receipts: [],
    tarifs: []
  };
  const { receipts, info, tarifs } = data;

  receipts.forEach(receiptForm => {
    if (receiptForm !== null) {
      newReceipts.receipts.push(receiptForm);
    }
  });

  info.forEach(infoLine => {
    if (infoLine !== null) {
      newReceipts.info.push(infoLine);
    }
  });

  tarifs.forEach(tarif => {
    if (tarif !== null) {
      newReceipts.tarifs.push(tarif);
    }
  });

  return newReceipts;
}

export function sumDecimals(decimals) {
  var newDecimal = 0;
  decimals.forEach(number => {
    newDecimal += number;
  });
  return newDecimal.toFixed(2);
}

export function getColumnSum(columns) {
  const keys = Object.keys(columns[0]);
  const values = new Map();
  keys.forEach(key => {
    const value = columns.reduce((a, column) => {
      return a + column[key];
    }, 0);
    const roundedValue = parseFloat(value.toFixed(2));
    values.set(key, roundedValue);
  });

  values.set(
    "rentTOTAL",
    sumDecimals([
      values.get("rent"),
      values.get("wasteCost"),
      values.get("parking")
    ])
  );

  values.set(
    "hotWaterTOTAL",
    sumDecimals([
      values.get("heatingCost"),
      values.get("hotWaterCost"),
      values.get("hotWaterLossCost")
    ])
  );

  return values;
}
