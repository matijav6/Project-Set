﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Threading;
using Microsoft.Office.Tools.Excel;
using System.Text.RegularExpressions;
using WindowsFormApplication1;
using System.Globalization;
using System.Runtime.InteropServices;

namespace WindowsFormApplication1
{
    public partial class FormNovaFirmaSlo : Form
    {
        public FormNovaFirmaSlo()
        {
            InitializeComponent();

            radioNePlaceno.Checked = true;
            textBoxDatumOd.Text = dateTimePickerOd.Value.ToShortDateString();
            textBoxDatumDo.Text = dateTimePickerDo.Value.ToShortDateString();
            textBoxDatum.Text = monthCalendar1.SelectionEnd.ToShortDateString();
        }
        string spremanje;
        string spremanjeNe;
        string IDRetka = "";
        string IDBaza = "";
        string BrFakture = "";
        string finish;


        public void SpremanjeKombi()
        {
            int i = 1;
            if (comboBox1.Text.Length == 0)
            {
                MessageBox.Show("Niste unijeli registraciju vozila!");
                goto kraj;
            }
            if (textBoxDatumOd.Text.Length == 0 || textBoxDatumDo.Text.Length == 0)
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
            BrFakture = textBoxBrFakture.Text;

            Zbrajanje();
            double ukupno = Convert.ToDouble(textBoxCestarina.Text) + Convert.ToDouble(textBoxNama.Text) + Convert.ToDouble(textBoxVozacu.Text) + Convert.ToDouble(textBoxGorivo.Text);
            textBoxCijenaTure.Text = ukupno.ToString();
            PripremaZaSpremanje();

            //kopira "BazaKombi.mdb" da bi se izradila nova baza s nazivom >>comboBox1.Text + ".mdb"<<
            if (!File.Exists(Application.StartupPath + "\\Vozila\\" + comboBox1.Text + ".mdb"))
            {
                string start = Application.StartupPath + "\\Fakture\\BazaKombi.mdb";
                finish = Application.StartupPath + "\\Vozila\\" + comboBox1.Text + ".mdb";
                File.Copy(start, finish);

            }

            //dodavanje troškova u postojeću bazu

            finish = Application.StartupPath + "\\Vozila\\" + comboBox1.Text + ".mdb";
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + finish;

            string sql = "SELECT * FROM Table1";

            OleDbConnection conn = new OleDbConnection(connString);
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

            conn.Open();

            string inDB = "INSERT INTO Table1 (Kombi,Vozac,Gorivo,Cestarina,Nama,Vozacu,Kilometri,DatumOd,DatumDo,UkupnaCijena,Napomena) " +
                    "VALUES ('" + comboBox1.Text + "','" + comboBoxVozač.Text + "'," + textBoxGorivo.Text + "," + textBoxCestarina.Text + "," + textBoxNama.Text + "," + textBoxVozacu.Text + "," +
                     textBoxKilometri.Text + ",'" + dateTimePickerOd.Value.ToShortDateString() + "','" +
                    dateTimePickerDo.Value.ToShortDateString() + "'," + textBoxCijenaTure.Text + ",'" + textBoxNapomena.Text + "')";

            OleDbCommand upis = new OleDbCommand(inDB, conn);
            upis.ExecuteNonQuery();
            conn.Close();

        // SpremanjeZaSyncBaza();
        kraj:
            i++;
            File.Delete(Application.StartupPath + "\\PrivBrFakture.txt");
        }
        public void SpremanjeFaktura()
        {
            textBoxPDV.Text = textBoxPDV.Text.Replace("%", "");
            textBoxRabat.Text = textBoxRabat.Text.Replace("%", "");

            string putanjaDoNoveFakture;

            string put = System.IO.File.ReadAllText(Application.StartupPath + "\\Fakture\\PutFakture.txt");
            if (textBoxRabat.Text.Length != 0)
                putanjaDoNoveFakture = Application.StartupPath + "\\Fakture\\NOVA_RABAT_SLO.xlsx";

            else putanjaDoNoveFakture = Application.StartupPath + "\\Fakture\\NOVA_SLO.xlsx";
            Excel.Application excelApp = new Excel.Application();

            if (radioPlaceno.Checked == true || radioNePlaceno.Checked == true)
            {
                Microsoft.Office.Interop.Excel.Application ExcelObj = null;
                ExcelObj = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(putanjaDoNoveFakture, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
                Microsoft.Office.Interop.Excel.Sheets sheets = theWorkbook.Worksheets;
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(1);


                int rowIndex, colIndex;
                excelApp.Workbooks.Open(putanjaDoNoveFakture);

                rowIndex = 17; colIndex = 8;
                excelApp.Cells[rowIndex, colIndex] = textBoxDVO.Text;

                rowIndex = 18; colIndex = 8;
                excelApp.Cells[rowIndex, colIndex] = textBoxValuta.Text;

                rowIndex = 21; colIndex = 7;
                excelApp.Cells[rowIndex, colIndex] = textBoxBrojFakture.Text;

                rowIndex = 22; colIndex = 7;
                excelApp.Cells[rowIndex, colIndex] = textBoxRegBroj.Text;

                rowIndex = 30; colIndex = 5;
                excelApp.Cells[rowIndex, colIndex] = textBoxKolicina.Text;

                rowIndex = 30; colIndex = 6;
                excelApp.Cells[rowIndex, colIndex] = textBoxCijena.Text;

                rowIndex = 27; colIndex = 1;
                if (textBoxRabat.Text.Length != 0) rowIndex = 29;
                    excelApp.Cells[rowIndex, colIndex] = textBoxRelacija.Text;

                rowIndex = 30; colIndex = 3;
                excelApp.Cells[rowIndex, colIndex] = textBoxJM.Text;

                rowIndex = 17; colIndex = 1;
                excelApp.Cells[rowIndex, colIndex] = textBoxImeFirme.Text;

                rowIndex = 18; colIndex = 1;
                excelApp.Cells[rowIndex, colIndex] = textBoxUlica.Text;

                rowIndex = 19; colIndex = 1;
                excelApp.Cells[rowIndex, colIndex] = textBoxMjesto.Text;

                rowIndex = 31; colIndex = 2;

                //if (textBoxRabat.Text.Length != 0)
                //{
                //    rowIndex = 31;
                //    colIndex = 3;
                //}
                    excelApp.Cells[rowIndex, colIndex] = textBoxPozicija.Text;


                //ako je s rabatom
                if (textBoxRabat.Text.Length != 0)
                {
                    rowIndex = 30; colIndex = 9;
                    double rabat = Convert.ToDouble(textBoxRabat.Text);
                    excelApp.Cells[rowIndex, colIndex] = rabat / 100;

                    rowIndex = 30; colIndex = 10;
                    double PDVa = Convert.ToDouble(textBoxPDV.Text);
                    excelApp.Cells[rowIndex, colIndex] = PDVa / 100;
                }

                else
                {
                    rowIndex = 30; colIndex = 9;
                    double PDV = Convert.ToDouble(textBoxPDV.Text);
                    excelApp.Cells[rowIndex, colIndex] = PDV / 100;
                }

                rowIndex = 34; colIndex = 6;
                string euro = textBoxEur.Text;
                if (euro.Contains('.'))
                {
                    textBoxEur.Text = euro.Replace('.', ',');
                }
                double UkupnaCijenaBezPDV = Convert.ToDouble(textBoxKolicina.Text) * Convert.ToDouble(textBoxCijena.Text);
                double UkupnaCijenaPDV = UkupnaCijenaBezPDV * (Convert.ToDouble(textBoxPDV.Text) / 100);
                double KonačnaCijena = UkupnaCijenaBezPDV + UkupnaCijenaPDV;
                double eur = KonačnaCijena / Convert.ToDouble(textBoxEur.Text);
                if (textBoxRabat.Text.Length != 0) excelApp.Cells[39, 6] = eur;
                else
                    excelApp.Cells[rowIndex, colIndex] = eur;

                var datum = Convert.ToDateTime(textBoxDVO.Text);
                string datumPrikaz = datum.ToShortDateString();

                int mjesec = datum.Month;
                int godina = datum.Year;

                string dira = put + textBoxImeFirme.Text + "\\" + textBoxRelacija.Text + "\\" + mjesec + "-" + godina + "\\PLAČENO\\";

                string dirNea = put + textBoxImeFirme.Text + "\\" + textBoxRelacija.Text + "\\" + mjesec + "-" + godina + "\\NEPLAČENO\\";

                string dir = dira.Replace("\\\\", "\\");
                string dirNe = dirNea.Replace("\\\\", "\\");

                spremanje = dir + textBoxBrFakture.Text + "  " + textBoxDVO.Text + ".xlsx";
                spremanjeNe = dirNe + textBoxBrFakture.Text + "  " + textBoxDVO.Text + ".xlsx";

                System.IO.Directory.CreateDirectory(dirNe);
                System.IO.Directory.CreateDirectory(dir);

                if (radioPlaceno.Checked)
                {
                    excelApp.ActiveWorkbook.SaveCopyAs(spremanje);
                    string ime = Path.GetFileNameWithoutExtension(spremanje);

                    Marshal.ReleaseComObject(ExcelObj);
                    Marshal.ReleaseComObject(theWorkbook);
                    Marshal.ReleaseComObject(sheets);
                    Marshal.ReleaseComObject(worksheet);
                    try
                    {
                        foreach (Process proc in Process.GetProcessesByName("EXCEL"))
                        {
                            proc.Kill();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    System.Diagnostics.Process.Start(spremanje);

                }


                if (radioNePlaceno.Checked)
                {
                    excelApp.ActiveWorkbook.SaveCopyAs(spremanjeNe);

                    string imeNe = Path.GetFileNameWithoutExtension(spremanjeNe);

                    Marshal.ReleaseComObject(ExcelObj);
                    Marshal.ReleaseComObject(theWorkbook);
                    Marshal.ReleaseComObject(sheets);
                    Marshal.ReleaseComObject(worksheet);
                    try
                    {
                        foreach (Process proc in Process.GetProcessesByName("EXCEL"))
                        {
                            proc.Kill();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    System.Diagnostics.Process.Start(spremanjeNe);

                }
                File.AppendAllText(Application.StartupPath + "\\Fakture\\data", System.Environment.NewLine + BrFakture);
            }
            else
            {
                MessageBox.Show("Niste označili da li je plačeno ili ne!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        public void SpremanjeZaSyncBaza()
        {


            //if (finish.Length != 0)
            //{
            //    string ime = Path.GetFileNameWithoutExtension(finish);
            //    string put = Application.StartupPath + "\\tmp\\" + ime + ".txt";
            //    File.WriteAllText(put, finish);
            //}
        }
        private void spremi_Click(object sender, EventArgs e)
        {
            try
            {
                SpremanjeFaktura();
                SpremanjeKombi();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Došlo je do greške prilikom spremanja", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }
        }

        private void FormNovaFirmaSlo_Load(object sender, EventArgs e)
        {
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

        private void textBoxBrFakture_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxBrojFakture_TextChanged(object sender, EventArgs e)
        {
            textBoxBrFakture.Text = textBoxBrojFakture.Text;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBoxDatum.Text = monthCalendar1.SelectionEnd.ToShortDateString();
        }

        private void textBoxValuta_TextChanged(object sender, EventArgs e)
        {
            textBoxDatum.Text = textBoxValuta.Text;
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

        private void textBoxVozacu_TextChanged(object sender, EventArgs e)
        {
            string n = textBoxVozacu.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxVozacu.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxVozacu.Clear();
            }
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
        private void dateTimePickerOd_ValueChanged(object sender, EventArgs e)
        {
            textBoxDatumOd.Text = dateTimePickerOd.Value.ToShortDateString();
        }

        private void dateTimePickerDo_ValueChanged(object sender, EventArgs e)
        {
            textBoxDatumDo.Text = dateTimePickerDo.Value.ToShortDateString();
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

        private void button3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Želite li stvarno zatvoriti program?", "IZLAZ",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
            {

                this.Close();


                try
                {
                    foreach (Process proc in Process.GetProcessesByName("EXCEL"))
                    {
                        proc.Kill();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBoxDVO_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxImeFirme_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxUlica_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxMjesto_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxRegBroj_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxKolicina_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCijena_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPDV_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxRelacija_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxJM_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEur_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDatum_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxVozač_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNapomena_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioPlaceno_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioNePlaceno_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
