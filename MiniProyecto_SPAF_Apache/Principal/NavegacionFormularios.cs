namespace MiniProyecto_SPAF_Apache.Principal;

internal static class NavegacionFormularios
{
    public static bool Saliendo { get; private set; }

    //oculta la ventana anterior y la recupera al regresar
    public static void Abrir(Form anterior, Form siguiente)
    {
        siguiente.StartPosition = FormStartPosition.Manual;
        Rectangle pantalla = Screen.FromControl(anterior).WorkingArea;
        siguiente.Location = new Point(
            Math.Max(pantalla.Left, Math.Min(anterior.Left, pantalla.Right - siguiente.Width)),
            Math.Max(pantalla.Top, Math.Min(anterior.Top, pantalla.Bottom - siguiente.Height)));
        anterior.Hide();
        try
        {
            siguiente.ShowDialog(anterior);
        }
        finally
        {
            if (!Saliendo && !anterior.IsDisposed && !anterior.Disposing)
            {
                anterior.Show();
                anterior.Activate();
            }
        }
    }

    //cierra todas las ventanas sin volver a mostrarlas
    public static void Salir()
    {
        Saliendo = true;
        Application.Exit();
    }

    public static Button CrearBotonSalir(Button referencia)
    {
        Button boton = new Button();
        boton.Name = "bSalir";
        boton.Size = new Size(Math.Max(100, referencia.Width), referencia.Height);
        boton.Font = referencia.Font;
        boton.BackColor = referencia.BackColor;
        boton.ForeColor = referencia.ForeColor;
        boton.FlatStyle = referencia.FlatStyle;
        boton.UseVisualStyleBackColor = false;
        boton.Click += (_, _) => Salir();
        return boton;
    }
}
