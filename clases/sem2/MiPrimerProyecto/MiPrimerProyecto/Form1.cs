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
            ListarData();
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

                var validardato = ListaPersona.Where(w => w.NroDocumento == txtnrodocumento.Text).Select(w => w.NroDocumento).FirstOrDefault();
                if (validardato != null)
                {

                    MessageBox.Show("El número de documento ya existe!");
                    return;
                }

                if (txtnrodocumento.Text.Length < 8)
                {
                    MessageBox.Show("Ingrese un documento válido, 8 dígitos");
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


                personaEnt = new PersonaEnt(Convert.ToInt32(txtIdpersona.Text), txtnombre.Text, txtapellidopaterno.Text, txtapellidoMaterno.Text, txtnrodocumento.Text, Convert.ToDateTime(dtpfechanacimiento.Value), Convert.ToInt32(txtedad.Text), 1);

                if (MessageBox.Show("Está seguro de realizar esta operación?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    ResultadoTransationE resultadoTransationE = new ResultadoTransationE();

                    if (Convert.ToInt32(txtIdpersona.Text) == 0)
                    {
                        resultadoTransationE = PersonaBus.PersonaInsert(personaEnt);
                    }
                    else {
                        resultadoTransationE = PersonaBus.PersonaUpdate(personaEnt);
                    }

                    

                    if (resultadoTransationE.IdRegistro == -1)
                    {
                        MessageBox.Show(resultadoTransationE.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (resultadoTransationE.value == false)
                    {
                        MessageBox.Show(resultadoTransationE.Mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        MessageBox.Show(resultadoTransationE.Mensaje, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarData();
                        LimpiarData();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try {
                if (MessageBox.Show("Está seguro de eliminar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                {
                    int _Idpersona = Convert.ToInt32(dgvLista.CurrentRow.Cells["IdPersona"].Value.ToString());
                   
                    personaEnt = new PersonaEnt();
                    personaEnt.IdPersona = _Idpersona;
                    personaEnt.user_Insert = 1;

                    ResultadoTransationE resultadoTransationE = PersonaBus.PersonaDelete(personaEnt);
                    if (resultadoTransationE.IdRegistro == -1)
                    {
                        MessageBox.Show(resultadoTransationE.Mensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else {
                        MessageBox.Show(resultadoTransationE.Mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarData();
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            ListarData();
        }


        private void ListarData()
        {

            string buscar = "%" + txtbuscar.Text + "%";


            try
            {
                dgvLista.DataSource = PersonaBus.PersonaList(1, buscar, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //dgvLista.DataSource = null;
            //ListaPersona.Add(obj);
            //dgvLista.DataSource = ListaPersona;
            //_Idpersona += 1;
        }

        private void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                DataGridViewRow fila = dgvLista.Rows[e.RowIndex];
                if (fila != null) {
                    int _Idpersona = Convert.ToInt32(fila.Cells["IdPersona"].Value.ToString());
                    PersonaEnt obj = PersonaBus.PersonaList_X_ID(2, "", _Idpersona);
                    if (obj != null)
                    {
                        txtIdpersona.Text = obj.IdPersona.ToString();
                        txtnombre.Text = obj.Nombre;
                        txtapellidopaterno.Text = obj.ApellidoPaterno;
                        txtapellidoMaterno.Text = obj.ApellidoMaterno;
                        txtnrodocumento.Text = obj.NroDocumento;
                        dtpfechanacimiento.Value = Convert.ToDateTime(obj.FechaNacimiento.ToString());
                        txtedad.Text = obj.Edad.ToString();
                    }
                }
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
            }
        }
    }
}
