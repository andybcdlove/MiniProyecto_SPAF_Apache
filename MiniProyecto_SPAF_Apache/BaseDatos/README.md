# Base de datos SQLite

Esta carpeta muestra el diseño de la base dentro del Explorador de soluciones.

- `Esquema.sql`: referencia legible de las cinco tablas y sus relaciones.
- `../Servicios/Persistencia/RepositorioEnvios.cs`: crea las tablas automáticamente y guarda/consulta lotes.
- `../Servicios/Persistencia/RepositorioEnvios.Recepciones.cs`: registra y consulta recepciones.

La base real **envios.db** se genera en `%LOCALAPPDATA%\MiniProyecto_SPAF_Apache`, una carpeta de datos por usuario de Windows. Por eso no aparece dentro del proyecto y no se sube a GitHub. Cada compañero obtiene una base vacía propia al ejecutar; después puede procesar y guardar sus lotes.

No hay que ejecutar Esquema.sql manualmente: es una copia documental de las instrucciones de RepositorioEnvios.Inicializar(). Las dependencias se restauran desde el archivo del proyecto. Para comprobarlo, ejecutar, guardar un lote, cerrar y abrir de nuevo y consultar Ver historial.
