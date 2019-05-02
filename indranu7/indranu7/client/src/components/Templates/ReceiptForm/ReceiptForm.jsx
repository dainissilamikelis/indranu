import React, { Component } from "react";
import FieldBox from "../../Molecules/FieldBox/FieldBox";
import Loader from "../../atoms/Loader/Loader";
import "./ReceiptForm.scss";
import {
  Button,
  FormControl,
  FormControlLabel,
  Switch
} from "@material-ui/core";
import TabForm from "../../organisms/TabForm/TabForm";
import { getInputValues, formatReceipts } from "../../../utils/utils";
import axios from "axios";
class ReceiptForm extends Component {
  state = {
    receipts: [],
    formFields: [],
    apartmentFields: [],
    loading: false,
    hidden: true,
    showApartments: false,
  };

  componentDidMount = () => {
    const { formFields, apartmentFields } = this.props;
    this.setState({ formFields, apartmentFields });
  };

  hanldeShowApartmentFields = () => {
    const {showApartments } = this.state;
    this.setState({showApartments: !showApartments});
  }

  handleGetReceipts = async data => {
    const { formFields, apartmentFields } = this.state;
    this.setState({ loading: true });
    const inputValues = [...getInputValues(formFields), ...getInputValues(apartmentFields)];
    axios
      .post("http://localhost:61466/api/receipt/getReciepts", inputValues)
      .then(response => {
        console.log(response.data);
        this.setState({
          loading: false,
          hidden: false,
          receipts: formatReceipts(response.data)
        });
      });
  };

  handleValueChange = event => {
    return event.target.value;
  };

  render() {
    const { formFields, apartmentFields, receipts, loading, hidden, showApartments } = this.state;
    return (
      <div className="receiptForm">
        <form onSubmit={this.handleGetReceipts}>
          <div>
            <FormControlLabel
              control={<Switch value="checkedA" />}
              label="Ziema"
            />
            <FormControlLabel
              onChange={this.hanldeShowApartmentFields}
              control={<Switch value="checkedA" />}
              label="Dzīvokļi"
            />
          <div hidden={!showApartments}>
          {apartmentFields.map(field => (
            <FieldBox
              key={field.label}
              label={field.label}
              inputType={field.type}
              unit={field.unit}
              value={field.value}
              setRef={field.ref} 
            />
          ))}
          </div>
          </div>
          {formFields.map(field => (
            <FieldBox
              key={field.label}
              label={field.label}
              inputType={field.type}
              unit={field.unit}
              value={field.value}
              setRef={field.ref}
            />
          ))}
        </form>
        <FormControl>
          <Button type="submit" onClick={this.handleGetReceipts}>
            Aprēķināt rēķinus
          </Button>
        </FormControl>

        {loading ? (
          <Loader />
        ) : (
          <div className="receipt-page" hidden={hidden}>
            <TabForm receipts={receipts} />
          </div>
        )}
      </div>
    );
  }
}

export default ReceiptForm;
