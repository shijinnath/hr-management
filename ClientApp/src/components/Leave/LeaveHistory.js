import React, { useEffect, useState } from 'react';
import leaveService from '../services/leaveService';

const LeaveHistory = () => {
  const [leaveHistory, setLeaveHistory] = useState([]);

  useEffect(() => {
    const fetchLeaveHistory = async () => {
      try {
        const data = await leaveService.getLeaveHistory();
        setLeaveHistory(data);
      } catch (error) {
        console.error('Error fetching leave history:', error.message);
      }
    };

    fetchLeaveHistory();
  }, []);

  return (
    <div>
      <h1>Leave History</h1>
      {leaveHistory.length > 0 ? (
        <table>
          <thead>
            <tr>
              <th>Reason</th>
              <th>Start Date</th>
              <th>End Date</th>
              <th>Status</th>
            </tr>
          </thead>
          <tbody>
            {leaveHistory.map((leave) => (
              <tr key={leave.id}>
                <td>{leave.reason}</td>
                <td>{new Date(leave.startDate).toLocaleDateString()}</td>
                <td>{new Date(leave.endDate).toLocaleDateString()}</td>
                <td>{leave.status}</td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        <p>No leave history available.</p>
      )}
    </div>
  );
};

export default LeaveHistory;
