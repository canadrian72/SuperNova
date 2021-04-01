import React, { Component } from 'react';

export class Launch extends Component {
  static displayName = Launch.name;

  constructor(props) {
    super(props);
    this.state = { launchTreat : false };
    this.launch = this.launch.bind(this);
  }

  render() {
    return (
      <div>
        <h1>Launch A Treat</h1>

        <p>Press the button to Yeet a Treet</p>
             
        <button className="btn btn-primary" onClick={this.launch}>Launch</button>
      </div>
    );
    }

    async launch() {
        const axios = require('axios');

        axios.post('/Launcher', {
            "power": 0
        })
            .then(function (response) {
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
            });
        this.state.lightOn = !this.state.lightOn;
    }
}
