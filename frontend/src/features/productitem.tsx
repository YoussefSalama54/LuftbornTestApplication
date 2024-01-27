import { List, ListItem, ListItemAvatar, Avatar, ListItemText, Button, Card, CardActions, CardContent, CardMedia, Typography, CardHeader } from "@mui/material";
import { Product } from "../models/product";
import { Link } from "react-router-dom";

interface Props {
    product: Product;
    
  }
export default function Productitem({product}:Props){
    return(
    // <List>
        
    //       <ListItem key={product.id}>
    //         <ListItemAvatar>
    //             <Avatar src ={product.pictureUrl}></Avatar>
    //         </ListItemAvatar>
    //         <ListItemText>{product.name}:{product.description}--- {product.price}</ListItemText>
    //       </ListItem>
        
    //   </List>
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
        
        <Button component= {Link} to= {`/ProductDetails/${product.id}`}size="small">Learn More</Button>
      </CardActions>
    </Card>
      )
}