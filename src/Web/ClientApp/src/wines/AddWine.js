import React, { Component } from "react";

class AddWine extends Component {
  render() {
    return (
      <div className="section">
        <div className="container">
          <form method="get">
            <div className="field has-addons">
              <div className="control">
                <input className="input" type="text" placeholder="Vinmonopolet id" name="vinmonopoletId" />
              </div>
              <div className="control">
                <input type="submit" className="button" />
              </div>
            </div>
          </form>

          <ul>
            <li>Model.Data.Name</li>
            <li>Model.Data.Vintage</li>
            <li>Model.Data.Producer</li>
            <li>Model.Data.Price</li>
            <li>Model.Data.Country</li>
          </ul>
        </div>
      </div>
    );
  }
}

export default AddWine;
