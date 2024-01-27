import { AppBar, List, ListItem, Toolbar, Typography } from "@mui/material";
import { NavLink } from "react-router-dom";

const navlinks=[
    {title:'Products',path:'/products'},
    {title:'Login',path:'/'},
    {title:'My Products',path:'/MyProducts'},
    {title:'Post Product', path:'/Create'}
]

export default function Header(){
    return(
       
        <AppBar position = 'static'>
            <Toolbar>
                <Typography variant = 'h5'>
                    Market Place
                </Typography>
                <List sx={{display:'flex'}}>
                    {navlinks.map((navlink)=> (
                        <ListItem>
                            <NavLink to={navlink.path}> {navlink.title}</NavLink>
                        </ListItem>
                    ))}
                </List>
            </Toolbar>
        </AppBar>
        
    )
}