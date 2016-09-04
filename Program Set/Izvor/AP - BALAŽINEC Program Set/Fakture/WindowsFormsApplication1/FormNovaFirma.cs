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
    public partial class FormNovaFirma : Form
    {
        public FormNovaFirma()
        {
            InitializeComponent();

            radioNePlaceno.Checked = true;
            textBoxDatumOd.Text = dateTimePickerOd.Value.ToShortDateString();
            textBoxDatumDo.Text = dateTimePickerDo.Value.ToShortDateString();
            textBoxDatum.Text = monthCalendar1.SelectionEnd.ToShortDateString();
        }
        string spremanje;
        string spremanjeNe;
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
            string putanjaDoNoveFakture;
            string put = System.IO.File.ReadAllText(Application.StartupPath + "\\Fakture\\PutFakture.txt");
            if (textBoxRabat.Text.Length != 0)   putanjaDoNoveFakture = Application.StartupPath + "\\Fakture\\NOVA_RABAT.xlsx";
            else putanjaDoNoveFakture = Application.StartupPath + "\\Fakture\\NOVA.xlsx";
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

                rowIndex = 18; colIndex = 8;
                excelApp.Cells[rowIndex, colIndex] = textBoxDVO.Text;

                rowIndex = 19; colIndex = 8;
                excelApp.Cells[rowIndex, colIndex] = textBoxValuta.Text;

                rowIndex = 22; colIndex = 7;
                excelApp.Cells[rowIndex, colIndex] = textBoxBrojFakture.Text;

                rowIndex = 23; colIndex = 7;
                excelApp.Cells[rowIndex, colIndex] = textBoxOIB.Text;

                rowIndex = 30; colIndex = 5;
                excelApp.Cells[rowIndex, colIndex] = textBoxKolicina.Text;

                rowIndex = 30; colIndex = 6;
                excelApp.Cells[rowIndex, colIndex] = textBoxCijena.Text;

                rowIndex = 28; colIndex = 1;
                excelApp.Cells[rowIndex, colIndex] = textBoxRelacija.Text;

                rowIndex = 30; colIndex = 4;
                excelApp.Cells[rowIndex, colIndex] = textBoxJM.Text;

                rowIndex = 31; colIndex = 2;
                excelApp.Cells[rowIndex, colIndex] = textBoxPozicija.Text;

                rowIndex = 18; colIndex = 1;
                excelApp.Cells[rowIndex, colIndex] = textBoxImeFirme.Text;

                rowIndex = 19; colIndex = 1;
                excelApp.Cells[rowIndex, colIndex] = textBoxUlica.Text;

                rowIndex = 20; colIndex = 1;
                excelApp.Cells[rowIndex, colIndex] = textBoxMjesto.Text;

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
                File.AppendAllText(Application.StartupPath + "\\Fakture\\data", Environment.NewLine + textBoxBrojFakture.Text);
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
        public void SigurnosnoSpremanje()
        {
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Fakture\\SafeBase.mdb";

            //----------SQL instrukcija-----------\\
            string sql = "SELECT * FROM TableSafeBase";

            //klase za povezivanje na ACCESS bazu podataka//
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\

            conn.Open();  //otvara spoj s bazom podataka

            //\\//\\//\\ **podaci** //\\//\\//\\
            string firma = textBoxImeFirme.Text;
            string pdv = textBoxPDV.Text;
            string CijenaTure = textBoxCijenaTure.Text;
            string JedinicnaMjera = textBoxJM.Text;
            string ulica = textBoxUlica.Text;
            string mjesto = textBoxMjesto.Text;
            string OIB = textBoxOIB.Text;
            string DVO = textBoxDVO.Text;
            string DatumValute = textBoxValuta.Text;
            string BrFakture = textBoxBrojFakture.Text;
            string Kolicina = textBoxKolicina.Text;
            string Cijena = textBoxCijena.Text;
            string Relacija = textBoxRelacija.Text;
            string Pozicija = textBoxPozicija.Text;
            string Kombi = comboBox1.Text;
            string Vozac = comboBoxVozač.Text;
            string Napomena = textBoxNapomena.Text;
            string PutDoOtvoreneFakture = "";

            string KilometriTxtBox = textBoxKilometri.Text.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string CestarinaTxtBox = textBoxCestarina.Text.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string UdioVozacuTxtBox = textBoxVozacu.Text.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string UdioNamaTxtBox = textBoxNama.Text.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string GorivoTxtBox = textBoxGorivo.Text.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\

            //spremanje
            string inDB = "INSERT INTO TableSafeBaseNovaFirma (PDV,CijenaTure,JedinicnaMjera,ImeFirme,Ulica,Mjesto,OIB,DVO,DatumValute,BrFakture,Kolicina,Cijena,Relacija,Pozicija,Kombi,Vozac,Kilometri,Cestarina,UdioVozacu,UdioNama,Gorivo,Napomena,Faktura) " +
                              "VALUES ('" + pdv + "','" + CijenaTure + "','" + JedinicnaMjera + "','" + firma + "','" + ulica + "','" + mjesto + "','" + OIB + "','" + DVO + "','" + DatumValute + "','" + BrFakture + "','" + Kolicina + "','" + Cijena + "','" + Relacija + "','" + Pozicija + "','" + Kombi + "','" + Vozac + "','" + KilometriTxtBox + "','" + CestarinaTxtBox + "','" + UdioVozacuTxtBox + "','" + UdioNamaTxtBox + "','" + GorivoTxtBox + "','" + Napomena + "','" + PutDoOtvoreneFakture + "')";

            OleDbCommand upis = new OleDbCommand(inDB, conn);
            upis.ExecuteNonQuery();
            conn.Close();

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
        private void spremi_Click(object sender, EventArgs e)
        {
        //    try
        //    {
                SigurnosnoSpremanje();
                SpremanjeFaktura();
                SpremanjeKombi();
            this.Close();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Došlo je do greške!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //    finally
        //    {

        //    }


    }

        private void textBrFakture_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxBrojFakture_TextChanged(object sender, EventArgs e)
        {
            textBoxBrFakture.Text = textBoxBrojFakture.Text;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBoxDatum_Click(object sender, EventArgs e)
        {

        }

        private void textBoxDatum_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBoxDatum.Text = monthCalendar1.SelectionEnd.ToShortDateString();
        }

        private void textBoxValuta_TextChanged(object sender, EventArgs e)
        {
            textBoxDatum.Text = textBoxValuta.Text;
        }

        private void FormNovaFirma_Load(object sender, EventArgs e)
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

        private void dateTimePickerOd_ValueChanged(object sender, EventArgs e)
        {
            textBoxDatumOd.Text = dateTimePickerOd.Value.ToShortDateString();
        }

        private void dateTimePickerDo_ValueChanged(object sender, EventArgs e)
        {
            textBoxDatumDo.Text = dateTimePickerDo.Value.ToShortDateString();
        }

        private void radioPlaceno_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonPopuniPremaPredlosku_Click(object sender, EventArgs e)
        {
            //vraćanje vrijednosti
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Fakture\\SafeBase.mdb";

            //----------SQL instrukcija-----------\\
            string sql = "SELECT * FROM TableSafeBaseNovaFirma";

            //klase za povezivanje na ACCESS bazu podataka//
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            OleDbCommand cmnd = new OleDbCommand(sql, conn);
            conn.Open();  //otvara spoj s bazom podataka

            try
            {
                using (OleDbDataReader Read = cmnd.ExecuteReader())
                {
                    while (Read.Read())
                    {
                        textBoxJM.Text = (Read["JedinicnaMjera"].ToString());
                        textBoxPDV.Text = (Read["PDV"].ToString());
                        textBoxCijenaTure.Text = (Read["CijenaTure"].ToString());
                        textBoxImeFirme.Text = (Read["ImeFirme"].ToString());
                        textBoxUlica.Text = (Read["Ulica"].ToString());
                        textBoxMjesto.Text = (Read["Mjesto"].ToString());
                        textBoxOIB.Text = (Read["OIB"].ToString());
                        textBoxDVO.Text = (Read["DVO"].ToString());
                        textBoxValuta.Text = (Read["DatumValute"].ToString());
                        textBoxBrojFakture.Text = (Read["BrFakture"].ToString());
                        textBoxKolicina.Text = (Read["Kolicina"].ToString());
                        textBoxCijena.Text = (Read["Cijena"].ToString());
                        textBoxRelacija.Text = (Read["Relacija"].ToString());
                        textBoxPozicija.Text = (Read["Pozicija"].ToString());
                        comboBox1.Text = (Read["Kombi"].ToString());
                        comboBoxVozač.Text = (Read["Vozac"].ToString());
                        textBoxKilometri.Text = (Read["Kilometri"].ToString());
                        textBoxCestarina.Text = (Read["Cestarina"].ToString());
                        textBoxVozacu.Text = (Read["UdioVozacu"].ToString());
                        textBoxNama.Text = (Read["UdioNama"].ToString());
                        textBoxGorivo.Text = (Read["Gorivo"].ToString());
                        textBoxNapomena.Text = (Read["Napomena"].ToString());

                    }
                }
                //brisanje nepotrebnog
                //OleDbCommand brisanje = new OleDbCommand("DELETE * FROM TableSafeBase", conn);
                //brisanje.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške!");
                MessageBox.Show(ex.ToString());

            }
        }

    }
}