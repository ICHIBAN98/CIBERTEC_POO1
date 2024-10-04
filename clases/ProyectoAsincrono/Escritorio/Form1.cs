using CapaEntidad;
using Newtonsoft.Json;
using RestSharp;

namespace Escritorio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            TrabajadorEnt trabajadorEnt = new TrabajadorEnt();
            trabajadorEnt.IdTrabajador = 1;
            trabajadorEnt.Nombres = "dasd";
            trabajadorEnt.Apellidos = "dasd";
            trabajadorEnt.NroDocumento = "45678932";
            trabajadorEnt.FechaNacimiento = DateTime.Now;
            trabajadorEnt.HorasTrabajadas = 4;
            trabajadorEnt.SueldoBasico = 1300;

            var json = JsonConvert.SerializeObject(trabajadorEnt);

            try
            {
                var _cliente = new RestClient("http://localhost:5221/Trabajador/registroTrabajador");
                var _request = new RestRequest();
                _request.Method = Method.Post;
                _request.AddJsonBody(json);
                var _response = _cliente.Execute(_request).Content;
                var data = JsonConvert.DeserializeObject<ResultadoTransationE>(_response);
                MessageBox.Show(data.Resultado);
                listarData();
            }
            catch (Exception ex)
            {
            }


            //txtJson.Text = json.ToString(); 
        }

        void listarData()
        {
            var _cliente = new RestClient("http://localhost:5221/Trabajador/ListadoTrabajador?orden=1&buscar=%&idTrabajador=0");
            var _request = new RestRequest();
            _request.Method = Method.Post;
            var _response = _cliente.Execute(_request).Content;
            var data = JsonConvert.DeserializeObject<List<TrabajadorEnt>>(_response);
            dataGridView1.DataSource = data;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listarData();
        }
    }
}
