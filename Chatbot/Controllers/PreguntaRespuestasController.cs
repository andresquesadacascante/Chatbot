namespace Chatbot.Controllers
{
    public class PreguntaRespuestasController : Controller
    {
        private readonly DataContext _context;

        public PreguntaRespuestasController(DataContext context)
        {
            _context = context;
        }

        // GET: PreguntaRespuestas
        public async Task<IActionResult> Index()
        {
            // Obtiene del contexto de la base de datos, en la tabla pregunta_respuesta(sql),
            // un query convertido a objeto de tipo PreguntaRespuesta(Entidad)
            // Se retorna de forma asincrona a la vista

            return View(await _context.PreguntaRespuestas.ToListAsync());
        }

        // GET: PreguntaRespuestas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
                return NotFound();

            // select p.Id, p.Pregunta, p.Respuesta from pregunta_respuesta as p where id = id
            // Retorna el resultado como objeto de tipo PreguntaRespuesta(Entidad)
            var preguntaRespuesta = await _context.PreguntaRespuestas.FirstOrDefaultAsync(m => m.Id == id);
            
            if (preguntaRespuesta is null)
                return NotFound();

            //Retorna PreguntaRespuesta a la vista(Views) (ya que la vista la consume)
            return View(preguntaRespuesta);
        }

        // GET: PreguntaRespuestas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PreguntaRespuestas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PreguntaRespuesta preguntaRespuesta)
        {
            // Verifica las condiciones para validar el objeto
            if (!ModelState.IsValid)
                //Retorna PreguntaRespuesta a la vista(Views) (ya que la vista la consume) en caso de estar mala
                return View(preguntaRespuesta);
            
            // Vamos a guardar la preguntaRespuesta
            _context.PreguntaRespuestas.Add(preguntaRespuesta);
            
            //Siempre se guardan los cambios
            await _context.SaveChangesAsync();

            // Redirecciona a la vista de Index (Lista) de la preguntaRespuestas
            return RedirectToAction(nameof(Index));
        }

        // GET: PreguntaRespuestas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id is null)
                return NotFound();

            // Buscamos la preguntaRespuesta por su id
            var preguntaRespuesta = await _context.PreguntaRespuestas.FindAsync(id);
            
            // Si el preguntaRespuesta viene o no con datos, se debe validar igualmente para determinar el
            // comportamiento.
            // Al tratarse de un objeto hay dos posibles resultados (El objeto preguntaRespuesta o null)
            if (preguntaRespuesta is null)
                return NotFound();

            //Retorna PreguntaRespuesta a la vista(Views) (ya que la vista la consume)
            return View(preguntaRespuesta);
        }

        // POST: PreguntaRespuestas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PreguntaRespuesta preguntaRespuesta)
        {
            if (id != preguntaRespuesta.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(preguntaRespuesta);

            try
            {
                _context.Update(preguntaRespuesta);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PreguntaRespuestaExistsAsync(preguntaRespuesta.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction(nameof(Edit));
        }

        // GET: PreguntaRespuestas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var preguntaRespuesta = await _context.PreguntaRespuestas.FirstOrDefaultAsync(m => m.Id == id);
            
            if (preguntaRespuesta is null) 
                return NotFound();

            return View(preguntaRespuesta);
        }

        // POST: PreguntaRespuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {            
            var preguntaRespuesta = await _context.PreguntaRespuestas.FindAsync(id);

            if (preguntaRespuesta is null)
                return NotFound();
            
            _context.PreguntaRespuestas.Remove(preguntaRespuesta);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PreguntaRespuestaExistsAsync(int id) =>
            await _context.PreguntaRespuestas.AnyAsync(e => e.Id == id);
        
    }
}
