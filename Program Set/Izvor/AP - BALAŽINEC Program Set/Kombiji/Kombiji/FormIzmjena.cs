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

namespace Kombiji
{
    public partial class FormIzmjena : Form
    {
        public FormIzmjena()
        {
            InitializeComponent();
        }

        string PutBaze;
        string odabir;
        private void buttonIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormIzmjena_Load(object sender, EventArgs e)
        {
           
            string[] files = Directory.GetFiles(Application.StartupPath + "\\Vozila", "*.mdb", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                string ime = Path.GetFileNameWithoutExtension(file);
                comboBoxOdabir.Items.Add(ime);
            }
            // TODO: This line of code loads data into the 'bazaKombiDataSet.Table1' table. You can move, or remove it, as needed.
             // this.table1TableAdapter.Fill(this.bazaKombiDataSet.Table1);

        }

        private void comboBoxOdabir_SelectedIndexChanged(object sender, EventArgs e)
        {
            PutBaze = Application.StartupPath + "\\Vozila\\" + comboBoxOdabir.Text + ".mdb";
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;            

            string sql = "SELECT * FROM Table1";

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
        }

        private void textBoxKriterij_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKriterij.Text.Length != 0)
            {
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

                string kriterij = textBoxKriterij.Text;

                string sql = "SELECT * FROM Table1 WHERE Vozac  LIKE '%" + kriterij + "%' OR Kombi  LIKE '%" + kriterij + "%'  OR Kilometri  LIKE '%" + kriterij + "%' OR DatumOd  LIKE '%" + kriterij + "%' OR DatumDo  LIKE '%" + kriterij + "%' ";

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
            }
            else
            {
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

                string kriterij = textBoxKriterij.Text;

                string sql = "SELECT * FROM Table1";

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
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];   //ID selektiranog retka  
                odabir = dr.Cells[0].Value.ToString();
                File.WriteAllText("IDRetka.txt", odabir);
                File.WriteAllText("Baza.txt", comboBoxOdabir.Text);

                FormUnos formUnos = new FormUnos();
                formUnos.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("ERROR!");
            }
            finally
            {
            }
        }
    }
}
