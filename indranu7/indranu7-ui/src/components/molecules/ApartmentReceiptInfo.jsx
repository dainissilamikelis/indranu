import React from 'react';
import PropTypes from 'prop-types';
import FormField, { styles as type } from '../atoms/FormField';

const groupStyle = {
  maxWidth: "100%",
  display: "flex",
};

const styles = {
  minWidth: "450px",
  maxWidth: "500px",
  border: "solid",
  borderColor: 'black',
  borderWidth: 'thin',
  padding: "10px",
  margin: '0px 10px 20px 10px',
};

const headerStyles = {
  textAlign: 'middle',
  margin: '0px'
};

const ApartmentReceiptInfo = ({
  apartmentNo,
  tenantAmount,
  goneDays,
  debt,
  debtInfo,
  extraInfo,
  onChange,
  index,
}) => (
    <div style={styles}>
      <h3 style={headerStyles}>
        {`Dz. ${apartmentNo}`}
      </h3>
      <div style={groupStyle}>
        <FormField
          id={`apartments[${index}].tenantAmount`}
          style={type.small}
          label="Starpība"
          onChange={onChange}
          value={tenantAmount}
          type="number"
        />
        <FormField
          id={`apartments[${index}].goneDays`}
          style={type.small}
          label="Dienas"
          onChange={onChange}
          value={goneDays}
          type="number"
        />
        <FormField
          id={`apartments[${index}].debt`}
          style={type.small}
          label="Parāds"
          onChange={onChange}
          value={debt}
          type="number"
        />
        <FormField
          id={`apartments[${index}].debtInfo`}
          label="Informācija"
          onChange={onChange}
          value={debtInfo}
        />
        <FormField
          id={`apartments[${index}].extraInfo`}
          label="Papildus Informācija"
          onChange={onChange}
          value={extraInfo}
        />
      </div>
    </div >
  );

ApartmentReceiptInfo.propTypes = {
  onChange: PropTypes.func.isRequired,
  apartmentNo: PropTypes.number.isRequired,
  tenantAmount: PropTypes.number,
  goneDays: PropTypes.number,
  debt: PropTypes.number,
}

ApartmentReceiptInfo.defaultProps = {
  tenantAmount: 0,
  goneDays: 0,
  debt: 0,
  extraInfo: '',
  debtInfo: '',
}

export default ApartmentReceiptInfo;