import React from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";
import './App.css';
import AppBar from './components/organisms/AppBar';
import Receipt from './components/pages/Receipt';

function App() {
  return (
    <Router>
      <div className="App">
        <AppBar />
        <div className="page">
          <Switch>
            <Route path="/createReceipt" component={Receipt} />
          </Switch>
        </div>
      </div>
    </Router>
  );
}

export default App;
