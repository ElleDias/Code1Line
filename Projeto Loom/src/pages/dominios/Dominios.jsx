import React, { useState } from "react";
import "./Dominios.css";
import { MenuLateral } from "../../components/Sidebar/Sidebar";

export default function Dominios() {
  // Estado para armazenar o filtro selecionado
  const [filtro, setFiltro] = useState("Todos");
  const [modoSidebar, setModoSidebar] = useState("close");
  // Dados dos domínios
  const dominios = [
    {
      categoria: "Produtivo",
      dominios: ["ClickUp.com", "Trello.com", "Miro.com"],
      quantidade: 3,
    },
    {
      categoria: "Não Produtivo",
      dominios: ["Youtube.com", "Pinterest.com"],
      quantidade: 2,
    },
    {
      categoria: "Em Análise",
      dominios: ["ChatGPT.com"],
      quantidade: 1,
    },
  ];

  // Filtro aplicado
  const dominiosFiltrados =
    filtro === "Todos"
      ? dominios
      : dominios.filter((item) => item.categoria === filtro);

  return (
    <div className={`dominios-page  sidebar-${modoSidebar}`}>
      {/* Sidebar igual às outras telas */}
      <MenuLateral
        perfil={true}
        geral={{ ativo: true, path: "/gestor", nome: "Monitoramento" }}      
        gestores={{ ativo: false, path: "/gestor", nome: "Gestores" }}
        funcionarios={{ ativo: false, path: "/funcionarios", nome: "Funcionários" }}
        mensagens={{ ativo: true, path: "/mensagem", nome: "Mensagens" }}
        voltarATela={{ ativo: true, nome: "Retornar" }}
        modo={modoSidebar}
        setModo={setModoSidebar}
      />

      {/* Conteúdo da página */}
      <div className="dominios-container">
        <h1 className="titulo-dominio">Domínios</h1>
        <p className="subtitulo-dominio">Equipe de desenvolvimento</p>

        {/* 🔍 Filtro */}
        <div className="filtro-dominio">
          <button
            className={filtro === "Todos" ? "ativo" : ""}
            onClick={() => setFiltro("Todos")}
          >
            Todos
          </button>
          <button
            className={filtro === "Produtivo" ? "ativo" : ""}
            onClick={() => setFiltro("Produtivo")}
          >
            Produtivo
          </button>
          <button
            className={filtro === "Não Produtivo" ? "ativo" : ""}
            onClick={() => setFiltro("Não Produtivo")}
          >
            Não Produtivo
          </button>
          <button
            className={filtro === "Em Análise" ? "ativo" : ""}
            onClick={() => setFiltro("Em Análise")}
          >
            Em Análise
          </button>
        </div>

        {/* Tabela */}
        <div className="tabela-dominio">
          <div className="tabela-header-dominio">
            <span>Categoria</span>
            <span>Domínios/Sistemas</span>
            <span>Quantidade</span>
          </div>

          {dominiosFiltrados.map((item, index) => (
            <div className="linha-dominio" key={index}>
              <span
                className={`categoria-dominio ${
                  item.categoria === "Produtivo"
                    ? "produtivo-dominio"
                    : item.categoria === "Não Produtivo"
                    ? "nao-produtivo-dominio"
                    : "analise-dominio"
                }`}
              >
                {item.categoria}
              </span>
              <span>{item.dominios.join(", ")}</span>
              <span>{item.quantidade}</span>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}
