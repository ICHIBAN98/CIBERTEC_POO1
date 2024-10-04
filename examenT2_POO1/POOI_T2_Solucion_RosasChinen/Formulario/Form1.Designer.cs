namespace Formulario
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtNombreProducto = new TextBox();
            txtCantidad = new TextBox();
            txtPrecioUnitario = new TextBox();
            txtSubTotal = new TextBox();
            txtIGV = new TextBox();
            txtMontoTotal = new TextBox();
            btnRegistrar = new Button();
            dtpFechaVenta = new DateTimePicker();
            label8 = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvLista = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 17);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre de producto:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(144, 17);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 1;
            label2.Text = "Fecha de venta:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(241, 17);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 2;
            label3.Text = "Cantidad:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(302, 17);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 3;
            label4.Text = "Precio Unitario:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(396, 17);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 4;
            label5.Text = "SubTotal:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(475, 17);
            label6.Name = "label6";
            label6.Size = new Size(28, 15);
            label6.TabIndex = 5;
            label6.Text = "IGV:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(556, 17);
            label7.Name = "label7";
            label7.Size = new Size(73, 15);
            label7.TabIndex = 6;
            label7.Text = "Monto total:";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Location = new Point(16, 35);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(122, 23);
            txtNombreProducto.TabIndex = 7;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(241, 35);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(58, 23);
            txtCantidad.TabIndex = 7;
            txtCantidad.TextChanged += txtCantidad_TextChanged;
            txtCantidad.KeyPress += txtCantidad_KeyPress;
            // 
            // txtPrecioUnitario
            // 
            txtPrecioUnitario.Location = new Point(302, 35);
            txtPrecioUnitario.Name = "txtPrecioUnitario";
            txtPrecioUnitario.Size = new Size(88, 23);
            txtPrecioUnitario.TabIndex = 7;
            txtPrecioUnitario.TextChanged += txtPrecioUnitario_TextChanged;
            txtPrecioUnitario.KeyPress += txtPrecioUnitario_KeyPress;
            // 
            // txtSubTotal
            // 
            txtSubTotal.Enabled = false;
            txtSubTotal.Location = new Point(396, 35);
            txtSubTotal.Name = "txtSubTotal";
            txtSubTotal.Size = new Size(74, 23);
            txtSubTotal.TabIndex = 7;
            // 
            // txtIGV
            // 
            txtIGV.Enabled = false;
            txtIGV.Location = new Point(476, 35);
            txtIGV.Name = "txtIGV";
            txtIGV.Size = new Size(74, 23);
            txtIGV.TabIndex = 7;
            // 
            // txtMontoTotal
            // 
            txtMontoTotal.Enabled = false;
            txtMontoTotal.Location = new Point(556, 35);
            txtMontoTotal.Name = "txtMontoTotal";
            txtMontoTotal.Size = new Size(74, 23);
            txtMontoTotal.TabIndex = 7;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(644, 17);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(94, 41);
            btnRegistrar.TabIndex = 8;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // dtpFechaVenta
            // 
            dtpFechaVenta.CustomFormat = " dd/MM/yyyy";
            dtpFechaVenta.Format = DateTimePickerFormat.Custom;
            dtpFechaVenta.Location = new Point(144, 35);
            dtpFechaVenta.Name = "dtpFechaVenta";
            dtpFechaVenta.Size = new Size(91, 23);
            dtpFechaVenta.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 70);
            label8.Name = "label8";
            label8.Size = new Size(205, 15);
            label8.TabIndex = 10;
            label8.Text = "Buscar por Nombre o Fecha de venta:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(16, 88);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(205, 23);
            txtBuscar.TabIndex = 11;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(241, 70);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 41);
            btnBuscar.TabIndex = 12;
            btnBuscar.Text = "Buscar/Listar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvLista
            // 
            dgvLista.AllowUserToAddRows = false;
            dgvLista.AllowUserToDeleteRows = false;
            dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLista.Location = new Point(16, 117);
            dgvLista.Name = "dgvLista";
            dgvLista.ReadOnly = true;
            dgvLista.Size = new Size(722, 321);
            dgvLista.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(756, 450);
            Controls.Add(dgvLista);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(label8);
            Controls.Add(dtpFechaVenta);
            Controls.Add(btnRegistrar);
            Controls.Add(txtMontoTotal);
            Controls.Add(txtIGV);
            Controls.Add(txtSubTotal);
            Controls.Add(txtPrecioUnitario);
            Controls.Add(txtCantidad);
            Controls.Add(txtNombreProducto);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
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
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtNombreProducto;
        private TextBox txtCantidad;
        private TextBox txtPrecioUnitario;
        private TextBox txtSubTotal;
        private TextBox txtIGV;
        private TextBox txtMontoTotal;
        private Button btnRegistrar;
        private DateTimePicker dtpFechaVenta;
        private Label label8;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvLista;
    }
}
