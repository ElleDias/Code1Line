import React, { useState, useEffect } from "react";
import axios from "axios";
import "./Chat.css";
import { MenuLateral } from "../../components/Sidebar/Sidebar";

export const Chat = () => {
  const [modoSidebar, setModoSidebar] = useState("close");
  const [messages, setMessages] = useState([]);
  const [newMessage, setNewMessage] = useState("");

  // 🧍 IDs temporários (para teste)
  const userAId = 1; // Gerente
  const userBId = 2; // Gestor
  const API_URL = "https://localhost:7283/api/mensagem"; // ajuste conforme a sua API

  // 🔹 Carregar mensagens da conversa
  const fetchMessages = async () => {
    try {
      const response = await axios.get(
        `${API_URL}/Mensagem/${userAId}/${userBId}`
      );

      const data = response.data;
      const ordered = data.sort(
        (a, b) => new Date(a.enviadaEm) - new Date(b.enviadaEm)
      );

      setMessages(ordered);
    } catch (error) {
      console.error("Erro ao carregar mensagens:", error);
    }
  };

  // 🔹 Enviar nova mensagem
  const handleSend = async () => {
    if (newMessage.trim() === "") return;

    const msgToSend = {
      remetenteId: userAId,
      destinatarioId: userBId,
      conteudo: newMessage,
    };

    try {
      const response = await axios.post(API_URL, msgToSend, {
        headers: {
          "Content-Type": "application/json",
        },
      });

      const savedMsg = response.data;
      setMessages((prev) => [...prev, savedMsg]);
      setNewMessage("");
    } catch (error) {
      console.error("Erro ao enviar mensagem:", error);
    }
  };

  // 🔹 Efeito para carregar e atualizar mensagens
  useEffect(() => {
    fetchMessages();
    const interval = setInterval(fetchMessages, 5000); // atualiza a cada 5s
    return () => clearInterval(interval);
  }, []);

  return (
    <div className="chat-page">
      <MenuLateral
        perfil={true}
        geral={{ ativo: true, path: "/Dominio", nome: "Dominios" }}
        gestores={{ ativo: false, path: "/gestor", nome: "Gestores" }}
        funcionarios={{ ativo: false, path: "/funcionarios", nome: "Funcionários" }}
        mensagens={{ ativo: true, path: "/mensagem", nome: "Mensagens" }}
        voltarATela={{ ativo: true, nome: "Retornar" }}
        modo={modoSidebar}
        setModo={setModoSidebar}
      />

      <div className="chat-container">
        <div className="chat-header">
          <img src="/assets/user.jpg" alt="User" className="user-avatar" />
          <div>
            <h3 className="user-name">Fulano da Silva</h3>
            <p className="user-status">online</p>
          </div>
        </div>

        <div className="chat-body">
          {messages.map((msg) => (
            <div
              key={msg.id}
              className={`chat-message ${
                msg.remetenteId === userAId ? "sent" : "received"
              }`}
            >
              <p className="message-text">{msg.conteudo}</p>
              <span className="message-time">
                {new Date(msg.enviadaEm).toLocaleTimeString([], {
                  hour: "2-digit",
                  minute: "2-digit",
                })}
              </span>
            </div>
          ))}
        </div>

        <div className="chat-input-area">
          <input
            type="text"
            placeholder="Digite uma mensagem..."
            value={newMessage}
            onChange={(e) => setNewMessage(e.target.value)}
            onKeyDown={(e) => e.key === "Enter" && handleSend()}
          />
          <button onClick={handleSend}>Enviar</button>
        </div>
      </div>
    </div>
  );
};
