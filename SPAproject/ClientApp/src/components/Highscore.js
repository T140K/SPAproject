import React, { useState } from 'react';

const Highscore = () => {
    const containerStyle = {
        display: 'flex',
        flexDirection: 'row',
        justifyContent: 'space-between',
    };

    return (
        <div style={containerStyle}>
            <div>
                <h3>Best of all time</h3>
            </div>
            <div>
                <h3>Best of today</h3>
            </div>
        </div>
    );
}

export default Highscore;