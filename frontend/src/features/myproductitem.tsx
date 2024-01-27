import { Button, Card, CardActions, CardContent, CardMedia, Typography, CardHeader } from "@mui/material";
import { Product } from "../models/product";
import { useState } from "react";
import { MessageModule } from "../models/MessageModule";
import { Link } from "react-router-dom";

interface Props {
    product: Product;
    
  }
export default function MyProductitem({product}:Props){
  const[name, setName] = useState(product.name);
  const[description, setDescription] = useState(product.description);
  const[price, setPrice] = useState(product.price);
  const[message, setMessage] = useState<MessageModule | null>(null)

  async function DeleteProduct(){
      await fetch(`https://localhost:7141/api/Product/DeleteProduct/${product.id}`,{method: 'POST', headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        }}).then((response) =>
    response.json().then((data) => alert(data.message)))
  }
  

    return(
    
    <Card sx={{ maxWidth: 345 }}>
      <CardHeader title={product.name}>

      </CardHeader>
      <CardMedia    
        sx={{ height: 140, backgroundSize:'contain'}}
        image={product.pictureUrl}
        title={product.name}
      />
      <CardContent>
        <Typography gutterBottom variant="h5" component="div">
          {product.price}
        </Typography>
        
      </CardContent>
      <CardActions>
        
        <Button component= {Link} to= {`/Update/${product.id}`}  size="small">Update</Button>
        <Button component= {Link} to= {`/MyProducts`} onClick={DeleteProduct} size="small">Delete</Button>
      </CardActions>
    </Card>
      )
}