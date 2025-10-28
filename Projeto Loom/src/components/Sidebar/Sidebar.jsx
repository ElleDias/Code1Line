import "./Sidebar.css";
import iconeSair from "../../assets/img/Logout.svg";
import Logo from "../../assets/img/Logo.svg";
import User from "../../assets/img/User.svg";
import Gestor from "../../assets/img/Management.svg";
 import Geral from "../../assets/img/Clipboard.svg";
import Func from "../../assets/img/Management.svg";
import Chat from "../../assets/img/SMS.svg";
import Voltar from "../../assets/img/Voltar.svg";
import { useNavigate, } from "react-router-dom";
import VoltarTela from "../../assets/img/Undo.svg"
// 💡 NOVO: Importar Hooks
import { useState, useEffect } from "react"; 

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
  
  // 💡 NOVO: Hook para rastrear se a tela é pequena (<= 750px)
  const [isMobile, setIsMobile] = useState(window.innerWidth <= 750);

  useEffect(() => {
    const handleResize = () => {
      const newIsMobile = window.innerWidth <= 750;
      setIsMobile(newIsMobile);

      // Lógica para garantir o estado correto ao redimensionar
      if (!newIsMobile && modo === "hidden") {
        // Desktop: 'hidden' deve ser tratado como 'mini'
        setModo("mini");
      }
      if (newIsMobile && modo === "mini") {
        // Mobile: 'mini' deve ser tratado como 'hidden'
        setModo("hidden");
      }
    };

    window.addEventListener("resize", handleResize);
    handleResize(); // Executa na montagem

    return () => window.removeEventListener("resize", handleResize);
  }, [modo, setModo]); // Adicionar dependências

  const isOpen = modo === "open";
  const isHidden = modo === "hidden";

  // 💡 MODIFICADO: Função para fechar totalmente (usada em mobile e ao clicar nos itens)
  const fecharTotal = () => setModo("hidden");

  // 💡 MODIFICADO: Função que alterna o estado
  const toggleMini = () => {
    if (isMobile) {
      // Em mobile, o botão no topo fecha o menu totalmente (hidden)
      fecharTotal();
    } else {
      // Em desktop, alterna entre 'open' e 'mini'
      setModo((m) => (m === "open" ? "mini" : "open"));
    }
  };

  const abrirTotal = () => setModo("open");

  if (isHidden) {
    // CLASSE NAO MODIFICADA: botao-abrir-total
    return (
      <button className="botao-abrir-total" onClick={abrirTotal} aria-label="Abrir menu">
        <img src={Voltar} alt="Abrir" className="icone-abrir" />
      </button>
    );
  }

  const handleClick = () => {
    navigate(-1); // sempre volta para a página anterior
    if (isMobile) {
      fecharTotal(); // Fecha o menu no mobile após navegar
    }
  };

  // CLASSE NAO MODIFICADA: menu-lateral
  return (
    <aside className={`menu-lateral ${isOpen ? "aberta" : "mini"}`}>
      {/* topo: botões de ação */}
      <div className="topo-acoes">
        <button
          // CLASSE NAO MODIFICADA: botao-mini
          className="botao-mini"
          onClick={toggleMini} // 💡 AGORA GERE O COMPORTAMENTO MOBILE/DESKTOP
          aria-label={isOpen ? (isMobile ? "Fechar" : "Recolher") : "Expandir"} // 💡 TEXTO AJUSTADO
        >
          {/* Em mobile aberto, o Voltar funciona como Fechar; em desktop, é Toggle. */}
          <img 
            src={Voltar} 
            alt="Toggle" 
            className={`icone-voltar ${isOpen ? "" : "rotacionado"}`} 
          />
        </button>
      </div>

      {/* navegação */}
      <nav>
        <ul>
          {/* 💡 MODIFICADO: Adicionado fecharTotal() em todos os cliques no mobile */}
          {perfil && (
             <li onClick={() => { navigate(perfil.path); if (isMobile) fecharTotal(); }} style={{ cursor: "pointer" }}>
              <img src={User} className="icone-menu" alt="Perfil" />
              {isOpen && <span>Perfil</span>}
            </li>
          )}

          {geral.ativo && (
             <li onClick={() => { navigate(geral.path); if (isMobile) fecharTotal(); }} style={{ cursor: "pointer" }}>
              <img src={Geral} className="icone-menu" alt={geral.nome} />
              {isOpen && <span>{geral.nome}</span>}
            </li>
          )}

          {gestores.ativo && (
             <li onClick={() => { navigate(gestores.path); if (isMobile) fecharTotal(); }}>
              <img src={Gestor} className="icone-menu" alt="Gestores" />
              {isOpen && <span>Gestores</span>}
            </li>
          )}

          {funcionarios.ativo && (
             <li onClick={() => { navigate(funcionarios.path); if (isMobile) fecharTotal(); }}>
              <img src={Func} className="icone-menu" alt="Funcionários" />
              {isOpen && <span>Funcionários</span>}
            </li>
          )}
          {mensagens.ativo && (
             <li className="ativo" onClick={() => { navigate(mensagens.path); if (isMobile) fecharTotal(); }}>
              <img src={Chat} className="icone-menu" alt="Mensagens" />
              {isOpen && <span>Mensagens</span>}
            </li>
          )}

          {/* BOTÃO RETORNAR */}
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