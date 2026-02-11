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

Nota: Los endpoints pueden variar segun la implementacion de los controladores.
Para obtener todas las tareas:

Instrucciones para realizar pruebas desde Swagger

Una vez que la aplicación se encuentra en ejecución, Swagger permite probar todos los endpoints de la API directamente desde el navegador.

Para acceder a Swagger, abrir la siguiente dirección en el navegador:

[https://localhost:PUERTO/swagger](https://localhost:PUERTO/swagger)

El número de puerto puede variar según la configuración del proyecto.

---

Crear una tarea

1. Ubicar el endpoint:
   POST /api/Tareas

2. Presionar el botón "Try it out".

3. Ingresar la información en el cuerpo de la solicitud en formato JSON:

{
"nombre": "Ejemplo de tarea",
"descripcion": "Descripción de prueba"
}

4. Presionar el botón "Execute".

5. Verificar que la respuesta sea exitosa (código 200) y que la tarea haya sido creada con estado "Pendiente".

---

Ver todas las tareas

1. Ubicar el endpoint:
   GET /api/Tareas

2. Presionar el botón "Try it out".

3. Presionar "Execute".

4. Se mostrará una lista con todas las tareas creadas, incluyendo su estado actual.

---

Completar una tarea

1. Ubicar el endpoint:
   PUT /api/Tareas/{id}/completar

2. Presionar "Try it out".

3. Ingresar el ID de la tarea que se desea completar.

4. Presionar "Execute".

5. Verificar que el estado de la tarea cambie a "Completada".

---

Consideraciones importantes

* El ID debe corresponder a una tarea existente.
* Si el ID no existe, la API devolverá un error 404.
* Los datos se almacenan en memoria y se eliminarán al reiniciar la aplicación.

