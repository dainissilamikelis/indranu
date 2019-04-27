import React from "react";
import "./FieldBox.scss";
import { TextField, Checkbox, FormControlLabel } from "@material-ui/core";
import InputAdornment from "@material-ui/core/InputAdornment";

const FieldBox = ({ fieldId, label, inputType, unit, readOnly, disabled }) => {
  return (
    <TextField
      style={{ marginRight: "20px" }}
      defaultValue="11.32"
      className="input-text"
      inputType={inputType}
      label={label}
      margin="normal"
      disabled={disabled}
      variant={disabled ? "filled" : "outlined"}
      InputProps={{
        endAdornment: <InputAdornment position="start">{unit}</InputAdornment>
      }}
    />
  );
};

export default FieldBox;
