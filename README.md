TaskApi es una API REST desarrollada en C# (.NET 8) para la gestion de tareas, utilizando un repositorio en memoria. El proyecto esta preparado para ser extendido facilmente y cuenta con documentacion interactiva mediante Swagger.
Caracteristicas
	API REST para operaciones CRUD de tareas.
	Repositorio en memoria (InMemoryTareaRepository) implementando la interfaz ITareaRepository.
	Documentacion automatica y exploracion de endpoints con Swagger.
	Arquitectura minimalista basada en controladores.
Requisitos
	.NET 8 SDK
	C# 12.0
Instalacion
1.	Clona el repositorio:

git clone https://github.com/tu-usuario/TaskApi.git
cd TaskApi

2.	Restaura los paquetes:

dotnet restore

3.	Compila el proyecto:

dotnet build

Ejecucion
Inicia la API ejecutando:


dotnet run --project TaskApi


La API estara disponible en http://localhost:5000 (o el puerto configurado).

Accede a la interfaz de Swagger para explorar y probar los endpoints:
http://localhost:5000/swagger

Estructura del Proyecto
	Program.cs: Configuracion principal de la aplicacion y registro de servicios.
	Repositorios/ITareaRepository.cs: Interfaz del repositorio de tareas.
	Repositorios/InMemoryTareaRepository.cs: Implementacion en memoria del repositorio.
	Controllers/: Controladores de la API.
	Models/: Modelos de datos (si existen).
Ejemplo de Endpoints
Nota: Los endpoints pueden variar segun la implementacion de los controladores.
Para obtener todas las tareas:

GET /api/tareas

Para crear una nueva tarea:
POST /api/tareas
Content-Type: application/json

{
  "titulo": "Nueva tarea",
  "descripcion": "Descripcion de la tarea"
}

