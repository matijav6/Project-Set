using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Data;

namespace Kombiji
{
    public partial class FormEvidencija : Form
    {
        public FormEvidencija()
        {
            InitializeComponent();
        }

        string finish, inDB, IDRetka, IDBaza, IDTablica;

        private void FormEvidencija_Load(object sender, EventArgs e)
        {
            
            string[] files = Directory.GetFiles(Application.StartupPath + "\\EvidencijaKombija", "*.mdb", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                string ime = Path.GetFileNameWithoutExtension(file);
                comboBoxKombi.Items.Add(ime);
            }

            try
            {
                IDRetka = File.ReadAllText(@"IDRetka.txt");                
                IDTablica = File.ReadAllText(@"IDtablica.txt");                
                IDBaza = File.ReadAllText(@"Baza.txt");                

                if (IDRetka.Length != 0 && IDBaza.Length != 0)
                {
                    string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\EvidencijaKombija\\" + IDBaza + ".mdb";

                    string sql = "SELECT * FROM " + IDTablica + " WHERE ID=" + IDRetka;

                    //klase za povezivanje na ACCESS bazu podataka//
                    OleDbConnection conn = new OleDbConnection(connString);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

                    DataSet ds = new DataSet();         //kreira noi objekt(kopiju) DataSet()-a
                    conn.Open();                        //otvara spoj s bazom podataka

                    adapter.Fill(ds, IDTablica);       //puni se DataSet s podacima tabele 
                    conn.Close();                       //zatvara se baza podataka

                    //nakon zatvaanja BP imamo odgovarajuće podatke u ds objektu ( DataSet() )
                    dataGridView1.DataSource = ds;      //upisivanje podataka id ds u dataGridView1
                    dataGridView1.DataMember = IDTablica;

                    dataGridView1.SelectAll();
                
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];

                comboBoxKombi.Text = IDBaza;
                textBoxKilometri.Text = dr.Cells[1].Value.ToString();
                textBoxSljedeciServis.Text = dr.Cells[2].Value.ToString();
                textBoxNapomena.Text = dr.Cells[3].Value.ToString();
                textBoxDatum.Text = dr.Cells[4].Value.ToString();


            }
            }
            catch (Exception ex)
            {
                //vjerojatno nije odabrana izmjena prije...

                //MessageBox.Show(ex.ToString());
            }
            finally
            {

            }
        }

        private void buttonSpremi_Click(object sender, EventArgs e)
        {
            int i = 1;
            if (comboBoxKombi.Text.Length == 0)
            {
                MessageBox.Show("Niste unijeli registraciju vozila!");
                goto kraj;
            }
            if (textBoxDatum.Text.Length == 0)
            {
                MessageBox.Show("Niste unijeli datum!");
                goto kraj;
            }

            if (textBoxKilometri.Text.Length == 0) textBoxKilometri.Text = "0";
            if (textBoxNapomena.Text.Length == 0) textBoxNapomena.Text = "-";
            if (textBoxSljedeciServis.Text.Length == 0) textBoxSljedeciServis.Text = "0";

            PripremaZaSpremanje();

            //provjera dal je nova baza ili ne
            string[] files = Directory.GetFiles(Application.StartupPath + "\\EvidencijaKombija", "*.mdb", SearchOption.AllDirectories);
            if (files.Length != 0)
            {
                foreach (string file in files)
                {
                    string ime = Path.GetFileNameWithoutExtension(file);
                    if (comboBoxKombi.Text == ime)
                        i = 0;
                }
            }
            //ako je odabrana izmjena prije
            if (File.Exists(@"IDRetka.txt"))
            {
                string brisi = Application.StartupPath + "\\EvidencijaKombija\\" + IDBaza + ".mdb";
                string connString1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + brisi;
                OleDbConnection conn1 = new OleDbConnection(connString1);
                conn1.Open();
                OleDbCommand brisanje = new OleDbCommand("DROP TABLE "+ IDTablica, conn1);
                brisanje.ExecuteNonQuery();
                conn1.Close();
            }

            //novo vozilo
            //kopira "BazaKombiEvidencija.mdb" da bi se izradila nova bazas nazivom >>comboBoxKombi.Text + ".mdb"<<
            if (i > 0)
            {
                string start = Application.StartupPath + "\\BazaKombiEvidencija.mdb";
                finish = Application.StartupPath + "\\EvidencijaKombija\\" + comboBoxKombi.Text + ".mdb";
                System.IO.File.Copy(start, finish);               
            }

            //dodavanje troškova u postojeću bazu
            if (i == 0)
            {
                finish = Application.StartupPath + "\\EvidencijaKombija\\" + comboBoxKombi.Text + ".mdb";                
            }

            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + finish;
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();

            OleDbCommand myCommand = new OleDbCommand();
            myCommand.Connection = conn;

            try
            {
                myCommand.CommandText = "CREATE TABLE " + textBoxDatum.Text.Replace(".", "") + "(ID INTEGER IDENTITY(1,1) PRIMARY KEY, Kombi varchar(100), TrenutnoKm varchar(100), SljedeciKm varchar(100), Napomena text(250), Datum varchar(200))";
                
                myCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                
            }
            finally
            {
                string inDB = "INSERT INTO " + textBoxDatum.Text.Replace(".", "") + " (Kombi, TrenutnoKm, SljedeciKm, Napomena, Datum)" +
                             "VALUES ('" + comboBoxKombi.Text + "','" + textBoxKilometri.Text + "','" + textBoxSljedeciServis.Text + "','" + textBoxNapomena.Text + "','" + textBoxDatum.Text + "')";
                myCommand.CommandText = inDB;
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();
            }
            MessageBox.Show("Uspješno spremanje u bazu!", "Hit!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            File.Delete(@"IDRetka.txt");
            File.Delete(@"IDTablica.txt");
            File.Delete(@"Baza.txt");
        kraj:
            i++;            
        }

        private void buttonIzlaz_Click(object sender, EventArgs e)
        {
            File.Delete("IDRetka.txt");
            File.Delete("IDTablica.txt");
            Close();
        }

        private void table1BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void monthCalendarOd_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBoxDatum.Clear();
            textBoxDatum.Text = monthCalendar.SelectionRange.Start.ToString("dd.MM.yyyy");            
        }
        public void PripremaZaSpremanje()
        {

            //string kilometri = textBoxKilometri.Text;

            //if (kilometri.Contains('.'))
            //{
                textBoxKilometri.Text = textBoxKilometri.Text.Replace(".", ",");
            //}

            //string sljedeciKilometri = textBoxSljedeciServis.Text;

            //if (kilometri.Contains('.'))
            //{
                textBoxSljedeciServis.Text = textBoxSljedeciServis.Text.Replace(".", ",");
            //}
        }            
    }
}
