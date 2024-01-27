import { List, ListItem, ListItemAvatar, Avatar, ListItemText, Grid } from "@mui/material";
import { Product } from "../models/product";
import MyProductitem from "./myproductitem"
import Header from "../layout/header";

interface Props {
    products: Product[];
    
  }
export default function myProductlist({products}:Props){
    return(
      <>
      <Header/> 
    <Grid container spacing={4}>
        {products.map((product) => (
        <Grid item xs={4}>
          <MyProductitem key ={product.id} product={product}/>
        </Grid>
        ))}
      </Grid>
      </>
      )
}