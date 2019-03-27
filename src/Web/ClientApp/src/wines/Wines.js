import React, { Component } from "react";

class Wines extends Component {
  render() {
    return (
      <div class="section">
        <div class="container is-fluid">
          <div class="columns">
            <div class="column is-three-quarters">
              <div class="columns is-multiline">
                {[1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1].map(x => {
                  return (
                    <div class="column is-one-third">
                      <div class="box">
                        <article class="media">
                          <div class="media-left">
                            <figure class="image is-128x128">
                              <img src="https://bulma.io/images/placeholders/256x256.png" alt="Placeholder" />
                            </figure>
                          </div>
                          <div class="media-content">
                            <div class="content">
                              <p class="title">Wine name (2018)</p>
                              <p class="subtitle">Pinot Noir - France</p>
                            </div>
                          </div>
                        </article>
                      </div>
                    </div>
                  );
                })}
              </div>
            </div>
            <div class="column has-background-primary">
              <div class="level-item">Høyre1</div>
              <div class="level-item">Høyre1</div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default Wines;
