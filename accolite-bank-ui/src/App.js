import logo from './logo.svg';
import './App.css';
import { Route, Routes } from "react-router-dom"
import Home from "./Components/Home"
import User from "./Components/User"
import SignUp from "./Components/Signup"
import Login from "./Components/Login"
import Navbar from './Components/Navbar/Navbar';
import Transactions from './Components/Transactions';

function App() {
  return (
    <div id="layout">
      <Navbar/>
      <Routes>
        <Route path='/' element={<Home/>} />
        <Route path='/signup' element={<SignUp/>} />
        <Route path='/login' element={<Login/>} />
        <Route path='/transactions' element={<Transactions/>} />
        <Route path='/account' element={<User/>} />
      </Routes>
    </div>
  );
}

export default App;
