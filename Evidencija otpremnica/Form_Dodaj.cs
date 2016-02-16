using System;
using System.Windows.Forms;
using System.Globalization;
using System.Data.OleDb;

namespace Evidencija_otpremnica
{
    public partial class Form_Dodaj : Form
    {
        public Form_Dodaj()
        {
            InitializeComponent();
        }
        public string Broj_otpremnice { get; set; }
        public string Odrediste { get; set; }
        private void Form_Dodaj_Load(object sender, EventArgs e)
        {
            button_UcitajCijenu.Hide();
            button_DodajOtpremnicu.Hide();
            this.Text = "";
        }

        private void button_izlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_DodajOtpremnicu_Click(object sender, EventArgs e)
        {
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";
           // string connString = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";

            string sql = "SELECT * FROM" + Broj_otpremnice;
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            
            //pretvorba točke u zarez...za svaki slučaj
            string tezina = textBox_Tezina.Text.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string cijena = textBox_Cijena.Text.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string postanski = textBox_PostanskiBroj.Text;
            conn.Open();
            try
            {
                string inDB = "INSERT INTO " + Broj_otpremnice + " (postanski, odrediste, cbm, cijena, dvo, datum_unosa) " +
                               " VALUES ('" + postanski + "','"+ Odrediste + "','" + tezina + "','" + cijena + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + DateTime.Today.ToShortDateString() + "')";
                OleDbCommand cmd = new OleDbCommand(inDB, conn);
                cmd.ExecuteNonQuery();
            }

            //ako ne postoji ta otpremnica, stvori ju (stvori novu tablicu)
            catch
            {
                //izrada tablice
                string NapraviTablicu = "CREATE TABLE " + Broj_otpremnice +
                                        "(postanski CHAR(4), odrediste CHAR(20), cbm CHAR(8), cijena CHAR(10), dvo DATETIME, datum_unosa DATETIME )";
                OleDbCommand cmdTable = new OleDbCommand(NapraviTablicu, conn);
                cmdTable.ExecuteNonQuery();

                ///upisivanje vrijednosti
                string inDB = "INSERT INTO " + Broj_otpremnice + " (postanski, odrediste, cbm, cijena, dvo, datum_unosa) " +
                               " VALUES ('" + postanski + "','" + Odrediste + "','" + tezina + "','" + cijena + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + DateTime.Today.ToShortDateString() + "')";
                OleDbCommand cmd = new OleDbCommand(inDB, conn);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            this.Text = "GOTOVO!";
        }

        string tablica;
        string postanskiBrojUcitavanje;
        private void button_UcitajCijenu_Click(object sender, EventArgs e)
        {
            try
            {
                int postanskiBroj = Convert.ToInt16(textBox_PostanskiBroj.Text);

                if (postanskiBroj >= 1000 && postanskiBroj < 2000) postanskiBrojUcitavanje = "1000";
                else if(postanskiBroj >= 2000 && postanskiBroj < 3000) postanskiBrojUcitavanje = "2000";
                else if (postanskiBroj >= 3000 && postanskiBroj < 4000) postanskiBrojUcitavanje = "3000";
                else if (postanskiBroj >= 4000 && postanskiBroj < 5000) postanskiBrojUcitavanje = "4000";
                else if (postanskiBroj >= 5000 && postanskiBroj < 6000) postanskiBrojUcitavanje = "5000";
                else if (postanskiBroj >= 6000 && postanskiBroj < 7000) postanskiBrojUcitavanje = "6000";
                else if (postanskiBroj >= 7000 && postanskiBroj < 8000)
                {
                    MessageBox.Show("Nema cijena za poštanski broj od 7000 do 8000!");
                    goto kraj;
                }
                else if (postanskiBroj >= 8000 && postanskiBroj < 9000) postanskiBrojUcitavanje = "8000";
                else if (postanskiBroj >= 9000 && postanskiBroj < 10000) postanskiBrojUcitavanje = "9000";
                
                //učitavanje cijene iz accessa prema poštanskom i težini

                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Evidencija otpremnica\\Cijene.mdb";
               // string connString = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=|DataDirectory|\\Cijene.mdb";

                OleDbConnection conn = new OleDbConnection(connString);
                double cbm = Convert.ToDouble(textBox_Tezina.Text);

                //traženje iz koje tablice 
                if (cbm <= 0.2) tablica = "prva";
                else if (cbm > 0.2 && cbm <= 0.5) tablica = "pol";
                else if (cbm > 0.5 && cbm <= 1) tablica = "jedan";
                else if (cbm > 1 && cbm <= 2) tablica = "dva";
                else if (cbm > 2 && cbm <= 3) tablica = "tri";
                else if (cbm > 3 && cbm <= 4) tablica = "cetiri";
                else if (cbm > 4 && cbm <= 6) tablica = "sest";
                else if (cbm > 6 && cbm <= 8) tablica = "osam";
                else if (cbm > 8 && cbm <= 10) tablica = "deset";
                else if (cbm > 10 && cbm <= 20) tablica = "dvadeset";
                else if (cbm > 20 && cbm <= 30) tablica = "trideset";
                else if (cbm > 30 && cbm <= 50) tablica = "pedeset";
                else if (cbm > 50 && cbm <= 70) tablica = "sedamdeset";
                else
                {
                    MessageBox.Show("Maksimalna težina je 70!!");
                    goto kraj;
                }
                //dobivanje cijene
                string sql = "SELECT Cijena FROM " + tablica + " WHERE Postanski_Broj = " + postanskiBrojUcitavanje;
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                double cijena = 0;
                while (reader.Read())
                {
                    cijena = Convert.ToDouble(reader[0].ToString());
                }
                // da pomnoži s kubikima jer je tak formula, tak mora biti
                double konacnaCijena = Convert.ToDouble(textBox_Tezina.Text) * cijena;
                textBox_Cijena.Text = konacnaCijena.ToString();
                conn.Close();
                button_DodajOtpremnicu.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        kraj:
            Refresh();
          }

        private void textBox_Tezina_TextChanged(object sender, EventArgs e)
        {
			this.Text = "";
            button_UcitajCijenu.Show();
            if (textBox_Tezina.Text.Length == 0) button_UcitajCijenu.Hide();
        }       

        private void textBox_PostanskiBroj_TextChanged(object sender, EventArgs e)
        {
            Text = "";
        }
    }
}
