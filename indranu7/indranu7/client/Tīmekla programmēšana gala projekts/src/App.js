import React, { Component } from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import ReceiptPage from "./components/pages/ReceiptPage/ReceiptPage";
import HistoryPage from "./components/pages/HistoryPage/HistoryPage";
import SideBar from "./components/organisms/SideBar/SideBar";
import TarifiPage from "./components/pages/TarifiPage/TarifiPage";
import AssetPage from "./components/pages/AssetPage/AssetPage";
import StatsPage from "./components/pages/StatsPage/StatsPage";
import "./App.scss";

class App extends Component {
  render() {
    return (
      <Router>
        <div className="App">
          <SideBar />
          <div className="page">
            <Switch>
              <Route path="/pages/createReceipt" component={ReceiptPage} />
              <Route path="/pages/history" component={HistoryPage} />
              <Route path="/pages/tarifs" component={TarifiPage} />
              <Route path="/pages/assets" component={AssetPage} />
              <Route path="/pages/stats" component={StatsPage} />
            </Switch>
          </div>
        </div>
      </Router>
    );
  }
}

export default App;
