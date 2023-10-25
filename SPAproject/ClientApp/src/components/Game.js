import React, { useState } from 'react';
import GuessForm from './GuessForm';
import authService from './AuthorizeService'

const Game = () => {
    const [gameId, setGameId] = useState(null);
    const [answer, setAnswer] = useState(null);

    const startNewGame = async () => {
        try {
            const token = await authService.getAccessToken();
            const response = await fetch('/api/game', {
                method: 'POST',
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            })
            const data = await response.json();
            setGameId(data.gameId);
            setAnswer(null);
        } catch (error) {
            console.error('error: ', error)
        }
    };

    const handleGuess = async (guess) => {
        try {
            const token = await authService.getAccessToken();
            const response = await fetch(`/api/guess/${gameId}/${guess}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            })
            const data = await response.json();
            setAnswer(data.response);
        } catch (error) {
            console.error('Error: ', error)
        }
    };
    return (
        <div>
            <h1>Guess the number</h1>
            <button onClick={startNewGame}>New game</button>
            <GuessForm onGuess={handleGuess} />
            <p>{answer}</p>
        </div>
    )
}

export default Game;