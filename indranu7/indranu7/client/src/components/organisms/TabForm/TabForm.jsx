import React, { Component } from "react";
import AppBar from "@material-ui/core/AppBar";
import Tabs from "@material-ui/core/Tabs";
import Tab from "@material-ui/core/Tab";
import Receipt from "../Receipt/Receipt";
import { Button } from "@material-ui/core";
import Loader from "../../atoms/Loader/Loader";
import createPDF from "../../../utils/pdfMaker";
import "./TabForm.scss";

class TabForm extends React.Component {
  state = {
    value: 0,
    loading: false,
    printRef: null,
  };

  handleChange = (event, value) => {
    debugger;
    this.setState({ value });
  };

  componentDidMount = () => {
    const { receipts } = this.props;
    const { value } = receipts[0];
    const printRef = React.createRef();
    this.setState({ value, printRef });
  };

  handleGetPDF = () => {
    const { printRef } = this.state;
    createPDF(printRef);
    // var prtContent = document.getElementById("receipt");
    // var WinPrint = window.open('', '', 'left=0,top=0,width=800,height=900,toolbar=0,scrollbars=0,status=0');
    // WinPrint.document.write(prtContent.innerHTML);
    // WinPrint.document.close();
    // WinPrint.focus();
    // WinPrint.print();
    // WinPrint.close();


  }
  render() {
    const { value, loading ,printRef } = this.state;
    const { receipts } = this.props;

    if (loading) return <Loader />;

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
          <div ref={printRef} id="receipt" key={receipt.value} className="receipts-grid">
            <div className="receipt-part receipt-1">
              <Receipt receipt={receipt} current={value} />
            </div>
            <div className="receipt-part  receipt-2">
              <Receipt receipt={receipt} current={value} />
            </div>
          </div>
        ))}
      </div>
    );
  }
}

export default TabForm;
