import { Container } from "@mui/material";
import Header from "./layout/header";
import { Outlet } from "react-router-dom";


function App() {
 
  return (
    <div>
      
      
      <Container>
        <Outlet/>
      </Container>
      
      
    </div>
  );
}
export default App;
