import "./Sidebar.css";
import { Link } from "react-router-dom";

import iconeSair from "../../assets/img/Logout.svg";
import Logo from "../../assets/img/Logo.svg";
import User from "../../assets/img/User.svg";
import Geral from "../../assets/img/Clipboard.svg";
import Func from "../../assets/img/Management.svg";
import Chat from "../../assets/img/Chat Bubble.svg";
import Voltar from "../../assets/img/Voltar.svg";
import TelaGerente from "../../pages/telagerente/TelaGerente";

export const MenuLateral = ({
  perfil = false,
  geral = "",
  gestores = false,
  funcionarios = false,
  mensagens = false,
  modo,
  setModo
}) => {
  const isOpen = modo === "open";
  const isHidden = modo === "hidden";

  const toggleMini = () => {
    setModo((m) => (m === "open" ? "mini" : "open"));
  };

  // const fecharTotal = () => setModo("hidden");
  const abrirTotal = () => setModo("open");

  if (isHidden) {
    return (
      <button className="botao-abrir-total" onClick={abrirTotal} aria-label="Abrir menu">
        <img src={Voltar} alt="Abrir" className="icone-abrir" />
      </button>
    );
  }

  return (
    <aside className={`menu-lateral ${isOpen ? "aberta" : "mini"}`}>
      {/* topo: botões de ação (mini/open e fechar total) */}
      <div className="topo-acoes">
        <button className="botao-mini" onClick={toggleMini} aria-label={isOpen ? "Recolher" : "Expandir"}>
          <img src={Voltar} alt="Toggle" className={`icone-voltar ${isOpen ? "" : "rotacionado"}`} />
        </button>


      </div>

      {/* navegação */}
      <nav>
        <ul>
          {perfil && (
            <Link to="/TeladoPerfil" className="link-menu">
            <li>
              <img src={User} className="icone-menu" alt="Perfil" />
              {isOpen && <span>Perfil</span>}
            </li>
            </Link>
          )}

          {geral && (
            <Link to="/Gerente" className="link-menu">
            <li>
              <img src={Geral} className="icone-menu" alt={geral} />
              {isOpen && <span>{geral}</span>}
            </li>
            </Link>
          )}
          {gestores && (
            <Link to="/Comparação" className="link-menu">
            <li>
              <img src={User} className="icone-menu" alt="Gestores" />
              {isOpen && <span>Gestores</span>}
            </li>
            </Link>
          )}

          {funcionarios && (
            <li>
              <img src={Func} className="icone-menu" alt="Funcionários" />
              {isOpen && <span>Funcionários</span>}
            </li>
          )}

          {mensagens && (
            <li className="ativo">
              <img src={Chat} className="icone-menu" alt="Mensagens" />
              {isOpen && <span>Mensagens</span>}
            </li>
          )}
        </ul>
      </nav>

      <div className="rodape">
        <div className="sair">
          <img src={iconeSair} className="icone-menu" alt="Sair" href="/" />
          {isOpen && <span>Sign Out</span>}
        </div>


        <img className="logo-sidebar" src={Logo} alt="Logo" />
      </div>
    </aside>
  );
};
