import React, { Component } from "react";
import FieldBox from "../../Molecules/FieldBox/FieldBox";
import "./ReceiptForm.scss";
import {
  Button,
  FormControl,
  FormControlLabel,
  Switch
} from "@material-ui/core";
class ReceiptForm extends Component {
  state = {};
  render() {
    return (
      <div className="receiptForm">
        <form>
          <div>
            <FormControlLabel
              control={<Switch value="checkedA" />}
              label="Ziema"
            />
          </div>
          <FieldBox label={"Siltumenerģija"} inputType={"text"} unit={"Mwh"} />
          <FieldBox
            label={"Iepr. Siltumenerģija"}
            inputType={"text"}
            unit={"Mwh"}
            disabled
          />
          <FieldBox label="Karstais ūdens" inputType={"text"} unit={"Mwh"} />
          <FieldBox
            label={"Iepr. Karstais ūdens"}
            inputType={"text"}
            unit={"Mwh"}
            disabled
          />
          <FieldBox label="Lietus notekūdeņi" inputType={"text"} unit={"Mwh"} />
          <FieldBox label="Aukstais ūdens" inputType={"text"} unit={"Mwh"} />
          <FieldBox label="Elektroapgāde" inputType={"text"} unit={"Mwh"} />
          <FieldBox
            label="Atikritumu izvešana"
            inputType={"text"}
            unit={"Mwh"}
          />
        </form>
        <FormControl>
          <Button type="submit">Aprēķināt rēķinus</Button>
        </FormControl>
      </div>
    );
  }
}

export default ReceiptForm;
