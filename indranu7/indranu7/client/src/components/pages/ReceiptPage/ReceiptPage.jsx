import React, { Component } from "react";
import axios from "axios";
import Loader from "../../atoms/Loader/Loader";
import "./ReceiptPage.scss";
import ReceiptForm from "../../Templates/ReceiptForm/ReceiptForm";
import {  formatReceiptForm } from "../../../utils/utils";

class ReceiptPage extends Component {
  state = {
    loading: true,
    form: []
  };

  componentDidMount = () => {
    axios.get("http://localhost:61466/api/receipt/getReceiptFields").then(Response => {
      this.setState({ form: formatReceiptForm(Response.data), loading: false });
    });
  };

  render() {
    const { loading, form} = this.state;
    return (
      <div className="ReceiptPage">
        {loading ? <Loader /> : <ReceiptForm form={form} />}
      </div>
    );
  }
}

export default ReceiptPage;
