namespace TaskApi.Modelos
{
    // Informacion de la tarea dentro del sistema
    public class Tarea
    {
        // Identificador tarea
        public int Id { get; set; }

        // Nombre tarea
        public string Name { get; set; } = string.Empty;

        // Descripción  tarea        
        public string Description { get; set; } = string.Empty;

        // estado de la tarea pendiente/Completada
        public bool IsCompleted { get; set; } = false;
    }
}
