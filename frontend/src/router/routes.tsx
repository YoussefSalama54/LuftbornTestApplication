import { createBrowserRouter } from "react-router-dom";
import ProductDetails from "../pages/ProductDetails";

import App from "../App";
import Login from "../pages/Login";
import Catalog from "../features/catalog";
import Register from "../pages/Register";
import MyProducts from "../pages/MyProducts";
import Create from "../pages/Create";
import Update from "../pages/Update";

export const router =  createBrowserRouter([
    {
        path:'/',
        element: <App />,
        children:[
            {path:'', element:<Login />},
            {path:'Register', element:<Register />},
            {path:'ProductDetails/:id', element:<ProductDetails/>},
            {path:'Products', element:<Catalog/>} ,
            {path:'MyProducts', element:<MyProducts/>},
            {path:'Create', element:<Create/>},
            {path:'Update/:id', element:<Update />}
            

        ]
    }
]);