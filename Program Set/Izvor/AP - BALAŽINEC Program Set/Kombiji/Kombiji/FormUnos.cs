using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Globalization;

namespace Kombiji
{
    public partial class FormUnos : Form
    {
        public FormUnos()
        {
            InitializeComponent();
           
        }
        public void Zbrajanje()
        {
            string cestrina = textBoxCestarina.Text;
            if (cestrina.Contains('.'))
            {
                textBoxCestarina.Text = textBoxCestarina.Text.Replace(".", ",");
            }
            string kilometri = textBoxKilometri.Text;

            if (kilometri.Contains('.'))
            {
                textBoxKilometri.Text = textBoxKilometri.Text.Replace(".", ",");
            }
            string CijenaTure = textBoxCijenaTure.Text;

            if (CijenaTure.Contains('.'))
            {
                textBoxCijenaTure.Text = textBoxCijenaTure.Text.Replace(".", ",");
            }
            string UdioVozaču = textBoxVozacu.Text;

            if (UdioVozaču.Contains('.'))
            {
                textBoxVozacu.Text = textBoxVozacu.Text.Replace(".", ",");
            }
            string UdioNama = textBoxNama.Text;

            if (UdioNama.Contains('.'))
            {
                textBoxNama.Text = textBoxNama.Text.Replace(".", ",");
            }
            string Gorivo = textBoxGorivo.Text;

            if (Gorivo.Contains('.'))
            {
                textBoxGorivo.Text = textBoxGorivo.Text.Replace(".", ",");
            }
        }
        public void PripremaZaSpremanje()
        {
            string cestrina = textBoxCestarina.Text;
            if (cestrina.Contains(','))
            {
                textBoxCestarina.Text = textBoxCestarina.Text.Replace(",", ".");
            }
            string kilometri = textBoxKilometri.Text;

            if (kilometri.Contains(','))
            {
                textBoxKilometri.Text = textBoxKilometri.Text.Replace(",", ".");
            }
            string CijenaTure = textBoxCijenaTure.Text;

            if (CijenaTure.Contains(','))
            {
                textBoxCijenaTure.Text = textBoxCijenaTure.Text.Replace(",", ".");
            }
            string UdioVozaču = textBoxVozacu.Text;

            if (UdioVozaču.Contains(','))
            {
                textBoxVozacu.Text = textBoxVozacu.Text.Replace(",", ".");
            }
            string UdioNama = textBoxNama.Text;

            if (UdioNama.Contains(','))
            {
                textBoxNama.Text = textBoxNama.Text.Replace(",", ".");
            }
            string Gorivo = textBoxGorivo.Text;

            if (Gorivo.Contains(','))
            {
                textBoxGorivo.Text = textBoxGorivo.Text.Replace(",", ".");
            }
        }
        private void monthCalendarDo_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBoxDatumDo.Clear();
            textBoxDatumDo.Text = monthCalendarDo.SelectionRange.Start.ToShortDateString();
        }
        string IDRetka = "";
        string IDBaza = "";
        string BrFakture = "";
        private void FormUnos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bazaKombiDataSet1.Table1' table. You can move, or remove it, as needed.
            this.table1TableAdapter1.Fill(this.bazaKombiDataSet1.Table1);
            string[] files = Directory.GetFiles(Application.StartupPath + "\\Vozila", "*.mdb", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                string ime = Path.GetFileNameWithoutExtension(file);
                comboBox1.Items.Add(ime);
            }
            try
            {
                BrFakture = File.ReadAllText(Application.StartupPath + "\\PrivBrFakture.txt");

            }
            catch
            {
                goto dalje;
            }
            finally
            {

            }
            dalje:
            try
            {
                IDRetka = System.IO.File.ReadAllText(@"IDRetka.txt");
                File.Delete(@"IDRetka.txt");
                IDBaza = System.IO.File.ReadAllText(@"Baza.txt");
                File.Delete(@"Baza.txt");
                if (IDRetka.Length != 0 && IDBaza.Length != 0)
                {
                    string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Vozila\\" + IDBaza + ".mdb";

                    string sql = "SELECT * FROM Table1 WHERE ID=" + IDRetka;

                    //klase za povezivanje na ACCESS bazu podataka//
                    OleDbConnection conn = new OleDbConnection(connString);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

                    DataSet ds = new DataSet();         //kreira noi objekt(kopiju) DataSet()-a
                    conn.Open();                        //otvara spoj s bazom podataka

                    adapter.Fill(ds, "Table1");       //puni se DataSet s podacima tabele t_razred
                    conn.Close();                       //zatvara se baza podataka

                    //nakon zatvaanja BP imamo odgovarajuće podatke u ds objektu ( DataSet() )
                    dataGridView1.DataSource = ds;      //upisivanje podataka id ds u dataGridView1
                    dataGridView1.DataMember = "Table1";

                    dataGridView1.SelectAll();

                    DataGridViewRow dr = dataGridView1.SelectedRows[0];

                    comboBox1.Text = dr.Cells[1].Value.ToString();
                    comboBoxVozač.Text = dr.Cells[2].Value.ToString();
                    textBoxGorivo.Text = dr.Cells[3].Value.ToString();
                    textBoxCestarina.Text = dr.Cells[4].Value.ToString();
                    textBoxNama.Text = dr.Cells[5].Value.ToString();
                    textBoxVozacu.Text = dr.Cells[6].Value.ToString();
                    textBoxKilometri.Text = dr.Cells[7].Value.ToString();
                    textBoxDatumOd.Text = dr.Cells[8].Value.ToString();
                    textBoxDatumDo.Text = dr.Cells[9].Value.ToString();
                    textBoxCijenaTure.Text = dr.Cells[10].Value.ToString();                   
                    textBoxNapomena.Text = dr.Cells[12].Value.ToString();
                }
            }
            catch
            {
                
            }
            finally
            {

            }
        }

        private void monthCalendarOd_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBoxDatumOd.Clear();
            textBoxDatumOd.Text = monthCalendarOd.SelectionRange.Start.ToShortDateString();
        }

        private void buttonIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string finish;
        private void buttonSpremi_Click(object sender, EventArgs e)
        {
            

            int i = 1;
            if(comboBox1.Text.Length == 0) 
            {
                MessageBox.Show("Niste unijeli registraciju vozila!");
                goto kraj;
            }
           if(textBoxDatumOd.Text.Length == 0 || textBoxDatumDo.Text.Length == 0)
            {
                MessageBox.Show("Niste unijeli datum!");
                goto kraj;
            }

            if (comboBoxVozač.Text.Length == 0) comboBoxVozač.Text = "-";
            if (textBoxCijenaTure.Text.Length == 0) textBoxCijenaTure.Text = "0";
            if (textBoxCestarina.Text.Length == 0) textBoxCestarina.Text = "0";
            if (textBoxKilometri.Text.Length == 0) textBoxKilometri.Text = "0";
            if (textBoxGorivo.Text.Length == 0) textBoxGorivo.Text = "0";
            if (textBoxVozacu.Text.Length == 0) textBoxVozacu.Text = "0";
            if (textBoxNama.Text.Length == 0) textBoxNama.Text = "0";
            if (textBoxNapomena.Text.Length == 0) textBoxNapomena.Text = "-";
            if(BrFakture == "") BrFakture = "0";

            Zbrajanje();
            double ukupno = Convert.ToDouble(textBoxCestarina.Text) + Convert.ToDouble(textBoxNama.Text) + Convert.ToDouble(textBoxVozacu.Text) + Convert.ToDouble(textBoxGorivo.Text);
            textBoxCijenaTure.Text = ukupno.ToString();
            PripremaZaSpremanje();

            //dodavanje postojećih vozila u comboBox1 za odabir
            string[] files = Directory.GetFiles(Application.StartupPath + "\\Vozila", "*.mdb", SearchOption.AllDirectories);
            if (files.Length != 0)
            {
                foreach (string file in files)
                {
                    string ime = Path.GetFileNameWithoutExtension(file);
                    if (comboBox1.Text == ime)
                        i=0;
                }
            }
            //ako je odabrana izmjena prije
            if(IDRetka.Length != 0)
            {                
                    string brisi = Application.StartupPath + "\\Vozila\\" + IDBaza + ".mdb";
                    string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + brisi;
                    OleDbConnection conn = new OleDbConnection(connString);
                    conn.Open();
                    OleDbCommand brisanje = new OleDbCommand("DELETE * FROM Table1 WHERE ID = " + IDRetka, conn);
                    brisanje.ExecuteNonQuery();
                    conn.Close();

                string imex = Path.GetFileNameWithoutExtension(brisi);
                string putx = Application.StartupPath + "\\tmp\\" + imex + ".txt";
                File.WriteAllText(putx, brisi);
            }

            //novo vozilo
            //kopira "BazaKombi.mdb" da bi se izradila nova bazas nazivom >>comboBox1.Text + ".mdb"<<

            
            if (i > 0)
            {
                string start = Application.StartupPath + "\\BazaKombi.mdb";
                finish = Application.StartupPath + "\\Vozila\\" + comboBox1.Text + ".mdb";
                System.IO.File.Copy(start, finish);

                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + finish;

                string sql = "SELECT * FROM Table1";

                OleDbConnection conn = new OleDbConnection(connString);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

                conn.Open();

                string inDB = "INSERT INTO Table1 (Kombi,Vozac,Gorivo,Cestarina,Nama,Vozacu,Kilometri,DatumOd,DatumDo,UkupnaCijena,BrojFakture,Napomena) " +
                             "VALUES ('" + comboBox1.Text + "','" + comboBoxVozač.Text + "'," + textBoxGorivo.Text + "," + textBoxCestarina.Text + "," + textBoxNama.Text + "," + textBoxVozacu.Text + "," + textBoxKilometri.Text + ",'" + textBoxDatumOd.Text + "','" + textBoxDatumDo.Text + "'," + textBoxCijenaTure.Text + "," + BrFakture + ",'" + textBoxNapomena.Text + "')";

                OleDbCommand upis = new OleDbCommand(inDB, conn);
                upis.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Uspješno spremanje u bazu!", "Hit!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //dodavanje troškova u postojeću bazu
                if (i == 0)
                {
                    finish = Application.StartupPath + "\\Vozila\\" + comboBox1.Text + ".mdb";
                    string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + finish;

                    string sql = "SELECT * FROM Table1";

                    OleDbConnection conn = new OleDbConnection(connString);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

                    conn.Open();

                string inDB = "INSERT INTO Table1 (Kombi,Vozac,Gorivo,Cestarina,Nama,Vozacu,Kilometri,DatumOd,DatumDo,UkupnaCijena,BrojFakture,Napomena) " +
                             "VALUES ('" + comboBox1.Text + "','" + comboBoxVozač.Text + "'," + textBoxGorivo.Text + "," + textBoxCestarina.Text + "," + textBoxNama.Text + "," + textBoxVozacu.Text + "," + textBoxKilometri.Text + ",'" + textBoxDatumOd.Text + "','" + textBoxDatumDo.Text + "'," + textBoxCijenaTure.Text + "," + BrFakture + ",'" + textBoxNapomena.Text + "')";

                OleDbCommand upis = new OleDbCommand(inDB, conn);
                    upis.ExecuteNonQuery();
                    conn.Close();
                MessageBox.Show("Uspješno spremanje u bazu!", "Hit!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            SpremanjeZaSync();
        kraj:
            i++;
            File.Delete(Application.StartupPath + "\\PrivBrFakture.txt");
         
        }
        public void SpremanjeZaSync()
        {


            if (finish.Length != 0)
            {
                string ime = Path.GetFileNameWithoutExtension(finish);
                string put = Application.StartupPath + "\\tmp\\" + ime + ".txt";
                File.WriteAllText(put, finish);
            }
        }
        private void textBoxKilometri_TextChanged(object sender, EventArgs e)
        {
            string n = textBoxKilometri.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxKilometri.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxKilometri.Clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxCestarina_TextChanged(object sender, EventArgs e)
        {
            string n = textBoxCestarina.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxCestarina.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxCestarina.Clear();
            }
        }

        private void textBoxCijenaTure_TextChanged(object sender, EventArgs e)
        {
            string n = textBoxCijenaTure.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxCijenaTure.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxCijenaTure.Clear();
            }
        }        

        private void textBoxNama_TextChanged(object sender, EventArgs e)
        {
            string n = textBoxNama.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxNama.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxNama.Clear();
            }
        }

        private void textBoxGorivo_TextChanged(object sender, EventArgs e)
        {
            string n = textBoxGorivo.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxGorivo.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxGorivo.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
