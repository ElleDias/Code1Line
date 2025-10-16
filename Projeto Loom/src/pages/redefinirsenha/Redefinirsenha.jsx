  import { useState, useEffect, useRef } from "react";
import "./RedefinirSenha.css";
import { FaEye, FaEyeSlash } from "react-icons/fa";
import Swal from "sweetalert2";

const RedefinirSenha = () => {
    const [senha, setSenha] = useState("");
    const [confirmarSenha, setConfirmarSenha] = useState("");
    const [mostrarSenha, setMostrarSenha] = useState(false);
    const [mostrarConfirmar, setMostrarConfirmar] = useState(false);
    const canvasRef = useRef(null);
    const particlesRef = useRef([]);
    const mouseRef = useRef({ x: 0, y: 0 });

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

    // Sistema de partículas interativas
    useEffect(() => {
        const canvas = canvasRef.current;
        const ctx = canvas.getContext('2d');

        // Ajustar tamanho do canvas
        const resizeCanvas = () => {
            canvas.width = window.innerWidth;
            canvas.height = window.innerHeight;
        };

        resizeCanvas();
        window.addEventListener('resize', resizeCanvas);

        // Classe para partículas
        class Particle {
            constructor() {
                this.x = Math.random() * canvas.width;
                this.y = Math.random() * canvas.height;
                this.size = Math.random() * 3 + 1;
                this.speedX = Math.random() * 1 - 0.5;
                this.speedY = Math.random() * 1 - 0.5;
                this.color = `rgba(255, 255, 255, ${Math.random() * 0.5 + 0.2})`;
            }

            update() {
                this.x += this.speedX;
                this.y += this.speedY;

                // Rebater nas bordas
                if (this.x < 0 || this.x > canvas.width) this.speedX *= -1;
                if (this.y < 0 || this.y > canvas.height) this.speedY *= -1;

                // Interação com o mouse
                const dx = mouseRef.current.x - this.x;
                const dy = mouseRef.current.y - this.y;
                const distance = Math.sqrt(dx * dx + dy * dy);

                if (distance < 100) {
                    this.speedX += dx * 0.001;
                    this.speedY += dy * 0.001;

                    // Limitar velocidade máxima
                    const speed = Math.sqrt(this.speedX * this.speedX + this.speedY * this.speedY);
                    if (speed > 2) {
                        this.speedX = (this.speedX / speed) * 2;
                        this.speedY = (this.speedY / speed) * 2;
                    }
                }
            }

            draw() {
                ctx.fillStyle = this.color;
                ctx.beginPath();
                ctx.arc(this.x, this.y, this.size, 0, Math.PI * 2);
                ctx.fill();
            }
        }

        // Criar partículas
        const createParticles = () => {
            particlesRef.current = [];
            for (let i = 0; i < 80; i++) {
                particlesRef.current.push(new Particle());
            }
        };

        // Animação
        const animate = () => {
            ctx.clearRect(0, 0, canvas.width, canvas.height);

            // Desenhar conexões entre partículas próximas
            for (let i = 0; i < particlesRef.current.length; i++) {
                for (let j = i + 1; j < particlesRef.current.length; j++) {
                    const dx = particlesRef.current[i].x - particlesRef.current[j].x;
                    const dy = particlesRef.current[i].y - particlesRef.current[j].y;
                    const distance = Math.sqrt(dx * dx + dy * dy);

                    if (distance < 100) {
                        ctx.beginPath();
                        ctx.strokeStyle = `rgba(255, 255, 255, ${0.2 * (1 - distance / 100)})`;
                        ctx.lineWidth = 0.5;
                        ctx.moveTo(particlesRef.current[i].x, particlesRef.current[i].y);
                        ctx.lineTo(particlesRef.current[j].x, particlesRef.current[j].y);
                        ctx.stroke();
                    }
                }
            }

            // Atualizar e desenhar partículas
            particlesRef.current.forEach(particle => {
                particle.update();
                particle.draw();
            });

            requestAnimationFrame(animate);
        };

        // Event listeners para interação com mouse
        const handleMouseMove = (e) => {
            mouseRef.current.x = e.clientX;
            mouseRef.current.y = e.clientY;
        };

        canvas.addEventListener('mousemove', handleMouseMove);

        // Inicializar
        createParticles();
        animate();

        // Cleanup
        return () => {
            window.removeEventListener('resize', resizeCanvas);
            canvas.removeEventListener('mousemove', handleMouseMove);
        };
    }, []);

    return (
        <main className="container_redefinir">
            {/* Canvas para partículas interativas */}
            <canvas
                ref={canvasRef}
                className="canvas-background"
            />

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
