import { BrowserRouter, Routes, Route } from "react-router-dom";

// Páginas principais
import Login from "../pages/login/Login";
import Gerente from "../pages/telagerente/TelaGerente";
import TelaGestor from "../pages/telagestor/TelaGestor";
import Acessos from "../pages/acessos/Acessos";
import GraficosDetalhados from "../pages/grafico/Grafico";
import Dominios from "../pages/dominios/Dominios";
import CadastroUsuario from "../pages/cadastroUsuario/CadastroUsuario";
import TarefasPendentes from "../pages/tarefasPendentes/TarefasPendentes";
import CadastroDeTarefas from "../pages/cadastroDeTarefas/CadastroDeTarefas";
import Mensagem from "../pages/mensagem/Mensagem";
import MensagemGestor from "../pages/mensagemGestor/MensagemGestor";
import ComparacaoFunc from "../../src/pages/comparacao/ComparacaoFunc";



const Rotas = () => {
  return (
    <BrowserRouter>
      <Routes>
        {/* Página de login */}
        <Route path="/" element={<Login />} />

        {/* Telas principais */}
        <Route path="/Gerente" element={<Gerente />} />
        <Route path="/Gestor" element={<TelaGestor />} />

        {/* Outras páginas */}
        <Route path="/Acesso" element={<Acessos />} />
        <Route path="/Graficos" element={<GraficosDetalhados />} />
        <Route path="/Dominio" element={<Dominios />} />
        <Route path="/Cadastro" element={<CadastroUsuario />} />
        <Route path="/TarefasPendentes" element={<TarefasPendentes />} />
        <Route path="/CadastroDeTarefas" element={<CadastroDeTarefas />} />
        <Route path="/Mensagem" element={<Mensagem />} />
        <Route path="/MensagemGestor" element={<MensagemGestor />} />
        <Route path="/Comparação" element={<ComparacaoFunc />} />

      </Routes>
    </BrowserRouter>
  );
};

export default Rotas;
