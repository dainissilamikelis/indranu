import React, { Component } from "react";
import axios from "axios";
import Loader from "../../atoms/Loader/Loader";
import "./TarifiPage.scss";
import TarifiForm from "../../Templates/TarifiForm/TarifiForm";

class TarifiPage extends Component {
  state = {
    loading: true,
    fields: []
  };

  componentDidMount = () => {
    axios.get("https://localhost:44356/api/tarif").then(Response => {
      this.setState({ fields: Response.data, loading: false });
    });
  };

  render() {
    const { loading, fields } = this.state;
    return (
      <div className="TarifiPage">
        {loading ? <Loader /> : <TarifiForm fields={fields} />}
      </div>
    );
  }
}

export default TarifiPage;
