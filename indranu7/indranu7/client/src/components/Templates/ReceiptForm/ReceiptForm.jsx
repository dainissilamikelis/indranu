import React, { Component } from "react";
import FieldBox from "../../atoms/FieldBox/FieldBox";
import Loader from "../../atoms/Loader/Loader";
import "./ReceiptForm.scss";
import {
  Button,
  FormControl,
  FormControlLabel,
  Switch
} from "@material-ui/core";
import TabForm from "../../organisms/TabForm/TabForm";
import {
  getInputValues,
  getApartmentFieldValues,
  formatReceipts
} from "../../../utils/utils";
import axios from "axios";
import ApartmentForm from "../ApartmentForm/ApartmentForm";
import Info from "../../organisms/Info/Info";
import Tarifs from "../../organisms/Tarifs/Tarifs";

class ReceiptForm extends Component {
  state = {
    receiptData: {
      info: [],
      receipts: []
    },
    formFields: [],
    apartments: [],
    hidden: true,
    showApartments: false,
    showReceipts: false
  };

  componentDidMount = () => {
    const { form } = this.props;
    this.setState({
      formFields: form.formFields,
      apartments: form.apartmentFields
    });
  };

  hanldeShowApartmentFields = () => {
    const { showApartments } = this.state;
    this.setState({ showApartments: !showApartments });
  };

  hanldeShowApartmentReceipts = () => {
    const { showReceipts } = this.state;
    this.setState({ showReceipts: !showReceipts });
  };

  handleGetReceipts = async () => {
    const { formFields, apartments } = this.state;
    const FormFields = getInputValues(formFields);
    const ApartmentFields = getApartmentFieldValues(apartments);
    const test = { FormFields, ApartmentFields };
    this.setState({ loading: true });
    axios
      .post("http://localhost:61466/api/receipt/getReciepts", test)
      .then(response => {
        this.setState({
          loading: false,
          hidden: false,
          receiptData: formatReceipts(response.data)
        });
      });
  };

  handleValueChange = event => {
    return event.target.value;
  };

  render() {
    const {
      formFields,
      apartments,
      receiptData,
      loading,
      hidden,
      showApartments,
      showReceipts
    } = this.state;
    const { info, receipts, tarifs } = receiptData;
    console.log(receiptData);
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
            <FormControlLabel
              onChange={this.hanldeShowApartmentReceipts}
              control={<Switch value="checkedA" />}
              label="Rādīt rēķinus"
            />
            <div className="apartment-area" hidden={!showApartments}>
              <ApartmentForm apartments={apartments} />
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
              sizeType={"input-text--input"}
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
            {receipts.length > 0 ? (
              <>
                <Tarifs tarifs={tarifs} />
                <Info info={info} />
                <div hidden={!showReceipts}>
                  <TabForm receipts={receipts} />
                </div>
              </>
            ) : (
              <p> Rēķinus neizdevās atrast, notika kļūme... </p>
            )}
          </div>
        )}
      </div>
    );
  }
}

export default ReceiptForm;
