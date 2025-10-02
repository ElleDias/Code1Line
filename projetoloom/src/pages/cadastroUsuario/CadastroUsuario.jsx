import Logo from "../../assets/img/logo.svg";
import "./CadastroUsuario.css";
import Botao from "../../components/Botao";

const CadastroUsuario = () => {
    return (
        <main className="main_cadastro">
            <div className="fundo_loom"></div>
            <section className="section_cadastro">
                <img  className= " logo_superior" src={Logo} alt="Logo da Loom" />
                <form action="" className="form_cadastro">
                    <h1>Cadastre-se</h1>
                    <h2>Por favor, preencha os campos.</h2>
                    <div className="campos_login">
                        <div className="campo_input">
                              <label htmlFor="Nome">Nome</label>
                             <input type="Nome" name="Nome" placeholder="Nome" />
                            <label htmlFor="Email">E-mail</label>
                            <input type="Email" name="Email" placeholder="Entre com seu e-mail" />
                        </div>
                        <div className="campo_input">
                            <label htmlFor=""> Criar Senha</label>
                            <input type="Password" name="Senha" placeholder="•••••••••" />
                            <label htmlFor="">Confirmar senha</label>
                            <input type="Password" name="Senha" placeholder="•••••••••" />
                        </div>
                    </div>
                     <Botao nomeDoBotao="Cadastrar"/> 
                    <div className="campos_cadastro">
                         <label htmlFor=""> Já possuo um cadastro</label>
                    
                    </div>
                  
                </form>
            </section>
        </main>
    )
}

export default CadastroUsuario;
