import React, { Component } from "react";
import FieldBox from "../../atoms/FieldBox/FieldBox";
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
    const { fields, title, editable, sizeType } = this.props;
    const { disabled } = this.state; 
    return (
      <>
        <div> {title} </div>
        <FormGroup row className="form-group">
          {fields.map(field => (
            <FieldBox
              key={field.name}
              label={field.label}
              inputType={field.inputType}
              value={field.value}
              unit={field.unit}
              disabled={disabled}
              sizeType={sizeType}
              setRef={field.ref}
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
