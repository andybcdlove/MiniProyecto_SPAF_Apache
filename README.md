# MiniProyecto SPAF Apache — rama Dana

Aplicación WinForms en C# sobre .NET 10 para procesar lotes de envíos.

## Trabajo de Dana: base de datos y exportación

- SQLite: tablas Lotes, Paquetes, Desgloses, Errores y Recepciones.
- Guardado transaccional con parámetros, historial y conservación de importes originales.
- Registro de recepciones, con fecha, responsable y observaciones; una por paquete.
- CSV delimitado por comas y Excel con tabla, filtros y formato monetario.
- Integración de los botones de procesamiento, guardado, historial, recepción y exportación.
- Pruebas con datos ficticios, script de publicación e instrucciones de instalación.

Se incorporaron los modelos/procesamiento de Mike y las clases de configuración/cálculo de Andy. Sus aportes no se presentan como trabajo de Dana. Los archivos parciales de integración deben coordinarse con la persona responsable de interfaz e idiomas.

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

Las pruebas se ejecutan según [la documentación técnica](docs/Persona3-implementacion.md). `PrepararInstalacion.ps1` genera un ZIP autocontenido Windows x64 en artifacts; los binarios generados no se guardan en Git. Consultar [instalación](docs/INSTALACION.txt) y [prueba en otra computadora](docs/Verificacion-otra-computadora.md).

Las pruebas locales pasaron. La comprobación en otra computadora corresponde a un integrante del equipo y todavía no está confirmada. Recepción se interpretó como llegada de un paquete guardado; el equipo debe comunicar esta interpretación al profesor. La traducción completa de interfaz sigue a cargo de su responsable.
