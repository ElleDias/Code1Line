import { BrowserRouter, Routes, Route } from "react-router-dom";
import CadastroUsuario from "../pages/cadastroUsuario/CadastroUsuario";
import TarefasPendentes from "../pages/tarefasPendentes/TarefasPendentes";
import CadastroDeTarefas from "../pages/cadastroDeTarefas/CadastroDeTarefas";

// import { Routes } from "react-router-dom";

const Rotas = () => {
    return(
        <BrowserRouter>
            <Routes>
                {/* http://localhost:3000/Cadastro => Cadastro */}
                  <Route path="/Cadastro" element={<CadastroUsuario/>} exact/>
                   <Route path="/TarefasPendentes" element={<TarefasPendentes/>} exact/>
                   <Route path="/CadastroDeTarefas" element={<CadastroDeTarefas/>} exact/>
            </Routes>
        </BrowserRouter>
    )
}

export default Rotas;