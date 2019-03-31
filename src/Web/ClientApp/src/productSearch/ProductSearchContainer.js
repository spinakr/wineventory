import React, { Component } from "react";
import ProductSearch from "./ProductSearchForm";
import ProductInfoCard from "../components/ProductInfoCard";

class ProductSearchContainer extends Component {
  constructor() {
    super();
    this.state = { searchResult: null };
    this.searchProduct = this.searchProduct.bind(this);
  }

  async searchProduct() {
    let res = await fetch("api/vinmonopoletProduct/3833001");
    this.setState({ searchResult: await res.json() });
  }

  render() {
    return (
      <div className="section">
        <div className="container">
          <ProductSearch searchProduct={this.searchProduct} />
          {this.state.searchResult ? <ProductInfoCard product={this.state.searchResult} /> : null}
        </div>
      </div>
    );
  }
}

export default ProductSearchContainer;
