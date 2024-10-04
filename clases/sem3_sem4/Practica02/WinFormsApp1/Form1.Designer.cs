namespace WinFormsApp1
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
            txtNroDocumento = new TextBox();
            txtNombres = new TextBox();
            label2 = new Label();
            txtApellido = new TextBox();
            label3 = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            dtpFechaContrato = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            txtHorasTrabajadas = new TextBox();
            label6 = new Label();
            txtTarifa = new TextBox();
            label7 = new Label();
            btnRegistrar = new Button();
            dgvLista = new DataGridView();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 37);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 0;
            label1.Text = "Nro Documento";
            // 
            // txtNroDocumento
            // 
            txtNroDocumento.Location = new Point(12, 64);
            txtNroDocumento.Name = "txtNroDocumento";
            txtNroDocumento.Size = new Size(144, 23);
            txtNroDocumento.TabIndex = 1;
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(162, 64);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(236, 23);
            txtNombres.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(162, 37);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(404, 64);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(271, 23);
            txtApellido.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(404, 37);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 4;
            label3.Text = "Apellidos";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaNacimiento.Location = new Point(681, 64);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(127, 23);
            dtpFechaNacimiento.TabIndex = 6;
            // 
            // dtpFechaContrato
            // 
            dtpFechaContrato.CustomFormat = "dd/MM/yyyy";
            dtpFechaContrato.Format = DateTimePickerFormat.Custom;
            dtpFechaContrato.Location = new Point(814, 64);
            dtpFechaContrato.Name = "dtpFechaContrato";
            dtpFechaContrato.Size = new Size(127, 23);
            dtpFechaContrato.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(681, 37);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 8;
            label4.Text = "Fecha Nacimiento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(814, 37);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 9;
            label5.Text = "Fecha Contrato";
            // 
            // txtHorasTrabajadas
            // 
            txtHorasTrabajadas.Location = new Point(947, 64);
            txtHorasTrabajadas.Name = "txtHorasTrabajadas";
            txtHorasTrabajadas.Size = new Size(144, 23);
            txtHorasTrabajadas.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(947, 37);
            label6.Name = "label6";
            label6.Size = new Size(96, 15);
            label6.TabIndex = 10;
            label6.Text = "Horas Trabajadas";
            // 
            // txtTarifa
            // 
            txtTarifa.Location = new Point(1097, 64);
            txtTarifa.Name = "txtTarifa";
            txtTarifa.Size = new Size(144, 23);
            txtTarifa.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1097, 37);
            label7.Name = "label7";
            label7.Size = new Size(35, 15);
            label7.TabIndex = 12;
            label7.Text = "Tarifa";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(1247, 37);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(131, 50);
            btnRegistrar.TabIndex = 14;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // dgvLista
            // 
            dgvLista.AllowUserToAddRows = false;
            dgvLista.AllowUserToDeleteRows = false;
            dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLista.Location = new Point(12, 153);
            dgvLista.Name = "dgvLista";
            dgvLista.ReadOnly = true;
            dgvLista.Size = new Size(1366, 555);
            dgvLista.TabIndex = 15;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(12, 124);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(596, 23);
            txtBuscar.TabIndex = 16;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(614, 97);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(131, 50);
            btnBuscar.TabIndex = 17;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1390, 720);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvLista);
            Controls.Add(btnRegistrar);
            Controls.Add(txtTarifa);
            Controls.Add(label7);
            Controls.Add(txtHorasTrabajadas);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dtpFechaContrato);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtApellido);
            Controls.Add(label3);
            Controls.Add(txtNombres);
            Controls.Add(label2);
            Controls.Add(txtNroDocumento);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNroDocumento;
        private TextBox txtNombres;
        private Label label2;
        private TextBox txtApellido;
        private Label label3;
        private DateTimePicker dtpFechaNacimiento;
        private DateTimePicker dtpFechaContrato;
        private Label label4;
        private Label label5;
        private TextBox txtHorasTrabajadas;
        private Label label6;
        private TextBox txtTarifa;
        private Label label7;
        private Button btnRegistrar;
        private DataGridView dgvLista;
        private TextBox txtBuscar;
        private Button btnBuscar;
    }
}
