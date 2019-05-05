import React, { Component } from "react";
import FieldBox from '../../atoms/FieldBox/FieldBox';
import "./AssetForm.scss";
import {
  Button,
  FormControl,
  FormControlLabel,
  Switch,
  FormGroup
} from "@material-ui/core";
import FieldRow from "../../Molecules/FieldRow/FieldRow";

class AssetForm extends Component {
  state = {
    winter: false,
    disabled: true
  };

  handleEnable = () => {
    const { disabled } = this.state;
    this.setState({ disabled: !disabled });
  };

  render() {
    const { disabled } = this.state;
    const { assets } = this.props;
    console.log("aseti", assets);
    return (
      <>
        <form>
          <h4> Dzīvokļi </h4>
          {assets.map(asset => (
            <FieldRow
              fields={asset.fields}
              title={asset.label}
              editable
              disabled
            />
          ))}
        </form>
        <FormControl>
          <Button disabled={disabled} type="submit">
            Izmainīt tarfius
          </Button>
        </FormControl>
      </>
    );
  }
}

export default AssetForm;
