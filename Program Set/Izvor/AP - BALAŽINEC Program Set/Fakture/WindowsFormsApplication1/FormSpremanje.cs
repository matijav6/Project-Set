using System;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsFormApplication1
{
    public partial class    FormSpremanje : Form
    {
        public FormSpremanje()
        {
            InitializeComponent();
        }

        Microsoft.Office.Interop.Excel.Application ExcelObj = null;
        Microsoft.Office.Interop.Excel.Workbook theWorkbook;
        Microsoft.Office.Interop.Excel.Sheets sheets;
        Microsoft.Office.Interop.Excel.Worksheet worksheet;
        Excel.Application excelApp; 
       
        //najava varijabli komponenata s Form1
        public string Registracija { get; set; }
        public string comboBoxVozač { get; set; }
        public string DatumOd { get; set; }
        public string DatumDo { get; set; }
        public string CijenaTure { get; set; }
        public string Cestarina { get; set; }
        public string Kilometri { get; set; }
        public string Gorivo { get; set; }
        public string Potrosnja { get; set; }
        public string Vozacu { get; set; }
        public string Nama { get; set; }
        public string Napomena { get; set; }
        public string DatumDvo { get; set; }
        public string DatumValuta { get; set; }
        public string BrojFakture { get; set; }
        public string CijenaFakture { get; set; }
        public string Kolicina { get; set; }
        public string Relacija { get; set; }
        public int RedRelacija { get; set; }
        public int StupacRelacija { get; set; }
        public string Pozicija { get; set; }
        public string OtvorenaFaktura { get; set; }
        public double rabat { get; set; }
        public string PDV { get; set; }
        public string PutanjaOtvoreneFakture { get; set; }
       public bool NovaRuta { get; set; }
       public bool Placeno { get; set; }

       string SpremljenaFaktura;

        string SpremljenaBaza;
        public void SpremanjeKombi()
        {     

            Zbrajanje();
            double ukupno = Convert.ToDouble(Cestarina) + Convert.ToDouble(Nama) + Convert.ToDouble(Vozacu) + Convert.ToDouble(Gorivo);
            CijenaTure = ukupno.ToString();

            

            PripremaZaSpremanje();

            if(!File.Exists(Application.StartupPath + "\\Vozila\\" + Registracija + ".mdb"))
            {
                File.Copy(Application.StartupPath + "\\Fakture\\BazaKombi.mdb", Application.StartupPath + "\\Vozila\\" + Registracija + ".mdb");
            }
            
            SpremljenaBaza = Application.StartupPath + "\\Vozila\\" + Registracija + ".mdb";            

            //Saving to DataBase  
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + SpremljenaBaza;

            string sql = "SELECT * FROM Table1";

            OleDbConnection conn = new OleDbConnection(connString);
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

            conn.Open();

            string inDB = "INSERT INTO Table1 (Kombi,Vozac,Gorivo,Cestarina,Nama,Vozacu,Kilometri,DatumOd,DatumDo,UkupnaCijena,Napomena,Potrosnja) " +
                          "VALUES ('" + Registracija + "','" + comboBoxVozač + "'," + Gorivo + "," + Cestarina + "," + Nama + "," + Vozacu + "," + Kilometri + ",'" + DatumOd + "','" + DatumDo + "'," + CijenaTure + ",'" + Napomena + "','"+Potrosnja+"')";


            OleDbCommand upis = new OleDbCommand(inDB, conn);
            upis.ExecuteNonQuery();
            conn.Close();

            
       
        }
        public void Zbrajanje()
        {
            string cestrina = Cestarina;
            if (Cestarina.Contains('.'))
            {
                Cestarina = cestrina.Replace(".", ",");
            }
            string kilometri = Kilometri;

            if (kilometri.Contains('.'))
            {
                Kilometri = kilometri.Replace(".", ",");
            }
            string potrosnja = Potrosnja;

            if (potrosnja.Contains('.'))
            {
                Potrosnja = potrosnja.Replace(".", ",");
            }
            string UdioVozaču = Vozacu;

            if (UdioVozaču.Contains('.'))
            {
                Vozacu = Vozacu.Replace(".", ",");
            }
            string UdioNama = Nama;

            if (UdioNama.Contains('.'))
            {
                Nama = Nama.Replace(".", ",");
            }
            string gorivo = Gorivo;

            if (gorivo.Contains('.'))
            {
                Gorivo = gorivo.Replace(".", ",");
            }

        }
        public void PripremaZaSpremanje()
        {
            string cestrina = Cestarina;
            if (cestrina.Contains(','))
            {
                Cestarina = Cestarina.Replace(",", ".");
            }
            string kilometri = Kilometri;

            if (kilometri.Contains(','))
            {
                Kilometri = Kilometri.Replace(",", ".");
            }
            string cijenaTure = CijenaTure;

            if (cijenaTure.Contains(','))
            {
                CijenaTure = cijenaTure.Replace(",", ".");
            }
            string UdioVozaču = Vozacu;

            if (UdioVozaču.Contains(','))
            {
                Vozacu = Vozacu.Replace(",", ".");
            }
            string UdioNama = Nama;

            if (UdioNama.Contains(','))
            {
                Nama = Nama.Replace(",", ".");
            }
            string gorivo = Gorivo;

            if (gorivo.Contains(','))
            {
                Gorivo = gorivo.Replace(",", ".");
            }
            string potrosnja = Potrosnja;

            if (potrosnja.Contains(','))
            {
                Potrosnja = potrosnja.Replace(",", ".");
            }
        }
        public void SpremanjeZaSyncBaza()
        {
            ////For syncing with other local computers
            //if (SpremljenaBaza.Length != 0)
            //{
            //    string ime = Path.GetFileNameWithoutExtension(SpremljenaBaza);
            //    string put = Application.StartupPath + "\\tmp\\" + ime + ".txt";
            //    File.WriteAllText(put, SpremljenaBaza);
            //}
        }
        public void SpremanjeZaSync()
        {
            //if (SpremljenaFaktura.Length != 0)
            //{
            //    string ime = Path.GetFileNameWithoutExtension(SpremljenaFaktura);
            //    string put = Application.StartupPath + "\\tmp\\" + ime + ".txt";
            //    File.WriteAllText(put, SpremljenaFaktura);
            //}
        }
        public void Zatvaranje()
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("EXCEL"))
                {
                    proc.Kill();
                }
                Marshal.ReleaseComObject(ExcelObj);
                Marshal.ReleaseComObject(theWorkbook);
                Marshal.ReleaseComObject(sheets);
                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(excelApp);
                excelApp.ActiveWorkbook.Close(0);
            theWorkbook.Close(0);
                excelApp.Quit();
                ExcelObj.Quit();
            }
            catch { }
        }
        public void SpremanjeFaktura()
        {

            //unos podataka
                ExcelObj = new Microsoft.Office.Interop.Excel.Application();
            excelApp = new Excel.Application();
                theWorkbook = ExcelObj.Workbooks.Open(OtvorenaFaktura, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
                sheets = theWorkbook.Worksheets;
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(1);

                int rowIndex, colIndex;
                excelApp.Workbooks.Open(OtvorenaFaktura);

                //DVO
                var qa = (worksheet.Cells[18, 6] as Microsoft.Office.Interop.Excel.Range).Value;
                string slovoqa = Convert.ToString(qa);
                if (slovoqa == "Datum valute:")
                {
                    rowIndex = 17; colIndex = 8;
                    excelApp.Cells[rowIndex, colIndex] = DatumDvo;                    
                }
                else
                    rowIndex = 18; colIndex = 8;
                excelApp.Cells[rowIndex, colIndex] = DatumDvo;



                //valuta
                var qb = (worksheet.Cells[19, 6] as Microsoft.Office.Interop.Excel.Range).Value;
                string slovoqb = Convert.ToString(qb);
                if (slovoqb == "Vrijeme:")
                {
                    rowIndex = 18; colIndex = 8;
                    excelApp.Cells[rowIndex, colIndex] = DatumValuta;
                }
                else
                    rowIndex = 19; colIndex = 8;
                excelApp.Cells[rowIndex, colIndex] = DatumValuta;

                //faktura
                var q = (worksheet.Cells[22, 6] as Microsoft.Office.Interop.Excel.Range).Value;
                string slovoq = Convert.ToString(q);
                if (slovoq == "OIB:" || slovoq == "oib:" || slovoq == "Oib:")
                {
                    rowIndex = 21; colIndex = 7;
                    excelApp.Cells[rowIndex, colIndex] = BrojFakture;
                }
                else
                    rowIndex = 22; colIndex = 7;
                excelApp.Cells[rowIndex, colIndex] = BrojFakture;


                //cijena, količina, rabat i PDV
                for (int red = 26; red <= 31; red += 1)
                {
                    var trazi = (worksheet.Cells[red, 6] as Microsoft.Office.Interop.Excel.Range).Value;

                    string STRtrazi = Convert.ToString(trazi);
                    float val;
                    if (((float.TryParse(STRtrazi, out val))) && STRtrazi.Length != 0)
                    {
                        excelApp.Cells[red, 6] = CijenaFakture;
                        excelApp.Cells[red, 5] = Kolicina;

                    if (rabat != 0)
                    {
                        excelApp.Cells[red, 9] = Convert.ToDouble(rabat);
                        excelApp.Cells[red, 10] = Convert.ToDouble(PDV);
                    }
                    else
                    {
                        excelApp.Cells[red, 9] = Convert.ToDouble(PDV);
                    }
                    break;
                    }

                }

                //relacija      
                string RedRelacija = File.ReadAllText(Application.StartupPath + "\\RedRelacija");
                string StupacRelacija = File.ReadAllText(Application.StartupPath + "\\StupacRelacija");
                excelApp.Cells[Convert.ToInt16(RedRelacija), Convert.ToInt16(StupacRelacija)] = Relacija;
                File.Delete(Application.StartupPath + "\\RedRelacija");
                File.Delete(Application.StartupPath + "\\StupacRelacija");

                //pozicija
                for (int stupac = 1; stupac <= 5; stupac++)
                {
                    for (int red = 26; red <= 34; red++)
                    {
                        var trazi = (worksheet.Cells[red, stupac] as Microsoft.Office.Interop.Excel.Range).Value;
                        string STRtrazi = Convert.ToString(trazi);

                        Boolean equals = String.Equals(STRtrazi, "Pozicija:", StringComparison.OrdinalIgnoreCase);
                        if (equals == true)
                        {
                            excelApp.Cells[red, stupac + 1] = Pozicija;
                        //MessageBox.Show(red + " " + stupac);
                            break;
                        }
                    }
                }
                var datum = Convert.ToDateTime(DatumDvo);

                int mjesec = datum.Month;
                int godina = datum.Year;


            FileInfo fInfo = new FileInfo(PutanjaOtvoreneFakture);
                string strFilePath = fInfo.DirectoryName;
  
                //plačeno,postojeća relacija
                DirectoryInfo dirPlaceno = new DirectoryInfo(strFilePath + "\\" + mjesec + "-" + godina + "\\PLAČENO\\");
                string dir = Convert.ToString(dirPlaceno);

                //neplačeno,postojeća relacija
                DirectoryInfo dirNePlaceno = new DirectoryInfo(strFilePath + "\\" + mjesec + "-" + godina + "\\NEPLAČENO\\");
                string dirNe = Convert.ToString(dirNePlaceno);

                //plačeno,nova relacija
                DirectoryInfo dirPlacenoNovo = new DirectoryInfo(PutanjaOtvoreneFakture + "\\" + Relacija+ "\\" + mjesec + "-" + godina + "\\PLAČENO\\");
                string dirNovo1 = Convert.ToString(dirPlacenoNovo);
                string dirNovo = dirNovo1.Replace("\\\\", "\\");

                //neplačeno,nova relacija
                DirectoryInfo dirNePlacenoNovo = new DirectoryInfo(PutanjaOtvoreneFakture + "\\" + Relacija + "\\" + mjesec + "-" + godina + "\\NEPLAČENO\\");
                string dirNeNovo1 = Convert.ToString(dirNePlacenoNovo);
                string dirNeNovo = dirNeNovo1.Replace("\\\\", "\\");

                string open;

                //nova ruta
                if (NovaRuta == true)
                {
                    //stvori oba direktorija,PLAČENO i NEPLAČENO
                    dirPlacenoNovo.Create();
                    dirNePlacenoNovo.Create();

                    if (Placeno == true)
                    {

                        excelApp.ActiveWorkbook.SaveCopyAs(dirNovo + BrojFakture + "  " + DatumDvo + ".xlsx");
                        open = dirNovo + BrojFakture + "  " + DatumDvo + ".xlsx";

                    }


                    else
                    {
                        excelApp.ActiveWorkbook.SaveCopyAs(dirNeNovo + BrojFakture + "  " + DatumDvo + ".xlsx");
                        open = dirNeNovo + BrojFakture + "  " + DatumDvo + ".xlsx";

                    }                   
                }
                //normalna faktura,postojeća relacija
                else
                {
                    //stvori oba direktorija,PLAČENO i NEPLAČENO
                    dirNePlaceno.Create();
                    dirPlaceno.Create();

                    if (Placeno == true)
                    {
                        if (dirPlaceno.Exists)
                        {
                            excelApp.ActiveWorkbook.SaveCopyAs(dir + BrojFakture + "  " + DatumDvo + ".xlsx");
                            open = dir + BrojFakture + "  " + DatumDvo + ".xlsx";
                        }
                        //Ako taj direktorij ne postoji->napravi ga 
                        else
                        {
                            excelApp.ActiveWorkbook.SaveCopyAs(dir + BrojFakture + "  " + DatumDvo + ".xlsx");
                            open = dir + BrojFakture + "  " + DatumDvo + ".xlsx";
                        }
                    }

                   else
                    {
                        if (dirNePlaceno.Exists)
                        {
                            excelApp.ActiveWorkbook.SaveCopyAs(dirNe + BrojFakture + "  " + DatumDvo + ".xlsx");
                            open = dirNe + BrojFakture + "  " + DatumDvo + ".xlsx";
                        }
                        //Ako taj direktorij ne postoji->napravi ga 
                        else
                        {
                            excelApp.ActiveWorkbook.SaveCopyAs(dirNe + BrojFakture + "  " + DatumDvo + ".xlsx");
                            open = dirNe + BrojFakture + "  " + DatumDvo + ".xlsx";

                        }
                    }                  

                }
                //Otvaranje spremljene fakture
                SpremljenaFaktura = open.Replace("\\", "\\\\");
                SpremanjeZaSync();
                Zatvaranje();
                System.Diagnostics.Process.Start(SpremljenaFaktura);

                File.AppendAllText(Application.StartupPath + "\\Fakture\\data", Environment.NewLine + BrojFakture);
            }
        private void FormSpremanje_Shown(object sender, EventArgs e)
        {
            //System.Timers.Timer timer = new System.Timers.Timer();
            //timer.Interval = 1000;
            //timer.Start();
            try
            {
                 SpremanjeFaktura();
                SpremanjeKombi();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške prilikom spremanja!");
                MessageBox.Show(ex.ToString());
                File.AppendAllText(Application.StartupPath + "\\FaktureNepodobneZaUcitavanje", Environment.NewLine + OtvorenaFaktura);
                Zatvaranje();
                Application.Restart();
            }
        }

        private void FormSpremanje_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
