import { List, ListItem, ListItemAvatar, Avatar, ListItemText, Grid } from "@mui/material";
import { Product } from "../models/product";
import Productitem from "./productitem";
import Header from "../layout/header";

interface Props {
    products: Product[];
    
  }
export default function Productlist({products}:Props){
    return(
      <>
      <Header/> 
    <Grid container spacing={4}>
        {products.map((product) => (
        <Grid item xs={4}>
          <Productitem key ={product.id} product={product}/>
        </Grid>
        ))}
      </Grid>
      </>
      )
}