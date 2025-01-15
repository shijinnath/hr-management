import axios from 'axios';
import apiClient from '../utils/apiClient';

const authService = {
  login: async (credentials) => {
    try {
      const response = await apiClient.post(`auth-service/api/auth/login`, credentials);
      return response.data;
    } catch (error) {
      throw new Error('Login failed: ' + error.message);
    }
  },

  validateToken: async (token) => {
    try {
      const response = await apiClient.post('/auth/validate', { token });
      return response.data;
    } catch (error) {
      throw new Error('Token validation failed: ' + error.message);
    }
  }
};

export default authService;