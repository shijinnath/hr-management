import logo from './logo.svg';
import './App.css';
import EmployeeOverview from './pages/EmployeeOverview';
import LeaveManagement from './pages/LeaveManagement';
import NotFound from './pages/NotFound';
import { Routes,Route } from 'react-router-dom';  
import { useRoutes } from 'react-router-dom';
import routes from './utils/routes';
function App() {
  const routing = useRoutes(routes);
  return <>{routing}</>;
}

export default App;
