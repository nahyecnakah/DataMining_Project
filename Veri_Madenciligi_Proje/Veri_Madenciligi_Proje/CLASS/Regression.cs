using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Veri_Madenciligi_Proje.CLASS
{
    public class Regression
    {
        public int N { get; set; }
        public decimal y_avg { get; set; }
        public decimal Rt { get; set; }
        public List<Sub_Regression_For_X> Sub_X { get; set; }
        public decimal Max_Delta_R { get; set; }
        public int Selected_Attribute { get; set; }




        public decimal get_y_Avg(DataTable _dt)
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
                sub_rt += (Convert.ToDecimal(_dt.Rows[i][_dt.Columns.Count - 1]) - y_avg) * (Convert.ToDecimal(_dt.Rows[i][_dt.Columns.Count - 1]) - y_avg);
            }

            return sub_rt = (1 / Convert.ToDecimal(_dt.Rows.Count)) * sub_rt;
        }

        public decimal get_deltaR_for_Attributes(DataTable _dt)
        {
            for (int i = 0; i < _dt.Columns.Count - 1; i++)
            {
                for (int j = 0; j < _dt.Rows.Count; j++)
                {
                    decimal selected_x = Convert.ToDecimal(_dt.Rows[j][i]);  // attribute seçimi

                    DataTable _dt_Left = new DataTable();
                    DataTable _dt_Right = new DataTable();

                    _dt_Left = _dt.Clone();
                    _dt_Right = _dt.Clone();

                    //sağ ve sol olarak ayır
                    for (int k = 0; k < _dt.Rows.Count; k++)
                    {
                        if (Convert.ToDecimal(_dt.Rows[k][i]) <= selected_x)
                        {
                            _dt_Left.Rows.Add(_dt.Rows[k].ItemArray);
                        }
                        else
                        {
                            _dt_Right.Rows.Add(_dt.Rows[k].ItemArray);
                        }
                    }

                    //sağ ve sol olmak üzere Rt bul
                    Sub_Regression_For_X sub = new Sub_Regression_For_X();

                    if (_dt_Left.Rows.Count != 0)
                    {
                        sub.Rt_Left = sub.get_Rt_Squared(_dt_Left);
                    }
                    else
                    {
                        sub.Rt_Left = 0;
                    }


                    if (_dt_Right.Rows.Count != 0)
                    {
                        sub.Rt_Right = sub.get_Rt_Squared(_dt_Right);
                    }
                    else
                    {
                        sub.Rt_Right = 0;
                    }

                    
                    sub.Delta_R = this.Rt - (sub.Rt_Left + sub.Rt_Right); //X için delta R

                    this.Sub_X.Add(sub);

                }
            }

            get_Max_Rt();

            return 1;
        }

        private void get_Max_Rt()
        {
            decimal max_Delta_R = this.Sub_X[0].Delta_R;

            for (int i = 0; i < this.Sub_X.Count; i++)
            {
                if (this.Sub_X[i].Delta_R > max_Delta_R)
                {
                    max_Delta_R = this.Sub_X[i].Delta_R;
                }
            }

            this.Max_Delta_R = max_Delta_R;
        }
    }
}
