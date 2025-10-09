import React, { useState } from "react";
import "./TarefasPendentes.css";
import Botao
 from "../../components/Botao/Botao";
 import { MenuLateral } from "../../components/MenuLateral/MenuLateral";
function App() {
  const [filtro, setFiltro] = useState("");

  const tarefas = [
    { nome: "Tarefa 1", funcionario: "Brenda", status: "Em andamento", data: "10/07/2026" },
    { nome: "Tarefa 2", funcionario: "Caio", status: "Pendente", data: "10/07/2026" },
    { nome: "Tarefa 3", funcionario: "Yasmim", status: "Concluída", data: "10/07/2026" },
    { nome: "Tarefa 4", funcionario: "Danielle", status: "Concluída", data: "10/07/2026" },
    { nome: "Tarefa 5", funcionario: "Laura", status: "Em andamento", data: "10/07/2026" },
    { nome: "Tarefa 6", funcionario: "Lucas", status: "Pendente", data: "10/07/2026" },
    { nome: "Tarefa 7", funcionario: "Funcionário 7", status: "Pendente", data: "14/07/2026" },
  ];

  const getStatusClass = (status) => {
    switch (status) {
      case "Concluída":
        return "status concluida";
      case "Em andamento":
        return "status andamento";
      case "Pendente":
        return "status pendente";
      default:
        return "status";
    }
  };

  // Filtra as tarefas pelo nome do funcionário digitado
  const tarefasFiltradas = tarefas.filter((t) =>
    t.funcionario.toLowerCase().includes(filtro.toLowerCase())
  );

  return (
    <div className="modal-overlay">
      <MenuLateral
                perfil={true}
                geral="Geral"
                gestores={true}
                funcionarios={true}
                mensagens={true}
            />
      <div className="modal">
        <h1 className="title">TAREFAS DA EQUIPE</h1>

        <form className="form">
          <label htmlFor="funcionario">Informe o nome do funcionário:</label>
          <input
            id="funcionario"
            type="text"
            placeholder="Ex: Funcionário 3"
            value={filtro}
            onChange={(e) => setFiltro(e.target.value)}
          />
          {/* <Botao nomeDoBotao="Voltar"/> */}
        </form>

        <div className="table">
          <div className="table-header">
            <div>Nome da Tarefa</div>
            <div>Funcionário</div>
            <div>Status</div>
            <div>Data</div>
          </div>

          {tarefasFiltradas.length > 0 ? (
            tarefasFiltradas.map((t, i) => (
              <div key={i} className="table-row">
                <div className="task-name">{t.nome}</div>
                <div className="employee">
                  <div className="avatar">👤</div>
                  <span>{t.funcionario}</span>
                </div>
                <div className={getStatusClass(t.status)}>{t.status}</div>
                <div className="date">{t.data}</div>
              </div>
            ))
          ) : (
            <p className="no-results">Nenhum funcionário encontrado.</p>
          )}
        </div>
      </div>
    </div>
  );
}

export default App;