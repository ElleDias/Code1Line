
import React, { useEffect, useState } from "react";
import axios from "axios";

export default function TelaDoPerfil() {
  const [usuario, setUsuario] = useState(null);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (!token) return;

    axios.get("https://localhost:7283/api/usuarios/me", {
      headers: { Authorization: `Bearer ${token}` },
    })
    .then(res => setUsuario(res.data.usuario))
    .catch(err => console.error("Erro ao carregar perfil:", err));
  }, []);

  if (!usuario) return <p>Carregando...</p>;

  return (
    <div>
      <h2>Bem-vindo, {usuario.Nome}!</h2>
      <p>Email: {usuario.Email}</p>
    </div>
  );
}
