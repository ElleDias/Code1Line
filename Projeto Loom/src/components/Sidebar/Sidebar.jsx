import "./Sidebar.css";
import iconeSair from "../../assets/img/Logout.svg";
import Logo from "../../assets/img/Logo.svg";
import User from "../../assets/img/User.svg";
import Geral from "../../assets/img/Clipboard.svg";
import Func from "../../assets/img/Management.svg";
import Chat from "../../assets/img/SMS.svg";
import Voltar from "../../assets/img/Voltar.svg";
import { useNavigate, useLocation } from "react-router-dom";
import VoltarTela from "../../assets/img/Undo.svg"

export const MenuLateral = ({
  perfil = false,
  geral = "",
  gestores = false,
  funcionarios = false,
  mensagens = false,
  voltarATela = true,
  modo,
  setModo
}) => {

  const navigate = useNavigate();
  const location = useLocation();

  const isOpen = modo === "open";
  const isHidden = modo === "hidden";

  const toggleMini = () => {
    setModo((m) => (m === "open" ? "mini" : "open"));
  };

  const abrirTotal = () => setModo("open");

  if (isHidden) {
    return (
      <button className="botao-abrir-total" onClick={abrirTotal} aria-label="Abrir menu">
        <img src={Voltar} alt="Abrir" className="icone-abrir" />
      </button>
    );
  }

  const handleClick = () => {
    navigate(-1); // sempre volta para a página anterior
  };

  return (
    <aside className={`menu-lateral ${isOpen ? "aberta" : "mini"}`}>
      {/* topo: botões de ação */}
      <div className="topo-acoes">
        <button
          className="botao-mini"
          onClick={toggleMini}
          aria-label={isOpen ? "Recolher" : "Expandir"}
        >
          <img src={Voltar} alt="Toggle" className={`icone-voltar ${isOpen ? "" : "rotacionado"}`} />
        </button>
      </div>

      {/* navegação */}
      <nav>
        <ul>
          {perfil && (
            <li onClick={() => navigate("/")}>
              <img src={User} className="icone-menu" alt="Perfil" />
              {isOpen && <span>Perfil</span>}
            </li>
          )}

          {geral.ativo && (
            <li onClick={() => navigate(geral.path)} style={{ cursor: "pointer" }}>
              <img src={Geral} className="icone-menu" alt={geral.nome} />
              {isOpen && <span>{geral.nome}</span>}
            </li>
          )}

          {gestores.ativo && (
            <li onClick={() => navigate(gestores.path)}>
              <img src={User} className="icone-menu" alt="Gestores" />
              {isOpen && <span>Gestores</span>}
            </li>
          )}

          {funcionarios.ativo && (
            <li onClick={() => navigate(funcionarios.path)}>
              <img src={Func} className="icone-menu" alt="Funcionários" />
              {isOpen && <span>Funcionários</span>}
            </li>
          )}
          {mensagens.ativo && (
            <li className="ativo" onClick={() => navigate(mensagens.path)}>
              <img src={Chat} className="icone-menu" alt="Mensagens" />
              {isOpen && <span>Mensagens</span>}
            </li>
          )}

          {/* BOTÃO RETORNAR NO LUGAR DAS MENSAGENS */}
          <li className="" onClick={handleClick}>
            <img src={VoltarTela} className="icone-menu" alt="Retornar" />
            {isOpen && <span>Retornar</span>}
          </li>
        </ul>
      </nav>


      {/* rodapé */}
      <div className="rodape">
        <div className="sair" onClick={() => navigate("/")}>
          <img src={iconeSair} className="icone-menu" alt="Sair" />
          {isOpen && <span>Sign Out</span>}
        </div>

        <img className="logo-sidebar" src={Logo} alt="Logo" />
      </div>
    </aside>
  );
};
