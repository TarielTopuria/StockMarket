import { Outlet } from 'react-router';
import './App.css';
import Navbar from './Navbar/Navbar';

function App() 
{ 
  return (
    <div>
      <Navbar/>
      <Outlet/>
    </div>
  );
}

export default App;