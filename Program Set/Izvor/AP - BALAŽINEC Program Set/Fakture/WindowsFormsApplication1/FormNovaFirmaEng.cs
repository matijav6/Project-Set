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
    public partial class FormNovaFirmaEng : Form
    {
        public FormNovaFirmaEng()
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
            string put = System.IO.File.ReadAllText(Application.StartupPath + "\\Fakture\\PutFakture.txt");
            string putanjaDoNoveFakture = Application.StartupPath + "\\Fakture\\NOVA_ENG.xlsx";
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
                excelApp.Cells[rowIndex, colIndex] = textBoxRelacija.Text;

                rowIndex = 30; colIndex = 3;
                excelApp.Cells[rowIndex, colIndex] = textBoxJM.Text;

                rowIndex = 17; colIndex = 1;
                excelApp.Cells[rowIndex, colIndex] = textBoxImeFirme.Text;

                rowIndex = 18; colIndex = 1;
                excelApp.Cells[rowIndex, colIndex] = textBoxUlica.Text;

                rowIndex = 19; colIndex = 1;
                excelApp.Cells[rowIndex, colIndex] = textBoxMjesto.Text;

                rowIndex = 26; colIndex = 2;
                excelApp.Cells[rowIndex, colIndex] = textBoxPozicija.Text;

                rowIndex = 30; colIndex = 9;
                string PDV = textBoxPDV.Text.Replace("%", "");
                excelApp.Cells[rowIndex, colIndex] = PDV + "%";

                string euro = textBoxEur.Text;
                if (euro.Contains('.'))
                {
                    textBoxEur.Text = euro.Replace('.', ',');
                }

                double UkupnaCijenaBezPDV = Convert.ToDouble(textBoxKolicina.Text) * Convert.ToDouble(textBoxCijena.Text);
                double UkupnaCijenaPDV = UkupnaCijenaBezPDV * (Convert.ToDouble(textBoxPDV.Text) / 100);
                double KonačnaCijena = UkupnaCijenaBezPDV + UkupnaCijenaPDV; 
               double eur = KonačnaCijena / Convert.ToDouble(textBoxEur.Text);

                excelApp.Cells[34, 6] = eur;

                var datum = Convert.ToDateTime(textBoxDatum.Text);
                string datumPrikaz = datum.ToShortDateString();

                int mjesec = datum.Month;
                int godina = datum.Year;

                string dira = put + textBoxImeFirme.Text + "\\" + textBoxRelacija.Text + "\\" + mjesec + "-" + godina + "\\PLAČENO\\";

                string dirNea = put + textBoxImeFirme.Text + "\\" + textBoxRelacija.Text + "\\" + mjesec + "-" + godina + "\\NEPLAČENO\\";

                string dir = dira.Replace("\\\\", "\\");
                string dirNe = dirNea.Replace("\\\\", "\\");

                spremanje = dir + textBoxBrFakture.Text + "  " + textBoxDatum.Text + ".xlsx";
                spremanjeNe = dirNe + textBoxBrFakture.Text + "  " + textBoxDatum.Text + ".xlsx";

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

                File.AppendAllText(Application.StartupPath + "\\Fakture\\data", System.Environment.NewLine + textBoxBrojFakture.Text);
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
            }
            catch(Exception ex)
            {
                MessageBox.Show("Došlo je do greške!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }
        }

        private void FormNovaFirmaEng_Load(object sender, EventArgs e)
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

        private void textBoxEur_TextChanged(object sender, EventArgs e)
        {
            string n = textBoxEur.Text;
            float val;
            if ((!(float.TryParse(n, out val))) && textBoxEur.Text.Length != 0)
            {
                MessageBox.Show("Samo brojevi!");
                textBoxEur.Clear();
            }            
        }
    }
}
