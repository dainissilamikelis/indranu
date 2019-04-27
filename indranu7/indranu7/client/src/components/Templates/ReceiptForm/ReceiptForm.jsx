import React, { Component } from "react";
import FieldBox from "../../Molecules/FieldBox/FieldBox";
import Receipt from "../../organisms/Receipt/Receipt";
import "./ReceiptForm.scss";
import {
  Button,
  FormControl,
  FormControlLabel,
  Switch
} from "@material-ui/core";
import TabForm from "../../organisms/TabForm/TabForm";
class ReceiptForm extends Component {
  state = {
    receipts: [],
    fields: []
  };

  componentDidMount = () => {
    const { fields } = this.props;
    console.log(fields);
    this.setState({ fields });
  };

  handleGetReceipts = () => {
    const receipts = [
      { label: "INFO", receipt: "b", value: 1 },
      { label: "Dz. 1", receipt: "c", value: 2 },
      { label: "Dz. 2", receipt: "c", value: 3 },
      { label: "Dz. 3", receipt: "c", value: 4 },
      { label: "Dz. 4", receipt: "c", value: 5 },
      { label: "Dz. 5", receipt: "b", value: 6 },
      { label: "Dz. 6", receipt: "c", value: 7 },
      { label: "Dz. 7", receipt: "c", value: 8 },
      { label: "Dz. 8", receipt: "c", value: 9 },
      { label: "Dz. 9", receipt: "c", value: 10 },
      { label: "Dz. 10", receipt: "b", value: 11 },
      { label: "Dz. 11", receipt: "c", value: 12 },
      { label: "Dz. 12", receipt: "c", value: 13 },
      { label: "Dz. 14", receipt: "c", value: 14 },
      { label: "Dz. 15", receipt: "c", value: 15 }
    ];
    this.setState({ receipts });
  };
  render() {
    const { fields, receipts } = this.state;
    console.log(fields);
    return (
      <div className="receiptForm">
        <form>
          <div>
            <FormControlLabel
              control={<Switch value="checkedA" />}
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
            />
          ))}
        </form>
        <FormControl>
          <Button type="submit" onClick={this.handleGetReceipts}>
            Aprēķināt rēķinus
          </Button>
        </FormControl>
        {receipts.length > 0 ? (
          <div className="receipt-page">
            <TabForm receipts={receipts} />
          </div>
        ) : null}
      </div>
    );
  }
}

export default ReceiptForm;
