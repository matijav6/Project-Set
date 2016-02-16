using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Globalization;

namespace Ponuda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }
        int i = 0;
        int ponuda = 0;

        public void Velicina()
        {
            this.Text = "Ponuda";
            this.Height = 500;
            this.Width = 1100;

            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label15.Hide();

            textBoxCestarina.Hide();
            textBoxCijenaGoriva.Hide();
            textBoxNama.Hide();
            textBoxTrajekt.Hide();
            textBoxVozac.Hide();
            textBoxUkupnaCijena.Hide();
            textBoxUkupnoKm.Hide();
            textBoxEur.Hide();
            textBoxNapomene.Hide();

            Povratak.Hide();
            PretraziFirme.Show();
            PretraziRelacije.Show();
            PromjenaUBazi.Show();
            buttonBrisanje.Show();
            UnosUBazu.Show();
            buttonPrikazSve.Show();
            button1.Show();
            SpremanjeUBazu.Hide();
            buttonracunaj.Hide();
            buttonUpute.Hide();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Velicina();
        }

        private void PretraziFirme_Click(object sender, EventArgs e)
        {
            if (textBoxFirma.Text.Length == 0)
            {
                MessageBox.Show("Niste unijeli ni jednu firmu za traženje!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string kriterijTrazenja = textBoxFirma.Text;
                System.IO.File.WriteAllText(@"privPonuda.txt", kriterijTrazenja);

                FormFirma formFirma = new FormFirma();
                formFirma.Show();

            }
        }

        private void PretraziRelacije_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete(@"PrivDo.txt");
            FormRelacije formRelacije = new FormRelacije();

            if (textBoxRelacijaDo.Text.Length == 0 && textBoxRelacijaOd.Text.Length == 0)
            {
                MessageBox.Show("Niste unijeli ni jednu relaciju!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         

            else
            {
                if (textBoxRelacijaOd.Text.Length != 0 && textBoxRelacijaDo.Text.Length == 0)
                {
                    string kriterijTrazenja = textBoxRelacijaOd.Text;
                    System.IO.File.WriteAllText(@"privOd.txt", kriterijTrazenja);

                    
                    formRelacije.Show();
                }

                else if (textBoxRelacijaOd.Text.Length == 0 && textBoxRelacijaDo.Text.Length != 0)
                {
                    string kriterijTrazenja = textBoxRelacijaDo.Text;
                    System.IO.File.WriteAllText(@"privDo.txt", kriterijTrazenja);
                    
                    formRelacije.Show();
                }
                else
                {
                    
                    string kriterijTrazenja1 = textBoxRelacijaOd.Text;                   
                    string kriterijTrazenja2 = textBoxRelacijaDo.Text;
                    System.IO.File.WriteAllText(@"privOd.txt", kriterijTrazenja1);
                    System.IO.File.WriteAllText(@"PrivDo.txt", kriterijTrazenja2);
                   
                    formRelacije.Show();
                   
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UnosUBazu_Click(object sender, EventArgs e)
        {
            

            this.Text = "Unos Nove Ponude";
            PretraziFirme.Hide();
            PretraziRelacije.Hide();
            PromjenaUBazi.Hide();
            UnosUBazu.Hide();
            button1.Hide();

            this.Height = 409;
            this.Width = 891;
           
            label4.Show();
            label5.Show();
            label6.Show();
            label7.Show();
            label8.Show();
            label9.Show();
            label10.Show();
            label11.Show();
            label12.Show();
            label13.Show();
            label14.Show();

            textBoxCestarina.Show();
            textBoxCijenaGoriva.Show();
            textBoxNama.Show();
            textBoxTrajekt.Show();
            textBoxVozac.Show();
            textBoxUkupnaCijena.Show();
            textBoxUkupnoKm.Show();
            textBoxEur.Show();
            textBoxNapomene.Show();

            PretraziFirme.Hide();
            PretraziRelacije.Hide();
            PromjenaUBazi.Hide();
            buttonBrisanje.Hide();
            UnosUBazu.Hide();
            buttonPrikazSve.Hide();
           // SpremanjeUBazu.Show();
            Povratak.Show();
            buttonracunaj.Show();
            buttonUpute.Show();
        }

        private void PromjenaUBazi_Click(object sender, EventArgs e)
        {
            FormIzmjena formIzmjena = new FormIzmjena();

            if (textBoxRelacijaDo.Text.Length == 0 && textBoxRelacijaOd.Text.Length == 0 && textBoxFirma.Text.Length == 0)
            {
                MessageBox.Show("Niste unijeli ni jedan podatak za traženje!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                if (textBoxFirma.Text.Length != 0)
                {
                  
                string kriterijTrazenja = textBoxFirma.Text;
                System.IO.File.WriteAllText(@"privPonuda.txt", kriterijTrazenja);


                formIzmjena.Show();

                }

                if (textBoxRelacijaOd.Text.Length != 0 && textBoxRelacijaDo.Text.Length == 0)
                {
                    string kriterijTrazenja = textBoxRelacijaOd.Text;
                    System.IO.File.WriteAllText(@"privOd.txt", kriterijTrazenja);

                    formIzmjena.Show();
                }

                if (textBoxRelacijaOd.Text.Length == 0 && textBoxRelacijaDo.Text.Length != 0)
                {
                    string kriterijTrazenja = textBoxRelacijaDo.Text;
                    System.IO.File.WriteAllText(@"privDo.txt", kriterijTrazenja);

                    formIzmjena.Show();
                }
                if (textBoxRelacijaOd.Text.Length != 0 && textBoxRelacijaDo.Text.Length != 0)
                {
                    string kriterijTrazenja1 = textBoxRelacijaOd.Text;
                    System.IO.File.WriteAllText(@"privOd.txt", kriterijTrazenja1);
                    string kriterijTrazenja2 = textBoxRelacijaDo.Text;
                    System.IO.File.WriteAllText(@"privDo.txt", kriterijTrazenja2);

                    formIzmjena.Show();

                }
            }
            
            

           
           
           
        }

        private void Povratak_Click(object sender, EventArgs e)
        {
            
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;                    
                        textBox.Clear();
                    
                }
            }
            Velicina();
            ponuda = 0;
        }
        string PutBaze;
        private void SpremanjeUBazu_Click(object sender, EventArgs e)
        {
            if (ponuda == 0)
            {
                PutBaze = System.IO.File.ReadAllText(Application.StartupPath + "\\Ponuda\\BazaPonuda.txt");
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

                //----------SQL instrukcija-----------\\
                string sql = "SELECT * FROM sve";

                //klase za povezivanje na ACCESS bazu podataka//
                OleDbConnection conn = new OleDbConnection(connString);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

                //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\

                conn.Open();                       //otvara spoj s bazom podataka


                if (textBoxEur.Text.Length == 0)
                {
                    MessageBox.Show("Niste unijeli valutu eura!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto kraj;
                }


                if (textBoxNapomene.Text.Length == 0)
                {
                    textBoxNapomene.Text = "-";
                }

                foreach (Control c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBox textBox = c as TextBox;
                        if (textBox.Text == string.Empty)
                        {
                            MessageBox.Show("Niste popunili sva polja potrebna za unos!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            goto kraj;
                        }
                    }
                }
                decimal a = Convert.ToDecimal(textBoxCestarina.Text);
                decimal b = Convert.ToDecimal(textBoxCijenaGoriva.Text);
                decimal cc = Convert.ToDecimal(textBoxNama.Text);
                decimal d = Convert.ToDecimal(textBoxTrajekt.Text);
                decimal f = Convert.ToDecimal(textBoxVozac.Text);
                decimal g = Convert.ToDecimal(textBoxUkupnoKm.Text);
                decimal h = Convert.ToDecimal(textBoxUkupnaCijena.Text);


                string cestar = a.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                string cijenagoriva = b.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                string mi = cc.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                string trajek = d.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                string voza = f.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                string ukupnokilometara = g.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                string ukupnacijena = h.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                string TrenutniDatum = DateTime.Now.ToShortDateString();

                string poc = textBoxRelacijaOd.Text;
                string ciljj = textBoxRelacijaDo.Text;
                string firme = textBoxFirma.Text;
                string nap = textBoxNapomene.Text;

                string inDB = "INSERT INTO sve (Firma,Pocetak,Zavrsetak,Gorivo,Cestarina,Trajekt,Vozac,Nama,Ukupna_Cijena,Ukupno_KM,Napomene,Datum_Unosa) " +
                              "VALUES ('" + firme + "','" + poc + "','" + ciljj + "'," + cijenagoriva + "," + cestar + "," + trajek + "," + voza + "," + mi + "," + ukupnacijena + "," + ukupnokilometara + ",'" + nap + "','" + TrenutniDatum  + "')";
                               
                OleDbCommand upis = new OleDbCommand(inDB, conn);
                upis.ExecuteNonQuery();

                //OleDbCommand getID;
                //getID = new OleDbCommand();
                //getID.CommandText = "SELECT @@IDENTITY";
                //getID.Connection = conn;
                //string ID = getID.ExecuteScalar().ToString();
                //string spremiZaSink = firme + "-" + poc + "-" + ciljj;
                //File.WriteAllText(Application.StartupPath + "\\tmp\\Ponuda-" + spremiZaSink + ".txt", ID);

                MessageBox.Show("Uspješno spremanje u bazu!", "Hit!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            kraj:
                conn.Close();                       //zatvara se baza podataka
                ponuda++;
            }
            else
            {
                MessageBox.Show("Već ste spremili ovu ponudu!");
            }

        }
        
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonBrisanje_Click(object sender, EventArgs e)
        {
            FormBrisanje formBrisanje = new FormBrisanje();

            if (textBoxRelacijaDo.Text.Length == 0 && textBoxRelacijaOd.Text.Length == 0 && textBoxFirma.Text.Length == 0)
            {
                MessageBox.Show("Niste unijeli ni jedan podatak za traženje!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                if (textBoxFirma.Text.Length != 0)
                {

                    string kriterijTrazenja = textBoxFirma.Text;
                    System.IO.File.WriteAllText(@"privPonuda.txt", kriterijTrazenja);


                    formBrisanje.Show();

                }

                if (textBoxRelacijaOd.Text.Length != 0 && textBoxRelacijaDo.Text.Length == 0)
                {
                    string kriterijTrazenja = textBoxRelacijaOd.Text;
                    System.IO.File.WriteAllText(@"privOd.txt", kriterijTrazenja);

                    formBrisanje.Show();
                }

                if (textBoxRelacijaOd.Text.Length == 0 && textBoxRelacijaDo.Text.Length != 0)
                {
                    string kriterijTrazenja = textBoxRelacijaDo.Text;
                    System.IO.File.WriteAllText(@"privDo.txt", kriterijTrazenja);

                    formBrisanje.Show();
                }
                if (textBoxRelacijaOd.Text.Length != 0 && textBoxRelacijaDo.Text.Length != 0)
                {
                    string kriterijTrazenja1 = textBoxRelacijaOd.Text;
                    System.IO.File.WriteAllText(@"privOd.txt", kriterijTrazenja1);
                    string kriterijTrazenja2 = textBoxRelacijaDo.Text;
                    System.IO.File.WriteAllText(@"privDo.txt", kriterijTrazenja2);

                    formBrisanje.Show();

                }
            }
            
        }

        private void buttonracunaj_Click(object sender, EventArgs e)
        {
            if (textBoxCijenaGoriva.Text.Length == 0)
            {
                textBoxCijenaGoriva.Text = "0";               
            }

            if (textBoxCestarina.Text.Length == 0)
            {
                textBoxCestarina.Text = "0";
            }
            if (textBoxNama.Text.Length == 0)
            {
                textBoxNama.Text = "0";
            }
            if (textBoxTrajekt.Text.Length == 0)
            {
                textBoxTrajekt.Text = "0";
            }
            if (textBoxVozac.Text.Length == 0)
            {
                textBoxVozac.Text = "0";
            }
            if (textBoxUkupnoKm.Text.Length == 0)
            {
                textBoxUkupnoKm.Text = "0";
            }
            if (i >= 1)
            {
                MessageBox.Show("Već ste kliknuli jedanput!", "Ups!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto kraj;
            }
            
            
            if (textBoxEur.Text.Length != 0)
            {
                double u = Convert.ToDouble(textBoxCestarina.Text);
                double u1 = Convert.ToDouble(textBoxCijenaGoriva.Text);
                double u2 = Convert.ToDouble(textBoxNama.Text);
                double u3 = Convert.ToDouble(textBoxTrajekt.Text);
                double u4 = Convert.ToDouble(textBoxVozac.Text);
                double eu = Convert.ToDouble(textBoxEur.Text);
                double u5 = u + u1 + u2 + u3 + u4;
                decimal rez1 = Convert.ToDecimal(u5);
                decimal rez2 = Convert.ToDecimal(eu);
                decimal u6 = rez1 / rez2;
                u6 = Math.Round(u6, 2);

                textBoxUkupnaCijena.Text = u6.ToString();

                i++;

                SpremanjeUBazu.Show();
            }

            else
            {
                MessageBox.Show("Unesi valutu EURA", "Hit!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        kraj:
            i++;
           
        }

        private void buttonUpute_Click(object sender, EventArgs e)
        {
            FormIzmjenaUpute formIzmjenaUpute = new FormIzmjenaUpute();
            formIzmjenaUpute.Show();
        }

        private void buttonPrikazSve_Click(object sender, EventArgs e)
        {
            FormPrikazSve formPrikazSve = new FormPrikazSve();
            formPrikazSve.Show();
        }

        private void textBoxEur_TextChanged(object sender, EventArgs e)
        {
            string n = textBoxEur.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxEur.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxEur.Clear();
                goto kraj;
            }
            label14.Hide();
            label15.Show();
            if (textBoxEur.TextLength == 0)
            {
                label14.Show();
                label15.Hide();
            }
            kraj:
            i = 0;

            }

        private void textBoxCijenaGoriva_TextChanged(object sender, EventArgs e)
        {
            i = 0;

            string n = textBoxCijenaGoriva.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxCijenaGoriva.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxCijenaGoriva.Clear();
            }
        }

        private void textBoxVozac_TextChanged(object sender, EventArgs e)
        {
            i = 0;

            string n = textBoxVozac.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxVozac.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxVozac.Clear();
            }
        }

        private void textBoxNama_TextChanged(object sender, EventArgs e)
        {
            i = 0;
            string n = textBoxNama.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxNama.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxNama.Clear();
            }
        }

        private void textBoxCestarina_TextChanged(object sender, EventArgs e)
        {
            i = 0;

            string n = textBoxCestarina.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxCestarina.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxCestarina.Clear();
            }
        }

        private void textBoxTrajekt_TextChanged(object sender, EventArgs e)
        {
            i = 0;

            string n = textBoxTrajekt.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxTrajekt.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxTrajekt.Clear();
            }
        }

        private void textBoxUkupnaCijena_TextChanged(object sender, EventArgs e)
        {
             i = 0;
             string n = textBoxUkupnaCijena.Text;
             float val;
             if ((!(float.TryParse(n, out val))) && textBoxUkupnaCijena.Text.Length != 0)
             {
                 MessageBox.Show("Samo brojevi!");
                 textBoxUkupnaCijena.Clear();
             }
        }

        private void textBoxUkupnoKm_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxUkupnoKm_TextChanged_1(object sender, EventArgs e)
        {
            string n = textBoxUkupnoKm.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxUkupnoKm.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxUkupnoKm.Clear();
            }
        }

        
    }
}
