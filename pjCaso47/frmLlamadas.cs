using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjCaso47
{
    public partial class frmLlamadas : Form
    {
        public frmLlamadas()
        {
            InitializeComponent();
        }
        //Boton de registro
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            tsRegistrar_Click(sender, e);
        }
        //Boton de cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tsCancelar_Click(sender, e);
        }
        private void tsRegistrar_Click(object sender, EventArgs e)
        {
            //Capturando los datos 
            string telefono = txtNumero.Text;
            int minutos = int.Parse(txtMinutos.Text);

            //Determinando el tipo de llamada
            string tipo="";
            if (rbfNacional.Checked == true) tipo = "Fijo Nacional";
            if (rbfInternacional.Checked == true) tipo = "Fijo Internacional";
            if (rbmNacional.Checked == true) tipo = "Movil Nacional";
            if (rbmInternacional.Checked == true) tipo = "Movil Internacional";

            //
            if (tipo == "")
            {
                MessageBox.Show("Debe seleccionar el tipo de llamada..!!","Llamadas");
                return;
            }
            

            //Asignando una tarifa segun el tipo de llamada
            double tarifa=0;
            switch (tipo)
            {
                case "Fijo Nacional": tarifa = 0.25; break;
                case "Fijo Internacional": tarifa = 1.75; break;
                case "Movil Nacional": tarifa = 1.25; break;
                case "Movil Internacional": tarifa = 2.50; break;
            }

            //Realizando los calculos de los importes
            double importe = tarifa * minutos;

            //Determinando el descuento segun los minutos
            double descuento;
            switch (tipo)
            {
                case "Fijo Nacional": descuento = 5.0/100 * importe; break;
                case "Fijo Internacional": descuento = 7.0 / 100 * importe; break;
                case "Movil Nacional": descuento = 9.0 / 100 * importe; break;
                case "Movil Internacional": descuento = 12.0 / 100 * importe; break;
                default: descuento = 0; break;
            }

            //Calculando el neto 
            double neto = importe - descuento;

            //Realizando impresiones
            ListViewItem fila = new ListViewItem(telefono);
            fila.SubItems.Add(tipo);
            fila.SubItems.Add(minutos.ToString());
            fila.SubItems.Add(importe.ToString("C"));
            fila.SubItems.Add(descuento.ToString("C"));
            fila.SubItems.Add(neto.ToString("C"));
            lvLlamadas.Items.Add(fila);

            //Limpiando los controles
            tsCancelar_Click(sender,e);
        }

        private void tsCancelar_Click(object sender, EventArgs e)
        {
            txtNumero.Clear();
            txtMinutos.Clear();
            rbfNacional.Checked = false;
            rbfInternacional.Checked = false;
            rbmNacional.Checked = false;
            rbmInternacional.Checked = false;
            txtNumero.Focus();
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Esta seguro de salir?",
                                              "Llamadas",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Exclamation);
            if (r == DialogResult.Yes) this.Close();
        }
        //Metodo para que solamente ingrese numeros en el cuadro de texto
        private void txtMinutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Debe ingresar solo numeros","Llamadas");
                e.Handled = true;
                return;
            }
        }
        //Metodo para que solamente ingrese numeros en el cuadro de texto
        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Debe ingresar solo numeros", "Llamadas");
                e.Handled = true;
                return;
            }
        }

        
    }
}
