namespace Ponuda
{
    partial class FormIzmjena
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIzmjena));
            this.dataBaseDataSet = new Ponuda.DataBaseDataSet();
            this.buttonOdaberi = new System.Windows.Forms.Button();
            this.sveTableAdapter = new Ponuda.DataBaseDataSetTableAdapters.sveTableAdapter();
            this.textBoxUkupnoKm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Povratak = new System.Windows.Forms.Button();
            this.SpremanjeUBazu = new System.Windows.Forms.Button();
            this.textBoxNama = new System.Windows.Forms.TextBox();
            this.textBoxVozac = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTrajekt = new System.Windows.Forms.TextBox();
            this.textBoxCestarina = new System.Windows.Forms.TextBox();
            this.textBoxCijenaGoriva = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRelacijaDo = new System.Windows.Forms.TextBox();
            this.textBoxRelacijaOd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFirma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPovratak = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxUkupnaCijena = new System.Windows.Forms.TextBox();
            this.textBoxEur = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonracunaj = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonUpute = new System.Windows.Forms.Button();
            this.textBoxNapomene = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
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
            this.label14 = new System.Windows.Forms.Label();
            this.labelKlik = new System.Windows.Forms.Label();
            this.labelValuta = new System.Windows.Forms.Label();
            this.sveBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Datum_Unosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sveBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataBaseDataSet
            // 
            this.dataBaseDataSet.DataSetName = "DataBaseDataSet";
            this.dataBaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonOdaberi
            // 
            this.buttonOdaberi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOdaberi.Location = new System.Drawing.Point(12, 518);
            this.buttonOdaberi.Name = "buttonOdaberi";
            this.buttonOdaberi.Size = new System.Drawing.Size(141, 42);
            this.buttonOdaberi.TabIndex = 4;
            this.buttonOdaberi.Text = "Izmjeni";
            this.buttonOdaberi.UseVisualStyleBackColor = true;
            this.buttonOdaberi.Click += new System.EventHandler(this.buttonOdaberi_Click);
            // 
            // sveTableAdapter
            // 
            this.sveTableAdapter.ClearBeforeFill = true;
            // 
            // textBoxUkupnoKm
            // 
            this.textBoxUkupnoKm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxUkupnoKm.Location = new System.Drawing.Point(17, 176);
            this.textBoxUkupnoKm.Name = "textBoxUkupnoKm";
            this.textBoxUkupnoKm.Size = new System.Drawing.Size(237, 31);
            this.textBoxUkupnoKm.TabIndex = 4;
            this.textBoxUkupnoKm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxUkupnoKm.TextChanged += new System.EventHandler(this.textBoxUkupnoKm_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(64, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 29);
            this.label10.TabIndex = 48;
            this.label10.Text = "Kilometara";
            // 
            // Povratak
            // 
            this.Povratak.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Povratak.Location = new System.Drawing.Point(916, 377);
            this.Povratak.Name = "Povratak";
            this.Povratak.Size = new System.Drawing.Size(165, 69);
            this.Povratak.TabIndex = 42;
            this.Povratak.Text = "Povratak";
            this.Povratak.UseVisualStyleBackColor = true;
            this.Povratak.Click += new System.EventHandler(this.Povratak_Click);
            // 
            // SpremanjeUBazu
            // 
            this.SpremanjeUBazu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SpremanjeUBazu.Location = new System.Drawing.Point(12, 377);
            this.SpremanjeUBazu.Name = "SpremanjeUBazu";
            this.SpremanjeUBazu.Size = new System.Drawing.Size(165, 69);
            this.SpremanjeUBazu.TabIndex = 41;
            this.SpremanjeUBazu.Text = "Spremi ponudu";
            this.SpremanjeUBazu.UseVisualStyleBackColor = true;
            this.SpremanjeUBazu.Click += new System.EventHandler(this.SpremanjeUBazu_Click);
            // 
            // textBoxNama
            // 
            this.textBoxNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNama.Location = new System.Drawing.Point(17, 266);
            this.textBoxNama.Name = "textBoxNama";
            this.textBoxNama.Size = new System.Drawing.Size(237, 31);
            this.textBoxNama.TabIndex = 7;
            this.textBoxNama.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNama.TextChanged += new System.EventHandler(this.textBoxNama_TextChanged);
            // 
            // textBoxVozac
            // 
            this.textBoxVozac.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxVozac.Location = new System.Drawing.Point(571, 176);
            this.textBoxVozac.Name = "textBoxVozac";
            this.textBoxVozac.Size = new System.Drawing.Size(237, 31);
            this.textBoxVozac.TabIndex = 6;
            this.textBoxVozac.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxVozac.TextChanged += new System.EventHandler(this.textBoxVozac_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(74, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 29);
            this.label8.TabIndex = 46;
            this.label8.Text = "Nama";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(618, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 29);
            this.label7.TabIndex = 45;
            this.label7.Text = "Vozač";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(618, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 29);
            this.label6.TabIndex = 44;
            this.label6.Text = "Trajekt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(318, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 29);
            this.label5.TabIndex = 43;
            this.label5.Text = "Cestarina";
            // 
            // textBoxTrajekt
            // 
            this.textBoxTrajekt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxTrajekt.Location = new System.Drawing.Point(571, 266);
            this.textBoxTrajekt.Name = "textBoxTrajekt";
            this.textBoxTrajekt.Size = new System.Drawing.Size(237, 31);
            this.textBoxTrajekt.TabIndex = 9;
            this.textBoxTrajekt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTrajekt.TextChanged += new System.EventHandler(this.textBoxTrajekt_TextChanged);
            // 
            // textBoxCestarina
            // 
            this.textBoxCestarina.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxCestarina.Location = new System.Drawing.Point(285, 266);
            this.textBoxCestarina.Name = "textBoxCestarina";
            this.textBoxCestarina.Size = new System.Drawing.Size(237, 31);
            this.textBoxCestarina.TabIndex = 8;
            this.textBoxCestarina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCestarina.TextChanged += new System.EventHandler(this.textBoxCestarina_TextChanged);
            // 
            // textBoxCijenaGoriva
            // 
            this.textBoxCijenaGoriva.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxCijenaGoriva.Location = new System.Drawing.Point(309, 176);
            this.textBoxCijenaGoriva.Name = "textBoxCijenaGoriva";
            this.textBoxCijenaGoriva.Size = new System.Drawing.Size(213, 31);
            this.textBoxCijenaGoriva.TabIndex = 5;
            this.textBoxCijenaGoriva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCijenaGoriva.TextChanged += new System.EventHandler(this.textBoxCijenaGoriva_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(309, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 29);
            this.label4.TabIndex = 40;
            this.label4.Text = "Cijena goriva";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(566, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 29);
            this.label3.TabIndex = 34;
            this.label3.Text = "-";
            // 
            // textBoxRelacijaDo
            // 
            this.textBoxRelacijaDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxRelacijaDo.Location = new System.Drawing.Point(592, 42);
            this.textBoxRelacijaDo.Name = "textBoxRelacijaDo";
            this.textBoxRelacijaDo.Size = new System.Drawing.Size(237, 31);
            this.textBoxRelacijaDo.TabIndex = 30;
            this.textBoxRelacijaDo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxRelacijaOd
            // 
            this.textBoxRelacijaOd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxRelacijaOd.Location = new System.Drawing.Point(323, 42);
            this.textBoxRelacijaOd.Name = "textBoxRelacijaOd";
            this.textBoxRelacijaOd.Size = new System.Drawing.Size(237, 31);
            this.textBoxRelacijaOd.TabIndex = 29;
            this.textBoxRelacijaOd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(512, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 29);
            this.label2.TabIndex = 30;
            this.label2.Text = "Relacija";
            // 
            // textBoxFirma
            // 
            this.textBoxFirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxFirma.Location = new System.Drawing.Point(12, 42);
            this.textBoxFirma.Name = "textBoxFirma";
            this.textBoxFirma.Size = new System.Drawing.Size(237, 31);
            this.textBoxFirma.TabIndex = 28;
            this.textBoxFirma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 29);
            this.label1.TabIndex = 27;
            this.label1.Text = "Firma";
            // 
            // buttonPovratak
            // 
            this.buttonPovratak.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPovratak.Location = new System.Drawing.Point(1072, 518);
            this.buttonPovratak.Name = "buttonPovratak";
            this.buttonPovratak.Size = new System.Drawing.Size(141, 42);
            this.buttonPovratak.TabIndex = 49;
            this.buttonPovratak.Text = "Povratak";
            this.buttonPovratak.UseVisualStyleBackColor = true;
            this.buttonPovratak.Click += new System.EventHandler(this.buttonPovratak_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(205, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 29);
            this.label9.TabIndex = 47;
            this.label9.Text = "Ukupna cijena";
            // 
            // textBoxUkupnaCijena
            // 
            this.textBoxUkupnaCijena.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxUkupnaCijena.Location = new System.Drawing.Point(205, 360);
            this.textBoxUkupnaCijena.Name = "textBoxUkupnaCijena";
            this.textBoxUkupnaCijena.Size = new System.Drawing.Size(237, 31);
            this.textBoxUkupnaCijena.TabIndex = 36;
            this.textBoxUkupnaCijena.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxUkupnaCijena.TextChanged += new System.EventHandler(this.textBoxUkupnaCijena_TextChanged);
            // 
            // textBoxEur
            // 
            this.textBoxEur.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxEur.Location = new System.Drawing.Point(859, 265);
            this.textBoxEur.Name = "textBoxEur";
            this.textBoxEur.Size = new System.Drawing.Size(130, 31);
            this.textBoxEur.TabIndex = 10;
            this.textBoxEur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxEur.TextChanged += new System.EventHandler(this.textBoxEur_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(854, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 29);
            this.label11.TabIndex = 50;
            this.label11.Text = "Valuta eura";
            // 
            // buttonracunaj
            // 
            this.buttonracunaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonracunaj.Location = new System.Drawing.Point(995, 260);
            this.buttonracunaj.Name = "buttonracunaj";
            this.buttonracunaj.Size = new System.Drawing.Size(82, 37);
            this.buttonracunaj.TabIndex = 52;
            this.buttonracunaj.Text = "Izračunaj!";
            this.buttonracunaj.UseVisualStyleBackColor = true;
            this.buttonracunaj.Click += new System.EventHandler(this.button1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(137, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(624, 33);
            this.label12.TabIndex = 53;
            this.label12.Text = "Koristi zarez,a ne točku za decimalne brojeve!!";
            // 
            // buttonUpute
            // 
            this.buttonUpute.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUpute.Location = new System.Drawing.Point(863, 99);
            this.buttonUpute.Name = "buttonUpute";
            this.buttonUpute.Size = new System.Drawing.Size(126, 45);
            this.buttonUpute.TabIndex = 54;
            this.buttonUpute.Text = "Upute";
            this.buttonUpute.UseVisualStyleBackColor = true;
            this.buttonUpute.Click += new System.EventHandler(this.buttonUpute_Click);
            // 
            // textBoxNapomene
            // 
            this.textBoxNapomene.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNapomene.Location = new System.Drawing.Point(550, 360);
            this.textBoxNapomene.Multiline = true;
            this.textBoxNapomene.Name = "textBoxNapomene";
            this.textBoxNapomene.Size = new System.Drawing.Size(279, 86);
            this.textBoxNapomene.TabIndex = 11;
            this.textBoxNapomene.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(550, 328);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(141, 29);
            this.label13.TabIndex = 56;
            this.label13.Text = "Napomene";
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
            this.napomeneDataGridViewTextBoxColumn,
            this.Datum_Unosa});
            this.dataGridView2.DataSource = this.sveBindingSource1;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView2.Location = new System.Drawing.Point(9, 10);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(1204, 500);
            this.dataGridView2.TabIndex = 100;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick_1);
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(229, 527);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(600, 25);
            this.label14.TabIndex = 58;
            this.label14.Text = "Klikni lijevo od ponude koju želite promjeniti,na strelicu!";
            // 
            // labelKlik
            // 
            this.labelKlik.AutoSize = true;
            this.labelKlik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelKlik.ForeColor = System.Drawing.Color.Red;
            this.labelKlik.Location = new System.Drawing.Point(1013, 299);
            this.labelKlik.Name = "labelKlik";
            this.labelKlik.Size = new System.Drawing.Size(51, 20);
            this.labelKlik.TabIndex = 62;
            this.labelKlik.Text = "Klikni";
            // 
            // labelValuta
            // 
            this.labelValuta.AutoSize = true;
            this.labelValuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelValuta.ForeColor = System.Drawing.Color.Red;
            this.labelValuta.Location = new System.Drawing.Point(871, 299);
            this.labelValuta.Name = "labelValuta";
            this.labelValuta.Size = new System.Drawing.Size(108, 20);
            this.labelValuta.TabIndex = 61;
            this.labelValuta.Text = "Unesi valutu";
            // 
            // sveBindingSource1
            // 
            this.sveBindingSource1.DataMember = "sve";
            this.sveBindingSource1.DataSource = this.dataBaseDataSet;
            // 
            // Datum_Unosa
            // 
            this.Datum_Unosa.DataPropertyName = "Datum_Unosa";
            this.Datum_Unosa.HeaderText = "Datum unosa";
            this.Datum_Unosa.Name = "Datum_Unosa";
            this.Datum_Unosa.ReadOnly = true;
            this.Datum_Unosa.Width = 157;
            // 
            // FormIzmjena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1225, 562);
            this.ControlBox = false;
            this.Controls.Add(this.labelKlik);
            this.Controls.Add(this.labelValuta);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.textBoxNapomene);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.buttonUpute);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.buttonracunaj);
            this.Controls.Add(this.textBoxEur);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.buttonPovratak);
            this.Controls.Add(this.textBoxUkupnoKm);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Povratak);
            this.Controls.Add(this.SpremanjeUBazu);
            this.Controls.Add(this.textBoxNama);
            this.Controls.Add(this.textBoxVozac);
            this.Controls.Add(this.textBoxUkupnaCijena);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxTrajekt);
            this.Controls.Add(this.textBoxCestarina);
            this.Controls.Add(this.textBoxCijenaGoriva);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxRelacijaDo);
            this.Controls.Add(this.textBoxRelacijaOd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFirma);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOdaberi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FormIzmjena";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Izmjena Ponude";
            this.Load += new System.EventHandler(this.FormIzmjena_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sveBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOdaberi;
        private DataBaseDataSet dataBaseDataSet;
        private DataBaseDataSetTableAdapters.sveTableAdapter sveTableAdapter;
        private System.Windows.Forms.TextBox textBoxUkupnoKm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Povratak;
        private System.Windows.Forms.Button SpremanjeUBazu;
        private System.Windows.Forms.TextBox textBoxNama;
        private System.Windows.Forms.TextBox textBoxVozac;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTrajekt;
        private System.Windows.Forms.TextBox textBoxCestarina;
        private System.Windows.Forms.TextBox textBoxCijenaGoriva;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRelacijaDo;
        private System.Windows.Forms.TextBox textBoxRelacijaOd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFirma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPovratak;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxUkupnaCijena;
        private System.Windows.Forms.TextBox textBoxEur;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonracunaj;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonUpute;
        private System.Windows.Forms.TextBox textBoxNapomene;
        private System.Windows.Forms.Label label13;
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
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelKlik;
        private System.Windows.Forms.Label labelValuta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum_Unosa;
        private System.Windows.Forms.BindingSource sveBindingSource1;
    }
}