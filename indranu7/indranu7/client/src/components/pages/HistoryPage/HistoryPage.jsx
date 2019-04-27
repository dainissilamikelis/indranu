import React, { Component } from "react";
import axios from "axios";
import Loader from "../../atoms/Loader/Loader";
import "./HistoryPage.scss";

class HistoryPage extends Component {
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
        {loading ? <Loader /> : <div> page HistoryPage </div>}
      </div>
    );
  }
}

export default HistoryPage;
