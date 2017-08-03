using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Gestion.Classes {
    class Func_Estadistica {


        public Decimal Get_N(DataTable tabla) {
            Decimal ac = 0;
            for (int i = 0; i < tabla.Rows.Count; i++) {
                ac += tabla.Rows[i].Field<Decimal>("(fi)");
            }
            return ac;
        }
        public DataTable Freq_Acum(DataTable tabla) {
            Decimal ac = 0;

            if (tabla.Columns.Contains("Fi") == false) {
                tabla.Columns.Add("Fi", typeof(Decimal));
            }                
            for (int i = 0; i < tabla.Rows.Count; i++) {
                ac += tabla.Rows[i].Field<Decimal>("(fi)");
                tabla.Rows[i]["Fi"] = ac;
            }
            return tabla;
        }
        public DataTable Freq_R(DataTable tabla, Decimal N) {
            Decimal val = 0;

            if (tabla.Columns.Contains("(hi)") == false) {
                tabla.Columns.Add("(hi)", typeof(Decimal));
            }
            for (int i = 0; i < tabla.Rows.Count; i++) {
                val = tabla.Rows[i].Field<Decimal>("(fi)");
                tabla.Rows[i]["(hi)"] = val / N;
            }
            return tabla;
        }

        public Decimal Get_S_hi(DataTable tabla) {
            Decimal ac = 0;
            for (int i = 0; i < tabla.Rows.Count; i++) {
                ac += tabla.Rows[i].Field<Decimal>("(hi)");
            }
            return ac;
        }

        public DataTable Freq_R_Acum(DataTable tabla) {
            Decimal ac = 0;

            if (tabla.Columns.Contains("Hi") == false) {
                tabla.Columns.Add("Hi", typeof(Decimal));
            }
            for (int i = 0; i < tabla.Rows.Count; i++) {
                ac += tabla.Rows[i].Field<Decimal>("(hi)");
                tabla.Rows[i]["Hi"] = ac;
            }
            return tabla;
        }
        public Decimal Get_Media(DataTable tabla) {
            Decimal ac = 0;
            Decimal Res;
            Decimal N = Get_N(tabla);
            for (int i = 0; i < tabla.Rows.Count; i++) {
                ac += tabla.Rows[i].Field<Decimal>("(Xi)") * tabla.Rows[i].Field<Decimal>("(fi)");
            }
            Res = ac / N;
            return Res;

        }



    }
}
