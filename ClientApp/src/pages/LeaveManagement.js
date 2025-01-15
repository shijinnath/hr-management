import React, { useState } from 'react';
import leaveService from '../services/leaveService';

const LeaveManagement = () => {
  const [leaveData, setLeaveData] = useState({
    reason: '',
    startDate: '',
    endDate: '',
  });
  const [message, setMessage] = useState('');

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setLeaveData({ ...leaveData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await leaveService.applyLeave(leaveData);
      setMessage('Leave request submitted successfully!');
      setLeaveData({ reason: '', startDate: '', endDate: '' });
    } catch (error) {
      setMessage('Error submitting leave request: ' + error.message);
    }
  };

  return (
    <div>
      <h1>Leave Management</h1>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Reason:</label>
          <input
            type="text"
            name="reason"
            value={leaveData.reason}
            onChange={handleInputChange}
          />
        </div>
        <div>
          <label>Start Date:</label>
          <input
            type="date"
            name="startDate"
            value={leaveData.startDate}
            onChange={handleInputChange}
          />
        </div>
        <div>
          <label>End Date:</label>
          <input
            type="date"
            name="endDate"
            value={leaveData.endDate}
            onChange={handleInputChange}
          />
        </div>
        <button type="submit">Submit</button>
      </form>
      {message && <p>{message}</p>}
    </div>
  );
};

export default LeaveManagement;
