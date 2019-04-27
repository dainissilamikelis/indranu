import React, { Component } from "react";
import axios from "axios";
import Loader from "../../atoms/Loader/Loader";
import "./ReceiptPage.scss";
import ReceiptForm from "../../Templates/ReceiptForm/ReceiptForm";

class ReceiptPage extends Component {
  state = {
    loading: false
  };

  componentDidMount = () => {
    axios.get("https://localhost:44356/api/values").then(Response => {
      this.setState({ test: Response.data, loading: false });
    });
  };

  render() {
    const { loading } = this.state;
    return (
      <div className="ReceiptPage">
        {loading ? <Loader /> : <ReceiptForm />}
      </div>
    );
  }
}

export default ReceiptPage;
