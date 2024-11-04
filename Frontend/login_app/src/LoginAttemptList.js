import React, { useState } from "react";
import "./LoginAttemptList.css";

const LoginAttempt = ({ attempt }) => (
    <li>
        <strong>{attempt.login}</strong> attempted to log in at {attempt.timestamp}
    </li>
);

const LoginAttemptList = ({ attempts }) => {
    const [filter, setFilter] = useState('');

    const filteredAttempts = attempts.filter(attempt =>
        attempt.login.toLowerCase().includes(filter.toLowerCase())
    );

    return (
        <div className="Attempt-List-Main">
            <p>Recent activity</p>
            <input
                type="text"
                placeholder="Filter..."
                value={filter}
                onChange={(e) => setFilter(e.target.value)}
            />
            <ul className="Attempt-List">
                {filteredAttempts.map((attempt, index) => (
                    <LoginAttempt key={index} attempt={attempt} />
                ))}
            </ul>
        </div>
    );
};

export default LoginAttemptList;
