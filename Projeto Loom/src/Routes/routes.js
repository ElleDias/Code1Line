import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "../pages/login/Login";
import Gerente from "../pages/telagerente/TelaGerente";
import TelaGestor from "../pages/telagestor/TelaGestor";
import Acessos from "../../src/pages/acessos/Acessos"
import GraficosDetalhados from "../pages/grafico/Grafico";
import Dominios from "../pages/dominios/Dominios";


const Rotas = () => {
    return (
        <BrowserRouter>
            <Routes>
                {/* http://localhost:3000/ => Login */}
                <Route path="/" element={<Login />} exact />
                {/* http://localhost:3000/ => Gerente */}
                <Route path="/Gerente" element={<Gerente />} exact />

                <Route path="/Gestor" element={<TelaGestor />} />
                <Route path="/Acesso" element={<Acessos />} />
                <Route path="/Graficos" element={<GraficosDetalhados />} />
                <Route path="/Dominio" element={<Dominios />} />
            </Routes>
        </BrowserRouter>
    )
}