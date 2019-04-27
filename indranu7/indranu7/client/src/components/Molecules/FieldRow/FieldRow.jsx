import React, { Component } from "react";
import FieldBox from "../FieldBox/FieldBox";
import { FormControlLabel, Switch, FormGroup } from "@material-ui/core";
import "./FieldRow.scss";
class FieldRow extends Component {
  state = { disabled: true };

  handleEnable = () => {
    const { disabled } = this.state;
    this.setState({ disabled: !disabled });
  };
  render() {
    const {
      number,
      price,
      area,
      inhabitants,
      tenant,
      phone,
      email,
      fromDate,
      toDate,
      hasParking,
      hasStorage,
      showInReceipt
    } = this.props;
    const { disabled } = this.state;
    return (
      <>
        <div className=""> dzivoklis 1 </div>
        <FormGroup row className="form-group">
          <FieldBox label="Menēša maksa" inputType="text" disabled={disabled} />
          <FieldBox label="Laukums" inputType="text" disabled={disabled} />
          <FieldBox label="Iedzīvotāji" inputType="text" disabled={disabled} />
          <FieldBox label="Īrnieks" inputType="text" disabled={disabled} />
          <FieldBox label="Telefons" inputType="text" disabled={disabled} />
          <FieldBox label="Epasts" inputType="text" disabled={disabled} />
          <FieldBox label="No" inputType="text" disabled={disabled} />
          <FieldBox label="Līdz" inputType="text" disabled={disabled} />
          <FieldBox label="Ir stāvieta" inputType="text" disabled={disabled} />
          <FieldBox label="Ir noliktava" inputType="text" disabled={disabled} />
          <FieldBox label="Rādīt rēķinā" inputType="text" disabled={disabled} />
          <FormControlLabel
            control={<Switch onChange={this.handleEnable} />}
            label="Rediģēt"
          />
        </FormGroup>
      </>
    );
  }
}

export default FieldRow;
