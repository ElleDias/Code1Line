import { useState } from "react";
import "./RedefinirSenha.css";
import { FaEye, FaEyeSlash } from "react-icons/fa";
import Swal from "sweetalert2";

const RedefinirSenha = () => {
    const [senha, setSenha] = useState("");
    const [confirmarSenha, setConfirmarSenha] = useState("");
    const [mostrarSenha, setMostrarSenha] = useState(false);
    const [mostrarConfirmar, setMostrarConfirmar] = useState(false);

    const requisitos = {
        especial: /[!@#$%^&*(),.?":{}|<>]/.test(senha),
        maiuscula: /[A-Z]/.test(senha),
        tamanho: senha.length >= 8,
    };

    // Para quando as senhas são diferentes.
    const SenhaIncorreta = () => {
        Swal.fire({
            icon: "error",
            title: "Oops...",
            text: "As senhas não coincidem. Reveja se são as mesmas.",
        });
    };

    // Para quando a senha não atingir as exigências de criação.
    const SenhaFraca = () => {
        Swal.fire({
            icon: "warning",
            title: "Senha fraca",
            text: "Siga os requisitos para a criação da senha.",
        });
    };

    // Para quando a senha atingir todas as exigências.
    const SenhaSucesso = () => {
        Swal.fire({
            icon: "success",
            title: "Senha redefinida!",
            text: "Sua nova senha foi salva com sucesso.",
        });
    };

    // Validação e envio do formulário
    const handleSubmit = (e) => {
        e.preventDefault();

        if (!requisitos.especial || !requisitos.maiuscula || !requisitos.tamanho) {
            SenhaFraca();
            return;
        }

        if (senha !== confirmarSenha) {
            SenhaIncorreta();
            return;
        }

        SenhaSucesso();
    };

    return (
        <main className="container_redefinir">
            <div className="card_redefinir">
                <h2>Redefinição de senha</h2>
                <p>Crie uma nova senha para acessar sua conta.</p>

                <form onSubmit={handleSubmit}>
                    {/* NOVA SENHA */}
                    <label>Nova senha</label>
                    <div className="input_senha">
                        <input
                            type={mostrarSenha ? "text" : "password"}
                            value={senha}
                            onChange={(e) => setSenha(e.target.value)}
                            placeholder="Digite sua nova senha"
                            required
                        />
                        <span
                            onClick={() => setMostrarSenha(!mostrarSenha)}
                            className="icone_olho"
                        >
                            {mostrarSenha ? <FaEyeSlash /> : <FaEye />}
                        </span>
                    </div>

                    {/* REQUISITOS */}
                    <ul className="requisitos">
                        <li className={requisitos.especial ? "valido" : ""}>
                            Pelo menos 1 caractere especial (!,@,#,$,%).
                        </li>
                        <li className={requisitos.maiuscula ? "valido" : ""}>
                            Pelo menos 1 letra maiúscula (A-Z).
                        </li>
                        <li className={requisitos.tamanho ? "valido" : ""}>
                            No mínimo 8 caracteres.
                        </li>
                    </ul>

                    {/* CONFIRMAR SENHA */}
                    <label>Confirmar nova senha</label>
                    <div className="input_senha">
                        <input
                            type={mostrarConfirmar ? "text" : "password"}
                            value={confirmarSenha}
                            onChange={(e) => setConfirmarSenha(e.target.value)}
                            placeholder="Confirme sua nova senha"
                            required
                        />
                        <span
                            onClick={() => setMostrarConfirmar(!mostrarConfirmar)}
                            className="icone_olho"
                        >
                            {mostrarConfirmar ? <FaEyeSlash /> : <FaEye />}
                        </span>
                    </div>

                    <button type="submit" className="btn_salvar">
                        Salvar
                    </button>
                </form>
            </div>
        </main>
    );
};

export default RedefinirSenha;
