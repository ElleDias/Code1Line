import "./Login.css";
import { useState } from "react";
import logo from "../../assets/img/Logo.svg";
import Botao from "../../components/Botao/Botao";
import { FaEye, FaEyeSlash } from "react-icons/fa";

const Login = () => {
    const [mostrarSenha, setMostrarSenha] = useState(false);
    

    return (
        <main className="main_login">
            <div className="fundo_loom"></div>
            <section className="section_login">
                <img className="logo_superior" src={logo} alt="Logo da Loom" />
                <form action="" className="form_login">

                    <h1>Bem Vindo</h1>
                    <h2>Por favor, preencha os campos.</h2>

                    <div className="campos_login">
                        <div className="campo_input">
                            <label className="email" htmlFor="Email">E-mail</label>
                            <input
                                type="email"
                                name="Email"
                                placeholder="Entre com seu e-mail"
                            />
                        </div>

                        <div className="campo_input">
                            <label className="senha" htmlFor="senha">Senha</label>
                            <div className="input_senha">
                                <input
                                    type={mostrarSenha ? "text" : "password"}
                                    id="senha"
                                    placeholder="•••••••••"
                                />
                                <span
                                    className="icone_olho"
                                    onClick={() => setMostrarSenha(!mostrarSenha)}
                                >
                                    {mostrarSenha ? <FaEyeSlash /> : <FaEye />}
                                </span>
                            </div>
                        </div>

                        <div className="options">
                            <label>
                                <input type="checkbox" /> Lembre-se de mim
                            </label>
                            <a className="link_esqueceuasenha" href="#">Esqueceu a senha?</a>
                        </div>
                    </div>

                    <Botao nomeDoBotao="Log In" />

                    <p className="nao_tem_uma_conta">
                        Não tem uma conta? <a className="link_registre" href="/Cadastro">Registre-se aqui</a>
                    </p>
                </form>
            </section>
        </main>
    );
};

export default Login;
