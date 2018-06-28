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
    public partial class ShipWeaponBrowse : UserControl
    {
        public DataStorage stf_Data;
        public DataTable ShipDataTable;
        BindingSource SBind;

        public ShipWeaponBrowse()
        {
            InitializeComponent();
            stf_Data = DataStorage.Instance;
            stf_Data.InstatiateTables();
            ShipDataTable = new DataTable();
            ShipDataTable = stf_Data.STF_Ship_Weapons.Copy();
            SBind = new BindingSource();
            SBind.DataSource = ShipDataTable;
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
            dgvc1.Width = 100;
            dgvc2.Width = 100;
            for (int x = 2; x < ShipBrowseGrid.ColumnCount; x++)
            {
                DataGridViewColumn dgvc = ShipBrowseGrid.Columns[x];
                dgvc.Width = 60;
            }
        }
    }
}
