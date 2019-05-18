import React from "react";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";
import LinkButton from "../../atoms/LinkButton/LinkButton";
import "./SideBar.scss";

const SideBar = () => (
  <AppBar position="static">
    <Toolbar className="appBar">
      <Typography variant="h6" color="inherit">
        Indrānu iela 7
      </Typography>
      <LinkButton linkText="Veidot rēķinu" pathName="/pages/createReceipt" />
      <LinkButton linkText="Tarifi" pathName="/pages/tarifs" />
      <LinkButton linkText="Vēsture" pathName="/pages/history" />
      <LinkButton linkText="Dzīvokļi" pathName="/pages/assets" />
      <LinkButton linkText="Informācija" pathName="/pages/stats" />
    </Toolbar>
  </AppBar>
);

export default SideBar;
