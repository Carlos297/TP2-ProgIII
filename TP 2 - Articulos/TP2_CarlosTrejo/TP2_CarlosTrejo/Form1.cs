using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_CarlosTrejo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


            CargarGrilla();

          
        }


        private void CargarGrilla()
        {
               ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                
                dgvArticulos.DataSource = negocio.listar2();

                //dgvArticulos.Columns[0].Visible = false;
                //dgvArticulos.Columns[1].Visible = false;
                //dgvArticulos.Columns[2].Visible = false;
                //dgvArticulos.Columns[3].Visible = false;
                dgvArticulos.Columns[4].Visible = false;
                dgvArticulos.Columns[5].Visible = false;
                //dgvArticulos.Columns[6].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        private void dgvArticulos_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Articulo art;
                art = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                ptbxArticulos.Load(art.ImagenURL);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
            CargarGrilla();

        }

        private void btnModifcar_Click(object sender, EventArgs e)
        {
            Articulo modificar;
            modificar = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
        }
    }
}
