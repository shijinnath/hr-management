import React, { useEffect, useState } from 'react';
import employeeService from '../services/employeeService';

const EmployeeList = () => {
  const [employees, setEmployees] = useState([]);

  useEffect(() => {
    const fetchEmployees = async () => {
      try {
        const data = await employeeService.getEmployees();
        setEmployees(data);
      } catch (error) {
        console.error('Error fetching employees:', error.message);
      }
    };
    fetchEmployees();
  }, []);

  return (
    <div>
      <h1>Employee List</h1>
      <ul>
        {employees.map(employee => (
          <li key={employee.id}>
            {employee.name} - {employee.department}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default EmployeeList;
