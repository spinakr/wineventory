import React, { Component } from "react";
import NavMenu from "./NavMenu";
import HeaderBanner from "./HeaderBanner";

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <div>
        <HeaderBanner />
        {this.props.children}
        <NavMenu />
      </div>
    );
  }
}
