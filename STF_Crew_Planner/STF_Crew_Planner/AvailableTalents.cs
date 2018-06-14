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
    public partial class AvailableTalents : UserControl
    {
        public DataStorage stf_Data;
        public DataTable TalentDataTable;
        public List<String> TalentList;
        public Int32 num_talent_points;
        public Int32 max_talent_points;
        public List<Int32> selectedTalentList;
        public DataTable selectedTalentTable;

        public AvailableTalents()
        {
            InitializeComponent();
            TalentList = new List<string>();
            stf_Data = DataStorage.Instance;
            stf_Data.InstatiateTables();
            TalentDataTable = new DataTable();
            selectedTalentTable = new DataTable();
            availableTalentBox.ScrollAlwaysVisible = true;
            num_talent_points = 0;
            max_talent_points = 0;
            selectedTalentList = new List<Int32>();
        }
        public void UpdateTalents(DataTable SelectedJobs, Int32 talent_points)
        {
            TalentList.Clear();
            availableTalentBox.Items.Clear();
            TalentDataTable.Rows.Clear();
            selectedTalentTable.Rows.Clear();
            max_talent_points = talent_points;
            selectedTalentList.Clear();
            num_talent_points = 0;
            UpdateTheSelectedTalents();

            if (SelectedJobs == null)
            {
                return;
            }

            var j = 1;
            var jobName1 = "";
            var jobName2 = "";
            var jobName3 = "";
            var theRank1 = 0;
            var theRank2 = 0;
            var theRank3 = 0;
            foreach (DataRow dr in SelectedJobs.Rows)
            {
                if (j == 1)
                {
                    jobName1 = dr[0].ToString();
                    theRank1 = Int32.Parse(dr[1].ToString());
                }
                else if (j == 2)
                {
                    jobName2 = dr[0].ToString();
                    theRank2 = Int32.Parse(dr[1].ToString());
                }
                else if (j == 3)
                {
                    jobName3 = dr[0].ToString();
                    theRank3 = Int32.Parse(dr[1].ToString());
                }
                j++;
            }
            DataTable tblFiltered1 = new DataTable();
            DataTable tblFiltered2 = new DataTable();
            DataTable tblFiltered3 = new DataTable();

            var test1 = jobName1 + " " + theRank1.ToString();
            var test2 = jobName2 + " " + theRank2.ToString();

            if (theRank1 > 0)
            {
                tblFiltered1 = stf_Data.stf_talent_job_table.AsEnumerable().Where(row => row.Field<String>("Job") == jobName1 && row.Field<Int32>("Rank") <= theRank1).OrderBy(row => row.Field<Int32>("Rank")).CopyToDataTable();
            }
            if (theRank2 > 0)
            {
                tblFiltered2 = stf_Data.stf_talent_job_table.AsEnumerable().Where(row => row.Field<String>("Job") == jobName2 && row.Field<Int32>("Rank") <= theRank2).OrderBy(row => row.Field<Int32>("Rank")).CopyToDataTable();
            }
            if (theRank3 > 0)
            {
                tblFiltered3 = stf_Data.stf_talent_job_table.AsEnumerable().Where(row => row.Field<String>("Job") == jobName3 && row.Field<Int32>("Rank") <= theRank3).OrderBy(row => row.Field<Int32>("Rank")).CopyToDataTable();
            }

            if (tblFiltered2.Rows.Count > 0)
            {
                foreach (DataRow dr in tblFiltered2.Rows)
                {
                    tblFiltered1.ImportRow(dr);
                }
            }
            if (tblFiltered3.Rows.Count > 0)
            {
                foreach (DataRow dr in tblFiltered3.Rows)
                {
                    tblFiltered1.ImportRow(dr);
                }
            }

            if (tblFiltered1.Rows.Count > 0)
            {
                //TalentDataTable = tblFiltered1.AsEnumerable().OrderBy(row => row.Field<Int32>("Rank")).CopyToDataTable();
                TalentDataTable = tblFiltered1.AsEnumerable().OrderBy(row => row.Field<string>("Job")).CopyToDataTable();
            }
            

            if (TalentDataTable.Rows.Count > 0)
            {
                UpdateTalentBox();
            }
            UpdateTalentNums();
        }
        public void UpdateTalentNums()
        {
            Int32 numLeft = max_talent_points - num_talent_points;
            string numString = numLeft.ToString();
            talentsLeft.Text = numString;
        }
        public void UpdateTalentBox()
        {
            foreach (DataRow dr in TalentDataTable.Rows)
            {
                var snglTab = "\t";
                var dblTab = "\t\t";
                var trpTab = "\t\t\t";
                var JobName = dr.Field<string>("Job");
                var Type = dr.Field<string>("Type");
                var Name = dr.Field<string>("Name");
                var Rank = dr.Field<Int32>("Rank");
                string displayRowString = "";
                if (Name.Length > 15)
                {
                    displayRowString = Rank.ToString() + snglTab + Name + snglTab + JobName;
                }
                else if (Name.Length < 8)
                {
                    displayRowString = Rank.ToString() + snglTab + Name + trpTab + JobName;
                }
                else
                {
                    displayRowString = Rank.ToString() + snglTab + Name + dblTab + JobName;
                }
                TalentList.Add(displayRowString);
            }
            if (TalentList.Count > 0)
            {
                foreach (string str in TalentList)
                {
                    availableTalentBox.Items.Add(str);
                }
            }
            
        }
        public string NewTalentString (DataRow dr)
        {
            var JobName = dr.Field<string>("Job");
            var Type = dr.Field<string>("Type");
            var Name = dr.Field<string>("Name");
            var Rank = dr.Field<Int32>("Rank");
            string displayRowString = Rank.ToString() + " " + Name + " " + Type + " " + JobName;
            return displayRowString;
        }
        private void availableTalentBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 testNum = availableTalentBox.SelectedIndices.Count;
            if (testNum > max_talent_points)
            {
                foreach (Int32 num in availableTalentBox.SelectedIndices)
                {
                    if (selectedTalentList.Contains(num))
                    {

                    }else
                    {
                        availableTalentBox.SetSelected(num, false);
                    }
                }
            }else {
                foreach (Int32 num in availableTalentBox.SelectedIndices)
                {
                    addToSelectedList(num);
                }
                List<Int32> toRemove = new List<Int32>();
                foreach (var num in selectedTalentList)
                {
                    if (availableTalentBox.SelectedIndices.Contains(num))
                    {

                    }else
                    {
                        toRemove.Add(num);
                    }
                }
                foreach (var num in toRemove)
                {
                    selectedTalentList.Remove(num);
                }
                Int32 selectedTalentNum = availableTalentBox.SelectedIndices.Count;
                num_talent_points = selectedTalentNum;
                UpdateTalentNums();
            }
            UpdateTalentTable();
        }
        private void addToSelectedList(Int32 num)
        {
            if (selectedTalentList.Contains(num))
            {

            }else
            {
                selectedTalentList.Add(num);
            }
        }
        private void UpdateTalentTable()
        {
            selectedTalentTable = new DataTable();
            selectedTalentTable = TalentDataTable.Clone();

            foreach (var num in selectedTalentList)
            {
                var row = TalentDataTable.Rows[num];
                selectedTalentTable.ImportRow(row);
            }
            UpdateTheSelectedTalents();
        }
        private void UpdateTheSelectedTalents()
        {
            BridgeMember myParent = (this.Parent as BridgeMember);
            myParent.updateTalentSelected(selectedTalentTable);
        }
        public void LoadTalentsFromFile(DataTable NewTalentChoices)
        {
            foreach (DataRow dr in NewTalentChoices.Rows)
            {
                var myString = dr.Field<string>("Name");
                TalentSelectRow(myString, availableTalentBox);
            }
        }
        private void TalentSelectRow(string newJobName, ListBox theBox)
        {
            foreach (var theItem in theBox.Items)
            {
                if (theItem.ToString().Contains(newJobName))
                {
                    theBox.SelectedItem = theItem;
                    break;
                }
            }
        }
    }
}
