using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.OleDb;
using System.Diagnostics;

namespace Cijene
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }


        Excel.Application ExcelObj;
        Excel.Workbook theWorkbook;
        Excel.Sheets sheets;
        Excel.Worksheet worksheet;
        Excel.Application excelApp;

        OleDbConnection conn;

        string dat, postanskiBrojUcitavanje, tablica, cijena_str, connString;
        double cijena;
        int stupacCBM, stupacZIP, stupacCijena, redCBM = 2, redZIP = 2, brojStupca;
        char stupac_chr = 'A';

        public void SigurnoPokretanje()
        {
            int i = 0;
            foreach (Process proc in Process.GetProcessesByName("EXCEL"))
            {
                i++;
            }
            if (i > 0)
            {
                if (MessageBox.Show("Pronađena je otvorena excel datoteka, da bi program radio morate ju zatvoriti. Želite li ju zatvoriti?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (Process proc in Process.GetProcessesByName("EXCEL"))
                    {
                        proc.Kill();
                    }

                }

            }
             connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Evidencija otpremnica\\Cijene.mdb";
            // string connString = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=|DataDirectory|\\Evidencija otpremnica\\Cijene.mdb";

            conn = new OleDbConnection(connString);
            try
            {
                conn.Open();
            }

            catch
            {
                //baza je već otvorena, pa ne treba opet
            }
        }

        public void BrojStupca_CHR(int kriterij_do)
        {
            stupac_chr = 'A';

            for (int i = 1; i < kriterij_do; i++)
            {
                stupac_chr++;
            }
        }
        public void StupacCHR_BrojStupca(char kriterij_do)
        {
            brojStupca = 1;
            for (char i = 'A'; i < kriterij_do; i++)
            {
                brojStupca++;
            }
        }
        //1 - prvo učitamo stupce
        public void DobijStupce()
        {
            ExcelObj = new Excel.Application();
            excelApp = new Excel.Application();
            theWorkbook = ExcelObj.Workbooks.Open(dat, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
            sheets = theWorkbook.Worksheets;
            worksheet = (Excel.Worksheet)sheets.get_Item(1);

            excelApp.Workbooks.Open(dat);

            for (int stupac = 1; stupac <= 25; stupac++)
            {
                var xlStupac = (worksheet.Cells[1, stupac] as Excel.Range).Value;
                string xlStupac_str = Convert.ToString(xlStupac);
                
                //za dobivanje stupca za kubike
                if (xlStupac_str == "Total Gross Volume")
                {
                    stupacCBM = stupac;
                    BrojStupca_CHR(stupacCBM);
                    textBoxCBM.Text = stupac_chr.ToString();

                }
                //else if (xlStupac_str.Contains("Volume"))
                //{
                //    stupacCBM = stupac;
                //}

                //za dobivanje stupca za ZIP
                else if (xlStupac_str == "Destination Postal Code")
                {
                    stupacZIP = stupac;
                    BrojStupca_CHR(stupacZIP);
                    textBoxZIP.Text = stupac_chr.ToString();
                }
               //else if (xlStupac_str.Contains("Postal"))
               // {
               //     stupacZIP = stupac;
               // }

                else if (xlStupac_str == null)
                {
                    stupacCijena = stupac;
                    BrojStupca_CHR(stupacCijena);
                    textBoxCijene.Text = stupac_chr.ToString();
                    break;
                }

            }
        }

        private void textBoxCBM_DoubleClick(object sender, EventArgs e)
        {
            
            MessageBox.Show(stupac_chr.ToString());
        }

        //2.1.
        public void DobijCijenu(double postanskiBroj, double cbm)
        {
            if (postanskiBroj > 10000)
                goto kraj;
             
                for (int x = 2; x <= 100; x++)
            {
                if (postanskiBroj >= 1000 && postanskiBroj < 2000) postanskiBrojUcitavanje = "1000";
                else if (postanskiBroj >= 2000 && postanskiBroj < 3000) postanskiBrojUcitavanje = "2000";
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
                
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //gotova cijena, spremna za upis u xl
                    cijena_str = reader[0].ToString();
                    cijena = Convert.ToDouble(cijena_str) * cbm;
                    goto kraj;
                }
            }
            kraj:
            Refresh();
        }

        //2 - nakon učitanih stupaca trebamo dobiti cijenu
        public void UcitajZIPiCBM()
        {

            StupacCHR_BrojStupca(Convert.ToChar(textBoxCBM.Text));
            stupacCBM = brojStupca;

            StupacCHR_BrojStupca(Convert.ToChar(textBoxZIP.Text));
            stupacZIP = brojStupca;

            StupacCHR_BrojStupca(Convert.ToChar(textBoxCijene.Text));
            stupacCijena = brojStupca;

            excelApp.Cells[1, stupacCijena] = "Cijena";

            progressBar1.Value = 0;
            int i = 17;
            while (i <= 100)
            {
                //dobivanje vrijednosti iz xl-a
                var kriterijCBM = (worksheet.Cells[redCBM, stupacCBM] as Excel.Range).Value;
                var kriterijZIP = (worksheet.Cells[redZIP, stupacZIP] as Excel.Range).Value;

                //dobivanje cijene iz BP
                double postanskiBroj = Convert.ToDouble(kriterijZIP);
                double cbm = Convert.ToDouble(kriterijCBM);
                
                DobijCijenu(postanskiBroj, cbm);

                if (cijena != 0)
                {
                    excelApp.Cells[redCBM, stupacCijena] = cijena;
                }
                progressBar1.Value = i;
                //prelazak na sljedeće
                redCBM++;
                redZIP++;
                i++;
            }

        }

        private void button_UcitajStupce_Click(object sender, EventArgs e)
        {
            try
            {
                button_UcitajStupce.Hide();
                DobijStupce();
                button_UpisiCijene.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SigurnoPokretanje();
            button_UpisiCijene.Hide();
            button_UcitajStupce.Hide();
            label4.Hide();
            progressBar1.Hide();
        }

        private void button_UcitajExcelDatoteku_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "EXCEL datoteke (*.xlsx) | *.xlsx";
            OFD.ShowDialog();
            dat = OFD.FileName.ToString();
                        
            button_UcitajStupce.Show();
        }

        private void button_Zatvori_Click(object sender, EventArgs e)
        {
            Close();

            try
            {
                conn.Close();
                theWorkbook.Close(0);
                excelApp.ActiveWorkbook.Close();
                excelApp.Quit();
            }
            catch { }
        }

        private void button_UpisiCijene_Click(object sender, EventArgs e)
        {
            //try
            {
                button_UpisiCijene.Hide();
                progressBar1.Show();

                UcitajZIPiCBM();
                excelApp.ActiveWorkbook.Save();
                progressBar1.Hide();
                label4.Show();
            }
            //catch(Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }

           // try
            {
                theWorkbook.Close(0);
                excelApp.ActiveWorkbook.Close();
                excelApp.Quit();
            }
            //catch { }
            System.Diagnostics.Process.Start(dat);
            Close();
        }
    }
}
