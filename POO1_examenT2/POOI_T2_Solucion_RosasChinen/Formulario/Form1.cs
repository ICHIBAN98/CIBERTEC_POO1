using CapaEntidad;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace Formulario
{
    public partial class Form1 : Form
    {
        public string rutaApi = "http://localhost:5023/";
        public Form1()
        {
            InitializeComponent();
        }
        VentaEnt ventaEnt = new VentaEnt();
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtSubTotal.Text = Convert.ToString(ventaEnt.CalcuSubTotal(Convert.ToInt32(txtCantidad.Text), Convert.ToDouble(txtPrecioUnitario.Text)));
                txtIGV.Text = Convert.ToString(ventaEnt.CalcuIGV(Convert.ToDouble(txtSubTotal.Text)));
                txtMontoTotal.Text = Convert.ToString(ventaEnt.CalcuMontoTotal(Convert.ToDouble(txtSubTotal.Text), Convert.ToDouble(txtIGV.Text)));
            }
            catch (Exception ex)
            {
                txtSubTotal.Text = "";
                txtIGV.Text = "";
                txtMontoTotal.Text = "";
            }
        }

        private void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtSubTotal.Text = Convert.ToString(ventaEnt.CalcuSubTotal(Convert.ToInt32(txtCantidad.Text), Convert.ToDouble(txtPrecioUnitario.Text)));
                txtIGV.Text = Convert.ToString(ventaEnt.CalcuIGV(Convert.ToDouble(txtSubTotal.Text)));
                txtMontoTotal.Text = Convert.ToString(ventaEnt.CalcuMontoTotal(Convert.ToDouble(txtSubTotal.Text), Convert.ToDouble(txtIGV.Text)));
            }
            catch (Exception ex)
            {
                txtSubTotal.Text = "";
                txtIGV.Text = "";
                txtMontoTotal.Text = "";
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                int diaActual = DateTime.Now.Day;

                if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
                {
                    MessageBox.Show("El campo Nombre de producto es obligatorio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dtpFechaVenta.Value.Day != diaActual)
                {
                    MessageBox.Show("Seleccione una fecha de venta válida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCantidad.Text))
                {
                    MessageBox.Show("El campo Cantidad es obligatorio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
                {
                    MessageBox.Show("El campo Precio unitario es obligatorio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                VentaEnt objVenta = new VentaEnt();
                objVenta.IdVenta = 0;
                objVenta.NombreProducto = txtNombreProducto.Text.Trim();
                objVenta.FechaVenta = Convert.ToDateTime(dtpFechaVenta.Value);
                objVenta.Cantidad = Convert.ToInt32(txtCantidad.Text.Trim());
                objVenta.PrecioUnitario = Convert.ToDouble(txtPrecioUnitario.Text.Trim());
                objVenta.SubTotal = Convert.ToDouble(txtSubTotal.Text.Trim());
                objVenta.IGV = Convert.ToDouble(txtIGV.Text.Trim());
                objVenta.MontoTotal = Convert.ToDouble(txtMontoTotal.Text.Trim());


                var Json = JsonConvert.SerializeObject(objVenta);

                var _cliente = new RestClient(rutaApi + "Venta/RegistrarVenta");
                var _request = new RestRequest();
                _request.Method = Method.Post;
                _request.AddJsonBody(Json);
                var _response = _cliente.Execute(_request);
                if (_response.StatusCode == HttpStatusCode.OK)
                {
                    var Respuesta = JsonConvert.DeserializeObject<ResultadoTransactionEnt>(_response.Content);
                    if (Respuesta.IdRegistro == -1)
                    {
                        MessageBox.Show(Respuesta.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Respuesta.Value == false)
                    {
                        MessageBox.Show(Respuesta.Mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Respuesta.Mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarData();
                        Limpiar();
                    }
                }
                else
                {
                    MessageBox.Show(_response.Content, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarData();
            Limpiar();
        }

        void ListarData()
        {
            try
            {
                string Buscar = "%" + txtBuscar.Text.Trim() + "%";


                var _cliente = new RestClient(rutaApi + "Venta/ListarVenta?Orden=1&IdTrabajador=0&Buscar=" + Buscar);
                var _request = new RestRequest();
                _request.Method = Method.Get;
                var _response = _cliente.Execute(_request);
                if (_response.StatusCode == HttpStatusCode.OK)
                {
                    var Listado = JsonConvert.DeserializeObject<List<VentaEnt>>(_response.Content);
                    dgvLista.DataSource = Listado;
                }
                else
                {
                    MessageBox.Show(_response.Content, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtNombreProducto.Text = "";
            txtCantidad.Text = "";
            txtPrecioUnitario.Text = "";
            dtpFechaVenta.Value = DateTime.Now;
            txtBuscar.Text = "";
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarData();
        }
    }
}
