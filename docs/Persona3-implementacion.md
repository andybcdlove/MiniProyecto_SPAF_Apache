# Dana: SQLite, CSV e instalación

## Estado

Se incorporó origin/Mike (f1c16c2) a Dana por avance directo, sin cambiar sus modelos. Se implementaron RepositorioEnvios y ExportadorCSV. Para completar la integración solicitada se tomaron CalculadoraFlete y ConfiguracionServicio de origin/Andy (7fc4f2c), y se conectaron los eventos mediante archivos parciales de los formularios, sin editar el diseñador. Compartir estos archivos con la persona 4 antes de integrar sus cambios de interfaz e idiomas.

Los botones Procesar, Limpiar, Guardar, Exportar, Ver historial y Actualizar ya tienen conexión. La configuración se carga al mostrar el formulario y se reintenta al procesar. Guardar asigna el Id al lote actual y desactiva el botón para impedir otro guardado del mismo lote. El historial recupera lotes completos y permite inspeccionar los paquetes y su desglose. Los eventos capturan errores de SQLite, archivos, configuración y operaciones inválidas, y los informan con MessageBox; los servicios no dependen de WinForms.

Se agregó el registro de recepciones con el alcance definido abajo. Pendientes externos: verificar el ZIP en otra computadora y coordinar los cambios de interfaz con la persona 4. La traducción completa de etiquetas sigue siendo responsabilidad de la persona 4; los nuevos avisos de guardado y exportación usan el idioma seleccionado. La ventana nueva de recepciones está en español.

Este documento reemplaza los nombres tentativos de Persona3-acuerdo-integracion.md: ahora se usan exactamente las propiedades de Mike.

## Uso desde los servicios y la interfaz

```csharp
var repositorio = new RepositorioEnvios();
repositorio.Inicializar();
long id = repositorio.GuardarLote(loteProcesado);
Lote[] historial = repositorio.ObtenerLotes();
Paquete[] paquetes = repositorio.ObtenerPaquetes(id);
new ExportadorCSV().Exportar(loteProcesado, rutaElegidaConSaveFileDialog);
```

GuardarLote devuelve el identificador sin modificar el objeto de Mike. La interfaz integrada reemplaza el lote por una instancia con Id y desactiva Guardar. Desde otro consumidor, volver a enviar el mismo objeto sin Id puede insertar otra copia. Un lote recuperado con Id se rechaza si se intenta guardar otra vez.

ObtenerLotes devuelve lotes completos del más reciente al más antiguo según su identificador. Los paquetes conservan el orden original. No se recalculan ni redondean los importes; se almacenan como TEXT invariable para evitar pérdidas de precisión por punto flotante. También se conservan los errores, su orden y sus códigos; para códigos conocidos, el modelo de Mike reconstruye el mensaje correspondiente al código.

La base se crea en `%LOCALAPPDATA%\MiniProyecto_SPAF_Apache\envios.db`. Las tablas son Lotes, Paquetes, Desgloses y Errores, con claves foráneas. El guardado completo usa una sola transacción. Los valores se envían como parámetros. Los recursos usan using. Los fallos de SQLite, archivos y permisos se propagan a la interfaz y son capturados por IntegracionPersistencia.Ejecutar. InvalidOperationException informa un intento de guardar un lote con Id.

CSV incluye una fila por paquete y doce encabezados; usa UTF-8 con BOM, comas, punto decimal y CRLF. Todos los campos van entre comillas, y las comillas internas se duplican. La ruta procede de SaveFileDialog; si el archivo existe se sobrescribe, por lo que el diálogo debe mantener su confirmación de sobrescritura. No contiene filas de errores ni un total adicional del lote.

### Exportación Excel con formato

El botón Exportar permite elegir Excel (*.xlsx) o CSV (*.csv). Excel es la opción inicial y se genera mediante ExportadorExcel y ClosedXML 0.105.1, sin necesitar Excel instalado. Incluye título amarillo, encabezados en vino, tabla con filtros, filas alternadas, encabezados fijos, anchos definidos, formato monetario y total del lote. Los valores proceden del procesamiento original; no se recalculan al exportar. El CSV obligatorio conserva sus comas y encabezados; no admite estilos. Si Excel abre el CSV en una sola columna, importarlo desde Datos con delimitador coma o usar la nueva opción .xlsx.

