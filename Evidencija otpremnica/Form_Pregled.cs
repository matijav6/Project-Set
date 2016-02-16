using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.Collections.Generic;
using Microsoft.CSharp;
using Excel = Microsoft.Office.Interop.Excel;

namespace Evidencija_otpremnica
{
    public partial class Form_Pregled : Form
    {
        public Form_Pregled()
        {
            InitializeComponent();
        }
        public string Broj_otpremnice { get; set; }

        List<string> tableNames = new List<string>();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public void dobivanjeTablica()
        {
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();

            //dobivanje imena svih tablica 

            if (Broj_otpremnice == "")
            {
                string[] restrictions = new string[4];
                restrictions[3] = "Table";

                DataTable dt = conn.GetSchema("Tables", restrictions);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tableNames.Add(dt.Rows[i][2].ToString());
                }

            }

            conn.Close();
        }
        public void ucitavanje()
        {
            //*** veza s bazom ***\\

            //  string connString = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=|DataDirectory|\\Evidencija otpremnica\\EvidencijaOtpremnica.mdb";
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();

            //odabir tablice
            string sql = "SELECT * FROM " + Broj_otpremnice;
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

            ////prikaz svega
            //if (Broj_otpremnice.Length == 0)
            //{
            //    //prvo napuni DataTable pa onda dodaj
            //    adapter.Fill(dt);
            //    ds.Tables.Add(dt);
            //}
            //else
          //  {
                adapter.Fill(ds, Broj_otpremnice);
           // }

             conn.Close();

            //zbrajanje cijene i težine
            double sum_tezina = 0, sum_cijena = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum_tezina += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                sum_cijena += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            textBox_UkupnoCijena.Text = sum_cijena.ToString();
            textBox_UkupnoKubika.Text = sum_tezina.ToString();
        }
        public void PonovnoUcitavanje()
        {

            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";
            //string connString = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();

            string kriterij = textBox2_PoCijeni.Text;
            string sql = "SELECT * FROM " + Broj_otpremnice;

            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

            DataSet ds = new DataSet();

            adapter.Fill(ds, Broj_otpremnice);
            conn.Close();


            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = Broj_otpremnice;

            //zbrajanje cijene i težine
            double sum_tezina = 0, sum_cijena = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum_tezina += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                sum_cijena += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            textBox_UkupnoCijena.Text = sum_cijena.ToString();
            textBox_UkupnoKubika.Text = sum_tezina.ToString();
        }
        private void Form_Pregled_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'evidencijaOtpremnicaDataSet1.test' table. You can move, or remove it, as needed.
            this.testTableAdapter.Fill(this.evidencijaOtpremnicaDataSet1.test);
            if (Broj_otpremnice.Length != 0)
            {
                ucitavanje();
            }
            else
            {
                dobivanjeTablica();
                foreach (string table in tableNames)
                {
                    //ako ime nije ' ' (prazno), onda učitaj tu tablicu
                    if (table != " ")
                    {
                        Broj_otpremnice = table;
                        ucitavanje();
                        ds.DataSetName = "Table123";
                    }

                }
            }


