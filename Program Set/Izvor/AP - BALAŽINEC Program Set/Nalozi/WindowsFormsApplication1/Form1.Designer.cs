namespace WindowsFormApplication1
{
    partial class Nalozi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nalozi));
            this.otvori = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.umetni = new System.Windows.Forms.Button();
            this.nalog_za_utovar_broj = new System.Windows.Forms.Label();
            this.adresa_utovara = new System.Windows.Forms.Label();
            this.datum_utovara = new System.Windows.Forms.Label();
            this.izvozno_carinjenje = new System.Windows.Forms.Label();
            this.vrsta_robe = new System.Windows.Forms.Label();
            this.kolicina = new System.Windows.Forms.Label();
            this.uvozno_carinjenje = new System.Windows.Forms.Label();
            this.datum_istovara = new System.Windows.Forms.Label();
            this.cijena_prijevoza = new System.Windows.Forms.Label();
            this.nalog_br = new System.Windows.Forms.TextBox();
            this.adresa_1 = new System.Windows.Forms.TextBox();
            this.adresa_2 = new System.Windows.Forms.TextBox();
            this.adresa_3 = new System.Windows.Forms.TextBox();
            this.adresa_4 = new System.Windows.Forms.TextBox();
            this.datum_ut = new System.Windows.Forms.TextBox();
            this.izvozno_car = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.vrstarobe = new System.Windows.Forms.TextBox();
            this.količina_1 = new System.Windows.Forms.TextBox();
            this.uvozno_car1 = new System.Windows.Forms.TextBox();
            this.uvozno_car2 = new System.Windows.Forms.TextBox();
            this.datum_isto = new System.Windows.Forms.TextBox();
            this.cijena_prijev = new System.Windows.Forms.TextBox();
            this.količina_2 = new System.Windows.Forms.TextBox();
            this.količina_3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // otvori
            // 
            this.otvori.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.otvori.Location = new System.Drawing.Point(13, 440);
            this.otvori.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.otvori.Name = "otvori";
            this.otvori.Size = new System.Drawing.Size(244, 112);
            this.otvori.TabIndex = 3;
            this.otvori.Text = "Otvori!";
            this.otvori.UseVisualStyleBackColor = true;
            this.otvori.Click += new System.EventHandler(this.otvori_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1168, 14);
            this.button3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(244, 110);
            this.button3.TabIndex = 4;
            this.button3.Text = "Izlaz";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.izlaz_Click);
            // 
            // umetni
            // 
            this.umetni.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.umetni.Location = new System.Drawing.Point(1168, 440);
            this.umetni.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.umetni.Name = "umetni";
            this.umetni.Size = new System.Drawing.Size(244, 112);
            this.umetni.TabIndex = 5;
            this.umetni.Text = "Umetni!";
            this.umetni.UseVisualStyleBackColor = true;
            this.umetni.Click += new System.EventHandler(this.umetni_Click);
            // 
            // nalog_za_utovar_broj
            // 
            this.nalog_za_utovar_broj.AutoSize = true;
            this.nalog_za_utovar_broj.Location = new System.Drawing.Point(23, 14);
            this.nalog_za_utovar_broj.Name = "nalog_za_utovar_broj";
            this.nalog_za_utovar_broj.Size = new System.Drawing.Size(203, 24);
            this.nalog_za_utovar_broj.TabIndex = 6;
            this.nalog_za_utovar_broj.Text = "Nalog za utovar broj:";
            // 
            // adresa_utovara
            // 
            this.adresa_utovara.AutoSize = true;
            this.adresa_utovara.Location = new System.Drawing.Point(23, 80);
            this.adresa_utovara.Name = "adresa_utovara";
            this.adresa_utovara.Size = new System.Drawing.Size(212, 24);
            this.adresa_utovara.TabIndex = 7;
            this.adresa_utovara.Text = "Adresa utovara (br.2):";
            // 
            // datum_utovara
            // 
            this.datum_utovara.AutoSize = true;
            this.datum_utovara.Location = new System.Drawing.Point(23, 225);
            this.datum_utovara.Name = "datum_utovara";
            this.datum_utovara.Size = new System.Drawing.Size(149, 24);
            this.datum_utovara.TabIndex = 8;
            this.datum_utovara.Text = "Datum utovara:";
            // 
            // izvozno_carinjenje
            // 
            this.izvozno_carinjenje.AutoSize = true;
            this.izvozno_carinjenje.Location = new System.Drawing.Point(23, 310);
            this.izvozno_carinjenje.Name = "izvozno_carinjenje";
            this.izvozno_carinjenje.Size = new System.Drawing.Size(185, 24);
            this.izvozno_carinjenje.TabIndex = 9;
            this.izvozno_carinjenje.Text = "Izvozno carinjenje:";
            // 
            // vrsta_robe
            // 
            this.vrsta_robe.AutoSize = true;
            this.vrsta_robe.Location = new System.Drawing.Point(665, 18);
            this.vrsta_robe.Name = "vrsta_robe";
            this.vrsta_robe.Size = new System.Drawing.Size(112, 24);
            this.vrsta_robe.TabIndex = 10;
            this.vrsta_robe.Text = "Vrsta robe:";
            // 
            // kolicina
            // 
            this.kolicina.AutoSize = true;
            this.kolicina.Location = new System.Drawing.Point(665, 80);
            this.kolicina.Name = "kolicina";
            this.kolicina.Size = new System.Drawing.Size(90, 24);
            this.kolicina.TabIndex = 11;
            this.kolicina.Text = "Količina:";
            // 
            // uvozno_carinjenje
            // 
            this.uvozno_carinjenje.AutoSize = true;
            this.uvozno_carinjenje.Location = new System.Drawing.Point(665, 208);
            this.uvozno_carinjenje.Name = "uvozno_carinjenje";
            this.uvozno_carinjenje.Size = new System.Drawing.Size(184, 24);
            this.uvozno_carinjenje.TabIndex = 12;
            this.uvozno_carinjenje.Text = "Uvozno carinjenje:";
            // 
            // datum_istovara
            // 
            this.datum_istovara.AutoSize = true;
            this.datum_istovara.Location = new System.Drawing.Point(665, 290);
            this.datum_istovara.Name = "datum_istovara";
            this.datum_istovara.Size = new System.Drawing.Size(152, 24);
            this.datum_istovara.TabIndex = 13;
            this.datum_istovara.Text = "Datum istovara:";
            // 
            // cijena_prijevoza
            // 
            this.cijena_prijevoza.AutoSize = true;
            this.cijena_prijevoza.Location = new System.Drawing.Point(665, 350);
            this.cijena_prijevoza.Name = "cijena_prijevoza";
            this.cijena_prijevoza.Size = new System.Drawing.Size(165, 24);
            this.cijena_prijevoza.TabIndex = 14;
            this.cijena_prijevoza.Text = "Cijena prijevoza:";
            // 
            // nalog_br
            // 
            this.nalog_br.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nalog_br.Location = new System.Drawing.Point(253, 18);
            this.nalog_br.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nalog_br.Name = "nalog_br";
            this.nalog_br.Size = new System.Drawing.Size(394, 24);
            this.nalog_br.TabIndex = 15;
            this.nalog_br.TextChanged += new System.EventHandler(this.nalog_br_TextChanged);
            // 
            // adresa_1
            // 
            this.adresa_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.adresa_1.Location = new System.Drawing.Point(253, 80);
            this.adresa_1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adresa_1.Name = "adresa_1";
            this.adresa_1.Size = new System.Drawing.Size(394, 24);
            this.adresa_1.TabIndex = 16;
            this.adresa_1.TextChanged += new System.EventHandler(this.adresa_1_TextChanged);
            // 
            // adresa_2
            // 
            this.adresa_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.adresa_2.Location = new System.Drawing.Point(253, 108);
            this.adresa_2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adresa_2.Name = "adresa_2";
            this.adresa_2.Size = new System.Drawing.Size(394, 24);
            this.adresa_2.TabIndex = 17;
            this.adresa_2.TextChanged += new System.EventHandler(this.adresa_2_TextChanged);
            // 
            // adresa_3
            // 
            this.adresa_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.adresa_3.Location = new System.Drawing.Point(253, 136);
            this.adresa_3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adresa_3.Name = "adresa_3";
            this.adresa_3.Size = new System.Drawing.Size(394, 24);
            this.adresa_3.TabIndex = 18;
            this.adresa_3.TextChanged += new System.EventHandler(this.adresa_3_TextChanged);
            // 
            // adresa_4
            // 
            this.adresa_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.adresa_4.Location = new System.Drawing.Point(253, 164);
            this.adresa_4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adresa_4.Name = "adresa_4";
            this.adresa_4.Size = new System.Drawing.Size(394, 24);
            this.adresa_4.TabIndex = 19;
            this.adresa_4.TextChanged += new System.EventHandler(this.adresa_4_TextChanged);
            // 
            // datum_ut
            // 
            this.datum_ut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datum_ut.Location = new System.Drawing.Point(253, 225);
            this.datum_ut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.datum_ut.Name = "datum_ut";
            this.datum_ut.Size = new System.Drawing.Size(394, 24);
            this.datum_ut.TabIndex = 20;
            this.datum_ut.TextChanged += new System.EventHandler(this.datum_ut_TextChanged);
            // 
            // izvozno_car
            // 
            this.izvozno_car.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.izvozno_car.Location = new System.Drawing.Point(253, 310);
            this.izvozno_car.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.izvozno_car.Name = "izvozno_car";
            this.izvozno_car.Size = new System.Drawing.Size(394, 24);
            this.izvozno_car.TabIndex = 21;
            this.izvozno_car.TextChanged += new System.EventHandler(this.izvozno_car_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(253, 338);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(394, 24);
            this.textBox1.TabIndex = 22;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // vrstarobe
            // 
            this.vrstarobe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vrstarobe.Location = new System.Drawing.Point(791, 18);
            this.vrstarobe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vrstarobe.Name = "vrstarobe";
            this.vrstarobe.Size = new System.Drawing.Size(349, 24);
            this.vrstarobe.TabIndex = 23;
            this.vrstarobe.TextChanged += new System.EventHandler(this.vrstarobe_TextChanged);
            // 
            // količina_1
            // 
            this.količina_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.količina_1.Location = new System.Drawing.Point(791, 82);
            this.količina_1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.količina_1.Name = "količina_1";
            this.količina_1.Size = new System.Drawing.Size(349, 24);
            this.količina_1.TabIndex = 24;
            this.količina_1.TextChanged += new System.EventHandler(this.količina_1_TextChanged);
            // 
            // uvozno_car1
            // 
            this.uvozno_car1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uvozno_car1.Location = new System.Drawing.Point(885, 208);
            this.uvozno_car1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uvozno_car1.Name = "uvozno_car1";
            this.uvozno_car1.Size = new System.Drawing.Size(394, 24);
            this.uvozno_car1.TabIndex = 27;
            this.uvozno_car1.TextChanged += new System.EventHandler(this.uvozno_car1_TextChanged);
            // 
            // uvozno_car2
            // 
            this.uvozno_car2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uvozno_car2.Location = new System.Drawing.Point(885, 236);
            this.uvozno_car2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uvozno_car2.Name = "uvozno_car2";
            this.uvozno_car2.Size = new System.Drawing.Size(394, 24);
            this.uvozno_car2.TabIndex = 28;
            this.uvozno_car2.TextChanged += new System.EventHandler(this.uvozno_car2_TextChanged);
            // 
            // datum_isto
            // 
            this.datum_isto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datum_isto.Location = new System.Drawing.Point(885, 290);
            this.datum_isto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.datum_isto.Name = "datum_isto";
            this.datum_isto.Size = new System.Drawing.Size(394, 24);
            this.datum_isto.TabIndex = 29;
            this.datum_isto.TextChanged += new System.EventHandler(this.datum_isto_TextChanged);
            // 
            // cijena_prijev
            // 
            this.cijena_prijev.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cijena_prijev.Location = new System.Drawing.Point(885, 350);
            this.cijena_prijev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cijena_prijev.Name = "cijena_prijev";
            this.cijena_prijev.Size = new System.Drawing.Size(394, 24);
            this.cijena_prijev.TabIndex = 30;
            this.cijena_prijev.TextChanged += new System.EventHandler(this.cijena_prijev_TextChanged);
            // 
            // količina_2
            // 
            this.količina_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.količina_2.Location = new System.Drawing.Point(791, 110);
            this.količina_2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.količina_2.Name = "količina_2";
            this.količina_2.Size = new System.Drawing.Size(349, 24);
            this.količina_2.TabIndex = 25;
            this.količina_2.TextChanged += new System.EventHandler(this.količina_2_TextChanged);
            // 
            // količina_3
            // 
            this.količina_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.količina_3.Location = new System.Drawing.Point(791, 138);
            this.količina_3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.količina_3.Name = "količina_3";
            this.količina_3.Size = new System.Drawing.Size(349, 24);
            this.količina_3.TabIndex = 26;
            this.količina_3.TextChanged += new System.EventHandler(this.količina_3_TextChanged);
            // 
            // Nalozi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1426, 568);
            this.ControlBox = false;
            this.Controls.Add(this.cijena_prijev);
            this.Controls.Add(this.datum_isto);
            this.Controls.Add(this.uvozno_car2);
            this.Controls.Add(this.uvozno_car1);
            this.Controls.Add(this.količina_3);
            this.Controls.Add(this.količina_2);
            this.Controls.Add(this.količina_1);
            this.Controls.Add(this.vrstarobe);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.izvozno_car);
            this.Controls.Add(this.datum_ut);
            this.Controls.Add(this.adresa_4);
            this.Controls.Add(this.adresa_3);
            this.Controls.Add(this.adresa_2);
            this.Controls.Add(this.adresa_1);
            this.Controls.Add(this.nalog_br);
            this.Controls.Add(this.cijena_prijevoza);
            this.Controls.Add(this.datum_istovara);
            this.Controls.Add(this.uvozno_carinjenje);
            this.Controls.Add(this.kolicina);
            this.Controls.Add(this.vrsta_robe);
            this.Controls.Add(this.izvozno_carinjenje);
            this.Controls.Add(this.datum_utovara);
            this.Controls.Add(this.adresa_utovara);
            this.Controls.Add(this.nalog_za_utovar_broj);
            this.Controls.Add(this.umetni);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.otvori);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "Nalozi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NALOZI";
            this.Load += new System.EventHandler(this.AP_Balažinec_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button otvori;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button umetni;
        private System.Windows.Forms.Label nalog_za_utovar_broj;
        private System.Windows.Forms.Label adresa_utovara;
        private System.Windows.Forms.Label datum_utovara;
        private System.Windows.Forms.Label izvozno_carinjenje;
        private System.Windows.Forms.Label vrsta_robe;
        private System.Windows.Forms.Label kolicina;
        private System.Windows.Forms.Label uvozno_carinjenje;
        private System.Windows.Forms.Label datum_istovara;
        private System.Windows.Forms.Label cijena_prijevoza;
        private System.Windows.Forms.TextBox nalog_br;
        private System.Windows.Forms.TextBox adresa_1;
        private System.Windows.Forms.TextBox adresa_2;
        private System.Windows.Forms.TextBox adresa_3;
        private System.Windows.Forms.TextBox adresa_4;
        private System.Windows.Forms.TextBox datum_ut;
        private System.Windows.Forms.TextBox izvozno_car;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox vrstarobe;
        private System.Windows.Forms.TextBox količina_1;
        private System.Windows.Forms.TextBox uvozno_car1;
        private System.Windows.Forms.TextBox uvozno_car2;
        private System.Windows.Forms.TextBox datum_isto;
        private System.Windows.Forms.TextBox cijena_prijev;
        private System.Windows.Forms.TextBox količina_2;
        private System.Windows.Forms.TextBox količina_3;
    }
}

