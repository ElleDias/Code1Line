import { BrowserRouter, Routes, Route } from "react-router-dom";
import CadastroUsuario from "../pages/cadastroUsuario/CadastroUsuario";

// import { Routes } from "react-router-dom";

const Rotas = () => {
    return(
        <BrowserRouter>
            <Routes>
                {/* http://localhost:3000/Cadastro => Cadastro */}
                  <Route path="/Cadastro" element={<CadastroUsuario/>} exact/>
            </Routes>
        </BrowserRouter>
    )
}

export default Rotas;