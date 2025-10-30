import { useEffect, useState } from "react";
import "./TarefasPendentes.css";
import { MenuLateral } from "../../components/Sidebar/Sidebar";
import api from "../../Services/services";
import Swal from "sweetalert2";

function TarefasPendentes() {
  const [tarefas, setTarefas] = useState([]);
  const [filtro, setFiltro] = useState("");
  const [modoSidebar, setModoSidebar] = useState("close");
  const [carregando, setCarregando] = useState(true);

  const [pagina, setPagina] = useState(1);
  const [itensPorPagina] = useState(5);

  async function carregarTarefas() {
    try {
      const resposta = await api.get("Atividade");
      console.log("📦 Dados recebidos da API:", resposta.data);
      setTarefas(resposta.data);
    } catch (erro) {
      console.error("❌ Erro ao buscar tarefas:", erro);
      Swal.fire({
        icon: "error",
        title: "Erro ao carregar tarefas",
        text: "Verifique se a API está rodando corretamente.",
        confirmButtonColor: "#b51d44",
      });
    } finally {
      setCarregando(false);
    }
  }

  useEffect(() => {
    carregarTarefas();
  }, []);

  const getStatusClass = (status) => {
    switch (status) {
      case "3":
      case "Concluída":
        return "status concluida";
      case "2":
      case "Em andamento":
        return "status andamento";
      case "1":
      case "Pendente":
        return "status pendente";
      default:
        return "status";
    }
  };

  const traduzirStatus = (status) => {
    switch (status) {
      case "1":
        return "Pendente";
      case "2":
        return "Em andamento";
      case "3":
        return "Concluída";
      default:
        return status;
    }
  };

  // 🔍 Filtra tarefas pelo nome do funcionário
  const tarefasFiltradas = tarefas.filter((t) =>
    t.funcionario?.nome?.toLowerCase().includes(filtro.toLowerCase())
  );

  // 📄 Calcula os itens da página atual
  const inicio = (pagina - 1) * itensPorPagina;
  const fim = inicio + itensPorPagina;
  const tarefasPaginadas = tarefasFiltradas.slice(inicio, fim);

  // 🔢 Total de páginas
  const totalPaginas = Math.ceil(tarefasFiltradas.length / itensPorPagina);

  // 🧭 Muda de página
  const mudarPagina = (novaPagina) => {
    if (novaPagina >= 1 && novaPagina <= totalPaginas) {
      setPagina(novaPagina);
    }
  };

  // 🔄 Resetar pra página 1 quando fizer uma busca nova
  useEffect(() => {
    setPagina(1);
  }, [filtro]);

  return (
    <div className={`tela-pendentes sidebar-${modoSidebar}`}>
      <MenuLateral
        perfil={true}
        geral={{ ativo: true, path: "/gerente", nome: "Geral" }}
        gestores={{ ativo: true, path: "/gestor", nome: "Gestores" }}
        funcionarios={{ ativo: false, path: "/funcionarios", nome: "Funcionários" }}
        mensagens={{ ativo: true, path: "/mensagem", nome: "Mensagens" }}
        voltarATela={{ ativo: true, nome: "Retornar" }}
        modo={modoSidebar}
        setModo={setModoSidebar}
      />

      <div className={`modal-overlay sidebar-${modoSidebar}`}>
        <div className="modal">
          <h1 className="title">Tarefas Pendentes</h1>

          <form className="form">
            <label htmlFor="funcionario">Informe o nome do funcionário:</label>
            <input
              id="funcionario"
              type="text"
              placeholder="Ex: Funcionário 3"
              value={filtro}
              onChange={(e) => setFiltro(e.target.value)}
            />
          </form>

          {carregando ? (
            <p className="carregando">Carregando tarefas...</p>
          ) : (
            <>
              <div className="table">
                <div className="table-header">
                  <div>Nome da Tarefa</div>
                  <div>Funcionário</div>
                  <div>Status</div>
                  <div>Data</div>
                </div>

                {tarefasPaginadas.length > 0 ? (
                  tarefasPaginadas.map((t, i) => (
                    <div key={i} className="table-row">
                      <div className="task-name">{t.descricao}</div>
                      <div className="employee">
                        <div className="avatar">👤</div>
                        <span>{t.funcionario?.nome || "Não informado"}</span>
                      </div>
                      <div className={getStatusClass(t.status)}>
                        {traduzirStatus(t.status)}
                      </div>
                      <div className="date">
                        {t.dataFim
                          ? new Date(t.dataFim).toLocaleDateString("pt-BR")
                          : "-"}
                      </div>
                    </div>
                  ))
                ) : (
                  <p className="no-results">Nenhum funcionário encontrado.</p>
                )}
              </div>

              {/* 🔢 Controles de Paginação */}
              {tarefasFiltradas.length > itensPorPagina && (
                <div className="pagination">
                  <button
                    disabled={pagina === 1}
                    onClick={() => mudarPagina(pagina - 1)}
                  >
                    ◀ Anterior
                  </button>
                  <span>
                    Página {pagina} de {totalPaginas}
                  </span>
                  <button
                    disabled={pagina === totalPaginas}
                    onClick={() => mudarPagina(pagina + 1)}
                  >
                    Próxima ▶
                  </button>
                </div>
              )}
            </>
          )}
        </div>
      </div>
    </div>
  );
}

export default TarefasPendentes;