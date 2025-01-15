import React, { useEffect, useState } from 'react';
import employeeService from '../services/employeeService';

const EmployeeOverview = () => {
  const [employees, setEmployees] = useState([]);

  useEffect(() => {
    const fetchEmployees = async () => {
      try {
        const data = await employeeService.getEmployees();
        console.log(data)
        setEmployees(data);
      } catch (error) {
        console.error('Error fetching employees:', error.message);
      }
    };

    fetchEmployees();
  }, []);

  return (
    <div>
      <h1>Employee Overview</h1>
      {employees && employees.length > 0 ? (
        <table>
          <thead>
            <tr>
              <th>Name</th>
              <th>Department</th>
              <th>Manager</th>
            </tr>
          </thead>
          <tbody>
            {employees.map((employee) => (
              <tr key={employee.id}>
                <td>{employee.name}</td>
                <td>{employee.department}</td>
                <td>{employee.reportingManager.name}</td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        <p>No employees found.</p>
      )}
    </div>
  );
};

export default EmployeeOverview;
