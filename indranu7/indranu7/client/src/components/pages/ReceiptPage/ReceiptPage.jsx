import React, { Component } from "react";
import axios from "axios";
import Loader from "../../atoms/Loader/Loader";
import "./ReceiptPage.scss";
import ReceiptForm from "../../Templates/ReceiptForm/ReceiptForm";
import { formatFields } from "../../../utils/utils";

class ReceiptPage extends Component {
  state = {
    loading: true,
    fields: []
  };

  componentDidMount = () => {
    axios.get("http://localhost:61466/api/receipt").then(Response => {
      this.setState({ fields: formatFields(Response.data), loading: false });
    });
  };

  render() {
    const { loading, fields } = this.state;
    return (
      <div className="ReceiptPage">
        {loading ? <Loader /> : <ReceiptForm fields={fields} />}
      </div>
    );
  }
}

export default ReceiptPage;
