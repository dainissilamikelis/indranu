import React from 'react';
import {
  Alignment,
  Button,
  Navbar,
  NavbarDivider,
  NavbarGroup,
  NavbarHeading,
} from "@blueprintjs/core";
import Link from '../atoms/Link';

const AppBar = () => (
  <Navbar>
    <NavbarGroup align={Alignment.LEFT}>
      <NavbarHeading>Blueprint</NavbarHeading>
      <NavbarDivider />
      <Link
        to={"createReceipt"}
        text="Veidot rēķinu"
      />
      <Button text="Home" />
      <Button text="Files" />
    </NavbarGroup>
  </Navbar>)

export default AppBar;