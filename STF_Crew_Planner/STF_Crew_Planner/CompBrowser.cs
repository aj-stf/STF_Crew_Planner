using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STF_CharacterPlanner
{
    public partial class CompBrowser : UserControl
    {
        public DataStorage stf_Data;
        public DataTable CompDataTable;
        BindingSource SBind;

        public CompBrowser()
        {
            InitializeComponent();
            stf_Data = DataStorage.Instance;
            stf_Data.InstatiateTables();
            CompDataTable = new DataTable();
            CompDataTable = stf_Data.STF_Ship_Components.Copy();
            SBind = new BindingSource();
            SBind.DataSource = CompDataTable;
            ShipBrowseGrid.DataSource = SBind;
            ShipBrowseGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ShipBrowseGrid.Refresh();
            SetColumnWidth();
        }

        private void SetColumnWidth()
        {
            foreach (DataGridViewColumn theColumn in ShipBrowseGrid.Columns)
            {
                theColumn.Width = 36;
            }
            DataGridViewColumn dgvc1 = ShipBrowseGrid.Columns[0];
            DataGridViewColumn dgvc2 = ShipBrowseGrid.Columns[1];
            dgvc1.Width = 160;
            dgvc2.Width = 50;
        }
    }
}
