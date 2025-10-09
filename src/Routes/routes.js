import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "../pages/login/Login";
import TelaGestor from "../pages/telagestor/TelaGestor";
import Acessos from "../../src/pages/acessos/Acessos"
import GraficosDetalhados from "../pages/grafico/Grafico";

function Rotas() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/Gestor" element={<TelaGestor />} />
        <Route path="/Acesso" element={<Acessos/>} />
        <Route path="/Graficos" element={<GraficosDetalhados/>} />
      </Routes>
    </BrowserRouter>
  );
}

export default Rotas;