            dataGridView1.DataSource = ds;
            // PROBLEM!
            dataGridView1.DataMember = Broj_otpremnice;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                excelApp.Quit();
                Close();
            }
            catch
            {
                Close();
            }
        }

        private void textBox_PoTezini_TextChanged(object sender, EventArgs e)
        {
            dateTimePicker1.ResetText();
            textBox2_PoCijeni.Clear();
            textBox_poFirmi.Clear();
            textBox_poPostanskom.Clear();

            if (textBox_PoTezini.Text.Length != 0)
            {
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";
               // string connString = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";
                OleDbConnection conn = new OleDbConnection(connString);
                conn.Open();

                string kriterij = textBox_PoTezini.Text;
                string sql = "SELECT * FROM " + Broj_otpremnice + " WHERE cbm LIKE '" + kriterij + "%'";

                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

                DataSet ds = new DataSet();

                adapter.Fill(ds, Broj_otpremnice);
                conn.Close();


                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = Broj_otpremnice;

                //zbrajanje cijene i težine
                double sum_tezina = 0, sum_cijena = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum_tezina += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    sum_cijena += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                }
                textBox_UkupnoCijena.Text = sum_cijena.ToString();
                textBox_UkupnoKubika.Text = sum_tezina.ToString();
            }
            else PonovnoUcitavanje();
        }

        private void textBox2_PoCijeni_TextChanged(object sender, EventArgs e)
        {
            textBox_PoTezini.Clear();
            textBox_poPostanskom.Clear();
            textBox_poFirmi.Clear();

            dateTimePicker1.ResetText();

            if (textBox2_PoCijeni.Text.Length != 0)
            {
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";
                //string connString = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";
                OleDbConnection conn = new OleDbConnection(connString);
                conn.Open();

                string kriterij = textBox2_PoCijeni.Text;
                string sql = "SELECT * FROM " + Broj_otpremnice + " WHERE cijena LIKE '" + kriterij + "%'";

                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

                DataSet ds = new DataSet();

                adapter.Fill(ds, Broj_otpremnice);
                conn.Close();


                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = Broj_otpremnice;

                //zbrajanje cijene i težine
                double sum_tezina = 0, sum_cijena = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum_tezina += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    sum_cijena += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                }
                textBox_UkupnoCijena.Text = sum_cijena.ToString();
                textBox_UkupnoKubika.Text = sum_tezina.ToString();
            }
            else if (textBox2_PoCijeni.Text.Length == 0)
            {
                PonovnoUcitavanje();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {           
            //textBox2_PoCijeni.Clear();
            //textBox_poFirmi.Clear();
            //textBox_poPostanskom.Clear();
            //textBox_PoTezini.Clear();

            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";
           // string connString = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";
                OleDbConnection conn = new OleDbConnection(connString);
                conn.Open();

            string kriterij = dateTimePicker1.Value.ToShortDateString();
                string sql = "SELECT * FROM " + Broj_otpremnice + " WHERE datum_unosa LIKE '%" + kriterij + "%'";

                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

                DataSet ds = new DataSet();

                adapter.Fill(ds, Broj_otpremnice);
                conn.Close();


                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = Broj_otpremnice;

            //zbrajanje cijene i težine
            double sum_tezina = 0, sum_cijena = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum_tezina += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                sum_cijena += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            textBox_UkupnoCijena.Text = sum_cijena.ToString();
            textBox_UkupnoKubika.Text = sum_tezina.ToString();

        }

        private void textBox_poPostanskom_TextChanged(object sender, EventArgs e)
        {
            textBox2_PoCijeni.Clear();
            textBox_poFirmi.Clear();
            textBox_PoTezini.Clear();

            dateTimePicker1.ResetText();

            if (textBox_poPostanskom.Text.Length != 0)
            {
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";
                //string connString = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";
                OleDbConnection conn = new OleDbConnection(connString);
                conn.Open();

                string kriterij = textBox_poPostanskom.Text;
                string sql = "SELECT * FROM " + Broj_otpremnice + " WHERE postanski LIKE '" + kriterij + "%'";

                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

                DataSet ds = new DataSet();

                adapter.Fill(ds, Broj_otpremnice);
                conn.Close();


                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = Broj_otpremnice;

                //zbrajanje cijene i težine
                double sum_tezina = 0, sum_cijena = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum_tezina += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    sum_cijena += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                }
                textBox_UkupnoCijena.Text = sum_cijena.ToString();
                textBox_UkupnoKubika.Text = sum_tezina.ToString();
            }
            else if (textBox_poPostanskom.Text.Length == 0)
            {
                PonovnoUcitavanje();
            }
        }

        private void textBox_poFirmi_TextChanged(object sender, EventArgs e)
        {
            textBox_PoTezini.Clear();
            textBox_poPostanskom.Clear();
            textBox2_PoCijeni.Clear();

            dateTimePicker1.ResetText();

            if (textBox_poFirmi.Text.Length != 0)
            {
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";
                //string connString = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";
                OleDbConnection conn = new OleDbConnection(connString);
                conn.Open();

                string kriterij = textBox_poFirmi.Text;
                string sql = "SELECT * FROM " + Broj_otpremnice + " WHERE odrediste LIKE '" + kriterij + "%'";

                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

                DataSet ds = new DataSet();

                adapter.Fill(ds, Broj_otpremnice);
                conn.Close();


                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = Broj_otpremnice;

                //zbrajanje cijene i težine
                double sum_tezina = 0, sum_cijena = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum_tezina += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    sum_cijena += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                }
                textBox_UkupnoCijena.Text = sum_cijena.ToString();
                textBox_UkupnoKubika.Text = sum_tezina.ToString();
            }
            else if (textBox_poFirmi.Text.Length == 0)
            {
                PonovnoUcitavanje();
            }
        }

        private void button_obrisi_Click(object sender, EventArgs e)
        {

            DataGridViewRow dr = dataGridView1.SelectedRows[0];

            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\EvidencijaOtpremnica.mdb";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();

            //odabir tablice
            string sql = "SELECT * FROM " + Broj_otpremnice;
            OleDbCommand brisanje = new OleDbCommand("DELETE * FROM "+ Broj_otpremnice +" WHERE ID = " + dr.Cells[0].Value.ToString(), conn);
            brisanje.ExecuteNonQuery();
            conn.Close();
            PonovnoUcitavanje();
            MessageBox.Show("Obrisano!");
        }

        int redPostanski , stupacPostanski;
        int redIstovar, stupacIstovar;
        int redTezina, stupacTezina;
        int redCijena, stupacCijena;
        int redDVO, stupacDVO;
        Excel.Application excelApp;
        private void button_print_Click(object sender, EventArgs e)
        {
            int redPostanski = 18, stupacPostanski = 1;
            int redIstovar = 18, stupacIstovar = 3;
            int redTezina = 18, stupacTezina = 5;
            int redCijena = 18, stupacCijena = 7;
            int redDVO = 18, stupacDVO = 9;
            Excel.Application ExcelObj = null;

            Excel.Sheets sheets;
            Excel.Worksheet worksheet;
           excelApp = new Excel.Application();
            Excel.Workbook theWorkbook;
            ExcelObj = new Excel.Application();
            theWorkbook = ExcelObj.Workbooks.Open(Application.StartupPath + "\\Evidencija otpremnica\\Otpremnice_print\\Otpremnica.xlsx", 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
            sheets = theWorkbook.Worksheets;
            worksheet = (Excel.Worksheet)sheets.get_Item(1);


            excelApp.Workbooks.Open(Application.StartupPath + "\\Evidencija otpremnica\\Otpremnice_print\\Otpremnica.xlsx");
           for(int y = 18; y <= 31; y++)
                for(int x = 1; x <= 9; x++)
                {
                    excelApp.Cells[y, x] = "";
                }
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                
                excelApp.Cells[redPostanski++, stupacPostanski] = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value); //poštanski
                excelApp.Cells[redIstovar++, stupacIstovar] = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value); //istovar
                excelApp.Cells[redTezina++, stupacTezina] = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value); //težina
                excelApp.Cells[redCijena++, stupacCijena] = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value); //cijena
                excelApp.Cells[redDVO++, stupacDVO] = Convert.ToString(dataGridView1.Rows[i].Cells[5].Value); //dvo

            }
            theWorkbook.Saved = true;
            theWorkbook.Close(0);
            excelApp.Visible = true;
            //excelApp.Quit();
        }
    }
}
