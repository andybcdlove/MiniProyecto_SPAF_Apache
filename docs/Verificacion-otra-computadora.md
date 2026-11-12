# Prueba de instalación en otra computadora

Usar el ZIP más reciente de artifacts. No hace falta instalar Visual Studio ni .NET para la publicación autocontenida Windows x64. Esta prueba requiere otra computadora real y está pendiente.

1. Copiar el ZIP, descomprimirlo completo y abrir MiniProyecto_SPAF_Apache.exe.
2. Pegar estas líneas y pulsar Procesar:

```text
PACK-001;Ana;Zona A;12.5;150
PACK-002;Luis;Zona C;25;1500
PACK-003;Error;Zona B;-1;50
```

3. Debe haber dos paquetes válidos, un error y total de 659.75 con el JSON de prueba. Luis debe aparecer antes que Ana por tener mayor total.
4. Seleccionar un paquete y comprobar su desglose. Pulsar Guardar; debe informar éxito y desactivar el botón.
5. Cerrar y abrir el programa. Entrar a Ver historial y seleccionar el lote; deben aparecer ambos paquetes y los mismos importes.
6. Procesar de nuevo y exportar CSV a una carpeta con permisos. Cancelar el diálogo no debe crear archivo ni mostrar un error. Confirmar sobrescritura al elegir un archivo existente.
7. Conservar un respaldo de appsettings.json; renombrarlo temporalmente con el programa cerrado. Al abrir debe informar que falta la configuración sin cerrarse. Restaurarlo y volver a pulsar Procesar; debe funcionar.
8. Comprobar que existe `%LOCALAPPDATA%\MiniProyecto_SPAF_Apache\envios.db`.
9. En historial, seleccionar el lote y abrir Recepciones. Elegir un paquete, indicar quién lo recibe y registrar. Debe mostrarse en la tabla. Intentar repetir el mismo paquete debe informar el error sin cerrar el programa.
10. Cerrar y volver a abrir el programa; comprobar que la recepción sigue en el mismo lote y los importes permanecen iguales.
11. Procesar y elegir Exportar → Excel (*.xlsx). Abrir el archivo: cada dato debe quedar en su columna, con encabezados azul claro, bordes azules, filtros y monedas. Elegir luego CSV (*.csv) y comprobar que aún exporta el formato exigido por la consigna.

Registrar nombre del evaluador, fecha, versión de Windows, nombre del ZIP y resultado de cada paso. Para un problema, anotar el mensaje exacto. No marcar como aprobada esta prueba hasta realizarla.
