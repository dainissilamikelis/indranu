import React, { Component } from "react";
import FieldBox from "../FieldBox/FieldBox";
import { FormControlLabel, Switch, FormGroup } from "@material-ui/core";
import "./FieldRow.scss";
class FieldRow extends Component {
  state = { disabled: true };

  componentDidMount = () => {
    const { disabled } = this.props;
    this.setState({ disabled });
  };

  componentWillReceiveProps = () => {
    const { disabled } = this.props;
    this.setState({ disabled });
  };

  handleEnable = () => {
    const { disabled } = this.state;
    this.setState({ disabled: !disabled });
  };
  render() {
    const { fields, title, editable } = this.props;
    const { disabled } = this.state; 
    return (
      <>
        <div> {title} </div>
        <FormGroup row className="form-group">
          {fields.map(field => (
            <FieldBox
              key={field.label}
              label={field.label}
              inputType={field.inputType}
              value={field.value}
              unit={field.unit}
              disabled={disabled}
            />
          ))}
          {editable ? (
            <FormControlLabel
              control={<Switch onChange={this.handleEnable} />}
              label="Rediģēt"
            />
          ) : null}
        </FormGroup>
      </>
    );
  }
}

export default FieldRow;
