import React, { Component } from "react";
import FieldBox from "../../atoms/FieldBox/FieldBox";
import "./TarifiForm.scss";
import {
  Button,
  FormControl,
  FormControlLabel,
  Switch
} from "@material-ui/core";

class TarifiForm extends Component {
  state = {
    winter: false,
    disabled: true
  };

  handleChangeWinter = () => {
    const { winter } = this.state;
    this.setState({ winter: !winter });
  };

  handleEnable = () => {
    const { disabled } = this.state;
    this.setState({ disabled: !disabled });
  };

  render() {
    const { winter, disabled } = this.state;
    const { fields } = this.props;
    return (
      <>
        <form>
          <div>
            <FormControlLabel
              control={<Switch onChange={this.handleEnable} />}
              label="Iespējot rediģēšanu"
            />
            <FormControlLabel
              control={
                <Switch
                  disabled={disabled}
                  onChange={this.handleChangeWinter}
                />
              }
              label="Ziema"
            />
          </div>
          {fields.map(field => (
            <FieldBox
              key={field.label}
              label={field.label}
              inputType={field.type}
              unit={field.unit}
              value={field.value}
              disable={disabled}
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

export default TarifiForm;
