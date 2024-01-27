import { Product } from "../models/product";
import { Button } from "@mui/material";
import Productlist from "./productlist";
import { useState, useEffect } from "react";


export default function Catalog() {

     const [products, setProducts] = useState<Product[]>([]);
  useEffect(() => {
    fetch(`https://localhost:7141/api/Product/GetAvailableProducts/${localStorage.getItem('token')?.toString()}`).then((response) =>
      response.json().then((data) => setProducts(data)),
    );
  }, []);
  function addProduct() {
    setProducts((prevState) => [
      ...prevState,
      {
        id: prevState.length + 101,
        name: "product" + (prevState.length + 1),
        price: prevState.length * 100 + 100,
        ownedById:"",
        description: "some description",
        pictureUrl: "../public/products/productimage2.jpg",
      },
    ]);
  }
  return (
    
    <>
      <Productlist products = {products}/>
      <Button variant= 'outlined' onClick={addProduct}>Add Product</Button>
    </>
  );
}