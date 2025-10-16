import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "../pages/login/Login";
import Gerente from "../pages/telaGerente/TelaGerente";
import TelaGestor from "../pages/telagestor/TelaGestor";
import Acessos from "../../src/pages/acessos/Acessos"
import GraficosDetalhados from "../pages/grafico/Grafico";
import Dominios from "../pages/dominios/Dominios";
import CadastroUsuario from "../pages/cadastroUsuario/CadastroUsuario";
import TarefasPendentes from "../pages/tarefasPendentes/TarefasPendentes";
import CadastroDeTarefas from "../pages/cadastroDeTarefas/CadastroDeTarefas";
import Mensagem from "../pages/mensagem/Mensagem";
import MensagemGestor from "../pages/mensagemGestor/MensagemGestor";
import RedefinirSenha from "../pages/redefinirSenha/RedefinirSenha";

const Rotas = () => {
    return (
        <BrowserRouter>
            <Routes>
                {/* http://localhost:3000/ => Login */}
                <Route path="/" element={<Login />} exact />
                {/* http://localhost:3000/ => Gestor */}
                <Route path="Gerente" element={<Gerente />} exact />
                {/* http://localhost:3000/ => Redefinir Senha */}
                <Route path="/RedefinirSenha" element={<RedefinirSenha />} exact />
                {/* http://localhost:3000/ => Gerente */}
                <Route path="/Gestor" element={<TelaGestor />} />
                {/* http://localhost:3000/ => Acessos */}
                <Route path="/Acesso" element={<Acessos />} />
                {/* http://localhost:3000/ => GraficosDetalhados */}
                <Route path="/Graficos" element={<GraficosDetalhados />} />
                {/* http://localhost:3000/ => Dominios */}
                <Route path="/Dominio" element={<Dominios />} />
                {/* http://localhost:3000/ => CadastroUsuario */}
                <Route path="/Cadastro" element={<CadastroUsuario />} exact />
                {/* http://localhost:3000/ => TarefasPendentes */}
                <Route path="/TarefasPendentes" element={<TarefasPendentes />} exact />
                {/* http://localhost:3000/ => CadastroDeTarefas */}
                <Route path="/CadastroDeTarefas" element={<CadastroDeTarefas />} exact />
                {/* http://localhost:3000/ => Mensagens */}
                <Route path="/Mensagem" element={<Mensagem />} />
                {/* http://localhost:3000/ => MensagensGestor */}
                <Route path="/MensagemGestor" element={<MensagemGestor />} />

            </Routes>
        </BrowserRouter>
    )
}
export default Rotas;