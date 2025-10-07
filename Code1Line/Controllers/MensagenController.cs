using Code1Line.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Code1Line.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagenController : ControllerBase
    {
        private readonly IMensagemRepository _mensagensRepository;

        public MensagenController(IMensagemRepository mensagensRepository)
        {
            _mensagensRepository = mensagensRepository;
        }
        
    }
}
