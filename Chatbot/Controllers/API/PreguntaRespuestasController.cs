namespace Chatbot.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntaRespuestasController : ControllerBase
    {
        private readonly DataContext _context;

        public PreguntaRespuestasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PreguntaRespuestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreguntaRespuesta>>> GetPreguntaRespuestas()
        {
            return await _context.PreguntaRespuestas.ToListAsync();
        }

        // GET: api/PreguntaRespuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreguntaRespuesta>> GetPreguntaRespuesta(int id)
        {
            var preguntaRespuesta = await _context.PreguntaRespuestas.FindAsync(id);

            if (preguntaRespuesta == null)
                return NotFound();

            return preguntaRespuesta;
        }

    }
}
