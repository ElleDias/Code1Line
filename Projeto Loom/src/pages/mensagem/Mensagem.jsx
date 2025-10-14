import React from 'react';
import './Mensagens.css';
import { FaUserCircle, FaEnvelope } from 'react-icons/fa';
import { BsChat, BsChatText } from 'react-icons/bs';

const listaMensagens = [
  { id: 1, icon: <BsChatText /> },
  { id: 2, icon: <BsChatText /> },
  { id: 3, icon: <BsChat /> },
  { id: 4, icon: <FaEnvelope className="unread" /> },
  { id: 5, icon: <BsChat /> },
];

function Mensagens() {
  return (
    // Nova div para agrupar o título e o container
    <div className="pagina-mensagens"> 
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