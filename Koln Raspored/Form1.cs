using Calendar.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Koln_Raspored
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        List<string> vozac1_ide, vozac1_nejde, vozac2_ide, vozac2_nejde, zamjena1_ide;
        List<string> ostaliVozac1_ide, ostaliVozac2_ide, ostaliVozac3_ide, ostaliVozac4_ide, ostaliVozac5_ide, ostaliVozac6_ide;
        private void Form1_Load(object sender, EventArgs e)
        {
            calendar1.CalendarDate = DateTime.Now;
            calendar1.CalendarView = CalendarViews.Month;
            calendar1.LoadPresetHolidays = false;

            vozac1_ide = loadDriver("Aleksandar");

            vozac2_ide = loadDriver("Hrvoje");

            zamjena1_ide = loadDriver("Marko");

            ostaliVozac1_ide = loadDriver("Nenad");

            ostaliVozac2_ide = loadDriver("Kruno");

            ostaliVozac3_ide = loadDriver("Darko");

            ostaliVozac4_ide = loadDriver("Sasa");

            ostaliVozac5_ide = loadDriver("Teo");

            ostaliVozac6_ide = loadDriver("Dubravko");


            var vozac1 = new CustomEvent
            {
                TooltipEnabled = false,
                IgnoreTimeComponent = true,
                ThisDayForwardOnly = false,
                ReadOnlyEvent = false,
                EventColor = Color.FromArgb(80, 170, 255),
                RecurringFrequency = RecurringFrequencies.Custom,
                EventText = "Aleksandar",
                Rank = 1,
                CustomRecurringFunction = glavniVozac1
            };
            calendar1.AddEvent(vozac1);

            var vozac2 = new CustomEvent
            {
                TooltipEnabled = false,
                IgnoreTimeComponent = true,
                ThisDayForwardOnly = false,
                ReadOnlyEvent = true,
                EventColor = Color.FromArgb(80, 170, 255),
                RecurringFrequency = RecurringFrequencies.Custom,
                EventText = "Hrvoje",
                Rank = 1,
                CustomRecurringFunction = glavniVozac2
            };
            calendar1.AddEvent(vozac2);

            var zamjena1 = new CustomEvent
            {
                TooltipEnabled = false,
                IgnoreTimeComponent = true,
                ThisDayForwardOnly = false,
                ReadOnlyEvent = true,
                EventColor = Color.FromArgb(80, 170, 255),
                RecurringFrequency = RecurringFrequencies.Custom,
                EventText = "Marko",
                Rank = 1,
                CustomRecurringFunction = vozacZamjena1
            };
            calendar1.AddEvent(zamjena1);
            
            var ostaliVozac1 = new CustomEvent
            {
                TooltipEnabled = false,
                IgnoreTimeComponent = true,
                ThisDayForwardOnly = false,
                ReadOnlyEvent = true,
                EventColor = Color.FromArgb(80, 170, 255),
                RecurringFrequency = RecurringFrequencies.Custom,
                EventText = "Nenad",
                Rank = 1,
                CustomRecurringFunction = ostaliVozaci1
            };
            calendar1.AddEvent(ostaliVozac1);

            var ostaliVozac2 = new CustomEvent
            {
                TooltipEnabled = false,
                IgnoreTimeComponent = true,
                ThisDayForwardOnly = false,
                ReadOnlyEvent = true,
                EventColor = Color.FromArgb(80, 170, 255),
                RecurringFrequency = RecurringFrequencies.Custom,
                EventText = "Kruno",
                Rank = 1,
                CustomRecurringFunction = ostaliVozaci2
            };
            calendar1.AddEvent(ostaliVozac2);

            var ostaliVozac3 = new CustomEvent
            {
                TooltipEnabled = false,
                IgnoreTimeComponent = true,
                ThisDayForwardOnly = false,
                ReadOnlyEvent = true,
                EventColor = Color.FromArgb(80, 170, 255),
                RecurringFrequency = RecurringFrequencies.Custom,
                EventText = "Darko",
                Rank = 1,
                CustomRecurringFunction = ostaliVozaci3
            };
            calendar1.AddEvent(ostaliVozac3);

            var ostaliVozac4 = new CustomEvent
            {
                TooltipEnabled = false,
                IgnoreTimeComponent = true,
                ThisDayForwardOnly = false,
                ReadOnlyEvent = true,
                EventColor = Color.FromArgb(80, 170, 255),
                RecurringFrequency = RecurringFrequencies.Custom,
                EventText = "Sasa",
                Rank = 1,
                CustomRecurringFunction = ostaliVozaci4
            };
            calendar1.AddEvent(ostaliVozac4);

            var ostaliVozac5 = new CustomEvent
            {
                TooltipEnabled = false,
                IgnoreTimeComponent = true,
                ThisDayForwardOnly = false,
                ReadOnlyEvent = true,
                EventColor = Color.FromArgb(80, 170, 255),
                RecurringFrequency = RecurringFrequencies.Custom,
                EventText = "Teo",
                Rank = 1,
                CustomRecurringFunction = ostaliVozaci5
            };
            calendar1.AddEvent(ostaliVozac5);            

            var ostaliVozac6 = new CustomEvent
            {                               
                TooltipEnabled = false,                
                IgnoreTimeComponent = true,
                ThisDayForwardOnly = false,
                ReadOnlyEvent = false,
                EventColor = Color.FromArgb(80, 170, 255),
                RecurringFrequency = RecurringFrequencies.Custom,
                EventText = "Dubravko",
                Rank = 1,
                CustomRecurringFunction = ostaliVozaci6
            };
            calendar1.AddEvent(ostaliVozac6);
            

        }

        [CustomRecurringFunction("Glavni vozači", "Računa svaki drugi tjedan")]
        private bool glavniVozac1(IEvent evnt, DateTime day)
        {
            string datum = day.Day + "." + day.Month + "." + day.Year.ToString() + ".";
            
            if (vozac1_ide.Contains(datum))
                return true;
            else
                return false;
        }
        private bool glavniVozac2(IEvent evnt, DateTime day)
        {
            string datum = day.Day + "." + day.Month + "." + day.Year.ToString() + ".";

            if (vozac2_ide.Contains(datum))
                return true;
            else
                return false;
        }

        private bool vozacZamjena1(IEvent evnt, DateTime day)
        {
            string datum = day.Day + "." + day.Month + "." + day.Year.ToString() + ".";

            if (zamjena1_ide.Contains(datum))
                return true;
            else
                return false;
        }

        private void buttonPomoc_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private bool ostaliVozaci1(IEvent evnt, DateTime day)
        {
            string datum = day.Day + "." + day.Month + "." + day.Year.ToString() + ".";

            if (ostaliVozac1_ide.Contains(datum))
                return true;
            else
                return false;
        }

        private bool ostaliVozaci2(IEvent evnt, DateTime day)
        {
            string datum = day.Day + "." + day.Month + "." + day.Year.ToString() + ".";

            if (ostaliVozac2_ide.Contains(datum))
                return true;
            else
                return false;
        }

        private bool ostaliVozaci3(IEvent evnt, DateTime day)
        {
            string datum = day.Day + "." + day.Month + "." + day.Year.ToString() + ".";

            if (ostaliVozac3_ide.Contains(datum))
                return true;
            else
                return false;
        }

        private bool ostaliVozaci4(IEvent evnt, DateTime day)
        {
            string datum = day.Day + "." + day.Month + "." + day.Year.ToString() + ".";

            if (ostaliVozac4_ide.Contains(datum))
                return true;
            else
                return false;
        }

        private bool ostaliVozaci5(IEvent evnt, DateTime day)
        {
            string datum = day.Day + "." + day.Month + "." + day.Year.ToString() + ".";

            if (ostaliVozac5_ide.Contains(datum))
                return true;
            else
                return false;
        }

        private bool ostaliVozaci6(IEvent evnt, DateTime day)
        {
            string datum = day.Day + "." + day.Month + "." + day.Year.ToString() + ".";

            if (ostaliVozac6_ide.Contains(datum))
                return true;
            else
                return false;
        }

        private void calendar1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Controls.Clear();
            this.InitializeComponent();
            this.Form1_Load(null, null);
        }

        static private List<string> loadDriver(string driver)
        {

            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|dataDirectory|\\bin\\vozaci.mdb";


            //----------SQL instrukcija-----------\\

            string sql = "SELECT * FROM " + driver;

            //klase za povezivanje na ACCESS bazu podataka//
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\

            DataSet ds = new DataSet();         //kreira noi objekt(kopiju) DataSet()-a
            conn.Open();
            List<String> datum_ide = new List<String>();

            OleDbDataReader reader = null;
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                datum_ide.Add(reader["datum_ide"].ToString());
            }

            conn.Close();                       //zatvara se baza podataka   
            return datum_ide;
        }



        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

    }
}
