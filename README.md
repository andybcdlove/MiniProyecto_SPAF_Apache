# MiniProyecto SPAF Apache

Aplicación WinForms en C# sobre .NET 10 para procesar lotes de envíos.

## Funciones integradas

- SQLite: tablas Lotes, Paquetes, Desgloses, Errores y Recepciones.
- Guardado transaccional con parámetros, historial y conservación de importes originales.
- Registro de recepciones, con fecha, responsable y observaciones; una por paquete.
- CSV delimitado por comas y Excel con tabla, filtros y formato monetario.
- Integración de los botones de procesamiento, guardado, historial, recepción y exportación.
- Pruebas con datos ficticios, script de publicación e instrucciones de instalación.

Mike desarrolló los modelos y el procesamiento; Andrea, la estructura inicial, el repositorio, la configuración y los cálculos; Dana, la persistencia, exportación y preparación de instalación; Valentina, la conexión de la interfaz, los idiomas y el manual de usuario. Andrea coordina la revisión e integración final.

La interfaz permite cambiar entre español e inglés. Al abrir Historial o Recepciones se oculta la pantalla anterior; Regresar la recupera y Salir cierra la aplicación.

## ¿Dónde está envios.db?

Cada equipo crea automáticamente su propia base al iniciar el programa y utilizar el repositorio. Se guarda en:

```text
%LOCALAPPDATA%\MiniProyecto_SPAF_Apache\envios.db
```

No se necesita copiar una base con datos de otra persona para ejecutar el proyecto. El archivo local se excluye de Git; el código de creación y consulta sí forma parte del repositorio. En Visual Studio, revisar **BaseDatos/Esquema.sql** y **BaseDatos/README.md** dentro del proyecto. La estructura ejecutada está en `RepositorioEnvios.Inicializar()`.

## Ejecutar

Abrir `MiniProyecto_SPAF_Apache.slnx` en Visual Studio compatible con .NET 10, restaurar NuGet y pulsar F5. También se puede usar:

```powershell
dotnet run --project MiniProyecto_SPAF_Apache
```

Pegar datos como `PACK-001;Ana;Zona A;12.5;150`, procesar y guardar. Cerrar y abrir de nuevo; Ver historial permite comprobar la persistencia. Desde historial se registran las recepciones. Exportar permite elegir Excel o CSV.

## Verificación y entrega

Las pruebas actuales y sus resultados están en [Verificación de la integración](docs/Verificacion-integracion.md). El proyecto `PruebasPersistencia` es una herramienta de desarrollo y no forma parte de la aplicación distribuida. `PrepararInstalacion.ps1` genera un ZIP autocontenido Windows x64 en artifacts; los binarios generados no se guardan en Git. Consultar [instalación](docs/INSTALACION.txt) y [prueba en otra computadora](docs/Verificacion-otra-computadora.md).

La comprobación del paquete final en otra computadora todavía está pendiente. Los documentos Persona3 conservan el contexto y los aportes de Dana; no sustituyen el documento técnico conjunto ni describen todos los cambios posteriores de integración.
