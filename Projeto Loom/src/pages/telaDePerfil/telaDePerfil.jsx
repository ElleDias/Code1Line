import { useState } from "react";
import "./telaDePerfil.css";
import {MenuLateral} from "../../components/Sidebar/Sidebar";
import Botao from "../../components/Botao/Botao";
import imgperfil from "./../../assets/img/icons8-usuário-96.png"

const TeladePerfil = () => {
   

  return (

<>

<body className="body_perfil">
  <div class="container"className="layout_grid">
    <div class="profile-card">
      <div class="profile-header">
        <iframe className="profile-img"  height="520" width="236" frameborder="0" scrolling="no" >{imgperfil}</iframe>
        <h2 class="profile-name">Lucas Andrade</h2>
        <p class="profile-role">Desenvolvedor Full Stack</p>
      </div>

      <div class="profile-info">
        <h3>Informações Pessoais</h3>
        <p><strong>Email:</strong> lucas.andrade@example.com</p>
        <p><strong>Telefone:</strong> (11) 98765-4321</p>
        <p><strong>Localização:</strong> São Paulo, SP</p>
      </div>

      <div class="profile-actions">
        <button class="btn_sair">Sair </button>
        
      </div>
    </div>
  </div>
</body>

   </>
    
  );
};

export default TeladePerfil;
