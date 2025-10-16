

import "./TelaGerente.css";
import { useState } from "react";
import { MenuLateral } from "../../components/Sidebar/Sidebar";
import { GraficoDesempenho } from "../../components/GraficoDesempenho/GraficoDesempenho";
import { useNavigate } from "react-router-dom";

const TelaGerente = () => {
  const [modoSidebar, setModoSidebar] = useState("close");

  const dadosPendentes = [
    { nome: "Seg", valor: 50 },
    { nome: "Ter", valor: 75 },
    { nome: "Qua", valor: 60 },
    { nome: "Qui", valor: 40 },
    { nome: "Sex", valor: 30 },
    { nome: "Sáb", valor: 20 },
    { nome: "Dom", valor: 10 },
  ];

  const dadosConcluidas = [
    { nome: "Seg", valor: 20 },
    { nome: "Ter", valor: 45 },
    { nome: "Qua", valor: 70 },
    { nome: "Qui", valor: 80 },
    { nome: "Sex", valor: 90 },
    { nome: "Sáb", valor: 60 },
    { nome: "Dom", valor: 40 },
  ];

  const [dadosAtuais, setDadosAtuais] = useState(dadosPendentes);
  const [tituloGrafico, setTituloGrafico] = useState("Tarefas Pendentes");


  const mostrarPendentes = () => {
    setDadosAtuais(dadosPendentes);
    setTituloGrafico("Tarefas Pendentes");
  };

  const mostrarConcluidas = () => {
    setDadosAtuais(dadosConcluidas);
    setTituloGrafico("Tarefas Concluídas");
  };
 const navigate = useNavigate(); // 👈 precisa declarar aqui
  return (

    <div className="tela-gerente">
      
      <MenuLateral
        perfil={true}
        geral="Geral"
        gestores={true}
        funcionarios={true}
        mensagens={true}
        modo={modoSidebar}
        setModo={setModoSidebar}
      />

      <div className={`visao_gerente-container sidebar-${modoSidebar}`}>
        <div className="geral-retangulo painel moderno">
          <div className="decor-stars"></div>
          <div className="geral-header">
            <h2>GERAL</h2>
            <h3 className="sub-header-elegante">Olá, gerente! Seja bem-vindo.</h3>
            <p className="sub-header-contexto">Aqui você encontrará um panorama completo da equipe.</p>
          </div>
          <p>
            Acompanhe o <strong>desempenho</strong> dos{" "}
            <a href="#">gestores</a> e <a href="#">funcionários</a>!<br />
            Visualize <strong>tarefas pendentes</strong> e{" "}
            <strong>concluídas</strong> e tenha acesso a relatórios estratégicos
            que facilitam a tomada de decisão.
          </p>
        </div>

        <div className="tarefas-container moderno">
          <button className="botao_tarefa azul" onClick={mostrarPendentes}>
            Tarefas Pendentes
          </button>
          <button className="botao_tarefa roxo" onClick={mostrarConcluidas}>
            Tarefas Concluídas
          </button>
          <button
      className="botao_graficos dourado"
      onClick={() => navigate("/Graficos")}
    >
      Gráficos Detalhados
    </button>
        </div>

        <GraficoDesempenho titulo={tituloGrafico} data={dadosAtuais} />
      </div>
    </div>
  );
};

export default TelaGerente;