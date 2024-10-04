using CapaEntidad;
using CapaNegocios;

namespace MiPrimerProyecto
{
    public partial class Form1 : Form
    {
        List<PersonaEnt> ListaPersona = new List<PersonaEnt>();
        PersonaEnt personaEnt = new PersonaEnt();
        PersonaBus PersonaBus = new PersonaBus();

        int _Idpersona = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int _Year = DateTime.Now.Year;
                int _YearObtenidad = Convert.ToDateTime(dtpfechanacimiento.Value).Year;

                if (string.IsNullOrWhiteSpace(txtnombre.Text))
                {
                    MessageBox.Show("El campo Nombre es obligatorio!");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtapellidopaterno.Text))
                {
                    MessageBox.Show("El campo Apellido Paterno es obligatorio!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtapellidoMaterno.Text))
                {
                    MessageBox.Show("El campo Apellido Materno es obligatorio!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtnrodocumento.Text))
                {
                    MessageBox.Show("El campo Nro Documento es obligatorio!");
                    return;
                }

                if ((_Year - _YearObtenidad) <= 0)
                {
                    MessageBox.Show("Seleccione una fecha válida!");
                    return;
                }

                var validardato = ListaPersona.Where(w=> w.NroDocumento == txtnrodocumento.Text).Select(w => w.NroDocumento).FirstOrDefault();
                if (validardato != null)
                {

                    MessageBox.Show("El número de documento ya existe!");
                    return;
                }


                /* primera forma de calcular la edad 
                    CalculosEnt calculosEnt = new CalculosEnt();
                    txtedad.Text = calculosEnt.CalcularEdad(Convert.ToDateTime(dtpfechanacimiento.Value)).ToString();
                */

                /*Primera Forma de captura datos*/
                /*
                personaEnt = new PersonaEnt();
                personaEnt.IdPersona = _Idpersona;
                personaEnt.Nombre = txtnombre.Text;
                personaEnt.ApellidoPaterno = txtapellidopaterno.Text;
                personaEnt.ApellidoMaterno = txtapellidoMaterno.Text;
                personaEnt.NroDocumento = txtnrodocumento.Text;
                personaEnt.FechaNacimiento = Convert.ToDateTime(dtpfechanacimiento.Value);
                personaEnt.Edad = Convert.ToInt32(txtedad.Text);
                */

                /*Segunda Forma datos por construtor*/
               

                personaEnt = new PersonaEnt(_Idpersona, txtnombre.Text, txtapellidopaterno.Text, txtapellidoMaterno.Text, txtnrodocumento.Text, Convert.ToDateTime(dtpfechanacimiento.Value), Convert.ToInt32(txtedad.Text), 1);

                ResultadoTransationE resultadoTransationE = PersonaBus.PersonaInsert(personaEnt);

                if (resultadoTransationE.IdRegistro == -1)
                {
                    MessageBox.Show(resultadoTransationE.Mensaje, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else 
                {
                    MessageBox.Show(resultadoTransationE.Mensaje, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                //ListarData(personaEnt);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }

        private void ListarData(PersonaEnt obj)
        {
            dgvLista.DataSource = null;
            ListaPersona.Add(obj);
            dgvLista.DataSource = ListaPersona;
            _Idpersona += 1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarData();
        }

        private void LimpiarData()
        {
            txtIdpersona.Text = "0";
            txtnombre.Text = "";
            txtapellidopaterno.Text = "";
            txtapellidoMaterno.Text = "";
            txtnrodocumento.Text = "";
            txtedad.Text = "";
            dtpfechanacimiento.Value = DateTime.Now;
        }

        private void dtpfechanacimiento_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtedad.Text = personaEnt.CalcularEdad(Convert.ToDateTime(dtpfechanacimiento.Value)).ToString();
            }
            catch (Exception ex)
            {
                txtedad.Text = "0";
            }
        }

        private void txtnrodocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
