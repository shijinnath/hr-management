import axios from 'axios';
import apiClient from '../utils/apiClient';

const employeeService = {
  getEmployees: async () => {
    try {
      const response = await apiClient.get('/employee-service/api/employee');
      return response.data;
    } catch (error) {
      throw new Error('Fetching employees failed: ' + error.message);
    }
  },

  getEmployeeById: async (id) => {
    try {
      const response = await apiClient.get(`/employee-service/api/employee${id}`);
      return response.data;
    } catch (error) {
      throw new Error('Fetching employee by ID failed: ' + error.message);
    }
  }
};

export default employeeService;
