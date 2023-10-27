import React, { useState, useEffect } from 'react';
import authService from './api-authorization/AuthorizeService';

const Statistics = () => {
    const [userStats, setUserStats] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const token = await authService.getAccessToken();
                const response = await fetch('/api/statistics', {
                    headers: {
                        'Authorization': `Bearer ${token}`
                    }
                });
                const data = await response.json();
                setUserStats(data);
            } catch (error) {
                console.error('Error: ', error);
            }
        };

        fetchData();
    }, []);

    return (
        <div>
            <h3>Your latest games</h3>
            <ul>
                {userStats.map((user, index) => (
                    <li key={index}>
                        Answer: {user.answer}, {user.guessCount} guesses<br />
                        Date: {user.displayDate}
                    </li>
                ))}
            </ul>
        </div>
    )
}

export default Statistics;