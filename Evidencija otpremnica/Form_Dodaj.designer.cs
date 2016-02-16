namespace Evidencija_otpremnica
{
    partial class Form_Dodaj
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Cijena = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_izlaz = new System.Windows.Forms.Button();
            this.button_DodajOtpremnicu = new System.Windows.Forms.Button();
            this.textBox_Tezina = new System.Windows.Forms.TextBox();
            this.button_UcitajCijenu = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_PostanskiBroj = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Poštanski broj";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Težina ";
            // 
            // textBox_Cijena
            // 
            this.textBox_Cijena.Enabled = false;
            this.textBox_Cijena.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold);
            this.textBox_Cijena.Location = new System.Drawing.Point(619, 37);
            this.textBox_Cijena.Name = "textBox_Cijena";
            this.textBox_Cijena.Size = new System.Drawing.Size(148, 33);
            this.textBox_Cijena.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(642, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cijena";
            // 
            // button_izlaz
            // 
            this.button_izlaz.AutoSize = true;
            this.button_izlaz.BackColor = System.Drawing.Color.Red;
            this.button_izlaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_izlaz.ForeColor = System.Drawing.Color.White;
            this.button_izlaz.Location = new System.Drawing.Point(12, 94);
            this.button_izlaz.Name = "button_izlaz";
            this.button_izlaz.Size = new System.Drawing.Size(118, 42);
            this.button_izlaz.TabIndex = 4;
            this.button_izlaz.Text = "Gotovo";
            this.button_izlaz.UseVisualStyleBackColor = false;
            this.button_izlaz.Click += new System.EventHandler(this.button_izlaz_Click);
            // 
            // button_DodajOtpremnicu
            // 
            this.button_DodajOtpremnicu.AutoSize = true;
            this.button_DodajOtpremnicu.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DodajOtpremnicu.Location = new System.Drawing.Point(503, 97);
            this.button_DodajOtpremnicu.Name = "button_DodajOtpremnicu";
            this.button_DodajOtpremnicu.Size = new System.Drawing.Size(110, 39);
            this.button_DodajOtpremnicu.TabIndex = 3;
            this.button_DodajOtpremnicu.Text = "Spremi";
            this.button_DodajOtpremnicu.UseVisualStyleBackColor = true;
            this.button_DodajOtpremnicu.Click += new System.EventHandler(this.button_DodajOtpremnicu_Click);
            // 
            // textBox_Tezina
            // 
            this.textBox_Tezina.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold);
            this.textBox_Tezina.Location = new System.Drawing.Point(202, 37);
            this.textBox_Tezina.Name = "textBox_Tezina";
            this.textBox_Tezina.Size = new System.Drawing.Size(148, 33);
            this.textBox_Tezina.TabIndex = 1;
            this.textBox_Tezina.TextChanged += new System.EventHandler(this.textBox_Tezina_TextChanged);
            // 
            // button_UcitajCijenu
            // 
            this.button_UcitajCijenu.AutoSize = true;
            this.button_UcitajCijenu.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_UcitajCijenu.Location = new System.Drawing.Point(202, 98);
            this.button_UcitajCijenu.Name = "button_UcitajCijenu";
            this.button_UcitajCijenu.Size = new System.Drawing.Size(170, 39);
            this.button_UcitajCijenu.TabIndex = 2;
            this.button_UcitajCijenu.Text = "Učitaj cijenu";
            this.button_UcitajCijenu.UseVisualStyleBackColor = true;
            this.button_UcitajCijenu.Click += new System.EventHandler(this.button_UcitajCijenu_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(130, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(433, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "OBAVEZNO KORISTITI DECIMALNU ZAREZ, NE TOČKU!!";
            // 
            // textBox_PostanskiBroj
            // 
            this.textBox_PostanskiBroj.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold);
            this.textBox_PostanskiBroj.Location = new System.Drawing.Point(17, 37);
            this.textBox_PostanskiBroj.Name = "textBox_PostanskiBroj";
            this.textBox_PostanskiBroj.Size = new System.Drawing.Size(148, 33);
            this.textBox_PostanskiBroj.TabIndex = 0;
            this.textBox_PostanskiBroj.TextChanged += new System.EventHandler(this.textBox_PostanskiBroj_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker1.Location = new System.Drawing.Point(356, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(257, 38);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // Form_Dodaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(799, 144);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox_PostanskiBroj);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_UcitajCijenu);
            this.Controls.Add(this.textBox_Tezina);
            this.Controls.Add(this.button_izlaz);
            this.Controls.Add(this.button_DodajOtpremnicu);
            this.Controls.Add(this.textBox_Cijena);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form_Dodaj";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodaj otpremnicu";
            this.Load += new System.EventHandler(this.Form_Dodaj_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Cijena;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_izlaz;
        private System.Windows.Forms.Button button_DodajOtpremnicu;
        private System.Windows.Forms.TextBox textBox_Tezina;
        private System.Windows.Forms.Button button_UcitajCijenu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_PostanskiBroj;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}