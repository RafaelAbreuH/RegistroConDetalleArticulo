﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistroDetalleArticulo.Entidades;

namespace RegistroDetalleArticulo.UI.Registros
{
    public partial class rArticulos : Form
    {
        public rArticulos()
        {
            InitializeComponent();
        }

        private Articulos LlenarClase()
        {

            Articulos art = new Articulos();

            art.ArticuloId = Convert.ToInt32(IdnumericUpDown.Value);
            art.Descripcion = DescripciontextBox.Text;
            art.Precio = Convert.ToInt32(PrecionumericUpDown.Value);
            art.FechaVencimiento = VencimientodateTimePicker.Value;
            art.CantidadCotizada = Convert.ToInt32(CantCotnumericUpDown.Value); // cambiar a numericupdown

            return art;
        }

        private bool Validar(int validar) // VALIDAR
        {

            bool paso = false;
            if (validar == 1 && IdnumericUpDown.Value == 0)
            {
                GeneralErrorProvider.SetError(IdnumericUpDown, "Ingrese un ID");
                paso = true;

            }
            if (validar == 2 && DescripciontextBox.Text == string.Empty)
            {
                GeneralErrorProvider.SetError(DescripciontextBox, "Ingrese una descripcion");
                paso = true;
            }
            if (validar == 2 && PrecionumericUpDown.Value == 0)
            {

                GeneralErrorProvider.SetError(PrecionumericUpDown, "Ingrese un precio");
                paso = true;
            }
            if (validar == 2 && CantCotnumericUpDown.Text == string.Empty)
            {
                GeneralErrorProvider.SetError(CantCotnumericUpDown, "Ingrese la cantidad cotizada");
            }
            return paso;

        }


        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            GeneralErrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Articulos articulo = BLL.ArticulosBLL.Buscar(id);

            if (articulo != null)
            {

                DescripciontextBox.Text = articulo.Descripcion;
                PrecionumericUpDown.Value = articulo.Precio;
                VencimientodateTimePicker.Text = articulo.FechaVencimiento.ToString();
                CantCotnumericUpDown.Text = articulo.CantidadCotizada.ToString();

            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if (Validar(2))
            {

                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }

            GeneralErrorProvider.Clear();

            if (IdnumericUpDown.Value == 0)
                paso = BLL.ArticulosBLL.Guardar(LlenarClase());
            else
                paso = BLL.ArticulosBLL.Modificar(LlenarClase());

            if (paso)

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            PrecionumericUpDown.Value = 0;
            CantCotnumericUpDown.Value = 0;
        }


        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            GeneralErrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.ArticulosBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


}
