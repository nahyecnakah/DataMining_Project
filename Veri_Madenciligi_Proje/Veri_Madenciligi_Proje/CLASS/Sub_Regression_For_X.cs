using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Veri_Madenciligi_Proje.CLASS
{
    public class Sub_Regression_For_X
    {
        public int N { get; set; }
        public decimal y_avg { get; set; }
        public decimal Rt_Left { get; set; }
        public decimal Rt_Right { get; set; }
        public decimal Delta_R { get; set; }

        //public int N_Left { get; set; }
        //public decimal y_avg_Left { get; set; }
        //public decimal Rt_Left { get; set; }
        //public int N_Right { get; set; }
        //public decimal y_avg_Right { get; set; }
        //public decimal Rt_Right { get; set; }




        private decimal get_y_Avg(DataTable _dt)
        {
            decimal subtotal = 0;

            if (_dt != null && _dt.Columns.Count > 1)
            {

                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    subtotal += Convert.ToInt32(_dt.Rows[i][_dt.Columns.Count - 1]);
                }
            }

            return subtotal / _dt.Rows.Count;
        }



        public decimal get_Rt_Squared(DataTable _dt)
        {
            decimal sub_rt = 0;

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                sub_rt += (Convert.ToDecimal(_dt.Rows[i][_dt.Columns.Count - 1]) - get_y_Avg(_dt)) * (Convert.ToDecimal(_dt.Rows[i][_dt.Columns.Count - 1]) - get_y_Avg(_dt));
            }

            return sub_rt = (1 / Convert.ToDecimal(_dt.Rows.Count)) * sub_rt;
        }
    }
}
