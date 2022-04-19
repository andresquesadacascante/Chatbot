

namespace Chatbot.Data.Entities
{
    public class PreguntaRespuesta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Pregunta { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Respuesta { get; set; }
    }
}
