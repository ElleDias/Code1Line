import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "../pages/login/Login";
import Gerente from "../pages/telagerente/TelaGerente";

const Rotas = () => {
    return (
        <BrowserRouter>
            <Routes>
                {/* http://localhost:3000/ => Login */}
                <Route path="/" element={<Login/>} exact />
                {/* http://localhost:3000/ => Gerente */}
                <Route path="/Gerente" element={<Gerente/>} exact />
            </Routes>
        </BrowserRouter>
    )
}

export default Rotas;
