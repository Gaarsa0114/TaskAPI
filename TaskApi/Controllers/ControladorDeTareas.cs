using Microsoft.AspNetCore.Mvc;
using TaskApi.Datos;
using TaskApi.Modelos;
using TaskApi.Repositorios;

namespace TaskApi.Controllers
{
 
    // Controlador de la Api que Se encarga de exponer los endpoints HTTP de la Gestion de tareas
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorDeTareas : ControllerBase
    {
        // Repositorio de tareas.
        private readonly ITareaRepository _repositorio;

        // Implementación del repositorio de tareas 
        public ControladorDeTareas(ITareaRepository repositorio)
        {
            _repositorio = repositorio;
        }
        // Endpoint HTTP POST./ Crea una nueva tarea.
        [HttpPost]
        [Route("Crear Tarea.")]

        public async Task<IActionResult> Crear(CreadorDeTareas request)
        {
            // Validación básica de entrada para evitar datos inválidos
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest("El nombre es obligatorio");

            // Se crea el modelo de dominio a partir del DTO
            var tarea = new Tarea
            {
                Name = request.Name,
                Description = request.Description,
                IsCompleted = false // Por defecto - queda pendiente
            };

            // Se guarda la tarea utilizando el repositorio
            var creada = await _repositorio.CreateAsync(tarea);

            // Se retorna la tarea creada al cliente
            return Ok(creada);
        }

        // Endpoint HTTP GET / Visualiza todas las tareas existentes.
        [HttpGet]
        [Route("Observar Tareas")]
        public async Task<IActionResult> Ver()
        {
            // Se obtienen todas las tareas del repositorio
            var tareas = await _repositorio.GetAllAsync();

            // Se transforma la respuesta para el cliente 
            return Ok(tareas.Select(t => new
            {
                t.Id,
                t.Name,
                t.Description,
                Estado = t.IsCompleted ? "Completada" : "Pendiente"
            }));
        }

        // Endpoint HTTP PUT. / Marca una tarea existente como completada.
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> Completar(int id)
        {
            // Se intenta marcar la tarea como completada
            var tarea = await _repositorio.CompleteAsync(id);

            // Si no se encuentra la tarea, se retorna 404
            if (tarea == null)
                return NotFound("Tarea no encontrada");

            // Se retorna la tarea ya completada
            return Ok(new
            {
                tarea.Id,
                tarea.Name,
                tarea.Description,
                Estado = "Completada"
            });
        }
    }
}
