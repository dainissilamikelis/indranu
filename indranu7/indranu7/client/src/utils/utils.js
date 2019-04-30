import React from 'react';

export function formatFields(fields) {
    fields.forEach(field => {
        field.ref= React.createRef();
    })

    return fields;
}

function getFieldValue(field) {
    return field.ref.current.props.value;
}

export function getInputValues(fields) {
     const valueFields = [];
     fields.forEach((field) => {
         const value = getFieldValue(field);
         valueFields.push({name: field.name, value, type: field.type});
     })
    return valueFields;
}

export function formatReceipts(receipts) {
    const newReceipts = [];
    receipts.forEach(receipt => {
        if(receipt) newReceipts.push(receipt);
    })

    return newReceipts;
}