import React, { Component } from "react";
import AppBar from "@material-ui/core/AppBar";
import Tabs from "@material-ui/core/Tabs";
import Tab from "@material-ui/core/Tab";
import Receipt from "../Receipt/Receipt";

class TabForm extends React.Component {
  state = {
    value: 0
  };

  handleChange = (event, value) => {
    this.setState({ value });
  };

  render() {
    const { value } = this.state;
    const { receipts } = this.props;
    return (
      <div>
        <AppBar position="static" style={{ marginBottom: "10px" }}>
          <Tabs
            style={{ backgroundColor: "#13315C" }}
            variant="fullWidth"
            value={value}
            onChange={this.handleChange}
          >
            {receipts.map(receipt => (
              <Tab
                key={receipt.label}
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
