import React, { Component } from 'react';
import FormField from '../atoms/FormField';

import { Switch } from '@blueprintjs/core';
import AllReceiptInfo from '../organisms/AllReceiptInfo';

class Receipt extends Component {
  state = {
  }

  handleChange = () => {

  }

  render() {
    return (
      <div>
        <Switch />
        <div>
          <AllReceiptInfo />
        </div>
      </div>
    );
  }
}




export default Receipt;