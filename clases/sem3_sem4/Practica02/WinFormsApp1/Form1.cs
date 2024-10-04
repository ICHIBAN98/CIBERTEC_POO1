using CapaEntidad;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public string rutaApi = "http://localhost:5134/";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarData();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                TrabajadorEnt objTrabajador = new TrabajadorEnt();
                objTrabajador.IdTrabajador = 0;
                objTrabajador.NroDocumento = txtNroDocumento.Text;
                objTrabajador.Nombres = txtNombres.Text;
                objTrabajador.Apellidos = txtApellido.Text;
                objTrabajador.FechaNacimiento = Convert.ToDateTime(dtpFechaNacimiento.Value);
                objTrabajador.FechaContrato = Convert.ToDateTime(dtpFechaContrato.Value);
                objTrabajador.HorasTrabajadas = Convert.ToInt32(txtHorasTrabajadas.Text);
                objTrabajador.Tarifa = Convert.ToDouble(txtTarifa.Text);


                var Json = JsonConvert.SerializeObject(objTrabajador);

                var _cliente = new RestClient(rutaApi + "Trabajador/RegistrarTrabajador");
                var _request = new RestRequest();
                _request.Method = Method.Post;
                _request.AddJsonBody(Json);
                var _response = _cliente.Execute(_request);
                if (_response.StatusCode == HttpStatusCode.OK)
                {
                    var Respuesta = JsonConvert.DeserializeObject<ResultadoTrasationE>(_response.Content);
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
                        Limpiar();
                        ListarData();
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

        private void Limpiar()
        {
            txtNroDocumento.Text = "";
            txtNombres.Text = "";
            txtApellido.Text = "";
            dtpFechaNacimiento.Value = DateTime.Now;
            dtpFechaContrato.Value = DateTime.Now;
            txtHorasTrabajadas.Text = "";
            txtTarifa.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarData();
        }

        void ListarData()
        {
            try {
                string Buscar = "%" + txtBuscar.Text.Trim() + "%";
               

                var _cliente = new RestClient(rutaApi + "Trabajador/ListarTrabajador?Orden=1&IdTrabajador=0&Buscar="+Buscar);
                var _request = new RestRequest();
                _request.Method = Method.Get;
                var _response = _cliente.Execute(_request);
                if (_response.StatusCode == HttpStatusCode.OK)
                {
                    var Listado = JsonConvert.DeserializeObject<List<TrabajadorEnt>>(_response.Content);
                    dgvLista.DataSource = Listado;
                }
                else {
                    MessageBox.Show(_response.Content, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
