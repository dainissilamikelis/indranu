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
  dual: {
    maxWidth: '120px',
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
  label,
  id,
  onChange,
  value,
  style,
}) => (
    <div style={style}>
      <FormGroup
        label={label}
        labelFor={id}
      >
        <InputGroup
          id={id}
          onChange={(e) => onChange(id, e.target.value)}
          value={value}
        />
      </FormGroup>
    </div >
  );

FormField.propTypes = {
  label: PropTypes.string.isRequired,
  id: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
  value: PropTypes.any.isRequired,
}

FormField.defaultProps = {
  style: styles.default,
}

export default FormField;
