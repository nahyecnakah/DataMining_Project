using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veri_Madenciligi_Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\DataSet.xlsx;Extended Properties='Excel 12.0 Xml; HDR = YES;IMEX=1;'");

            OleDbDataAdapter da = new OleDbDataAdapter("Select * from [Sayfa1$]", conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt != null)
            {
                int a = dt.Columns.Count;

                dataGridView1.DataSource = dt;
            }
        }
    }
}
