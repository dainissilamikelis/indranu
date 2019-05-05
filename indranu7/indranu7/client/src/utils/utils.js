import React from 'react';
import { read } from 'fs';

export function formatReceiptForm(receiptForm) {
    receiptForm.formFields.forEach(field => {
        field.ref= React.createRef();
    })
    receiptForm.apartmentFields.forEach(apartment => {
        apartment.fields.forEach(field => {
            field.ref= React.createRef();
        })
    })
    return receiptForm;
}

function getFieldValue(field) {
    return field.ref.current.props.value;
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
    })
}

export function getInputValues(fields) {
    const valueFields = [];
    fields.forEach((field) => {
        const value = getFieldValue(field);
        valueFields.push({name: field.name, value, type: field.type, unit: field.unit});
    })
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
    })
}

export function formatReceipts(receipts) {
    const newReceipts = [];
    receipts.forEach(receiptForm => {
        if(receiptForm) {
            const { payer, receiver, receipt } =  receiptForm;
            const { additionalInformation, closingInformation, costFields, fields } = receipt;  
            refMaker(payer);
            refMaker(receiver);
            refMaker(additionalInformation);
            refMaker(closingInformation);
            refMaker(fields);
            costFieldRefMaker(costFields);
            newReceipts.push(receiptForm);
        } 
    })

    return newReceipts;
}

export function setReceiptFieldValues(receipts) {
    receipts.forEach(receiptForm => {
        const { payer, receiver, receipt } =  receiptForm;
        const { additionalInformation, closingInformation, costFields, fields } = receipt;
        setFieldValue(additionalInformation);
        setFieldValue(closingInformation);
        setFieldValue(costFields);
        setFieldValue(fields);
        setFieldValue(payer);
        setFieldValue(receiver);
    });
}
