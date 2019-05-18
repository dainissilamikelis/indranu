import React, { Component } from "react";
import AppBar from "@material-ui/core/AppBar";
import Tabs from "@material-ui/core/Tabs";
import Tab from "@material-ui/core/Tab";
import Receipt from "../Receipt/Receipt";
import { Button } from "@material-ui/core";
import Loader from "../../atoms/Loader/Loader";
import { PDFViewer, ReactPDF } from 'react-pdf';
import MyDocument from '../../Templates/PrintReceipt/PrintReceipt';
class TabForm extends React.Component {
  state = {
    value: 0,
    loading: false
  };

  handleChange = (event, value) => {
    debugger;
    this.setState({ value });
  };

  componentDidMount = () => {
    const { receipts } = this.props;
    const { value } = receipts[0];
    ReactPDF.render(<MyDocument />, `${__dirname}/example.pdf`);
    this.setState({ value })
  }

  handleGetPDF = () => {
    window.print();
  }

  render() {
    const { value, loading } = this.state;
    const { receipts } = this.props;

    if (loading) return <Loader />

    return (
      <div>
        <Button onClick={this.handleGetPDF}> Printēt PDF rēķinus </Button>
        <AppBar position="static" style={{ marginBottom: "10px" }}>
          <Tabs
            style={{ backgroundColor: "#13315C" }}
            variant="fullWidth"
            value={value}
            onChange={this.handleChange}
          >
            {receipts.map(receipt => (
              <Tab
                key={receipt.value}
                style={{ minWidth: "50px", paddingLeft: 0, paddingRight: 0 }}
                className="tab"
                label={receipt.label}
              />
            ))}
          </Tabs>
        </AppBar>
        {receipts.map(receipt => (
          <Receipt key={receipt.value} receipt={receipt} current={value} />
        ))}
      </div>
    );
  }
}

export default TabForm;
