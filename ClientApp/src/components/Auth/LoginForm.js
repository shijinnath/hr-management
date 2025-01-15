import React, { useState } from 'react';
import authService from '../services/authService';

const LoginForm = () => {
  const [credentials, setCredentials] = useState({ username: '', password: '' });

  const handleLogin = async () => {
    try {
      const data = await authService.login(credentials);
      console.log('Login successful', data); // Redirect or update UI
    } catch (error) {
      console.error('Login failed:', error.message);
    }
  };

  return (
    <div>
      <input
        type="text"
        placeholder="Username"
        value={credentials.username}
        onChange={(e) => setCredentials({ ...credentials, username: e.target.value })}
      />
      <input
        type="password"
        placeholder="Password"
        value={credentials.password}
        onChange={(e) => setCredentials({ ...credentials, password: e.target.value })}
      />
      <button onClick={handleLogin}>Login</button>
    </div>
  );
};

export default LoginForm;
