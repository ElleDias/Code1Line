import { useState } from "react";
import './MensagemGestor.css';
import { FaUserCircle, FaEnvelope } from 'react-icons/fa';
import { BsChat, BsChatText } from 'react-icons/bs';
import { MenuLateral } from "../../components/Sidebar/Sidebar";

const listaMensagens = [
  { id: 1, icon: <BsChatText /> },
  { id: 2, icon: <BsChatText /> },
  { id: 3, icon: <BsChat /> },
  { id: 4, icon: <FaEnvelope className="unread" /> },
  { id: 5, icon: <BsChat /> },
];

function Mensagens() {
  const [modoSidebar, setModoSidebar] = useState("close");
  return (
    // Nova div para agrupar o título e o container
    <div className={`pagina-mensagens sidebar-${modoSidebar}`}
    >
      <MenuLateral
        perfil={true}
        geral={{ ativo: true, nome: "Geral" }}
        gestores={{ ativo: false, path: "/gestor", nome: "Gestores" }}
        funcionarios={{ ativo: false, path: "/funcionarios", nome: "Funcionários" }}
        mensagens={{ ativo: true, path: "/mensagem", nome: "Mensagens" }}
        voltarATela={{ ativo: true, nome: "Retornar" }}
        modo={modoSidebar}
        setModo={setModoSidebar}
      />
      {/* Título agora está FORA do container branco */}
      <h1 className="titulo-externo">MENSAGENS</h1>

      <div className="mensagens-container">
        {/* O título foi removido daqui de dentro */}
        <div className="lista-mensagens">
          {listaMensagens.map((mensagem) => (
            <div key={mensagem.id} className="item-mensagem">
              <div className="avatar">
                <FaUserCircle size={36} color="#555" />
              </div>
              <div className="icone-acao">
                {mensagem.icon}
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}

export default Mensagens;