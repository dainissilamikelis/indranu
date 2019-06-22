import React from 'react';
import { NavLink } from "react-router-dom";

const Link = ({
  to,
  text
}) => (
    <NavLink
      className="link"
      to={`/${to}`}
      activeClassName="activeLink"
    >
      {text}
    </NavLink>
  );

export default Link;