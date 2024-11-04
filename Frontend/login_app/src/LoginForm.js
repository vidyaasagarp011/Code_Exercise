import React, { useState } from "react";
import './LoginForm.css';

const LoginForm = (props) => {
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();

        props.onSubmit({
            login,
            password,
        });

        setLogin('');
        setPassword('');
    }

    return (
        <form className="form" onSubmit={handleSubmit}>
            <h1>Login</h1>

            <div className="form-group">
                <label htmlFor="name">Name</label>
                <input
                    type="text"
                    id="name"
                    value={login}
                    onChange={(e) => setLogin(e.target.value)}
                />
            </div>

            <div className="form-group">
                <label htmlFor="password">Password</label>
                <input
                    type="password"
                    id="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
            </div>

            <button type="submit">Continue</button>
        </form>
    )
}

export default LoginForm;
