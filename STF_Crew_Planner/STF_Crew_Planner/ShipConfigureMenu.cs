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
    public partial class ShipConfigureMenu : UserControl
    {
        public DataStorage stf_Data;
        public DataTable ShipDataTable;
        public DataTable ShipBaseTable;
        public List<string> ShipNames;
        public DataTable SelectedShipTable;
        public DataStorage.SelectedComponents MySelectedComp;
        public DataTable SelectedComps;
        public DataTable CompiledComponents;
        BindingSource SBind;

        public ShipConfigureMenu()
        {
            InitializeComponent();
            stf_Data = DataStorage.Instance;
            stf_Data.InstatiateTables();
            ShipDataTable = new DataTable();
            ShipBaseTable = new DataTable();
            ShipDataTable = stf_Data.STF_Ship_Data.Copy();
            SelectedShipTable = stf_Data.STF_Ship_Data.Clone();
            ShipBaseTable = stf_Data.STF_Ship_Data.Clone();
            CompiledComponents = stf_Data.STF_Ship_Components.Clone();
            SelectedComps = stf_Data.STF_Ship_Components.Clone();
            ConstructBaseShipData();
            SBind = new BindingSource();
            ShipNames = ReturnShips(stf_Data.STF_Ship_Data);
            SBind.DataSource = SelectedShipTable;
            ShipBrowseGrid.DataSource = SBind;
            ShipBrowseGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ShipBrowseGrid.Columns["Tier"].Visible = false;
            ShipBrowseGrid.Refresh();
            SetColumnWidth();
            SetShipBox();
        }
        public void IntakeNewComponents(DataStorage.SelectedComponents aComp)
        {
            MySelectedComp = aComp;
            ConstructCompiledList();
        }
        public void ConstructCompiledList()
        {
            CompiledComponents.Clear();
            CompiledComponents = stf_Data.STF_Ship_Components.Clone();
            DataRow newRow = CompiledComponents.NewRow();
            newRow[0] = "Compiled";
            newRow[1] = "Large";
            for (int x = 2; x < CompiledComponents.Columns.Count; x++)
            {
                newRow[x] = 0;
            }
            foreach (DataRow dr in MySelectedComp.Large.Rows)
            {
                newRow = TabulateRowData(dr, newRow);
            }
            foreach (DataRow dr in MySelectedComp.Medium.Rows)
            {
                newRow = TabulateRowData(dr, newRow);
            }
            foreach (DataRow dr in MySelectedComp.Small.Rows)
            {
                newRow = TabulateRowData(dr, newRow);
            }
            CompiledComponents.Rows.Add(newRow);
            //DisplayNewData();
            AddShipToData();
        }
        private void ConstructBaseShipData()
        {
            var CopyShips = stf_Data.STF_Ship_Data.Copy();
            foreach (DataRow dr in CopyShips.Rows)
            {
                string theName = dr[0].ToString();
                var myComp = stf_Data.STF_Ship_Defaults.AsEnumerable().Where(row => row.Field<String>("Ship") == theName).OrderBy(row => row.Field<String>("Component")).CopyToDataTable();
                var theComps = DefaultCompReturn(myComp);
                foreach (DataRow dc in theComps.Rows)
                {
                    for (int x = 2; x < theComps.Columns.Count; x++)
                    {
                        string myColName = theComps.Columns[x].ColumnName;
                        int theNewInt = Int32.Parse(dc[myColName].ToString());
                        int theOldInt = Int32.Parse(dr[myColName].ToString());
                        int anInt = theOldInt - theNewInt;
                        if (myColName.Equals("Armour"))
                        {
                            anInt = theOldInt;
                        }
                        if (myColName.Equals("Shield"))
                        {
                            anInt = theOldInt;
                        }
                        dr[myColName] = anInt;
                    }
                }
                ShipBaseTable.ImportRow(dr);
            }
        }
        private DataTable DefaultCompReturn (DataTable theList)
        {
            var aTable = stf_Data.STF_Ship_Components.Clone();

            foreach (DataRow dr in theList.Rows)
            {
                var aString = dr[1].ToString();
                var bTable = stf_Data.STF_Ship_Components.AsEnumerable().Where(row => row.Field<String>("Name") == aString).OrderBy(row => row.Field<String>("Name")).CopyToDataTable();
                var dc = bTable.Rows[0];
                aTable.ImportRow(dc);
            }
            aTable = CleanTheTable(aTable);
            return aTable;
        }
        private DataTable CleanTheTable(DataTable dt)
        {
            dt.Columns.Remove("Guest");
            dt.Columns.Remove("Medical");
            dt.Columns.Remove("Prison");
            dt.Columns.Remove("Shield");
            return dt;
        }
        public void AddShipToData()
        {
            var aString = SelectedShipTable.Rows[0][0].ToString();
            var olddt = ShipBaseTable.AsEnumerable().Where(row => row.Field<String>("Ship") == aString).CopyToDataTable();
            DataRow dr = SelectedShipTable.Rows[0];
            DataRow inputRow = olddt.Rows[0];
            dr.BeginEdit();

            var dt = CleanTheTable2(CompiledComponents).Copy();
            inputRow["Max Crew"] = 0;
            for (int x = 2; x < dt.Columns.Count; x++)
            {
                string myColName = dt.Columns[x].ColumnName;
                int theNewInt = Int32.Parse(dt.Rows[0][x].ToString());
                int theOldInt = Int32.Parse(inputRow[myColName].ToString());
                int anInt = theOldInt + theNewInt;
                dr[myColName] = anInt;
            }
            dr["Fuel Range"] = ReturnFuelRange(dr);
            dr.AcceptChanges();
            ShipBrowseGrid.Refresh();
        }
        private int ReturnFuelRange (DataRow dr)
        {
            int myInt = 0;
            int myFuel = Int32.Parse(dr["Fuel Tank"].ToString());
            int myCost = Int32.Parse(dr["Fuel Cost"].ToString());
            myInt = myFuel / myCost;

            return myInt;
        }
        public void DisplayNewData()
        {
            SBind.DataSource = CompiledComponents;
            ShipBrowseGrid.Refresh();
        }
        public DataRow TabulateRowData(DataRow aRow, DataRow sumRow)
        {
            for (int x = 2; x < CompiledComponents.Columns.Count;x++)
            {
                int addInt = Int32.Parse(aRow[x].ToString());
                int sumInt = Int32.Parse(sumRow[x].ToString());
                sumInt = addInt + sumInt;
                sumRow[x] = sumInt;
            }

            return sumRow;
        }
        public DataRow CopyShipDataRow()
        {
            DataRow myNewRow = SelectedShipTable.NewRow();
            var dt = CleanTheTable2(CompiledComponents).Copy();
            for(int x = 0; x < SelectedShipTable.Columns.Count; x++)
            {
                myNewRow[x] = SelectedShipTable.Rows[0][x];
            }

            for (int x = 2; x < dt.Columns.Count; x++)
            {
                string myColName = dt.Columns[x].ColumnName;
                int theNewInt = Int32.Parse(dt.Rows[0][x].ToString());

                myNewRow[myColName] = theNewInt; 
            }
            return myNewRow;
        }
        private DataTable CleanTheTable2(DataTable dt)
        {
            dt.Columns.Remove("Guest");
            dt.Columns.Remove("Medical");
            dt.Columns.Remove("Prison");
            return dt;
        }
        private List<string> ReturnShips(DataTable dt)
        {
            var theNew = new List<string>();
            var newTable = dt.AsEnumerable().OrderBy(row => row.Field<string>("Ship")).ThenBy(row => row.Field<string>("Price")).CopyToDataTable();
            foreach (DataRow dr in newTable.Rows)
            {
                string aString = dr[0].ToString();
                theNew.Add(aString);
            }

            return theNew;
        }
        private void SetShipBox()
        {
            selectShipBox.Items.Clear();
            foreach (var aString in ShipNames)
            {
                selectShipBox.Items.Add(aString);
            }
            selectShipBox.Refresh();
        }
        private void SetColumnWidth()
        {
            foreach (DataGridViewColumn theColumn in ShipBrowseGrid.Columns)
            {
                theColumn.Width = 36;
            }
            DataGridViewColumn dgvc1 = ShipBrowseGrid.Columns[0];
            DataGridViewColumn dgvc2 = ShipBrowseGrid.Columns[1];
            DataGridViewColumn dgvc3 = ShipBrowseGrid.Columns[2];
            dgvc1.Width = 100;
            dgvc2.Width = 50;
            dgvc3.Width = 100;
        }
        private void browseShipsButton_Click(object sender, EventArgs e)
        {
            BrowseShipsForm newForm = new BrowseShipsForm();
            newForm.Show();
        }

        private void selectShipBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var aString = selectShipBox.SelectedItem.ToString();
            SelectedShipTable = ShipBaseTable.AsEnumerable().Where(row => row.Field<String>("Ship") == aString).CopyToDataTable();
            SBind.DataSource = SelectedShipTable;
            ShipBrowseGrid.Refresh();

            var theName = SelectedShipTable.Rows[0][0].ToString();
            var Large = Int32.Parse(SelectedShipTable.Rows[0][6].ToString());
            var Med = Int32.Parse(SelectedShipTable.Rows[0][7].ToString());
            var Small = Int32.Parse(SelectedShipTable.Rows[0][8].ToString());
            var Tier = SelectedShipTable.Rows[0].Field<Int32>("Tier");
            var Engine = SelectedShipTable.Rows[0].Field<string>("Engine");
            ConfigureShipForm theForm = (this.Parent as ConfigureShipForm);
            theForm.componentSelect1.UpdateComponentBoxes(theName, Large, Med, Small, Tier, Engine);
        }

        private void browseCompsButton_Click(object sender, EventArgs e)
        {
            BrowseCompsForm newForm = new BrowseCompsForm();
            newForm.Show();
        }
        public DataStorage.SelectedShip SaveShipData()
        {
            DataStorage.SelectedShip newShip = new DataStorage.SelectedShip();
            newShip.Components.Large = MySelectedComp.Large.Copy();
            newShip.Components.Medium = MySelectedComp.Medium.Copy();
            newShip.Components.Small = MySelectedComp.Small.Copy();
            newShip.Ship = SelectedShipTable.Copy();
            newShip.Name = newShip.Ship.Rows[0][0].ToString();
            newShip.isSet = true;

            return newShip;
        }
        public void ShipUpdate(DataStorage.SelectedShip theShip)
        {
            foreach (var item in selectShipBox.Items)
            {
                if (theShip.Name.Equals(item.ToString()))
                {
                    selectShipBox.SelectedItem = item;
                    break;
                }
            }
        }
    }
}
