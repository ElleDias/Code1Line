import { useState } from "react";
import "./Acessos.css";
import {MenuLateral} from "../../components/Sidebar/Sidebar";

const Acesso = () => {
  const [modoSidebar, setModoSidebar] = useState("close");
  const acessoGestor = [
    { nome: "Fulano", AcessoAtual: "Youtube.com", tempoAtivo: "6 horas e 40 minutos" },
    { nome: "Fulano", AcessoAtual: "Spotify.com", tempoAtivo: "6 horas e 40 minutos" },
    { nome: "Fulano", AcessoAtual: "Chatgpt.com", tempoAtivo: "6 horas e 40 minutos" },
    { nome: "Fulano", AcessoAtual: "Shoppe.com", tempoAtivo: "6 horas e 40 minutos" },
    { nome: "Fulano", AcessoAtual: "Pinterest.com", tempoAtivo: "6 horas e 40 minutos" },
    { nome: "Fulano", AcessoAtual: "Miro.com", tempoAtivo: "6 horas e 40 minutos" },
  ];

  return (
    <div className={` monitoramento-container sidebar-${modoSidebar}`}>
      <MenuLateral
              perfil={true}
              geral="Monitoramento"
              gestores={false}
              funcionarios={false}
              mensagens={true}
               modo={modoSidebar}
               setModo={setModoSidebar}
            />
      <h1 className="titulo">Acessos</h1>
      <p className="subtitulo">Equipe de desenvolvimento</p>

      <div className="tabela">
        <div className="cabecalho">
          <span>Funcionário</span>
          <span>Acesso Atual</span>
          <span>Tempo Ativo</span>
        </div>

        {acessoGestor.map((f, index) => (
          <div className="linha" key={index}>
            <span className="coluna">{f.nome}</span>
            <span className="coluna">{f.AcessoAtual}</span>
            <span className="coluna">{f.tempoAtivo}</span>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Acesso;
