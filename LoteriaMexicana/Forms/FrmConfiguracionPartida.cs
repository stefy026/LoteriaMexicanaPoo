using LoteriaMexicana.Models;
using System;
using System.Windows.Forms;

namespace LoteriaMexicana.Forms
{
    public partial class FrmConfiguracionPartida : Form
    {
        public int CantidadCartones { get; private set; }
        public OpcionesVictoria OpcionesVictoria { get; private set; }

        public FrmConfiguracionPartida()
        {
            InitializeComponent();
            ConfigurarValoresIniciales();
        }

        private void ConfigurarValoresIniciales()
        {
            nudCantidadCartones.Minimum = 1;
            nudCantidadCartones.Maximum = 10;
            nudCantidadCartones.Value = 1;

            chkHorizontal.Checked = true;
            chkVertical.Checked = true;
            chkDiagonal.Checked = true;
            chkLleno.Checked = true;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (!chkHorizontal.Checked &&
                !chkVertical.Checked &&
                !chkDiagonal.Checked &&
                !chkLleno.Checked)
            {
                MessageBox.Show(
                    "Debes seleccionar al menos una forma de ganar.",
                    "Modo de victoria",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            CantidadCartones = (int)nudCantidadCartones.Value;

            OpcionesVictoria = new OpcionesVictoria
            {
                Horizontal = chkHorizontal.Checked,
                Vertical = chkVertical.Checked,
                Diagonal = chkDiagonal.Checked,
                Lleno = chkLleno.Checked
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}