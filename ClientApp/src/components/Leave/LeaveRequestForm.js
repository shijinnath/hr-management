import React, { useState } from 'react';
import leaveService from '../services/leaveService';

const LeaveRequestForm = () => {
  const [leaveData, setLeaveData] = useState({ reason: '', startDate: '', endDate: '' });

  const handleSubmit = async () => {
    try {
      const data = await leaveService.applyLeave(leaveData);
      console.log('Leave request successful', data);
    } catch (error) {
      console.error('Error submitting leave request:', error.message);
    }
  };

  return (
    <div>
      <h1>Apply for Leave</h1>
      <input
        type="text"
        placeholder="Reason"
        value={leaveData.reason}
        onChange={(e) => setLeaveData({ ...leaveData, reason: e.target.value })}
      />
      <input
        type="date"
        placeholder="Start Date"
        value={leaveData.startDate}
        onChange={(e) => setLeaveData({ ...leaveData, startDate: e.target.value })}
      />
      <input
        type="date"
        placeholder="End Date"
        value={leaveData.endDate}
        onChange={(e) => setLeaveData({ ...leaveData, endDate: e.target.value })}
      />
      <button onClick={handleSubmit}>Submit Leave Request</button>
    </div>
  );
};

export default LeaveRequestForm;
