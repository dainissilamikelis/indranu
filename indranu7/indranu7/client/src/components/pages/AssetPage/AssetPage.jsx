import React, { Component } from "react";
import axios from "axios";
import Loader from "../../atoms/Loader/Loader";
import "./AssetPage.scss";
import AssetForm from "../../Templates/AssetForm/AssetForm";

class AssetPage extends Component {
  state = {
    loading: true,
    assets: []
  };

  componentDidMount = () => {
    axios.get("http://localhost:61466/api/asset").then(Response => {
      this.setState({ assets: Response.data, loading: false });
    });
  };

  render() {
    const { loading, assets } = this.state;
    return (
      <div className="AssetPage">
        {loading ? <Loader /> : <AssetForm assets={assets} />}
      </div>
    );
  }
}

export default AssetPage;
