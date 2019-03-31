import React, { Component } from "react";

class ProductSearchForm extends Component {
  render() {
    return (
      <form>
        <div className="field has-addons">
          <div className="control">
            <input className="input" type="text" placeholder="Vinmonopolet id" name="vinmonopoletId" />
          </div>
          <div className="control">
            <a className="button" onClick={() => this.props.searchProduct()}>
              Search
            </a>
          </div>
        </div>
      </form>
    );
  }
}

export default ProductSearchForm;
