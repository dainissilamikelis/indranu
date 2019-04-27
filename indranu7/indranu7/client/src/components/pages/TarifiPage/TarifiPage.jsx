import React, { Component } from "react";
import axios from "axios";
import Loader from "../../atoms/Loader/Loader";
import "./TarifiPage.scss";
import TarifiForm from "../../Templates/TarifiForm/TarifiForm";

class TarifiPage extends Component {
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
      <div className="tarifiPage">{loading ? <Loader /> : <TarifiForm />}</div>
    );
  }
}

export default TarifiPage;
