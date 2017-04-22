using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kombiji
{
    public partial class FormEvidencijaPretrazivanje : Form
    {
        public FormEvidencijaPretrazivanje()
        {
            InitializeComponent();
        }

        private void FormEvidencijaPretrazivanje_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bazaKombiEvidencijaDataSet.table1' table. You can move, or remove it, as needed.
            //this.table1TableAdapter.Fill(this.bazaKombiEvidencijaDataSet.table1);
            string[] files = Directory.GetFiles(Application.StartupPath + "\\EvidencijaKombija", "*.mdb", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                string ime = Path.GetFileNameWithoutExtension(file);
                comboBoxOdabir.Items.Add(ime);
            }

        }

        private void buttonIzlaz_Click(object sender, EventArgs e)
        {
            Close();
        }

        string PutBaze, table;
        private void comboBoxOdabir_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxDatum.Items.Clear();
            comboBoxDatum.Text = "";
            PutBaze = Application.StartupPath + "\\EvidencijaKombija\\" + comboBoxOdabir.Text + ".mdb";
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                foreach (DataRow row in schema.Rows)
                {
                    string tablica = row[2].ToString();
                    if (!tablica.Contains("MS") && !tablica.Contains("table"))
                        comboBoxDatum.Items.Add(row[2].ToString());
                }
                connection.Close();

            }
        }

        private void comboBoxDatum_SelectedIndexChanged(object sender, EventArgs e)
        {
            PutBaze = Application.StartupPath + "\\EvidencijaKombija\\" + comboBoxOdabir.Text + ".mdb";
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

            string sql = "SELECT * FROM " + comboBoxDatum.Text;

            //klase za povezivanje na ACCESS bazu podataka//
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

            DataSet ds = new DataSet();         //kreira noi objekt(kopiju) DataSet()-a
            conn.Open();                        //otvara spoj s bazom podataka

            adapter.Fill(ds, comboBoxDatum.Text);       //puni se DataSet s podacima tabele t_razred
            conn.Close();                       //zatvara se baza podataka

            //nakon zatvaanja BP imamo odgovarajuće podatke u ds objektu ( DataSet() )
            dataGridView1.DataSource = ds;      //upisivanje podataka id ds u dataGridView1
            dataGridView1.DataMember = comboBoxDatum.Text;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxKriterij.Clear();
        }

        private void textBoxKriterij_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxKriterij.Text.Length != 0)
                {
                    string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

                    string kriterij = textBoxKriterij.Text;

                    string sql = "SELECT * FROM " + comboBoxDatum.Text + " WHERE Kombi  LIKE '%" + kriterij + "%' OR TrenutnoKm  LIKE '%" + kriterij + "%'  OR SljedeciKm  LIKE '%" + kriterij + "%' OR Napomena  LIKE '%" + kriterij + "%' OR Datum  LIKE '%" + kriterij + "%' ";

                    //klase za povezivanje na ACCESS bazu podataka//
                    OleDbConnection conn = new OleDbConnection(connString);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

                    DataSet ds = new DataSet();         //kreira noi objekt(kopiju) DataSet()-a
                    conn.Open();                        //otvara spoj s bazom podataka

                    adapter.Fill(ds, comboBoxDatum.Text);       //puni se DataSet s podacima tabele t_razred
                    conn.Close();                       //zatvara se baza podataka

                    //nakon zatvaanja BP imamo odgovarajuće podatke u ds objektu ( DataSet() )
                    dataGridView1.DataSource = ds;      //upisivanje podataka id ds u dataGridView1
                    dataGridView1.DataMember = comboBoxDatum.Text;
                }
                else
                {
                    string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

                    string kriterij = textBoxKriterij.Text;

                    string sql = "SELECT * FROM " + comboBoxDatum.Text;

                    //klase za povezivanje na ACCESS bazu podataka//
                    OleDbConnection conn = new OleDbConnection(connString);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

                    DataSet ds = new DataSet();         //kreira noi objekt(kopiju) DataSet()-a
                    conn.Open();                        //otvara spoj s bazom podataka

                    adapter.Fill(ds, comboBoxDatum.Text);       //puni se DataSet s podacima tabele t_razred
                    conn.Close();                       //zatvara se baza podataka

                    //nakon zatvaanja BP imamo odgovarajuće podatke u ds objektu ( DataSet() )
                    dataGridView1.DataSource = ds;      //upisivanje podataka id ds u dataGridView1
                    dataGridView1.DataMember = comboBoxDatum.Text;
                }
            }
            catch
            {
                textBoxKriterij.Clear();
                MessageBox.Show("Odaberi kombi!");
            }
        }
    }
}
