import React, { Component } from "react";
import axios from "axios";
import Loader from "../../atoms/Loader/Loader";
import "./StatsPage.scss";

class StatsPage extends Component {
  state = {
    loading: true
  };

  componentDidMount = () => {
    axios.get("https://localhost:44356/api/values").then(Response => {
      this.setState({ test: Response.data, loading: false });
    });
  };

  render() {
    const { loading } = this.state;
    return (
      <div className="Page">
        {loading ? <Loader /> : <div> page StatsPage </div>}
      </div>
    );
  }
}

export default StatsPage;
