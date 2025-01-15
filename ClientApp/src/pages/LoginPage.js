import React, { useState } from 'react';
import authService from '../services/authService';
import { useNavigate  } from "react-router-dom"; 
const LoginPage = (props) => {
  const [credentials, setCredentials] = useState({ email: '', password: '' });
  const history = useNavigate();
  const handleLogin = async () => {
    try {
      const data = await authService.login(credentials);
      console.log(data);
      localStorage.setItem('token', data.token);
      console.log('Login successful', data); // Redirect or update UI
      history('/employee-overview')
    } catch (error) {
      console.error(error.message);
    }
  };

  return (
    <div>
      <input
        type="text"
        placeholder="Username"
        value={credentials.username}
        onChange={(e) => setCredentials({ ...credentials, email: e.target.value })}
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

export default LoginPage;
