import React, { useState } from "react";

const ProductSearch = ({ searchProduct, searchResult, addProduct }) => {
  const [searchInput, setSearchInput] = useState("");
  return (
    <form>
      <div className="field is-grouped">
        <div className="control">
          <input className="input" value={searchInput} onChange={e => setSearchInput(e.target.value)} type="text" />
        </div>
        <div className="control">
          <a className="button" onClick={() => searchProduct(searchInput)}>
            Search
          </a>
        </div>
        {searchResult && (
          <div className="control">
            <a className="button" onClick={() => addProduct()}>
              Add
            </a>
          </div>
        )}
      </div>
    </form>
  );
};

export default ProductSearch;
