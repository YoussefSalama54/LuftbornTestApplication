import { Product } from "../models/product";
import MyProductlist from "../features/myproductlist";
import { useState, useEffect } from "react";



export default function MyProducts() {
     const [products, setProducts] = useState<Product[]>([]);
  useEffect(() => {
    fetch(`https://localhost:7141/api/Product/GetMyPostedProducts/${localStorage.getItem('token')?.toString()}`,{method: 'GET', headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    }}).then((response) =>
      response.json().then((data) => setProducts(data)),
    );
  }, []);
  
  return (
    <>
      <MyProductlist products = {products}/>
      
    </>
  );
    

}