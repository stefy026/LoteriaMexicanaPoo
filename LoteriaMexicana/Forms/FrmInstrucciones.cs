using System;
using System.Windows.Forms;

namespace LoteriaMexicana
{
    public partial class FrmInstrucciones : Form
    {
        public FrmInstrucciones()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmInstrucciones_Load(object sender, EventArgs e)
        {
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}