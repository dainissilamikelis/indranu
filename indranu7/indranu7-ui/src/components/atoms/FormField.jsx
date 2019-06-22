import React from 'react';
import PropTypes from 'prop-types';
import {
  FormGroup,
  InputGroup
} from "@blueprintjs/core";

export const styles = {
  small: {
    maxWidth: '50px',
    marginLeft: '5px',
  },
  medium: {
    maxWidth: '150px',
    marginLeft: '5px',
  },
  large: {
    maxWidth: '250px',
    marginLeft: '5px',
  },
  default: {
    marginLeft: '5px',
  }
}

const FormField = ({
  helperText,
  label,
  id,
  labelInfo,
  placehHolder,
  onChange,
  value,
  style,
}) => (
    <div style={style}>
      <FormGroup
        helperText={helperText}
        label={label}
        labelFor={id}
        labelInfo={labelInfo}
      >
        <InputGroup
          id={id}
          placeholder={placehHolder}
          onChange={onChange}
          value={value}
        />
      </FormGroup>
    </div >
  );

FormField.propTypes = {
  helperText: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  id: PropTypes.string.isRequired,
  labelInfo: PropTypes.string.isRequired,
  placehHolder: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
  value: PropTypes.string.isRequired,
}

FormField.defaultProps = {
  style: styles.default,
}

export default FormField;
