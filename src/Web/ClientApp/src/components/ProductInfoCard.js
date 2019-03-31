import React from "react";

const ProductInfoCard = ({ product }) => {
  if (!product) return null;
  return (
    <div className="box">
      <article className="media">
        <div className="media-left">
          <figure className="image is-128x128">
            <img src="https://bulma.io/images/placeholders/256x256.png" alt="Placeholder" />
          </figure>
        </div>
        <div className="media-content">
          <div className="content">
            <p className="title">
              {product.name} ({product.vintage})
            </p>
            <p className="subtitle">
              {product.fruit} - {product.country}
            </p>
            <p>{product.price}</p>
          </div>
        </div>
      </article>
    </div>
  );
};

export default ProductInfoCard;
