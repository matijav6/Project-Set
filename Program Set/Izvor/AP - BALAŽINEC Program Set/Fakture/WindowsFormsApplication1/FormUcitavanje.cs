using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace WindowsFormApplication1
{
    public partial class FormUcitavanje : Form
    {
        public FormUcitavanje()
        {
            InitializeComponent();
        }

        Excel.Application ExcelObj = null;
        Excel.Workbook theWorkbook;
        Excel.Sheets sheets;
        Excel.Worksheet worksheet;
        Excel.Application excelApp;

        FormSpremanje formSpremanje = new FormSpremanje();
        AP_Balažinec formHome = new AP_Balažinec();
        public string OtvorenaFaktura { get; set; }
        public string[] dirs { get; set; }
        string STRtražiRelaciju;
        string STRte;
        string ImeRelacije;
        int provjeraRelacija = 0;
        
        public void UcitavanjeFaktura()
        {
            try
            {                // umetanje vrijednosti
                ExcelObj = new Microsoft.Office.Interop.Excel.Application();
                excelApp = new Excel.Application();
                theWorkbook = ExcelObj.Workbooks.Open(OtvorenaFaktura, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
                sheets = theWorkbook.Worksheets;
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(1);
                
                //cijena                 
                for (int red = 26; red <= 31; red++)
                {
                    var traži = (worksheet.Cells[red, 6] as Microsoft.Office.Interop.Excel.Range).Value;
                    string STRtraži = Convert.ToString(traži);

                    string n = STRtraži;
                    float val;
                    if (((float.TryParse(n, out val))) && STRtraži.Length != 0)
                    {
                        File.WriteAllText(Application.StartupPath + "\\Cijena", STRtraži);

                        //rabat i PDV
                        try
                        {
                            var te = (worksheet.Cells[red, 10] as Microsoft.Office.Interop.Excel.Range).Value;
                            STRte = Convert.ToString(te);
                            if (STRte.Length == 0)
                            {
                                var rabata = (worksheet.Cells[red, 9] as Microsoft.Office.Interop.Excel.Range).Value;
                                string STRrabata = Convert.ToString(rabata);

                            }
                        }
                        catch {
                            var rabata = (worksheet.Cells[red, 9] as Microsoft.Office.Interop.Excel.Range).Value;
                            string STRrabata = Convert.ToString(rabata);
                            File.WriteAllText(Application.StartupPath + "\\PDV", STRrabata);
                            goto dalje;
                        }


                        var rabat = (worksheet.Cells[red, 9] as Microsoft.Office.Interop.Excel.Range).Value;
                            string STRrabat = Convert.ToString(rabat);
                            File.WriteAllText(Application.StartupPath + "\\rabat", STRrabat);

                            var PDV = (worksheet.Cells[red, 10] as Microsoft.Office.Interop.Excel.Range).Value;
                            string STRPDV = Convert.ToString(PDV);
                            File.WriteAllText(Application.StartupPath + "\\PDV", STRPDV);
                        dalje:
                        break;
                    }
                }

                //pozicija
                for (int stupac = 1; stupac <= 5; stupac++)
                {
                    for (int red = 26; red <= 34; red++)
                    {
                        var trazi = (worksheet.Cells[red, stupac] as Microsoft.Office.Interop.Excel.Range).Value;
                        string STRtrazi = Convert.ToString(trazi);
                        if (STRtrazi != null)
                        {
                            if ((STRtrazi.Contains("Pozicija:") || STRtrazi.Contains("POZICIJA:")) && STRtrazi.Length != 0)
                            {
                                var trazi1 = (worksheet.Cells[red, stupac + 1] as Microsoft.Office.Interop.Excel.Range).Value;
                                string STRtrazi1 = Convert.ToString(trazi1);

                                if (STRtrazi1 == null)
                                    File.WriteAllText(Application.StartupPath + "\\Pozicija", STRtrazi);

                                else
                                    File.WriteAllText(Application.StartupPath + "\\Pozicija", STRtrazi1);
                                break;
                            }
                        }
                    }
                }

                //relacija  
                for (int stupac = 1; stupac <= 3; stupac++)
                {
                    for (int red = 26; red <= 31; red++)
                    {
                        var traži = (worksheet.Cells[red, stupac] as Microsoft.Office.Interop.Excel.Range).Value;
                        STRtražiRelaciju = Convert.ToString(traži);

                        if (STRtražiRelaciju != null)
                        {
                            if (STRtražiRelaciju == ImeRelacije || STRtražiRelaciju.Contains("-"))
                            {
                                //Ne može prenašati vrijednosti u aktivni form
                                File.Delete(Application.StartupPath + "\\RelacijaIme");
                                File.WriteAllText(Application.StartupPath + "\\StupacRelacija", stupac.ToString());
                               File.WriteAllText(Application.StartupPath + "\\Relacija", STRtražiRelaciju);
                                File.WriteAllText(Application.StartupPath + "\\RedRelacija", red.ToString());
                                provjeraRelacija++;
                                goto kraj;
                            }
                            
                        }
                       
                    }

                }
                if (provjeraRelacija == 0)
                {
                    MessageBox.Show("Došlo je do otvaranja neočekivane fakture,program će se resetirati.");

                    File.AppendAllText(Application.StartupPath + "\\Fakture\\FaktureNepodobneZaUcitavanje", Environment.NewLine + OtvorenaFaktura);
                    provjeraRelacija++;
                    Zatvaranje();
                    Application.Restart();
                }
            kraj:
                this.Refresh();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                if (provjeraRelacija < 2)
                {
                    MessageBox.Show("Došlo je do otvaranja neočekivane fakture,program će se resetirati.");
                    

                    File.AppendAllText(Application.StartupPath + "\\Fakture\\FaktureNepodobneZaUcitavanje", Environment.NewLine + OtvorenaFaktura);
                    Zatvaranje();
                    Application.Restart();
                }
            }
        }        
        public void Zatvaranje()
        {
            try
            {                
                Marshal.ReleaseComObject(ExcelObj);
                Marshal.ReleaseComObject(theWorkbook);
                Marshal.ReleaseComObject(sheets);
                Marshal.ReleaseComObject(worksheet);
                File.Delete(Application.StartupPath + "\\Cijena");
                File.Delete(Application.StartupPath + "\\Relacija");
                File.Delete(Application.StartupPath + "\\StupacRelacija");
                File.Delete(Application.StartupPath + "\\RedRelacija");
                File.Delete(Application.StartupPath + "\\RelacijaIme");
                File.Delete(Application.StartupPath + "\\Pozicija");

                foreach (Process proc in Process.GetProcessesByName("EXCEL"))
                {
                    proc.Kill();
                }
            }
            catch { }
        }

        private void FormUcitavanje_Shown(object sender, EventArgs e)
        {
            try
            {
                ImeRelacije = File.ReadAllText(Application.StartupPath + "\\RelacijaIme");
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Interval = 2000;
                timer.Start();                
                UcitavanjeFaktura();
                this.Close();
            }
           catch(FileNotFoundException)
            {
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Interval = 2000;
                timer.Start();
                ImeRelacije = "-";
                UcitavanjeFaktura();
                this.Close();
            }
            //catch (exception ex)
            //{
            //    messagebox.show("došlo je do greške!");
            //    messagebox.show(ex.tostring());
            //    file.delete(application.startuppath + "\\cijena");
            //    file.delete(application.startuppath + "\\relacija");
            //    file.delete(application.startuppath + "\\stupacrelacija");
            //    file.delete(application.startuppath + "\\redrelacija");
            //    file.delete(application.startuppath + "\\relacijaime");
            //    file.delete(application.startuppath + "\\pozicija");
            //    zatvaranje();
            //    application.restart();
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormUcitavanje_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
