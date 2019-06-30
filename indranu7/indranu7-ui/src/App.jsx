import React from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";
import './App.css';
import AppBar from './components/organisms/AppBar';
import Receipt from './components/pages/Receipt';
import TEST from './components/pages/test';

function App() {
  return (
    <Router>
      <div className="App">
        <AppBar />
        <div className="page">
          <Switch>
            <Route path="/createReceipt" component={Receipt} />
            <Route path="/test" component={TEST} />
          </Switch>
        </div>
      </div>
    </Router>
  );
}

export default App;
