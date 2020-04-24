using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio1;
using Negocio;
using Negocio1;

namespace TP2_CarlosTrejo
{
    public partial class frmAltaArticulo : Form
    {
        public frmAltaArticulo()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("SEGURO QUE QUERES SALIR??");
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                nuevo.Codigo = txtCodArt.Text.Trim();
                nuevo.Nombre = txtNombre.Text.Trim();
                nuevo.Descripcion = txtDescripcion.Text.Trim();
                nuevo.ImagenURL = txtURLImagen.Text.Trim();
                nuevo.Marca = (Marca)cboMarcas.SelectedItem;
                nuevo.Categoria = (Categoria)cboCategoria.SelectedItem;
                nuevo.Precio = Convert.ToDouble(txtPrecio.Text);
                //nuevo.Precio = txtPrecio.Text.CopyTo
                negocio.agregar(nuevo);
                Dispose();



            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message);
            }
        }

      
        
        
        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {

            CategoriaNegocio categoria = new CategoriaNegocio();
            MarcaNegocio marca = new MarcaNegocio();
            
            

            try
            {
               


               cboCategoria.DataSource = categoria.listar();
                cboMarcas.DataSource = marca.listar();


                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
