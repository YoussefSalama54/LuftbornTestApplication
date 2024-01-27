import { Button, Card, CardActions, CardContent, CardHeader, CardMedia, Typography } from "@mui/material";
import { Product } from "../models/product";
import { useState, useEffect } from "react";
import { Link, useParams } from "react-router-dom";
import { MessageModule } from "../models/MessageModule";


export default function ProductDetails(){
    const{id} = useParams<{id:string}>();
    const[product, setProduct] = useState<Product | null>(null);
    const[message, setMessage] = useState<MessageModule | null>(null)
    const[loading,setLoading] = useState(true);


    useEffect(()=> {
        fetch(`https://localhost:7141/api/Product/GetProduct/${id}`).then((response) =>
      response.json().then((data) => setProduct(data)).catch(error =>console.log(error)).finally(()=>setLoading(false)),);
    },[id])
    if(loading) return <h1>Loading...</h1>
    if(!product) return <h1>Product not found</h1>



    async function buyProduct(product:Product){
        
        console.log(product.ownedById);
        await fetch(`https://localhost:7141/api/Product/BuyProduct`,{method: 'POST', headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },body:JSON.stringify({'ownedById': product.ownedById ,'token':localStorage.getItem("token")?.toString(),'price':product.price.toString(), 'productId': product.id.toString()})}).then((response) =>
      response.json().then((data) => alert(data.message)))
      
    //   console.log(message)
    //   if(message)
    //     alert(message.message);
    }
    return(
        <>
        <Typography>Product Details</Typography>
        <Card sx={{ maxWidth: 500 }}>
        <CardHeader title={product.name}></CardHeader>
        <CardMedia    
        sx={{ height: 200, background: 'contain'}}
        image={product.pictureUrl}
        title={product.name}
        />
        <CardContent>
        <Typography gutterBottom variant="h3" component="div">
          {product.price}
        </Typography>
        <Typography variant="body1" color="text.secondary">
          {product.description}
        </Typography>
        
      </CardContent>
      <CardActions>
        
        <Button component= {Link} to= {`/Products`} onClick={() => buyProduct(product)} size="small">Buy</Button>
      </CardActions>
        </Card>
        </>
    )
}