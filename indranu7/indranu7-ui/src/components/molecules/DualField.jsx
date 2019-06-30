import React from 'react';
import PropTypes from 'prop-types';
import FormField, { styles as type } from '../atoms/FormField';

const groupStyle = {
  minWidth: "100px",
  maxWidth: "100%",
  display: "flex",
  backgroundColor: '#dbe9ff',
  padding: '0px 10px 0px 0px',
  borderRadius: '5px',
  margin: '0px 10px 20px 10px',
};

const DualField = ({
  label,
  unit,
  value,
  valueSum,
  onChange,
  id,
}) => (
    <div style={groupStyle}>
      <FormField
        id={id}
        style={type.dual}
        label={`${label}, ${unit}`}
        onChange={onChange}
        value={value}
      />
      <FormField
        id={`${id}Sum`}
        style={type.dual}
        label="Summa, EUR"
        onChange={onChange}
        value={valueSum}
      />
    </div>
  )

DualField.propTypes = {
  label: PropTypes.string.isRequired,
  unit: PropTypes.string.isRequired,
  value: PropTypes.number.isRequired,
  valueSum: PropTypes.number.isRequired,
  onChange: PropTypes.func.isRequired,
  id: PropTypes.string.isRequired,
}


export default DualField;