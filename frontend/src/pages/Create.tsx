import { Typography, Button } from "@mui/material"
import { useState } from "react";
import { Link, NavLink } from "react-router-dom"
import { MessageModule } from "../models/MessageModule";
import { Product } from "../models/product";

export default function Create(){
    const[name, setName] = useState("");
    const[description, setDescription] = useState("");
    const[price, setPrice] = useState("");
    const[message, setMessage] = useState<MessageModule | null>(null)
    async function CreateProduct(){
        await fetch(`https://localhost:7141/api/Product/CreateProduct`,{method: 'POST', headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },body:JSON.stringify({'name': name,'description': description, 'price':price , 
          'token': localStorage.getItem('token')?.toString() })}).then((response) =>
      response.json().then((data) => alert(data.message)))
    }
    return(
        <>
        <Typography>Create New Product</Typography> 
        <input type="text" placeholder="name" onChange={async (e)=>{setName(e.target.value)}}></input><li></li>
        <input type="text" placeholder="description" onChange={async (e)=>{setDescription(e.target.value)}}></input><li></li>
        <input type="text" placeholder="price" onChange={async (e)=>{setPrice(e.target.value)}}></input><li></li>
        <Button component= {Link} to= {`/MyProducts`} onClick={CreateProduct} > Submit </Button>
        </>
    )
}