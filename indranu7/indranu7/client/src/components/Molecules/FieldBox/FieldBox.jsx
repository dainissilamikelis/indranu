import React from "react";
import "./FieldBox.scss";
import { TextField, Checkbox, FormControlLabel } from "@material-ui/core";
import InputAdornment from "@material-ui/core/InputAdornment";

const FieldBox = ({
  fieldId,
  label,
  inputType,
  unit,
  readOnly,
  disabled,
  value,
  multiLine
}) => {
  return (
    <TextField
      style={{ marginRight: "20px" }}
      defaultValue="11.32"
      className={`input-text ${disabled ? "readOnly" : "test"}`}
      type={inputType}
      value={value}
      label={label}
      margin="normal"
      disabled={disabled}
      variant={disabled ? "filled" : "outlined"}
      InputProps={{
        endAdornment: <InputAdornment position="start">{unit}</InputAdornment>
      }}
      multiLine={multiLine}
      rows={2}
      rowsMax={4}
    />
  );
};

export default FieldBox;
