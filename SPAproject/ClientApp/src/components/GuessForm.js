import React, { useState } from 'react';

const GuessForm = ({ onGuess }) => {
    const [guess, setGuess] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        onGuess(guess);
    }

    return (
        <form onSubmit={handleSubmit}>
            <input
                type="number"
                value={guess}
                onChange={(e) => setGuess(e.target.value) }
            />
            <button type="submit">Guess</button>
        </form>
    );
}

export default GuessForm;