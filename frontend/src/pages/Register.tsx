import { Button, Typography } from "@mui/material";
import { useState, useCallback } from "react";
import { useNavigate } from "react-router-dom";
import { LoginModule } from "../models/LoginModule";
import { MessageModule } from "../models/MessageModule";


export default function Resgister(){
    const[register, setRegister] = useState<MessageModule | null>(null)
    const[email, setEmail] = useState("");
    const[username, setUsername] = useState("");
    const[password, setPassword] = useState("");
    const navigate = useNavigate();

    const RegisterSuccess =  useCallback(() => {
        
        if (register?.success == true) {
          navigate("/", { replace: true });
          
        }
        console.log(register);
      }, [register, navigate]);

    const RegisterCheck = useCallback(()=> {
        fetch(`https://localhost:7141/api/MarketPlaceUser/Register`, {method: 'POST', headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },body:JSON.stringify({'Email' : email, 'userName' : username, 'Password':password})}).then((response) =>
      response.json().then((data) => setRegister(data)),);
    },[email,password])
    function RegisterConfirm(){
        RegisterCheck();
        //console.log(login);
        if(register != null){
            alert(register.message)
        RegisterSuccess();
            
        }
    }
    return(
        <>
        <Typography>RegisterPage</Typography> 
        <input type="text" placeholder="email" onChange={async (e)=>{setEmail(e.target.value)}}></input><li></li>
        <input type="text" placeholder="username" onChange={async (e)=>{setUsername(e.target.value)}}></input><li></li>
        <input type="text" placeholder="password" onChange={async (e)=>{setPassword(e.target.value)}}></input><li></li>
        <Button onClick={RegisterConfirm}> Register </Button>
        </>
    )
} 