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
    await fetch(`api/inventoryProducts`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(state.searchResult)
    });
  };

  return (
    <div>
      <div className="section">
        <ProductSearch searchProduct={searchProduct} searchResult={state.searchResult} addProduct={addProduct} />
      </div>
      <div className="section">{state.searchResult ? <ProductInfoCard product={state.searchResult} /> : null}</div>
    </div>
  );
};

export default ProductSearchContainer;
