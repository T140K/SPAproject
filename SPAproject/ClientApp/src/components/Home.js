import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Hello, world</h1>
        <h3>Welcome to the high-low game!</h3>
        <p>This is a number guessing game with some hints, you go to the game tab and press play! Then you have to guess a random number between 1 and 100</p>
        <p>If your guess is higher than the answer, you will be prompted to guess lower, and vice versa</p>
        <p>The goal is to guess the answer in the least number of guesses, you can see your games in the stats tab and high scores in the highscores tab</p>
        <p>Good luck!</p>
      </div>
    );
  }
}
