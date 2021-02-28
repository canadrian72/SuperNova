import React, { Component } from 'react';
import nova from '../images/nova.jpg'

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Nova's Brothel</h1>
            <p>Welcome to the Super Nova Launch System&trade;</p>
            <img src={nova} width = "300" height = "400"/>
      </div>
    );
  }
}
