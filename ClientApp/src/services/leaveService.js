import axios from 'axios';
import apiClient from '../utils/apiClient';

const leaveService = {
  getLeaveRequests: async () => {
    try {
      const response = await apiClient.get('/leaves');
      return response.data;
    } catch (error) {
      throw new Error('Fetching leave requests failed: ' + error.message);
    }
  },
  getLeaveHistory: async () => {
    try {
      const response = await apiClient.get('/leave/history');
      return response.data;
    } catch (error) {
      throw new Error('Error fetching leave history: ' + error.message);
    }
  },
  applyLeave: async (leaveData) => {
    try {
      const response = await apiClient.post('/leaves', leaveData);
      return response.data;
    } catch (error) {
      throw new Error('Applying leave failed: ' + error.message);
    }
  }
};

export default leaveService;
