import React, { Component } from "react";
import "./FieldBox.scss";
import { TextField } from "@material-ui/core";
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
    const { disabled, label, inputType, setRef, sizeType } = this.props;
    let { unit } = this.props;
    if (!unit) unit = "";
    
    return (
      <TextField
        style={{ marginRight: "20px" }}
        fullWidth
        className={`input-text ${sizeType ? sizeType : "input-text--default"} ${disabled ? "readOnly" : ""}`}
        type={inputType}
        value={value}
        ref={setRef}
        onChange={this.handleChange}
        label={label}
        margin="normal"
        disabled={disabled}
        InputProps={{
          endAdornment: <InputAdornment position="start">{unit}</InputAdornment>
        }}
      />
    );
  }
}

export default FieldBox;
