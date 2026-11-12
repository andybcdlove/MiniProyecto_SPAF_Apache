# Persona 3: persistencia, CSV e instalación

> Propuesta inicial conservada como referencia. La implementación actual y los nombres reales de Mike están descritos en Persona3-implementacion.md.

## Estado revisado

El commit inicial `edb554f` contiene los formularios y las clases vacías. Microsoft.Data.Sqlite 10.0.14 ya está referenciado y appsettings.json se copia a la salida. Este documento es una propuesta de integración, no funcionalidad implementada.

## Propuesta para acordar con el equipo

Antes de programar el repositorio, confirmar con la persona 1 los nombres y tipos de las propiedades. Con la persona 2, confirmar qué importes produce la calculadora. No modificar sus archivos sin coordinación.

Datos que necesita guardar cada paquete:

- Codigo, Cliente, Zona: string.
- PesoKg, ValorDeclarado: decimal.
- SubtotalPeso, RecargoZona, PenalizacionSobrepeso, Seguro, CostoFijoEnvio, Iva, Total: decimal.

Datos que necesita guardar cada lote:

- Id: long, asignado al guardar.
- FechaProcesamiento: DateTimeOffset.
- Paquetes: Paquete[] con solo posiciones ocupadas.
- Total: decimal correspondiente al procesamiento original.

Confirmar si los errores de validación también deben persistirse y si el lote requiere los parámetros originales del JSON para auditoría. El historial debe recuperar los importes guardados sin recalcularlos con las tarifas actuales.

Métodos propuestos para RepositorioEnvios, sujetos a los modelos acordados:

```csharp
void Inicializar();
long GuardarLote(Lote lote);
Lote[] ObtenerLotes();
Paquete[] ObtenerPaquetes(long loteId);
```

Método propuesto para ExportadorCSV:

```csharp
void Exportar(Lote lote, string rutaDestino);
```

La persona 4 proporcionará la ruta mediante SaveFileDialog, llamará a los servicios y mostrará los errores en el idioma seleccionado. Los servicios no deben mostrar MessageBox.

## Diseño previsto

- SQLite: tablas Lotes y Paquetes; tabla Desgloses con relación uno a uno con Paquetes. Claves foráneas activadas por conexión.
- Guardar lote, paquetes y desgloses en una sola transacción con parámetros. Un fallo debe revertir todo el lote.
- Guardar decimales sin pérdida de precisión, por ejemplo como texto con CultureInfo.InvariantCulture; evitar convertir dinero a double.
- Base local propuesta: `%LOCALAPPDATA%/MiniProyecto_SPAF_Apache/envios.db`, fuera de la carpeta de instalación. Crear su carpeta y esquema al iniciar el repositorio.
- Liberar conexiones, comandos, lectores, transacciones y archivos mediante using.
- CSV con encabezados, comas como delimitador, números con cultura invariable y codificación UTF-8. Encerrar los campos con comas, comillas o saltos de línea entre comillas y duplicar las comillas internas.
- Manejar fallos de acceso, escritura y SQLite con contexto para que la interfaz pueda informar al usuario.

La consigna también menciona recepciones, pero no define sus datos ni operaciones. Consultar al equipo/profesor antes de inventar esa funcionalidad.

## Pruebas pendientes

1. Guardar y consultar un lote con varios paquetes y todos sus importes.
2. Reiniciar el proceso y recuperar exactamente los mismos importes.
3. Cambiar las tarifas y comprobar que el historial permanece igual.
4. Provocar un fallo durante el guardado y comprobar que no quedan registros parciales.
5. Exportar nombres con comas, comillas, acentos y saltos de línea; recuperar las mismas columnas con un lector CSV.
6. Comprobar rutas inválidas, archivos bloqueados y errores de permisos.

## Instalación pendiente

Al terminar la integración, preparar una publicación Release para Windows con las dependencias SQLite y appsettings.json. Decidir si será autocontenida o requerirá .NET Desktop Runtime 10. Incluir instrucciones de ejecución, ubicación de la base y exportaciones y copia de seguridad. Probar en otra computadora antes de entregar el ZIP; compilar en la computadora de desarrollo no verifica la instalación.

## Mensaje que puedes compartir con tu equipo

> Ya cloné el repositorio y tengo la rama Dana. Para implementar SQLite y CSV necesito acordar las propiedades de Lote y Paquete y los campos del desglose financiero. Dejé una propuesta en docs/Persona3-acuerdo-integracion.md. ¿Qué nombres usarán? También necesitamos aclarar con el profesor qué debe hacer el sistema con las recepciones.
