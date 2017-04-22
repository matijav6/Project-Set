namespace Kombiji
{
    partial class FormEvidencijaPretrazivanje
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDatum = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kombiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trenutnoKmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sljedeciKmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.napomenaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bazaKombiEvidencijaDataSet = new Kombiji.BazaKombiEvidencijaDataSet();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxKriterij = new System.Windows.Forms.TextBox();
            this.comboBoxOdabir = new System.Windows.Forms.ComboBox();
            this.buttonIzlaz = new System.Windows.Forms.Button();
            this.table1TableAdapter = new Kombiji.BazaKombiEvidencijaDataSetTableAdapters.table1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bazaKombiEvidencijaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(743, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 42);
            this.label1.TabIndex = 31;
            this.label1.Text = "Odabir datuma:";
            // 
            // comboBoxDatum
            // 
            this.comboBoxDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.comboBoxDatum.FormattingEnabled = true;
            this.comboBoxDatum.Location = new System.Drawing.Point(741, 64);
            this.comboBoxDatum.MaxDropDownItems = 15;
            this.comboBoxDatum.Name = "comboBoxDatum";
            this.comboBoxDatum.Size = new System.Drawing.Size(262, 45);
            this.comboBoxDatum.Sorted = true;
            this.comboBoxDatum.TabIndex = 32;
            this.comboBoxDatum.SelectedIndexChanged += new System.EventHandler(this.comboBoxDatum_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.kombiDataGridViewTextBoxColumn,
            this.trenutnoKmDataGridViewTextBoxColumn,
            this.sljedeciKmDataGridViewTextBoxColumn,
            this.napomenaDataGridViewTextBoxColumn,
            this.datumDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.table1BindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(5, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1246, 425);
            this.dataGridView1.TabIndex = 30;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            this.iDDataGridViewTextBoxColumn.Width = 57;
            // 
            // kombiDataGridViewTextBoxColumn
            // 
            this.kombiDataGridViewTextBoxColumn.DataPropertyName = "Kombi";
            this.kombiDataGridViewTextBoxColumn.HeaderText = "Kombi";
            this.kombiDataGridViewTextBoxColumn.Name = "kombiDataGridViewTextBoxColumn";
            // 
            // trenutnoKmDataGridViewTextBoxColumn
            // 
            this.trenutnoKmDataGridViewTextBoxColumn.DataPropertyName = "TrenutnoKm";
            this.trenutnoKmDataGridViewTextBoxColumn.HeaderText = "TrenutnoKm";
            this.trenutnoKmDataGridViewTextBoxColumn.Name = "trenutnoKmDataGridViewTextBoxColumn";
            this.trenutnoKmDataGridViewTextBoxColumn.Width = 162;
            // 
            // sljedeciKmDataGridViewTextBoxColumn
            // 
            this.sljedeciKmDataGridViewTextBoxColumn.DataPropertyName = "SljedeciKm";
            this.sljedeciKmDataGridViewTextBoxColumn.HeaderText = "SljedeciKm";
            this.sljedeciKmDataGridViewTextBoxColumn.Name = "sljedeciKmDataGridViewTextBoxColumn";
            this.sljedeciKmDataGridViewTextBoxColumn.Width = 152;
            // 
            // napomenaDataGridViewTextBoxColumn
            // 
            this.napomenaDataGridViewTextBoxColumn.DataPropertyName = "Napomena";
            this.napomenaDataGridViewTextBoxColumn.HeaderText = "Napomena";
            this.napomenaDataGridViewTextBoxColumn.Name = "napomenaDataGridViewTextBoxColumn";
            this.napomenaDataGridViewTextBoxColumn.Width = 147;
            // 
            // datumDataGridViewTextBoxColumn
            // 
            this.datumDataGridViewTextBoxColumn.DataPropertyName = "Datum";
            this.datumDataGridViewTextBoxColumn.HeaderText = "Datum";
            this.datumDataGridViewTextBoxColumn.Name = "datumDataGridViewTextBoxColumn";
            this.datumDataGridViewTextBoxColumn.Width = 102;
            // 
            // table1BindingSource
            // 
            this.table1BindingSource.DataMember = "table1";
            this.table1BindingSource.DataSource = this.bazaKombiEvidencijaDataSet;
            // 
            // bazaKombiEvidencijaDataSet
            // 
            this.bazaKombiEvidencijaDataSet.DataSetName = "BazaKombiEvidencijaDataSet";
            this.bazaKombiEvidencijaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(465, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 42);
            this.label3.TabIndex = 27;
            this.label3.Text = "Odabir vozila:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(10, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(432, 42);
            this.label4.TabIndex = 26;
            this.label4.Text = "Kriterij za pretraživanje:";
            // 
            // textBoxKriterij
            // 
            this.textBoxKriterij.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxKriterij.Location = new System.Drawing.Point(17, 49);
            this.textBoxKriterij.Multiline = true;
            this.textBoxKriterij.Name = "textBoxKriterij";
            this.textBoxKriterij.Size = new System.Drawing.Size(402, 79);
            this.textBoxKriterij.TabIndex = 25;
            this.textBoxKriterij.TextChanged += new System.EventHandler(this.textBoxKriterij_TextChanged);
            // 
            // comboBoxOdabir
            // 
            this.comboBoxOdabir.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.comboBoxOdabir.FormattingEnabled = true;
            this.comboBoxOdabir.Location = new System.Drawing.Point(463, 64);
            this.comboBoxOdabir.MaxDropDownItems = 15;
            this.comboBoxOdabir.Name = "comboBoxOdabir";
            this.comboBoxOdabir.Size = new System.Drawing.Size(262, 45);
            this.comboBoxOdabir.Sorted = true;
            this.comboBoxOdabir.TabIndex = 28;
            this.comboBoxOdabir.SelectedIndexChanged += new System.EventHandler(this.comboBoxOdabir_SelectedIndexChanged);
            // 
            // buttonIzlaz
            // 
            this.buttonIzlaz.AutoSize = true;
            this.buttonIzlaz.BackColor = System.Drawing.Color.Red;
            this.buttonIzlaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.buttonIzlaz.ForeColor = System.Drawing.Color.White;
            this.buttonIzlaz.Location = new System.Drawing.Point(1100, 4);
            this.buttonIzlaz.Name = "buttonIzlaz";
            this.buttonIzlaz.Size = new System.Drawing.Size(158, 52);
            this.buttonIzlaz.TabIndex = 29;
            this.buttonIzlaz.Text = "IZLAZ";
            this.buttonIzlaz.UseVisualStyleBackColor = false;
            this.buttonIzlaz.Click += new System.EventHandler(this.buttonIzlaz_Click);
            // 
            // table1TableAdapter
            // 
            this.table1TableAdapter.ClearBeforeFill = true;
            // 
            // FormEvidencijaPretrazivanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 571);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDatum);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxKriterij);
            this.Controls.Add(this.comboBoxOdabir);
            this.Controls.Add(this.buttonIzlaz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormEvidencijaPretrazivanje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evidencija Pretrazivanje";
            this.Load += new System.EventHandler(this.FormEvidencijaPretrazivanje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bazaKombiEvidencijaDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDatum;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxKriterij;
        private System.Windows.Forms.ComboBox comboBoxOdabir;
        private System.Windows.Forms.Button buttonIzlaz;
        private BazaKombiEvidencijaDataSet bazaKombiEvidencijaDataSet;
        private System.Windows.Forms.BindingSource table1BindingSource;
        private BazaKombiEvidencijaDataSetTableAdapters.table1TableAdapter table1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kombiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trenutnoKmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sljedeciKmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn napomenaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumDataGridViewTextBoxColumn;
    }
}