using TaskApi.Modelos;

namespace TaskApi.Repositorios
{
    // contrato la gestión de tareas
    public interface ITareaRepository
    {
        Task<Tarea> CreateAsync(Tarea tarea);
        Task<IEnumerable<Tarea>> GetAllAsync();
        Task<Tarea?> CompleteAsync(int id);
    }
}
    