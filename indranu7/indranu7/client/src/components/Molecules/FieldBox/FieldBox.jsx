import React, { Component } from "react";
import "./FieldBox.scss";
import { TextField, Checkbox, FormControlLabel } from "@material-ui/core";
import InputAdornment from "@material-ui/core/InputAdornment";

class FieldBox extends Component {
  state = { value: "" };

  componentDidMount = () => {
    const { value } = this.props;
    this.setState({ value });
  };

  handleChange = event => {
    this.setState({ value: event.target.value });
  };

  render() {
    const { value } = this.state;
    const { disabled, label, inputType, unit } = this.props;

    return (
      <TextField
        style={{ marginRight: "20px" }}
        defaultValue="11.32"
        className={`input-text ${disabled ? "readOnly" : "test"}`}
        type={inputType}
        value={value}
        onChange={this.handleChange}
        label={label}
        margin="normal"
        disabled={disabled}
        variant={disabled ? "filled" : "outlined"}
        InputProps={{
          endAdornment: <InputAdornment position="start">{unit}</InputAdornment>
        }}
      />
    );
  }
}

export default FieldBox;
