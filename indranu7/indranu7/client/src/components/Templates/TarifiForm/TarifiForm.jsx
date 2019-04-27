import React, { Component } from "react";
import FieldBox from "../../Molecules/FieldBox/FieldBox";
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
    console.log(winter, disabled);
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
          <FieldBox
            label={"Siltumenerģija"}
            inputType={"text"}
            unit={"EUR/Mwh"}
            disabled={disabled}
          />
          <FieldBox
            label={"Apkure ziemā"}
            inputType={"text"}
            unit={"EUR/m2"}
            disabled={disabled || winter}
          />
          <FieldBox
            label={"Karstais ūdens ziemā"}
            inputType={"text"}
            unit={"EUR/m3"}
            disabled={disabled || winter}
          />
          <FieldBox
            label={"Karstais ūdens vasarā"}
            inputType={"text"}
            unit={"EUR/m3"}
            disabled={disabled || !winter}
          />
          <FieldBox
            label={"Cirkulācijas zudumi"}
            inputType={"text"}
            unit={"EUR/dz"}
            disabled={disabled}
          />
          <FieldBox
            label={"Ūdensapgāde"}
            inputType={"text"}
            unit={"EUR/dz"}
            disabled={disabled}
          />
          <FieldBox
            label={"Ūdensvada zudumi sistēmā"}
            inputType={"text"}
            unit={"EUR/m3"}
            disabled={disabled}
          />
          <FieldBox
            label={"Elektroenerģija"}
            inputType={"text"}
            unit={"EUR/dz"}
            disabled={disabled}
          />
          <FieldBox
            label={"E obligata komponente"}
            inputType={"text"}
            unit={"EUR/dz"}
            disabled={disabled}
          />
          <FieldBox
            label={"Piegādes pakalpojumi"}
            inputType={"text"}
            unit={"EUR/dz"}
            disabled={disabled}
          />
          <FieldBox
            label={"Menēša maksa"}
            inputType={"text"}
            unit={"EUR/dz"}
            disabled={disabled}
          />
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
