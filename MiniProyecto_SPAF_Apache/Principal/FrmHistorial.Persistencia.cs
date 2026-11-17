using MiniProyecto_SPAF_Apache.Dominio;
using MiniProyecto_SPAF_Apache.Servicios.Persistencia;

namespace MiniProyecto_SPAF_Apache.Principal
{
    public partial class FrmHistorial
    {
        private RepositorioEnvios _repositorio = new RepositorioEnvios();
        private Button bRecepciones = new Button();
        private Button bSalir = null!;

        private void ConectarPersistencia()
        {
            //prepara las tablas
            IntegracionPersistencia.PrepararTabla(dataGridView1);
            IntegracionPersistencia.PrepararTabla(dgvPaquetes);

            //agrega el boton de recepciones
            bRecepciones.Name = "bRecepciones";
            bRecepciones.Text = "Recepciones";
            bRecepciones.AutoSize = true;
            bRecepciones.Location = new Point(
                bActualizar.Right + 20, bActualizar.Top);
            bRecepciones.Height = bActualizar.Height;
            bRecepciones.BackColor = bActualizar.BackColor;
            bRecepciones.ForeColor = bActualizar.ForeColor;
            bRecepciones.Font = bActualizar.Font;
            bRecepciones.FlatStyle = bActualizar.FlatStyle;
            bRecepciones.UseVisualStyleBackColor = false;

            Controls.Add(bRecepciones);

            //conserva el regreso y agrega la salida
            bSalir = NavegacionFormularios.CrearBotonSalir(bCerrar);
            bSalir.Location = new Point(bCerrar.Left - bSalir.Width - 16, bCerrar.Top);
            Controls.Add(bSalir);

            bRecepciones.Click += bRecepciones_Click;
            cbIdioma.SelectedIndexChanged += ActualizarIdiomaRecepciones;
            ActualizarIdiomaRecepciones(this, EventArgs.Empty);
        }

        private void ActualizarIdiomaRecepciones(object? sender, EventArgs e)
        {
            //actualiza el texto del boton
            if (cbIdioma.SelectedIndex == 1)
            {
                bRecepciones.Text = "Receptions";
                bCerrar.Text = "Back";
                bSalir.Text = "Exit";
            }
            else
            {
                bRecepciones.Text = "Recepciones";
                bCerrar.Text = "Regresar";
                bSalir.Text = "Salir";
            }
        }

        private void bRecepciones_Click(object? sender, EventArgs e)
        {
            //obtiene el lote seleccionado
            Lote? lote = null;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                lote = dataGridView1.SelectedRows[0].Tag as Lote;
            }

            if (lote == null || lote.Id == null)
            {
                string mensaje = "Selecciona primero un lote guardado.";

                if (cbIdioma.SelectedIndex == 1)
                {
                    mensaje = "Select a saved batch first.";
                }

                MessageBox.Show(this, mensaje);
                return;
            }

            //abre las recepciones del lote
            using (FrmRecepciones ventana =
                new FrmRecepciones(_repositorio, lote, cbIdioma.SelectedIndex == 1))
            {
                NavegacionFormularios.Abrir(this, ventana);
            }
        }
    }
}
