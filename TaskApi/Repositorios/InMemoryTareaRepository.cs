using System.Collections.Concurrent;
using TaskApi.Modelos;

namespace TaskApi.Repositorios
{
    // Implementación del repositorio de tareas que almacena en memoria
    public class InMemoryTareaRepository : ITareaRepository
    {
        // Diccionario seguro para múltiples hilos (thread-safe)
        private readonly ConcurrentDictionary<int, Tarea> _tareas = new();

        // Contador interno para generar identificadores únicos para cada tarea creada
        private int _currentId = 0;

        // Crea una nueva tarea y la guarda en memoria.
        public Task<Tarea> CreateAsync(Tarea tarea)
        {
            // Genera un ID único de forma segura
            tarea.Id = Interlocked.Increment(ref _currentId);

            // Almacena la tarea en el diccionario
            _tareas[tarea.Id] = tarea;

            // Devuelve la tarea creada
            return Task.FromResult(tarea);
        }

        // Obtiene todas las tareas almacenadas en memoria.
        public Task<IEnumerable<Tarea>> GetAllAsync()
        {
            // Retorna todos los valores del diccionario
            return Task.FromResult(_tareas.Values.AsEnumerable());
        }

        // Marca una tarea existente como completada.
        public Task<Tarea?> CompleteAsync(int id)
        {
            // obtenemos la tarea desde el diccionario
            if (!_tareas.TryGetValue(id, out var tarea))
            {
                // Si no existe, se Devuelve null
                return Task.FromResult<Tarea?>(null);
            }

            // Marca la tarea como completada
            tarea.IsCompleted = true;

            // Retorna la tarea actualizada
            return Task.FromResult(tarea);
        }
    }
}
