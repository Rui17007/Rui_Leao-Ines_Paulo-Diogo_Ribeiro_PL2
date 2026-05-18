using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Views
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TipoArtigo form = new TipoArtigo();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void btnArtigo_Click(object sender, EventArgs e)
        {
            Artigo form = new Artigo();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }
    }
}
