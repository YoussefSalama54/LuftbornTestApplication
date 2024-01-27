import { Button, Typography } from "@mui/material";
import { useState, useCallback } from "react";
import { NavLink, useNavigate } from "react-router-dom";
import { LoginModule } from "../models/LoginModule";
import  '../styles/styles.css'

export default function Login(){
    const[login, setLogin] = useState<LoginModule | null>(null)
    const[email, setEmail] = useState("");
    const[password, setPassword] = useState("");
    const navigate = useNavigate();

    const loginSuccess =  useCallback(() => {
        
        if (login?.token != null) {
          navigate("/products", { replace: true });
          localStorage.setItem("token", login.token)
        }
        console.log(login);
      }, [login, navigate]);

    const logincheck = useCallback(()=> {
        fetch(`https://localhost:7141/api/MarketPlaceUser/Login`, {method: 'POST', headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },body:JSON.stringify({'Email' : email, 'Password':password})}).then((response) =>
      response.json().then((data) => setLogin(data)),);
    },[email,password])
    function loginConfirm(){
        logincheck();
        //console.log(login);
        if(login != null){
            alert(login.message)
        loginSuccess();
            
        }
    }
    return(
        <h2>
        <Typography>Login Page</Typography> 
        <input type="text" placeholder="email" onChange={async (e)=>{setEmail(e.target.value)}}></input><li></li>
        <input type="password" placeholder="password" onChange={async (e)=>{setPassword(e.target.value)}}></input><li></li>
        <button  onClick={loginConfirm}> Login </button>
        <NavLink to='/Register'> Don't have an account? Register</NavLink>
        </h2>
    )
} 