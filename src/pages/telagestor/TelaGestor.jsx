import React from "react";
import "./TelaGestor.css";
import {MenuLateral} from "../../components/Sidebar/Sidebar";


const TelaGestor = () => {
  const funcionarios = [
    { nome: "Fulano", tempoInativo: "40 minutos", tempoAtivo: "6 horas e 40 minutos" },
    { nome: "Fulano", tempoInativo: "40 minutos", tempoAtivo: "6 horas e 40 minutos" },
    { nome: "Fulano", tempoInativo: "40 minutos", tempoAtivo: "6 horas e 40 minutos" },
    { nome: "Fulano", tempoInativo: "40 minutos", tempoAtivo: "6 horas e 40 minutos" },
    { nome: "Fulano", tempoInativo: "40 minutos", tempoAtivo: "6 horas e 40 minutos" },
    { nome: "Fulano", tempoInativo: "40 minutos", tempoAtivo: "6 horas e 40 minutos" },
  ];

  return (
    <div className="monitoramento-container">
      <MenuLateral
        perfil={true}
        geral="Acessos"
        gestores={false}
        funcionarios={false}
        mensagens={true}
      />
      <h1 className="titulo">Monitoramento</h1>
      <p className="subtitulo">Equipe de desenvolvimento</p>

      <div className="tabela">
        <div className="cabecalho">
          <span>Funcionário</span>
          <span>Tempo inativo</span>
          <span>Tempo ativo</span>
        </div>

        {funcionarios.map((f, index) => (
          <div className="linha" key={index}>
            <span className="coluna">{f.nome}</span>
            <span className="coluna">{f.tempoInativo}</span>
            <span className="coluna">{f.tempoAtivo}</span>
          </div>
        ))}
      </div>
    </div>
  );
};

export default TelaGestor;
