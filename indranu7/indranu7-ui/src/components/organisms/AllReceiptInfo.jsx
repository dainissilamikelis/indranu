import React, { Component } from 'react';
import ApartmentReceiptInfo from '../molecules/ApartmentReceiptInfo';

const AllReceiptInfo = ({
  apartmentData,
  onChange,
}) => (
    <>
      <h3> Dzīvokļu informācija (skaits, prombūtne) </h3>
      <div style={{ display: 'flex', flexWrap: 'Wrap', maxWidth: '100%' }}>
        {
          apartmentData.map((info, index) => (
            <ApartmentReceiptInfo
              key={index}
              index={index}
              apartmentNo={info.apartmentNo}
              tenantAmount={info.tenantAmount}
              goneDays={info.goneDays}
              debt={info.debt}
              debtInfo={info.debtInfo}
              extraInfo={info.extraInfo}
              onChange={onChange}
            />
          ))
        }
      </div>
    </>
  );

export default AllReceiptInfo;
