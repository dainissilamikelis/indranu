import React, { Component } from "react";
import FieldBox from "../../Molecules/FieldBox/FieldBox";
import Loader from '../../atoms/Loader/Loader';
import "./ReceiptForm.scss";
import {
  Button,
  FormControl,
  FormControlLabel,
  Switch
} from "@material-ui/core";
import TabForm from "../../organisms/TabForm/TabForm";
import axios from "axios";
class ReceiptForm extends Component {
  state = {
    receipts: [],
    fields: [],
    loading: false,
    hidden: true,
  };

  componentDidMount = () => {
    const { fields } = this.props;
    this.setState({ fields });
  };

  handleGetReceipts = async data => {
    this.setState({ loading:true })
    axios.post("http://localhost:61466/api/values", {}).then(response => {
      debugger;
      console.log(response);
      this.setState({ loading:false, hidden:false })
    })
  };

  render() {
    const { fields, receipts, loading, hidden } = this.state;
    return (
      <div className="receiptForm">
        <form onSubmit={this.handleGetReceipts}>
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
        
        {loading ? <Loader /> :(
          <div className="receipt-page" hidden={hidden}>
              <TabForm receipts={receipts} />             
          </div>
        )}
      </div>
    );
  }
}

export default ReceiptForm;
