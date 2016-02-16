namespace Ponuda
{
    partial class FormFirma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFirma));
            this.sveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataBaseDataSet = new Ponuda.DataBaseDataSet();
            this.sveTableAdapter = new Ponuda.DataBaseDataSetTableAdapters.sveTableAdapter();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firmaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pocetakDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zavrsetakDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gorivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cestarinaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trajektDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vozacDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ukupnaCijenaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ukupnoKMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.napomeneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // sveBindingSource
            // 
            this.sveBindingSource.DataMember = "sve";
            this.sveBindingSource.DataSource = this.dataBaseDataSet;
            // 
            // dataBaseDataSet
            // 
            this.dataBaseDataSet.DataSetName = "DataBaseDataSet";
            this.dataBaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sveTableAdapter
            // 
            this.sveTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.firmaDataGridViewTextBoxColumn,
            this.pocetakDataGridViewTextBoxColumn,
            this.zavrsetakDataGridViewTextBoxColumn,
            this.gorivoDataGridViewTextBoxColumn,
            this.cestarinaDataGridViewTextBoxColumn,
            this.trajektDataGridViewTextBoxColumn,
            this.vozacDataGridViewTextBoxColumn,
            this.namaDataGridViewTextBoxColumn,
            this.ukupnaCijenaDataGridViewTextBoxColumn,
            this.ukupnoKMDataGridViewTextBoxColumn,
            this.napomeneDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.sveBindingSource;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView2.Location = new System.Drawing.Point(2, 11);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(1204, 502);
            this.dataGridView2.TabIndex = 58;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 5;
            // 
            // firmaDataGridViewTextBoxColumn
            // 
            this.firmaDataGridViewTextBoxColumn.DataPropertyName = "Firma";
            this.firmaDataGridViewTextBoxColumn.HeaderText = "Firma";
            this.firmaDataGridViewTextBoxColumn.Name = "firmaDataGridViewTextBoxColumn";
            this.firmaDataGridViewTextBoxColumn.ReadOnly = true;
            this.firmaDataGridViewTextBoxColumn.Width = 88;
            // 
            // pocetakDataGridViewTextBoxColumn
            // 
            this.pocetakDataGridViewTextBoxColumn.DataPropertyName = "Pocetak";
            this.pocetakDataGridViewTextBoxColumn.HeaderText = "Početak";
            this.pocetakDataGridViewTextBoxColumn.Name = "pocetakDataGridViewTextBoxColumn";
            this.pocetakDataGridViewTextBoxColumn.ReadOnly = true;
            this.pocetakDataGridViewTextBoxColumn.Width = 109;
            // 
            // zavrsetakDataGridViewTextBoxColumn
            // 
            this.zavrsetakDataGridViewTextBoxColumn.DataPropertyName = "Zavrsetak";
            this.zavrsetakDataGridViewTextBoxColumn.HeaderText = "Završetak";
            this.zavrsetakDataGridViewTextBoxColumn.Name = "zavrsetakDataGridViewTextBoxColumn";
            this.zavrsetakDataGridViewTextBoxColumn.ReadOnly = true;
            this.zavrsetakDataGridViewTextBoxColumn.Width = 124;
            // 
            // gorivoDataGridViewTextBoxColumn
            // 
            this.gorivoDataGridViewTextBoxColumn.DataPropertyName = "Gorivo";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.gorivoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.gorivoDataGridViewTextBoxColumn.HeaderText = "Gorivo";
            this.gorivoDataGridViewTextBoxColumn.Name = "gorivoDataGridViewTextBoxColumn";
            this.gorivoDataGridViewTextBoxColumn.ReadOnly = true;
            this.gorivoDataGridViewTextBoxColumn.Width = 96;
            // 
            // cestarinaDataGridViewTextBoxColumn
            // 
            this.cestarinaDataGridViewTextBoxColumn.DataPropertyName = "Cestarina";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.cestarinaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.cestarinaDataGridViewTextBoxColumn.HeaderText = "Cestarina";
            this.cestarinaDataGridViewTextBoxColumn.Name = "cestarinaDataGridViewTextBoxColumn";
            this.cestarinaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cestarinaDataGridViewTextBoxColumn.Width = 122;
            // 
            // trajektDataGridViewTextBoxColumn
            // 
            this.trajektDataGridViewTextBoxColumn.DataPropertyName = "Trajekt";
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.trajektDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.trajektDataGridViewTextBoxColumn.HeaderText = "Trajekt";
            this.trajektDataGridViewTextBoxColumn.Name = "trajektDataGridViewTextBoxColumn";
            this.trajektDataGridViewTextBoxColumn.ReadOnly = true;
            this.trajektDataGridViewTextBoxColumn.Width = 98;
            // 
            // vozacDataGridViewTextBoxColumn
            // 
            this.vozacDataGridViewTextBoxColumn.DataPropertyName = "Vozac";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.vozacDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.vozacDataGridViewTextBoxColumn.HeaderText = "Vozač";
            this.vozacDataGridViewTextBoxColumn.Name = "vozacDataGridViewTextBoxColumn";
            this.vozacDataGridViewTextBoxColumn.ReadOnly = true;
            this.vozacDataGridViewTextBoxColumn.Width = 93;
            // 
            // namaDataGridViewTextBoxColumn
            // 
            this.namaDataGridViewTextBoxColumn.DataPropertyName = "Nama";
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.namaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.namaDataGridViewTextBoxColumn.HeaderText = "Nama";
            this.namaDataGridViewTextBoxColumn.Name = "namaDataGridViewTextBoxColumn";
            this.namaDataGridViewTextBoxColumn.ReadOnly = true;
            this.namaDataGridViewTextBoxColumn.Width = 89;
            // 
            // ukupnaCijenaDataGridViewTextBoxColumn
            // 
            this.ukupnaCijenaDataGridViewTextBoxColumn.DataPropertyName = "Ukupna_Cijena";
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.ukupnaCijenaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.ukupnaCijenaDataGridViewTextBoxColumn.HeaderText = "Ukupna cijena";
            this.ukupnaCijenaDataGridViewTextBoxColumn.Name = "ukupnaCijenaDataGridViewTextBoxColumn";
            this.ukupnaCijenaDataGridViewTextBoxColumn.ReadOnly = true;
            this.ukupnaCijenaDataGridViewTextBoxColumn.Width = 168;
            // 
            // ukupnoKMDataGridViewTextBoxColumn
            // 
            this.ukupnoKMDataGridViewTextBoxColumn.DataPropertyName = "Ukupno_KM";
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.ukupnoKMDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.ukupnoKMDataGridViewTextBoxColumn.HeaderText = "Ukupno km";
            this.ukupnoKMDataGridViewTextBoxColumn.Name = "ukupnoKMDataGridViewTextBoxColumn";
            this.ukupnoKMDataGridViewTextBoxColumn.ReadOnly = true;
            this.ukupnoKMDataGridViewTextBoxColumn.Width = 140;
            // 
            // napomeneDataGridViewTextBoxColumn
            // 
            this.napomeneDataGridViewTextBoxColumn.DataPropertyName = "Napomene";
            this.napomeneDataGridViewTextBoxColumn.HeaderText = "Napomene";
            this.napomeneDataGridViewTextBoxColumn.Name = "napomeneDataGridViewTextBoxColumn";
            this.napomeneDataGridViewTextBoxColumn.ReadOnly = true;
            this.napomeneDataGridViewTextBoxColumn.Width = 138;
            // 
            // FormFirma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1208, 524);
            this.Controls.Add(this.dataGridView2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FormFirma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pretraživanje Po Firmama";
            this.Load += new System.EventHandler(this.FormFirma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataBaseDataSet dataBaseDataSet;
        private System.Windows.Forms.BindingSource sveBindingSource;
        private DataBaseDataSetTableAdapters.sveTableAdapter sveTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firmaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pocetakDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zavrsetakDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gorivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cestarinaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trajektDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vozacDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ukupnaCijenaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ukupnoKMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn napomeneDataGridViewTextBoxColumn;
    }
}