// import Home from './components/Home';
import Login from '../pages/LoginPage'; 
import LeaveManagement from '../pages/LeaveManagement';
import NotFound from '../pages/NotFound';
import EmployeeOverview from '../pages/EmployeeOverview';

const routes = [ 
  { path: '/login', element: <Login  /> },
  { path: '/employee-overview', element: <EmployeeOverview /> },
  { path: '/leave-management', element: <LeaveManagement /> }, 
  { path: '*', element: <NotFound /> }, // Catch-all route for undefined paths
];

export default routes;
