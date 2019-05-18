import React from "react";
import { NavLink } from "react-router-dom";
import "./LinkButton.scss";

const LinkButton = ({ linkText, pathName }) => (
  <NavLink
    className="link-button"
    activeClassName="link-button--active"
    to={pathName}
  >
    {linkText}
  </NavLink>
);

export default LinkButton;
