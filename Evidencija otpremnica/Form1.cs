using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Evidencija_otpremnica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_izlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_DodajOtpremnicu_Click(object sender, EventArgs e)
        {
            Form_Dodaj form_dodaj = new Form_Dodaj();

            form_dodaj.Broj_otpremnice = textBox_BrojOtpremnice.Text;
            form_dodaj.Odrediste = textBox_odredisnaFirma.Text;
            form_dodaj.ShowDialog();
        }

        private void button_Evidencija_Click(object sender, EventArgs e)
        {
            Form_Pregled form_pregled = new Form_Pregled();

            form_pregled.Broj_otpremnice = textBox_BrojOtpremnice.Text;
            form_pregled.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
