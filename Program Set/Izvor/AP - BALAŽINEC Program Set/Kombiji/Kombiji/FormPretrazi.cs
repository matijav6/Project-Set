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
    public partial class FormPretrazi : Form
    {
        public FormPretrazi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string PutBaze;
        private void FormPretrazi_Load(object sender, EventArgs e)
        {          
            string[] files = Directory.GetFiles(Application.StartupPath + "\\Vozila", "*.mdb", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                string ime = Path.GetFileNameWithoutExtension(file);
                comboBox1.Items.Add(ime);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

                string kriterij = textBox1.Text;

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

                string kriterij = textBox1.Text;

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
   
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PutBaze = Application.StartupPath + "\\Vozila\\" + comboBox1.Text + ".mdb";
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

            string kriterij = textBox1.Text;

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

            textBoxUkupnoKilometara.Clear();
            textBoxUkupnoCestarina.Clear();
            textBoxUkupnoCijena.Clear();
            textBoxUkupnoGorivo.Clear();
            textBoxVozaču.Clear();

            double sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum1 += Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                sum2 += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                sum3 += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                sum4 += Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                sum5 += Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
            }
            textBoxUkupnoKilometara.Text = sum1.ToString();
            textBoxUkupnoCestarina.Text = sum2.ToString();
            textBoxUkupnoGorivo.Text = sum3.ToString();
            textBoxUkupnoCijena.Text = sum4.ToString();
            textBoxVozaču.Text = sum5.ToString();
        }

        private void buttonIzlaz_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string datum = dateTimePicker1.Value.Month.ToString() + "." + dateTimePicker1.Value.Year.ToString() + ".";

            try
            {
                if (datum.Length != 0)
                {
                    string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

                    string sql = "SELECT * FROM Table1 WHERE DatumOd  LIKE '%" + datum + "%' ";

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

                    textBoxUkupnoKilometara.Clear();
                    textBoxUkupnoCestarina.Clear();
                    textBoxUkupnoCijena.Clear();
                    textBoxUkupnoGorivo.Clear();
                    textBoxVozaču.Clear();

                    double sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        sum1 += Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                        sum2 += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                        sum3 += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                        sum4 += Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                        sum5 += Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                    }
                    textBoxUkupnoKilometara.Text = sum1.ToString();
                    textBoxUkupnoCestarina.Text = sum2.ToString();
                    textBoxUkupnoGorivo.Text = sum3.ToString();
                    textBoxUkupnoCijena.Text = sum4.ToString();
                    textBoxVozaču.Text = sum5.ToString();
                }
                else
                {
                    string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

                    string kriterij = textBox1.Text;

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

                    textBoxUkupnoKilometara.Clear();
                    textBoxUkupnoCestarina.Clear();
                    textBoxUkupnoCijena.Clear();
                    textBoxUkupnoGorivo.Clear();
                    textBoxVozaču.Clear();

                    double sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        sum1 += Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                        sum2 += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                        sum3 += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                        sum4 += Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                        sum5 += Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                    }
                    textBoxUkupnoKilometara.Text = sum1.ToString();
                    textBoxUkupnoCestarina.Text = sum2.ToString();
                    textBoxUkupnoGorivo.Text = sum3.ToString();
                    textBoxUkupnoCijena.Text = sum4.ToString();
                    textBoxVozaču.Text = sum5.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Prvo odaberite vozilo!");
            }
            finally { }

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            try
            {
                PutBaze = Application.StartupPath + "\\Vozila\\" + comboBox1.Text + ".mdb";
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PutBaze;

                string kriterij = textBox1.Text;

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

                textBoxUkupnoKilometara.Clear();
                textBoxUkupnoCestarina.Clear();
                textBoxUkupnoCijena.Clear();
                textBoxUkupnoGorivo.Clear();
                textBoxVozaču.Clear();

                double sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum1 += Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                    sum2 += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                    sum3 += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    sum4 += Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                    sum5 += Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                }
                textBoxUkupnoKilometara.Text = sum1.ToString();
                textBoxUkupnoCestarina.Text = sum2.ToString();
                textBoxUkupnoGorivo.Text = sum3.ToString();
                textBoxUkupnoCijena.Text = sum4.ToString();
                textBoxVozaču.Text = sum5.ToString();
            }
            catch
            {
                MessageBox.Show("Niste Odabrali vozilo!");
            }
            finally
            { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxUkupnoCestarina_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
