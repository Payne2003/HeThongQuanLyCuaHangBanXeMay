using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QLCHBX
{
    internal class ChucNang
    {
        public void FillComboBox(ComboBox comboname, DataTable data, string displayMember, string valuesMember)
        {
            comboname.DataSource = data;
            comboname.DisplayMember = displayMember;
            comboname.ValueMember = valuesMember;

        }
    }
}
