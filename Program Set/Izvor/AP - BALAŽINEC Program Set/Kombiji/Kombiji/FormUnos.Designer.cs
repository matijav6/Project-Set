namespace Kombiji
{
    partial class FormUnos
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
            this.textBoxDatumDo = new System.Windows.Forms.TextBox();
            this.textBoxDatumOd = new System.Windows.Forms.TextBox();
            this.textBoxKilometri = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSpremi = new System.Windows.Forms.Button();
            this.buttonIzlaz = new System.Windows.Forms.Button();
            this.monthCalendarOd = new System.Windows.Forms.MonthCalendar();
            this.monthCalendarDo = new System.Windows.Forms.MonthCalendar();
            this.textBoxCestarina = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxNapomena = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bazaKombiDataSet1 = new Kombiji.BazaKombiDataSet();
            this.textBoxCijenaTure = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxNama = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxVozacu = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxGorivo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.table1TableAdapter1 = new Kombiji.BazaKombiDataSetTableAdapters.Table1TableAdapter();
            this.comboBoxVozač = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bazaKombiDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxDatumDo
            // 
            this.textBoxDatumDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxDatumDo.Location = new System.Drawing.Point(533, 424);
            this.textBoxDatumDo.Multiline = true;
            this.textBoxDatumDo.Name = "textBoxDatumDo";
            this.textBoxDatumDo.ReadOnly = true;
            this.textBoxDatumDo.Size = new System.Drawing.Size(183, 57);
            this.textBoxDatumDo.TabIndex = 21;
            this.textBoxDatumDo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxDatumOd
            // 
            this.textBoxDatumOd.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxDatumOd.Location = new System.Drawing.Point(297, 424);
            this.textBoxDatumOd.Multiline = true;
            this.textBoxDatumOd.Name = "textBoxDatumOd";
            this.textBoxDatumOd.ReadOnly = true;
            this.textBoxDatumOd.Size = new System.Drawing.Size(183, 57);
            this.textBoxDatumOd.TabIndex = 20;
            this.textBoxDatumOd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxKilometri
            // 
            this.textBoxKilometri.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxKilometri.Location = new System.Drawing.Point(237, 116);
            this.textBoxKilometri.Multiline = true;
            this.textBoxKilometri.Name = "textBoxKilometri";
            this.textBoxKilometri.Size = new System.Drawing.Size(314, 57);
            this.textBoxKilometri.TabIndex = 3;
            this.textBoxKilometri.TextChanged += new System.EventHandler(this.textBoxKilometri_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(486, 436);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "Do";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(249, 436);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Od";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(12, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 42);
            this.label4.TabIndex = 14;
            this.label4.Text = "Datum ture:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(9, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 42);
            this.label3.TabIndex = 13;
            this.label3.Text = "Kilometri:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(9, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 42);
            this.label2.TabIndex = 12;
            this.label2.Text = "Kombi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 42);
            this.label1.TabIndex = 11;
            this.label1.Text = "Vozač:";
            // 
            // buttonSpremi
            // 
            this.buttonSpremi.AutoSize = true;
            this.buttonSpremi.Font = new System.Drawing.Font("Modern No. 20", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSpremi.Location = new System.Drawing.Point(742, 2);
            this.buttonSpremi.Name = "buttonSpremi";
            this.buttonSpremi.Size = new System.Drawing.Size(245, 93);
            this.buttonSpremi.TabIndex = 9;
            this.buttonSpremi.Text = "Spremi!";
            this.buttonSpremi.UseVisualStyleBackColor = true;
            this.buttonSpremi.Click += new System.EventHandler(this.buttonSpremi_Click);
            // 
            // buttonIzlaz
            // 
            this.buttonIzlaz.AutoSize = true;
            this.buttonIzlaz.BackColor = System.Drawing.Color.Red;
            this.buttonIzlaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonIzlaz.ForeColor = System.Drawing.Color.White;
            this.buttonIzlaz.Location = new System.Drawing.Point(744, 552);
            this.buttonIzlaz.Name = "buttonIzlaz";
            this.buttonIzlaz.Size = new System.Drawing.Size(243, 103);
            this.buttonIzlaz.TabIndex = 23;
            this.buttonIzlaz.Text = "IZLAZ";
            this.buttonIzlaz.UseVisualStyleBackColor = false;
            this.buttonIzlaz.Click += new System.EventHandler(this.buttonIzlaz_Click);
            // 
            // monthCalendarOd
            // 
            this.monthCalendarOd.Location = new System.Drawing.Point(281, 493);
            this.monthCalendarOd.Name = "monthCalendarOd";
            this.monthCalendarOd.TabIndex = 24;
            this.monthCalendarOd.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarOd_DateChanged);
            // 
            // monthCalendarDo
            // 
            this.monthCalendarDo.Location = new System.Drawing.Point(533, 493);
            this.monthCalendarDo.Name = "monthCalendarDo";
            this.monthCalendarDo.TabIndex = 25;
            this.monthCalendarDo.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarDo_DateChanged);
            // 
            // textBoxCestarina
            // 
            this.textBoxCestarina.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxCestarina.Location = new System.Drawing.Point(237, 179);
            this.textBoxCestarina.Multiline = true;
            this.textBoxCestarina.Name = "textBoxCestarina";
            this.textBoxCestarina.Size = new System.Drawing.Size(314, 57);
            this.textBoxCestarina.TabIndex = 4;
            this.textBoxCestarina.TextChanged += new System.EventHandler(this.textBoxCestarina_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(12, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(198, 42);
            this.label7.TabIndex = 26;
            this.label7.Text = "Cestarina:";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(237, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(262, 45);
            this.comboBox1.TabIndex = 1;
            // 
            // textBoxNapomena
            // 
            this.textBoxNapomena.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNapomena.Location = new System.Drawing.Point(237, 305);
            this.textBoxNapomena.Multiline = true;
            this.textBoxNapomena.Name = "textBoxNapomena";
            this.textBoxNapomena.Size = new System.Drawing.Size(314, 113);
            this.textBoxNapomena.TabIndex = 8;
            this.textBoxNapomena.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(9, 305);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(220, 42);
            this.label8.TabIndex = 30;
            this.label8.Text = "Napomena:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13});
            this.dataGridView1.DataSource = this.table1BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(862, 368);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(100, 150);
            this.dataGridView1.TabIndex = 31;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Kombi";
            this.dataGridViewTextBoxColumn2.HeaderText = "Kombi";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Vozac";
            this.dataGridViewTextBoxColumn3.HeaderText = "Vozac";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Gorivo";
            this.dataGridViewTextBoxColumn4.HeaderText = "Gorivo";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Cestarina";
            this.dataGridViewTextBoxColumn5.HeaderText = "Cestarina";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Nama";
            this.dataGridViewTextBoxColumn6.HeaderText = "Nama";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Vozacu";
            this.dataGridViewTextBoxColumn7.HeaderText = "Vozacu";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Kilometri";
            this.dataGridViewTextBoxColumn8.HeaderText = "Kilometri";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "DatumOd";
            this.dataGridViewTextBoxColumn9.HeaderText = "DatumOd";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "DatumDo";
            this.dataGridViewTextBoxColumn10.HeaderText = "DatumDo";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "UkupnaCijena";
            this.dataGridViewTextBoxColumn11.HeaderText = "UkupnaCijena";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "BrojFakture";
            this.dataGridViewTextBoxColumn12.HeaderText = "BrojFakture";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Napomena";
            this.dataGridViewTextBoxColumn13.HeaderText = "Napomena";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // table1BindingSource
            // 
            this.table1BindingSource.DataMember = "Table1";
            this.table1BindingSource.DataSource = this.bazaKombiDataSet1;
            // 
            // bazaKombiDataSet1
            // 
            this.bazaKombiDataSet1.DataSetName = "BazaKombiDataSet";
            this.bazaKombiDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBoxCijenaTure
            // 
            this.textBoxCijenaTure.Enabled = false;
            this.textBoxCijenaTure.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxCijenaTure.Location = new System.Drawing.Point(237, 242);
            this.textBoxCijenaTure.Multiline = true;
            this.textBoxCijenaTure.Name = "textBoxCijenaTure";
            this.textBoxCijenaTure.Size = new System.Drawing.Size(314, 57);
            this.textBoxCijenaTure.TabIndex = 5;
            this.textBoxCijenaTure.TextChanged += new System.EventHandler(this.textBoxCijenaTure_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(12, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(220, 42);
            this.label9.TabIndex = 33;
            this.label9.Text = "Cijena ture:";
            // 
            // textBoxNama
            // 
            this.textBoxNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNama.Location = new System.Drawing.Point(557, 247);
            this.textBoxNama.Multiline = true;
            this.textBoxNama.Name = "textBoxNama";
            this.textBoxNama.Size = new System.Drawing.Size(247, 57);
            this.textBoxNama.TabIndex = 6;
            this.textBoxNama.TextChanged += new System.EventHandler(this.textBoxNama_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(557, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(218, 42);
            this.label10.TabIndex = 36;
            this.label10.Text = "Udio nama:";
            // 
            // textBoxVozacu
            // 
            this.textBoxVozacu.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxVozacu.Location = new System.Drawing.Point(557, 142);
            this.textBoxVozacu.Multiline = true;
            this.textBoxVozacu.Name = "textBoxVozacu";
            this.textBoxVozacu.Size = new System.Drawing.Size(247, 57);
            this.textBoxVozacu.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(557, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(247, 42);
            this.label11.TabIndex = 38;
            this.label11.Text = "Udio vozaču:";
            // 
            // textBoxGorivo
            // 
            this.textBoxGorivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxGorivo.Location = new System.Drawing.Point(557, 352);
            this.textBoxGorivo.Multiline = true;
            this.textBoxGorivo.Name = "textBoxGorivo";
            this.textBoxGorivo.Size = new System.Drawing.Size(247, 57);
            this.textBoxGorivo.TabIndex = 7;
            this.textBoxGorivo.TextChanged += new System.EventHandler(this.textBoxGorivo_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(557, 307);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(145, 42);
            this.label12.TabIndex = 40;
            this.label12.Text = "Gorivo:";
            // 
            // table1TableAdapter1
            // 
            this.table1TableAdapter1.ClearBeforeFill = true;
            // 
            // comboBoxVozač
            // 
            this.comboBoxVozač.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.comboBoxVozač.FormattingEnabled = true;
            this.comboBoxVozač.Items.AddRange(new object[] {
            "Saša Sršan",
            "Krunoslav Sukačić",
            "Marko Pajtak",
            "Hrvoje Petek",
            "Bruno Tkalec",
            "Nikola Hižak",
            "Aleksandar Pozder",
            "Željko Benković"});
            this.comboBoxVozač.Location = new System.Drawing.Point(237, 65);
            this.comboBoxVozač.Name = "comboBoxVozač";
            this.comboBoxVozač.Size = new System.Drawing.Size(314, 45);
            this.comboBoxVozač.TabIndex = 41;
            // 
            // FormUnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(987, 658);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxVozač);
            this.Controls.Add(this.textBoxGorivo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxVozacu);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxNama);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxCijenaTure);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxNapomena);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxCestarina);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.monthCalendarDo);
            this.Controls.Add(this.monthCalendarOd);
            this.Controls.Add(this.buttonIzlaz);
            this.Controls.Add(this.buttonSpremi);
            this.Controls.Add(this.textBoxDatumDo);
            this.Controls.Add(this.textBoxDatumOd);
            this.Controls.Add(this.textBoxKilometri);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormUnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormUnos";
            this.Load += new System.EventHandler(this.FormUnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bazaKombiDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDatumDo;
        private System.Windows.Forms.TextBox textBoxDatumOd;
        private System.Windows.Forms.TextBox textBoxKilometri;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSpremi;
        private System.Windows.Forms.Button buttonIzlaz;
        private System.Windows.Forms.MonthCalendar monthCalendarOd;
        private System.Windows.Forms.MonthCalendar monthCalendarDo;
        private System.Windows.Forms.TextBox textBoxCestarina;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxNapomena;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxCijenaTure;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxNama;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxVozacu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxGorivo;
        private System.Windows.Forms.Label label12;
        private BazaKombiDataSet bazaKombiDataSet;
        private BazaKombiDataSetTableAdapters.Table1TableAdapter table1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kombiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vozacDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gorivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cestarinaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vozacuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kilometriDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumOdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumDoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ukupnaCijenaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brojFaktureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn napomenaDataGridViewTextBoxColumn;
        private BazaKombiDataSet bazaKombiDataSet1;
        private System.Windows.Forms.BindingSource table1BindingSource;
        private BazaKombiDataSetTableAdapters.Table1TableAdapter table1TableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.ComboBox comboBoxVozač;
    }
}