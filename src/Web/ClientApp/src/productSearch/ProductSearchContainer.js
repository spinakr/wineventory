import React, { useState } from "react";
import ProductSearch from "./ProductSearch";
import ProductInfoCard from "../components/ProductInfoCard";

const ProductSearchContainer = () => {
  const [state, setState] = useState({ searchResult: null });

  const searchProduct = async searchInput => {
    let res = await fetch(`api/vinmonopoletProduct/${searchInput}`);
    setState({ searchResult: await res.json() });
  };

  const addProduct = async () => {
    let res = await fetch(`api/vinmonopoletProduct`, {
      method: "POST",
      body: JSON.stringify(state.searchResult)
    });
  };

  return (
    <div className="section">
      <div className="container">
        <ProductSearch searchProduct={searchProduct} searchResult={state.searchResult} addProduct={addProduct} />
        {state.searchResult ? <ProductInfoCard product={state.searchResult} /> : null}
      </div>
    </div>
  );
};

export default ProductSearchContainer;