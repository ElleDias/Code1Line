import logo from "../../assets/img/logo.svg";
import "./Login.css";
import Botao from "../../components/Botao/Botao";

const Login = () => {
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
                            <input type="Email" name="Email" placeholder="Entre com seu e-mail" />
                        </div>
                        <div className="campo_input">
                            <label className="senha" htmlFor="senha">Senha</label>
                            <input type="password" id="senha" placeholder="•••••••••" />
                        </div>
                        <div className="options">
                            <label>
                                <input type="checkbox" /> Lembre-se de mim
                            </label>
                            <a href="#">Esqueceu a senha?</a>
                        </div>
                    </div>
                    <Botao nomeDoBotao="Log In" />
                    <p className="nao_tem_uma_conta">
                        Não tem uma conta? <a href="#">Registre-se aqui</a>
                    </p>
                </form>

            </section>
        </main>
    )
}

export default Login;
