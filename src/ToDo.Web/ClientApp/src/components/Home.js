import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello, world!</h1>
        <p>Welcome to your new Todo List build with Asp.net Core 3.1 with Reactjs</p>
        
        <p>Use the top menu to navigate to the different pages</p>
      </div>
    );
  }
}
