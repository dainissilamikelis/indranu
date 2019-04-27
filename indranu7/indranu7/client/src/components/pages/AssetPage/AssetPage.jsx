import React, { Component } from "react";
import axios from "axios";
import Loader from "../../atoms/Loader/Loader";
import "./AssetPage.scss";
import AssetForm from "../../Templates/AssetForm/AssetForm";

class AssetPage extends Component {
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
      <div className="AssetPage">{loading ? <Loader /> : <AssetForm />}</div>
    );
  }
}

export default AssetPage;
