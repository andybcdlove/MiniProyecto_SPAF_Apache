# Verificación local de la integración

Fecha: 16 de noviembre de 2026. Rama de trabajo: prueba-integracion.

## Resultado

Compilación de aplicación y pruebas: cero errores y cero advertencias.

Pruebas automáticas aprobadas:

- JSON ausente, mal formado, campo obligatorio ausente, precio cero, IVA fuera de rango, costo fijo negativo, raíz incorrecta y tipo de dato incorrecto. Cada caso muestra un aviso y bloquea Procesar.
- Restauración del JSON y recuperación del procesamiento.
- Eventos actuales del formulario, cálculo de 659.75, guardado único en una base temporal y consulta del historial.
- Recepciones: rechazo de nombre vacío o de espacios, guardado válido y rechazo de duplicado con mensaje en inglés.
- Limpiar, captura vacía y lote completamente inválido sin habilitar Guardar ni Exportar.
- Conservación del lote y de la geometría de los controles de tamaño fijo al cambiar de idioma. Las etiquetas AutoSize pueden ajustar su ancho al texto.
- Cancelación real del diálogo de exportación, sin archivo ni mensaje de éxito.
- SQLite: recuperación en otro proceso, conservación de importes y errores, rechazo de duplicados y rollback ante un fallo simulado.
- CSV: lectura con un lector independiente, comas, comillas, acentos, saltos de línea, importes y rechazo de una ruta inválida.
- Excel: lectura del archivo generado, texto especial, valores numéricos, total, tabla, filtros, formato monetario y validación Open XML.

Las pruebas usan bases y exportaciones temporales. Los casos de configuración modifican solo el JSON junto al ejecutable de pruebas y lo restauran al finalizar. No modifican la base de datos de la usuaria ni el JSON del proyecto.

## Repetir las pruebas

Desde la raíz, elegir carpetas nuevas en cada ejecución:

```powershell
dotnet build PruebasPersistencia/PruebasPersistencia.csproj
dotnet run --project PruebasPersistencia --no-build -- guardar .pruebas/datos-nuevos
dotnet run --project PruebasPersistencia --no-build -- recuperar .pruebas/datos-nuevos
dotnet run --project PruebasPersistencia --no-build -- excel .pruebas/excel-nuevo
dotnet run --project PruebasPersistencia --no-build -- interfaz .pruebas/interfaz-nueva
```

El modo interfaz abre y cierra automáticamente sus propios diálogos. Su temporizador solo actúa sobre ventanas del hilo de la prueba.

## Limpieza realizada

- Eliminado el recurso vacío FrmRecepciones.resx generado al abrir el diseñador de un formulario construido por código.
- Eliminados métodos duplicados sin uso de procesamiento, resumen, exportación CSV exclusiva y presentación de tablas.
- Eliminado el evento vacío CellContentClick y su conexión del diseñador.
- Unificado el guardado para usar el mismo repositorio que el historial.
- Actualizada la prueba de interfaz para usar los eventos vigentes en vez de métodos retirados.
- Conservados modelos, recursos bilingües, ServicioEnvios, esquema SQL, instalador portable, documentación y pruebas útiles.

## Pendientes de entrega

Esta revisión local no sustituye la ejecución del paquete final en otra computadora. Aún deben terminarse la documentación técnica conjunta, la actualización de los manuales, el video, el respaldo final y el cierre/publicación de la integración en Git.
