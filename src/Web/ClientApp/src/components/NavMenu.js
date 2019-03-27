import React, { Component } from "react";
import { Link } from "react-router-dom";

export default class NavMenu extends Component {
  render() {
    return (
      <nav class="navbar is-fixed-bottom is-warning">
        <div class="container">
          <Link to="Wines" className="navbar-item">
            Wines
          </Link>
          <Link to="AddWine" className="navbar-item">
            Add new
          </Link>
        </div>
      </nav>
    );
  }
}
