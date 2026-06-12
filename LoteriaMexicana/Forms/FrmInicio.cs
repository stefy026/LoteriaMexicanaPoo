using LoteriaMexicana.Forms;
using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace LoteriaMexicana
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            FrmJuego frmJuego = new FrmJuego();
            frmJuego.Show();
            this.Hide();
        }

        private void btnInstrucciones_Click(object sender, EventArgs e)
        {
            FrmInstrucciones frmInstrucciones = new FrmInstrucciones();
            frmInstrucciones.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}