using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PrintCMR_nmspace
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
        Excel.Application excelApp = new Excel.Application(); 
      
        
        public void SpremanjeFaktura()
        {
            string OtvorenaFaktura = Application.StartupPath + "\\CMR\\CMR.xlsx";


            //unos podataka
                ExcelObj = new Microsoft.Office.Interop.Excel.Application();
                theWorkbook = ExcelObj.Workbooks.Open(OtvorenaFaktura, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
                sheets = theWorkbook.Worksheets;
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(1);
            
                excelApp.Workbooks.Open(OtvorenaFaktura);
                
            var BrojOtpremnice = (worksheet.Cells[1, 10] as Microsoft.Office.Interop.Excel.Range).Value;
            int NoviBrojOtpremnice = Convert.ToInt16(BrojOtpremnice) + 1;
            
                excelApp.Cells[1, 10] = NoviBrojOtpremnice;

            excelApp.ActiveWorkbook.Save();
            theWorkbook.Close(0);            
            excelApp.Quit();
            foreach (Process proc in Process.GetProcessesByName("EXCEL"))
            {
                proc.Kill();
            }
            Process.Start(OtvorenaFaktura);
            }
        private void FormSpremanje_Shown(object sender, EventArgs e)
        {            
            try
            {
                SpremanjeFaktura();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške prilikom spremanja!");
                MessageBox.Show(ex.ToString());         
                Close();
            }
        }

        private void FormSpremanje_Load(object sender, EventArgs e)
        {

        }
      
    }
}
