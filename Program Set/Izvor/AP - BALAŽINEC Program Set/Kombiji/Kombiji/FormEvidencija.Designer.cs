namespace Kombiji
{
    partial class FormEvidencija
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
            this.comboBoxKombi = new System.Windows.Forms.ComboBox();
            this.textBoxKilometri = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSljedeciServis = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNapomena = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.textBoxDatum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonIzlaz = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonSpremi = new System.Windows.Forms.Button();
            this.bazaKombiEvidencijaDataSet = new Kombiji.BazaKombiEvidencijaDataSet();
            this.table1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.table1TableAdapter = new Kombiji.BazaKombiEvidencijaDataSetTableAdapters.table1TableAdapter();
            this.kombiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trenutnoKmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sljedeciKmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.napomenaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bazaKombiEvidencijaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxKombi
            // 
            this.comboBoxKombi.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.comboBoxKombi.FormattingEnabled = true;
            this.comboBoxKombi.Location = new System.Drawing.Point(237, 12);
            this.comboBoxKombi.Name = "comboBoxKombi";
            this.comboBoxKombi.Size = new System.Drawing.Size(314, 45);
            this.comboBoxKombi.TabIndex = 14;
            // 
            // textBoxKilometri
            // 
            this.textBoxKilometri.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxKilometri.Location = new System.Drawing.Point(237, 82);
            this.textBoxKilometri.Multiline = true;
            this.textBoxKilometri.Name = "textBoxKilometri";
            this.textBoxKilometri.Size = new System.Drawing.Size(314, 57);
            this.textBoxKilometri.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 68);
            this.label3.TabIndex = 17;
            this.label3.Text = "Trenutna\r\nkilometraža:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 34);
            this.label2.TabIndex = 16;
            this.label2.Text = "Kombi:";
            // 
            // textBoxSljedeciServis
            // 
            this.textBoxSljedeciServis.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxSljedeciServis.Location = new System.Drawing.Point(237, 180);
            this.textBoxSljedeciServis.Multiline = true;
            this.textBoxSljedeciServis.Name = "textBoxSljedeciServis";
            this.textBoxSljedeciServis.Size = new System.Drawing.Size(314, 57);
            this.textBoxSljedeciServis.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 68);
            this.label1.TabIndex = 19;
            this.label1.Text = "Sljedeći \r\nservis (km):";
            // 
            // textBoxNapomena
            // 
            this.textBoxNapomena.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNapomena.Location = new System.Drawing.Point(237, 267);
            this.textBoxNapomena.Multiline = true;
            this.textBoxNapomena.Name = "textBoxNapomena";
            this.textBoxNapomena.Size = new System.Drawing.Size(314, 113);
            this.textBoxNapomena.TabIndex = 31;
            this.textBoxNapomena.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 34);
            this.label8.TabIndex = 32;
            this.label8.Text = "Napomena:";
            // 
            // monthCalendar
            // 
            this.monthCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.monthCalendar.Location = new System.Drawing.Point(296, 460);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 35;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarOd_DateChanged);
            // 
            // textBoxDatum
            // 
            this.textBoxDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxDatum.Location = new System.Drawing.Point(254, 391);
            this.textBoxDatum.Multiline = true;
            this.textBoxDatum.Name = "textBoxDatum";
            this.textBoxDatum.ReadOnly = true;
            this.textBoxDatum.Size = new System.Drawing.Size(297, 57);
            this.textBoxDatum.TabIndex = 34;
            this.textBoxDatum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(239, 34);
            this.label4.TabIndex = 33;
            this.label4.Text = "Datum servisa:";
            // 
            // buttonIzlaz
            // 
            this.buttonIzlaz.AutoSize = true;
            this.buttonIzlaz.BackColor = System.Drawing.Color.Red;
            this.buttonIzlaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonIzlaz.ForeColor = System.Drawing.Color.White;
            this.buttonIzlaz.Location = new System.Drawing.Point(568, 541);
            this.buttonIzlaz.Name = "buttonIzlaz";
            this.buttonIzlaz.Size = new System.Drawing.Size(159, 75);
            this.buttonIzlaz.TabIndex = 36;
            this.buttonIzlaz.Text = "IZLAZ";
            this.buttonIzlaz.UseVisualStyleBackColor = false;
            this.buttonIzlaz.Click += new System.EventHandler(this.buttonIzlaz_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kombiDataGridViewTextBoxColumn,
            this.trenutnoKmDataGridViewTextBoxColumn,
            this.sljedeciKmDataGridViewTextBoxColumn,
            this.napomenaDataGridViewTextBoxColumn,
            this.datumDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.table1BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(617, 334);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(110, 152);
            this.dataGridView1.TabIndex = 37;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // buttonSpremi
            // 
            this.buttonSpremi.AutoSize = true;
            this.buttonSpremi.Font = new System.Drawing.Font("Consolas", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSpremi.Location = new System.Drawing.Point(557, 12);
            this.buttonSpremi.Name = "buttonSpremi";
            this.buttonSpremi.Size = new System.Drawing.Size(178, 68);
            this.buttonSpremi.TabIndex = 38;
            this.buttonSpremi.Text = "Spremi!";
            this.buttonSpremi.UseVisualStyleBackColor = true;
            this.buttonSpremi.Click += new System.EventHandler(this.buttonSpremi_Click);
            // 
            // bazaKombiEvidencijaDataSet
            // 
            this.bazaKombiEvidencijaDataSet.DataSetName = "BazaKombiEvidencijaDataSet";
            this.bazaKombiEvidencijaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // table1BindingSource
            // 
            this.table1BindingSource.DataMember = "table1";
            this.table1BindingSource.DataSource = this.bazaKombiEvidencijaDataSet;
            // 
            // table1TableAdapter
            // 
            this.table1TableAdapter.ClearBeforeFill = true;
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
            // 
            // sljedeciKmDataGridViewTextBoxColumn
            // 
            this.sljedeciKmDataGridViewTextBoxColumn.DataPropertyName = "SljedeciKm";
            this.sljedeciKmDataGridViewTextBoxColumn.HeaderText = "SljedeciKm";
            this.sljedeciKmDataGridViewTextBoxColumn.Name = "sljedeciKmDataGridViewTextBoxColumn";
            // 
            // napomenaDataGridViewTextBoxColumn
            // 
            this.napomenaDataGridViewTextBoxColumn.DataPropertyName = "Napomena";
            this.napomenaDataGridViewTextBoxColumn.HeaderText = "Napomena";
            this.napomenaDataGridViewTextBoxColumn.Name = "napomenaDataGridViewTextBoxColumn";
            // 
            // datumDataGridViewTextBoxColumn
            // 
            this.datumDataGridViewTextBoxColumn.DataPropertyName = "Datum";
            this.datumDataGridViewTextBoxColumn.HeaderText = "Datum";
            this.datumDataGridViewTextBoxColumn.Name = "datumDataGridViewTextBoxColumn";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // FormEvidencija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(739, 628);
            this.Controls.Add(this.buttonSpremi);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonIzlaz);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.textBoxDatum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNapomena);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxSljedeciServis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxKombi);
            this.Controls.Add(this.textBoxKilometri);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEvidencija";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evidencija kombija";
            this.Load += new System.EventHandler(this.FormEvidencija_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bazaKombiEvidencijaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxKombi;
        private System.Windows.Forms.TextBox textBoxKilometri;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSljedeciServis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNapomena;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.TextBox textBoxDatum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonIzlaz;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSpremi;
        private BazaKombiEvidencijaDataSet bazaKombiEvidencijaDataSet;
        private System.Windows.Forms.BindingSource table1BindingSource;
        private BazaKombiEvidencijaDataSetTableAdapters.table1TableAdapter table1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn kombiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trenutnoKmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sljedeciKmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn napomenaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    }
}