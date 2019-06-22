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
  padding: "10px",
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
}) => (
    <div style={{ ...styles }}>
      <h3 style={{ ...headerStyles }}>
        {`Dz. ${apartmentNo}`}
      </h3>
      <div style={{ ...groupStyle }}>
        <FormField
          style={type.small}
          label="Starpība"
          onChange={onChange}
          value={tenantAmount}
        />
        <FormField
          style={type.small}
          label="Dienas"
          onChange={onChange}
          value={goneDays}
        />
        <FormField
          style={type.small}
          label="Parāds"
          onChange={onChange}
          value={debt}
        />
        <FormField
          label="Informācija"
          onChange={onChange}
          value={debtInfo}
        />
        <FormField
          label="Papildus Informācija"
          onChange={onChange}
          value={extraInfo}
        />
      </div>
    </div >
  );

ApartmentReceiptInfo.propTypes = {
  onChange: PropTypes.func.isRequired,
  apartmentNo: PropTypes.string.isRequired,
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