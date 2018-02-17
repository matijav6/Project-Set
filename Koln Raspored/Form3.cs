using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Koln_Raspored
{
    public partial class FormZamjena : Form
    {
        public FormZamjena(string[] items)
        {
            InitializeComponent();
            
            for(int i = 0; i < items.Count(); i++)
                comboBox1.Items.Add(items[i]);
        }
        public string zamjena { get; set; }

        private void FormZamjena_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            zamjena = comboBox1.SelectedItem.ToString();            
            this.Close();
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
