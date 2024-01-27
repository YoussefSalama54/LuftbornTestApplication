import { Typography, Button } from "@mui/material"
import { useEffect, useState } from "react";
import { Link, NavLink, useParams } from "react-router-dom"
import { MessageModule } from "../models/MessageModule";
import { Product } from "../models/product";
import '../styles/styles.css';
interface Props {
    product: Product;
    
  }
export default function Update(){
    const{id} = useParams<{id:string}>();
    const[name, setName] = useState("");
    const[description, setDescription] = useState("");
    const[price, setPrice] = useState("");
    const[product, setProduct] = useState<Product>();
    const[message, setMessage] = useState<MessageModule | null>(null)

    

    async function UpdateProduct(){
        await fetch(`https://localhost:7141/api/Product/UpdateProduct`,{method: 'POST', headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },body:JSON.stringify({'id':id,'name': name,'description': description, 'price':price ,
           'token':localStorage.getItem('token')?.toString() })}).then((response) =>
      response.json().then((data) => alert(data.message)))
    }
    return(
        <>
        <Typography>Update Product</Typography> 
        <input type="text" placeholder="name" onChange={async (e)=>{setName(e.target.value)}}></input><li></li>
        <input type="text" placeholder="description" onChange={async (e)=>{setDescription(e.target.value)}}></input><li></li>
        <input type="text" placeholder="price" onChange={async (e)=>{setPrice(e.target.value)}}></input><li></li>
        <Button component= {Link} to= {`/MyProducts`} onClick={UpdateProduct} > Submit </Button>
        </>
    )
}