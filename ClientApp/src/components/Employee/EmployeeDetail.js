import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import employeeService from '../services/employeeService';

const EmployeeDetail = () => {
  const { id } = useParams(); // Assumes the route is like /employee/:id
  const [employee, setEmployee] = useState(null);

  useEffect(() => {
    const fetchEmployeeDetail = async () => {
      try {
        const data = await employeeService.getEmployeeById(id);
        setEmployee(data);
      } catch (error) {
        console.error('Error fetching employee details:', error.message);
      }
    };

    fetchEmployeeDetail();
  }, [id]);

  if (!employee) {
    return <p>Loading employee details...</p>;
  }

  return (
    <div>
      <h1>Employee Details</h1>
      <p><strong>Name:</strong> {employee.name}</p>
      <p><strong>Department:</strong> {employee.department}</p>
      <p><strong>Manager:</strong> {employee.reportingManager}</p>
      <p>
        <strong>Photo:</strong> 
        {employee.photo ? (
          <img src={employee.photo} alt={`${employee.name}`} style={{ width: '100px', height: '100px' }} />
        ) : (
          'No photo available'
        )}
      </p>
    </div>
  );
};

export default EmployeeDetail;
