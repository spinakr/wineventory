import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import Wines from "./wines/Wines";
import AddWine from "./wines/AddWine";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" />
        <Route path="/wines" component={Wines} />
        <Route path="/addwine" component={AddWine} />
      </Layout>
    );
  }
}
