import React from 'react';
import { Switch } from '@blueprintjs/core';

const SwitchField = ({
  label,
  onChange
}) => (
    <div style={{ margin: '10px' }}>
      <p>{label}</p>
      <Switch onChange={onChange} />
    </div>
  )

export default SwitchField;