Prueba adicional: `dotnet run --project PruebasPersistencia -- excel .pruebas/excel-nueva`. Reabre el archivo, compara texto e importes, comprueba tabla, filtros y formato y valida la estructura mediante OpenXmlValidator. Referencia de la biblioteca: https://docs.closedxml.io/en/latest/features/tables.html

## Recepciones: alcance implementado

Ante la solicitud de implementar esta parte sin esperar una aclaración externa, se interpretó recepción como la llegada de un paquete ya registrado en un lote guardado. Es una decisión de implementación, no una especificación confirmada por el profesor.

En Ver historial, seleccionar un lote y abrir Recepciones. Elegir el paquete, escribir quién lo recibió y, opcionalmente, observaciones. Se registra la fecha y hora UTC con desplazamiento explícito. La tabla muestra las recepciones persistidas. Solo puede existir una recepción por paquete, protegida con restricción UNIQUE y transacción. Un lote y el índice original de paquete identifican el registro sin depender de que sus códigos sean únicos. No se modifican los importes financieros ni se implementan estados de transporte adicionales.

API: RegistrarRecepcion(long loteId, int indicePaquete, string recibidoPor, string observaciones = "") devuelve el Id; ObtenerRecepciones(long loteId) devuelve Recepcion[]. La tabla Recepciones referencia Paquetes y se agrega con CREATE TABLE IF NOT EXISTS, compatible con bases creadas antes de esta ampliación.

Se añadió una entidad independiente Recepcion sin modificar las entidades de Mike. El registro se verifica con pruebas de recuperación en otro proceso, rechazo de duplicados y rechazo de paquetes inexistentes.

## Pruebas reproducibles

Desde la raíz del repositorio, usar una carpeta nueva en cada ejecución:

```powershell
dotnet run --project PruebasPersistencia -- guardar .pruebas/ejecucion-nueva
dotnet run --project PruebasPersistencia --no-restore -- recuperar .pruebas/ejecucion-nueva
dotnet run --project PruebasPersistencia --no-restore -- interfaz .pruebas/interfaz-nueva
```

Las dos órdenes ejecutan procesos distintos. Comprueban siete paquetes (ampliación del arreglo), errores, fecha, todos los importes y precisión, recuperación, rechazo de un lote recuperado, CSV mediante un lector independiente con comas, comillas, acentos y saltos de línea, ruta inválida y rollback mediante un trigger que falla al insertar el desglose. No dependen de formularios ni de la calculadora.

La tercera orden comprueba controles reales de WinForms en un hilo STA, sin mostrar ventanas: procesamiento con calculadora y JSON, tablas de válidos/errores, guardado, prevención de duplicados y selección del lote en historial. No automatiza SaveFileDialog ni verifica visualmente el diseño.

También verifica la tabla de la nueva ventana de recepciones. Las tres modalidades pasaron en el equipo de desarrollo. La compilación/publicación mostró NU1900 al consultar por red los datos de vulnerabilidades de NuGet; no hubo errores de compilación ni fallos de las pruebas. La auditoría de paquetes por red no quedó validada.

## Preparar archivos de instalación

Cuando el equipo termine la integración, ejecutar desde la raíz:

```powershell
./PrepararInstalacion.ps1
```

Produce un ZIP para Windows x64 con .NET incluido, appsettings.json, recursos y dependencias SQLite. Necesita acceso a NuGet durante la publicación. Es un paquete portable, no un instalador MSI. No editar tarifas en el código; el responsable de JSON debe validar el archivo de configuración.

Se ejecutó el script y se generó correctamente un ZIP de desarrollo en artifacts. Esta comprobación valida la publicación y el empaquetado, no el funcionamiento de los formularios ni la instalación en otra computadora.

Antes de entregar, seguir docs/Verificacion-otra-computadora.md en otra computadora Windows x64. Falta realizar esta verificación y probar visualmente los diálogos. No afirmar que la instalación en otra computadora ya fue validada.
