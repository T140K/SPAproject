import React, { useState, useEffect } from 'react';

const Highscore = () => {
    const [highscoreToday, setHighscoreToday] = useState([]);
    const [highscoreAllTime, setHighscoreAllTime] = useState([]);

    const containerStyle = {
        display: 'flex',
        flexDirection: 'row',
        justifyContent: 'space-between',
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch('/api/highscore');
                const data = await response.json();
                setHighscoreToday(data.today);
                setHighscoreAllTime(data.allTime);
            } catch (error) {
                console.error('Error: ', error);
            }
        };

        fetchData();
    }, []);


    return (
        <div style={containerStyle}>
            <div>
                <h3>Best of all time</h3>
                <ul>
                    {highscoreAllTime.map((highscore, index) => (
                        <li key={index}>
                            {highscore.user}: {highscore.guessAmount} guesses<br />
                            Date: {highscore.date}
                        </li>
                    ))}
                </ul>
            </div>
            <div>
                <h3>Best of today</h3>
                <ul>
                    {highscoreToday.map((highscore, index) => (
                        <li key={index}>
                            {highscore.user}: {highscore.guessAmount} guesses<br />
                            Date: {highscore.date}
                        </li>
                    ))}
                </ul>
            </div>
        </div>
    );
}

export default Highscore;