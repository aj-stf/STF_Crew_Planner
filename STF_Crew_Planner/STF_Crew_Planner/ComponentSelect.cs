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
    public partial class ComponentSelect : UserControl
    {
        public DataStorage stf_Data;
        public DataTable LargeComponents;
        public DataTable MediumComponents;
        public DataTable SmallComponents;
        public DataTable ComponentTable;
        public DataTable SmallRow;
        public DataTable MediumRow;
        public DataTable LargeRow;
        public List<Label> LargeCompLabels;
        public List<Label> MedCompLabels;
        public List<Label> SmallCompLabels;
        public List<string> LargeList;
        public List<string> MedList;
        public List<string> SmallList;
        public int LargeM;
        public int MedM;
        public int SmallM;
        public int SmallC;
        public int MedC;
        public int LargeC;
        public int TierNum;
        public string EngineStr;
        public DataStorage.SelectedComponents MySelectedComp;
        private Color c1;
        private Color c2;
        

        public ComponentSelect()
        {
            InitializeComponent();
            c1 = Color.FromArgb(226, 239, 250);
            c2 = Color.FromArgb(68, 152, 221);
            stf_Data = DataStorage.Instance;
            stf_Data.InstatiateTables();
            EngineStr = "";
            TierNum = 0;
            LargeC = 0;
            MedC = 0;
            SmallC = 0;
            MySelectedComp.Large = new DataTable();
            MySelectedComp.Medium = new DataTable();
            MySelectedComp.Small = new DataTable();
            LargeCompLabels = new List<Label>();
            MedCompLabels = new List<Label>();
            SmallCompLabels = new List<Label>();

            ComponentTable = new DataTable();
            LargeComponents = new DataTable();
            MediumComponents = new DataTable();
            SmallComponents = new DataTable();
            LargeList = new List<string>();
            MedList = new List<string>();
            SmallList = new List<string>();

            SetComponentTables();
            ComponentTable = stf_Data.STF_Ship_Components.Copy();
            SmallRow = ComponentTable.Clone();
            MediumRow = ComponentTable.Clone();
            LargeRow = ComponentTable.Clone();
        }

        private void SetComponentTables()
        {
            SmallComponents = stf_Data.STF_Ship_Components.AsEnumerable().Where(row => row.Field<String>("Size") == "Small").OrderBy(row => row.Field<String>("Name")).CopyToDataTable();
            MediumComponents = stf_Data.STF_Ship_Components.AsEnumerable().Where(row => row.Field<String>("Size") == "Medium").OrderBy(row => row.Field<String>("Name")).CopyToDataTable();
            LargeComponents = stf_Data.STF_Ship_Components.AsEnumerable().Where(row => row.Field<String>("Size") == "Large").OrderBy(row => row.Field<String>("Name")).CopyToDataTable();
            MySelectedComp.Large = SmallComponents.Clone();
            MySelectedComp.Medium = SmallComponents.Clone();
            MySelectedComp.Small = SmallComponents.Clone();

            SmallList.Clear();
            MedList.Clear();
            LargeList.Clear();
            LargeCompSelect.Items.Clear();
            MedCompSelect.Items.Clear();
            SmallCompSelect.Items.Clear();

            CleanListForTier();

            foreach (DataRow dr in SmallComponents.Rows)
            {
                SmallList.Add(dr[0].ToString());
            }
            foreach (DataRow dr in MediumComponents.Rows)
            {
                MedList.Add(dr[0].ToString());
            }
            foreach (DataRow dr in LargeComponents.Rows)
            {
                LargeList.Add(dr[0].ToString());
            }

            foreach (string myString in SmallList)
            {
                SmallCompSelect.Items.Add(myString);
            }
            foreach (string myString in MedList)
            {
                MedCompSelect.Items.Add(myString);
            }
            foreach (string myString in LargeList)
            {
                LargeCompSelect.Items.Add(myString);
            }
        }
        private void SetNewComponentBoxes()
        {
            var newTable = stf_Data.STF_Ship_Components.AsEnumerable().OrderBy(row => row.Field<string>("Name")).CopyToDataTable();
        }
        public void UpdateComponentBoxes(string aName, int LargeMax, int MediumMax, int SmallMax, int tier, string Engine)
        {
            LargeM = LargeMax;
            MedM = MediumMax;
            SmallM = SmallMax;
            TierNum = tier + 1;
            EngineStr = SetNewEngineString(Engine);
            largeMaxDis.Text = LargeM.ToString();
            mediumMaxDis.Text = MedM.ToString();
            smallMaxDis.Text = SmallM.ToString();
            MySelectedComp.Large.Rows.Clear();
            MySelectedComp.Medium.Rows.Clear();
            MySelectedComp.Small.Rows.Clear();
            ResetListLabels();
            SetComponentTables();

            var newTable = stf_Data.STF_Ship_Defaults.AsEnumerable().Where(row => row.Field<String>("Ship") == aName).OrderBy(row => row.Field<String>("Component")).CopyToDataTable();
            var checkTable = stf_Data.STF_Ship_Components.Clone();

            foreach (DataRow dr in newTable.Rows)
            {
                string CheckString = dr[1].ToString();
                foreach (DataRow cr in ComponentTable.Rows)
                {
                    var aString = cr[0].ToString();
                    if (CheckString.Equals(aString))
                    {
                        checkTable.ImportRow(cr);
                        break;
                    }
                }
            }
            foreach (DataRow dr in checkTable.Rows)
            {
                string CheckString = dr[0].ToString();
                foreach (DataRow drL in LargeComponents.Rows)
                {
                    string aString = drL[0].ToString();
                    if (CheckString.Equals(aString))
                    {
                        MySelectedComp.Large.ImportRow(dr);
                        break;
                    }
                }
                foreach (DataRow drL in MediumComponents.Rows)
                {
                    string aString = drL[0].ToString();
                    if (CheckString.Equals(aString))
                    {
                        MySelectedComp.Medium.ImportRow(dr);
                        break;
                    }
                }
                foreach (DataRow drL in SmallComponents.Rows)
                {
                    string aString = drL[0].ToString();
                    if (CheckString.Equals(aString))
                    {
                        MySelectedComp.Small.ImportRow(dr);
                        break;
                    }
                }
            }
            
            LargeC = MySelectedComp.Large.Rows.Count;
            MedC = MySelectedComp.Medium.Rows.Count;
            SmallC = MySelectedComp.Small.Rows.Count;
            largeCurrentDis.Text = MySelectedComp.Large.Rows.Count.ToString();
            mediumCurrentDis.Text = MySelectedComp.Medium.Rows.Count.ToString();
            smallCurrentDis.Text = MySelectedComp.Small.Rows.Count.ToString();
            SendCompToMenu();
            CreateVisualTables();
        }
        private void CleanListForTier()
        {
            if (EngineStr.Count() > 0)
            {
                CleanEngineLists();
                CleanHyperWarpLists(LargeComponents);
                CleanHyperWarpLists(MediumComponents);
                CleanHyperWarpLists(SmallComponents);
            }
            if (TierNum > 1)
            {
                CleanBarracksLists(MediumComponents);
                CleanBarracksLists(LargeComponents);
            }
        }
        private void CleanEngineLists()
        {
            for (int x = LargeComponents.Rows.Count-1;x >= 0; x--)
            {
                DataRow dr = LargeComponents.Rows[x];
                if (dr[0].ToString().Contains("Engine"))
                {
                    if (dr[0].ToString().Contains(EngineStr))
                    {

                    }
                    else
                    {
                        LargeComponents.Rows.Remove(dr);
                    }
                }
            }
        }
        private void CleanHyperWarpLists(DataTable dt)
        {
            for (int x = dt.Rows.Count - 1; x >= 0; x--)
            {
                DataRow dr = dt.Rows[x];
                if (dr[0].ToString().Contains("Hyperwarp"))
                {
                    if (dr[0].ToString().Contains(EngineStr))
                    {

                    }
                    else
                    {
                        dt.Rows.Remove(dr);
                    }
                }
            }
        }
        private void CleanBarracksLists(DataTable dt)
        {
            var checkList = new List<int>();
            for (int x = 0; x < TierNum; x++)
            {
                var newInt = x+1;
                checkList.Add(newInt);
            }
            for (int x = dt.Rows.Count - 1; x >= 0; x--)
            {
                DataRow dr = dt.Rows[x];
                if (dr[0].ToString().Contains("Barracks"))
                {
                    var theTruth = true;
                    foreach (var myInt in checkList)
                    {
                        if (dr[0].ToString().Contains(myInt.ToString()))
                        {
                            theTruth = false;
                        }
                    }
                    if (theTruth)
                    {
                        dt.Rows.Remove(dr);
                    }
                }
            }
        }
        private string SetNewEngineString(string aString)
        {
            string engineString = "";
            if (aString.Contains("2400"))
            {
                engineString = "2400";
            }
            else if (aString.Contains("5000"))
            {
                engineString = "5000";
            }
            else if(aString.Contains("6000"))
            {
                engineString = "6000";
            }
            else if(aString.Contains("7000"))
            {
                engineString = "7000";
            }
            else if(aString.Contains("8000"))
            {
                engineString = "8000";
            }
            else if(aString.Contains("3400"))
            {
                engineString = "3400";
            }
            else if (aString.Contains("9000"))
            {
                engineString = "9000";
            }
            return engineString;
        }

        private void CreateVisualTables()
        {
            ResetListLabels();
            createSmallComps(850, 70);
            createMedComps(445, 70);
            createLargeComps(40, 70);
        }
        private void ResetListLabels()
        {
            if (SmallCompLabels.Count > 0)
            {
                foreach (Label aLabel in SmallCompLabels)
                {
                    aLabel.Dispose();
                }
            }
            if (MedCompLabels.Count > 0)
            {
                foreach (Label aLabel in MedCompLabels)
                {
                    aLabel.Dispose();
                }
            }
            if (LargeCompLabels.Count > 0)
            {
                foreach (Label aLabel in LargeCompLabels)
                {
                    aLabel.Dispose();
                }
            }
            SmallCompLabels.Clear();
            MedCompLabels.Clear();
            LargeCompLabels.Clear();
        }
        private void createSmallComps(int x, int y)
        {
            foreach (DataRow dr in MySelectedComp.Small.Rows)
            {
                var aLabel = getTextLabel(x, y, dr[0].ToString());
                SmallCompLabels.Add(aLabel);
                y = y + 20;
            }
        }
        private void createMedComps(int x, int y)
        {
            foreach (DataRow dr in MySelectedComp.Medium.Rows)
            {
                var aLabel = getTextLabel(x, y, dr[0].ToString());
                MedCompLabels.Add(aLabel);
                y = y + 20;
            }
        }
        private void createLargeComps(int x, int y)
        {
            foreach (DataRow dr in MySelectedComp.Large.Rows)
            {
                var aLabel = getTextLabel(x, y, dr[0].ToString());
                LargeCompLabels.Add(aLabel);
                y = y + 20;
            }
        }
        private Label getTextLabel(int x, int y, string Job)
        {
            var txtSize = new Size();
            txtSize.Width = 150;
            txtSize.Height = 16;
            System.Windows.Forms.Label txt = new System.Windows.Forms.Label();
            txt.AutoSize = false;
            txt.Size = txtSize;
            this.Controls.Add(txt);
            txt.Top = y;
            txt.Left = x;
            txt.Text = Job;
            txt.BackColor = c1;
            txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt.Click += new System.EventHandler(this.txtBox_Click);

            return txt;
        }
        private void txtBox_Click(object sender, EventArgs e)
        {
            Label myText = (sender as Label);
            var aName = myText.Text;
            SearchAndRemoveComp(aName);
            CreateVisualTables();
            SendCompToMenu();
        }
        private void SearchAndRemoveComp(string aName)
        {
            foreach (DataRow dr in MySelectedComp.Small.Rows)
            {
                var checkName = dr[0].ToString();
                if (aName.Equals(checkName))
                {
                    MySelectedComp.Small.Rows.Remove(dr);
                    SmallC = SmallC - 1;
                    UpdateCurrentLabel();
                    break;
                }
            }
            foreach (DataRow dr in MySelectedComp.Medium.Rows)
            {
                var checkName = dr[0].ToString();
                if (aName.Equals(checkName))
                {
                    MySelectedComp.Medium.Rows.Remove(dr);
                    MedC = MedC - 1;
                    UpdateCurrentLabel();
                    break;
                }
            }
            foreach (DataRow dr in MySelectedComp.Large.Rows)
            {
                var checkName = dr[0].ToString();
                if (aName.Equals(checkName))
                {
                    MySelectedComp.Large.Rows.Remove(dr);
                    LargeC = LargeC - 1;
                    UpdateCurrentLabel();
                    break;
                }
            }
        }
        private void UpdateCurrentLabel()
        {
            smallCurrentDis.Text = SmallC.ToString();
            mediumCurrentDis.Text = MedC.ToString();
            largeCurrentDis.Text = LargeC.ToString();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LargeCompSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var aString = LargeCompSelect.SelectedItem.ToString();
            LargeRow.Rows.Clear();
            LargeRow = ComponentTable.AsEnumerable().Where(row => row.Field<String>("Name") == aString).CopyToDataTable();
        }

        private void MedCompSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var aString = MedCompSelect.SelectedItem.ToString();
            MediumRow.Rows.Clear();
            MediumRow = ComponentTable.AsEnumerable().Where(row => row.Field<String>("Name") == aString).CopyToDataTable();
        }

        private void SmallCompSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var aString = SmallCompSelect.SelectedItem.ToString();
            SmallRow.Rows.Clear();
            SmallRow = ComponentTable.AsEnumerable().Where(row => row.Field<String>("Name") == aString).CopyToDataTable();
        }

        private void AddLargeButton_Click(object sender, EventArgs e)
        {
            if (LargeC + 1 > LargeM)
            {

            }else
            {
                LargeC = LargeC + 1;
                UpdateCurrentLabel();
                foreach (DataRow dr in LargeRow.Rows)
                {
                    MySelectedComp.Large.ImportRow(dr);
                }
                CreateVisualTables();
                SendCompToMenu();
            }
           
        }

        private void AddMedButton_Click(object sender, EventArgs e)
        {
            if (MedC + 1 > MedM)
            {

            }
            else
            {
                MedC = MedC + 1;
                UpdateCurrentLabel();
                foreach (DataRow dr in MediumRow.Rows)
                {
                    MySelectedComp.Medium.ImportRow(dr);
                }
                CreateVisualTables();
                SendCompToMenu();
            }
            
        }
        private void SendCompToMenu()
        {
            ConfigureShipForm theForm = (this.Parent as ConfigureShipForm);
            theForm.shipConfigureMenu1.IntakeNewComponents(MySelectedComp);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (SmallC + 1 > SmallM)
            {

            }
            else
            {
                SmallC = SmallC + 1;
                UpdateCurrentLabel();
                foreach (DataRow dr in SmallRow.Rows)
                {
                    MySelectedComp.Small.ImportRow(dr);
                }
                CreateVisualTables();
                SendCompToMenu();
            }
        }
        public void ShipUpdate(DataStorage.SelectedShip theShip)
        {
            MySelectedComp.Large.Rows.Clear();
            MySelectedComp.Medium.Rows.Clear();
            MySelectedComp.Small.Rows.Clear();

            MySelectedComp.Small = theShip.Components.Small.Copy();
            MySelectedComp.Medium = theShip.Components.Medium.Copy();
            MySelectedComp.Large = theShip.Components.Large.Copy();

            LargeC = MySelectedComp.Large.Rows.Count;
            MedC = MySelectedComp.Medium.Rows.Count;
            SmallC = MySelectedComp.Small.Rows.Count;

            UpdateCurrentLabel();
            SendCompToMenu();
            CreateVisualTables();
        }
    }
}
