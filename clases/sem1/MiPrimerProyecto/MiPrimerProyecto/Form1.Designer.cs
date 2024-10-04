namespace MiPrimerProyecto
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtIdpersona = new TextBox();
            label2 = new Label();
            txtnombre = new TextBox();
            label3 = new Label();
            txtapellidopaterno = new TextBox();
            label4 = new Label();
            txtapellidoMaterno = new TextBox();
            label5 = new Label();
            txtnrodocumento = new TextBox();
            label6 = new Label();
            dtpfechanacimiento = new DateTimePicker();
            label7 = new Label();
            txtedad = new TextBox();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            dgvLista = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 22);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Id Persona:";
            // 
            // txtIdpersona
            // 
            txtIdpersona.Enabled = false;
            txtIdpersona.Location = new Point(22, 40);
            txtIdpersona.Name = "txtIdpersona";
            txtIdpersona.Size = new Size(100, 23);
            txtIdpersona.TabIndex = 1;
            txtIdpersona.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(136, 22);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre:";
            // 
            // txtnombre
            // 
            txtnombre.Location = new Point(136, 40);
            txtnombre.Name = "txtnombre";
            txtnombre.Size = new Size(275, 23);
            txtnombre.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(422, 22);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 4;
            label3.Text = "Apellido Paterno:";
            // 
            // txtapellidopaterno
            // 
            txtapellidopaterno.Location = new Point(422, 40);
            txtapellidopaterno.Name = "txtapellidopaterno";
            txtapellidopaterno.Size = new Size(196, 23);
            txtapellidopaterno.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(629, 22);
            label4.Name = "label4";
            label4.Size = new Size(102, 15);
            label4.TabIndex = 6;
            label4.Text = "Apellido Materno:";
            // 
            // txtapellidoMaterno
            // 
            txtapellidoMaterno.Location = new Point(629, 40);
            txtapellidoMaterno.Name = "txtapellidoMaterno";
            txtapellidoMaterno.Size = new Size(196, 23);
            txtapellidoMaterno.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(833, 22);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 8;
            label5.Text = "Nro Documento:";
            // 
            // txtnrodocumento
            // 
            txtnrodocumento.Location = new Point(833, 40);
            txtnrodocumento.MaxLength = 8;
            txtnrodocumento.Name = "txtnrodocumento";
            txtnrodocumento.Size = new Size(196, 23);
            txtnrodocumento.TabIndex = 9;
            txtnrodocumento.KeyPress += txtnrodocumento_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 81);
            label6.Name = "label6";
            label6.Size = new Size(106, 15);
            label6.TabIndex = 10;
            label6.Text = "Fecha Nacimiento:";
            // 
            // dtpfechanacimiento
            // 
            dtpfechanacimiento.CustomFormat = "dd/MM/yyyy";
            dtpfechanacimiento.Format = DateTimePickerFormat.Custom;
            dtpfechanacimiento.Location = new Point(21, 107);
            dtpfechanacimiento.Name = "dtpfechanacimiento";
            dtpfechanacimiento.Size = new Size(139, 23);
            dtpfechanacimiento.TabIndex = 11;
            dtpfechanacimiento.ValueChanged += dtpfechanacimiento_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(177, 81);
            label7.Name = "label7";
            label7.Size = new Size(36, 15);
            label7.TabIndex = 12;
            label7.Text = "Edad:";
            // 
            // txtedad
            // 
            txtedad.Enabled = false;
            txtedad.Location = new Point(177, 107);
            txtedad.Name = "txtedad";
            txtedad.Size = new Size(96, 23);
            txtedad.TabIndex = 13;
            txtedad.Text = "0";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.MediumTurquoise;
            btnGuardar.Location = new Point(296, 97);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(180, 33);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.Location = new Point(482, 97);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(180, 33);
            btnEliminar.TabIndex = 15;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.SkyBlue;
            btnCancelar.Location = new Point(668, 97);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(180, 33);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // dgvLista
            // 
            dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLista.Location = new Point(21, 154);
            dgvLista.Name = "dgvLista";
            dgvLista.Size = new Size(1006, 363);
            dgvLista.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 529);
            Controls.Add(dgvLista);
            Controls.Add(btnCancelar);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(txtedad);
            Controls.Add(label7);
            Controls.Add(dtpfechanacimiento);
            Controls.Add(label6);
            Controls.Add(txtnrodocumento);
            Controls.Add(label5);
            Controls.Add(txtapellidoMaterno);
            Controls.Add(label4);
            Controls.Add(txtapellidopaterno);
            Controls.Add(label3);
            Controls.Add(txtnombre);
            Controls.Add(label2);
            Controls.Add(txtIdpersona);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIdpersona;
        private Label label2;
        private TextBox txtnombre;
        private Label label3;
        private TextBox txtapellidopaterno;
        private Label label4;
        private TextBox txtapellidoMaterno;
        private Label label5;
        private TextBox txtnrodocumento;
        private Label label6;
        private DateTimePicker dtpfechanacimiento;
        private Label label7;
        private TextBox txtedad;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnCancelar;
        private DataGridView dgvLista;
    }
}
