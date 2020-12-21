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
using Veri_Madenciligi_Proje.CLASS;

namespace Veri_Madenciligi_Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection conn;
        OleDbDataAdapter da;
        DataTable dt;

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\DataSet.xlsx;Extended Properties='Excel 12.0 Xml; HDR = YES;IMEX=1;'");

            da = new OleDbDataAdapter("Select * from [Sayfa1$]", conn);

            dt = new DataTable();

            da.Fill(dt);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }

        private void btnRegression_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Regression reg = new Regression();

                reg.y_avg = reg.get_y_Avg(dt);                  // y ort değerleri bul
                reg.Rt = reg.get_Rt_Squared(dt);                // Rt bul
                reg.Sub_X = new List<Sub_Regression_For_X>();

                reg.get_deltaR_for_Attributes(dt);               // Tüm Attributeler için Delta R değerlerini bul 
            }
        }
    }
}
