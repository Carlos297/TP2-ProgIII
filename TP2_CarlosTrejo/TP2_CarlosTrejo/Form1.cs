using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace TP2_CarlosTrejo
{

    

    public partial class Form1 : Form
    {

        private List<Articulo> lista;

        public Form1()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            InitializeComponent();
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
                lista = negocio.listar2();
                dgvArticulos.DataSource = lista;
               
                
                          dgvArticulos.Columns[0].Visible = false;
                          dgvArticulos.Columns[1].Visible = false;
                          //dgvArticulos.Columns[2].Visible = false;
                          //dgvArticulos.Columns[3].Visible = false;
                          dgvArticulos.Columns[4].Visible = false;
                          dgvArticulos.Columns[5].Visible = false;
                          dgvArticulos.Columns[6].Visible = false;
                          dgvArticulos.Columns[7].Visible = false;
                
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
            frmAltaArticulo alta = new frmAltaArticulo(modificar);
            alta.ShowDialog();
            CargarGrilla();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                int id = ((Articulo)dgvArticulos.CurrentRow.DataBoundItem).Id;
                negocio.eliminar(id);
                CargarGrilla();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnContar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lista.Count.ToString());

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

            List<Articulo> listaFiltrada;

            try
            {
                if (txtBusqueda.Text == "")
                {
                   listaFiltrada = lista;
                }
                else
                {
                    listaFiltrada = lista.FindAll(k => k.Descripcion.ToLower().Contains(txtBusqueda.Text.ToLower()) || k.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower()));
                    //dgvArticulos.DataSource = listaFiltrada;
                }

                dgvArticulos.DataSource = listaFiltrada;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            
            Articulo art;
            art = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            //ptbxArticulos.Load(art.ImagenURL);
            MessageBox.Show("Codigo del Articulo: " +  art.Codigo + "     "  + Environment.NewLine + Environment.NewLine + "Marca: " + art.Marca.Descripcion + "     " + Environment.NewLine + Environment.NewLine + "Categoria: " + art.Categoria.Descripcion + "     " + Environment.NewLine + Environment.NewLine + "Precio: $ " + art.Precio);

        }
    }
}
