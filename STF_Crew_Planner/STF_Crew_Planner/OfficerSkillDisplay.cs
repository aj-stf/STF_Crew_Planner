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
    public partial class OfficerSkillDisplay : UserControl
    {
        public List<String> SkillsList;
        public List<String> NumList;
        public DataStorage stf_Data;
        public DataTable SkillDataTable;

        public OfficerSkillDisplay()
        {
            InitializeComponent();
            SkillsList = new List<string>();
            NumList = new List<string>();
            stf_Data = DataStorage.Instance;
            stf_Data.InstatiateTables();
            SkillDataTable = new DataTable();
            CreateSkillTable(SkillDataTable);
        }
        public void UpdateSkills(DataTable SelectedJobs)
        {
            SkillsList.Clear();
            NumList.Clear();
            SetSkillDataZero();
            if (SelectedJobs == null)
            {
                return;
            }
            string newString = NewSkillString();
            foreach (DataRow dr in SelectedJobs.Rows)
            {
                var newDT = GetSkillData(dr[0].ToString(), Int32.Parse(dr[1].ToString()));
                PollSkillData(newDT);
            }
            SendToList();
            UpdateListBoxes();
        }
        private void UpdateListBoxes()
        {
            skillsListBox.Items.Clear();
            numBox1.Items.Clear();
            if (SkillsList.Count > 0)
            {
                skillsListBox.Items.AddRange(SkillsList.ToArray());
            }
            if (NumList.Count > 0)
            {
                numBox1.Items.AddRange(NumList.ToArray());
            }
        }
        private string NewSkillString()
        {
            var theString = "";
            return theString;
        }
        private DataTable GetSkillData(string term, Int32 theRank)
        {
            DataTable tblFiltered = stf_Data.skill_per_job_table.AsEnumerable().Where(row => row.Field<String>("Job") == term && row.Field<Int32>("Rank") == theRank).CopyToDataTable();
            var myObject = new DataObject();
            var theString = myObject.TableToString(tblFiltered);
            return tblFiltered;
        }
        private void SendToList()
        {
            foreach (DataRow dr in SkillDataTable.Rows)
            {
                Int32 checkInt = Int32.Parse(dr[1].ToString());
                if (checkInt > 0)
                {
                    var myString = dr[0].ToString();
                    var numString = dr[1].ToString();
                    SkillsList.Add(myString);
                    NumList.Add(numString);
                }
            }
        }
        private void PollSkillData(DataTable dt)
        {
            if (dt == null)
            {
                return;
            }
            foreach (DataRow dr in dt.Rows)
            {
                string polledString1 = dr.Field<string>("1-Name");
                Int32 skillToAdd1 = dr.Field<Int32>("1-Num");
                string polledString2 = dr.Field<string>("2-Name");
                Int32 skillToAdd2 = dr.Field<Int32>("2-Num");
                string polledString3 = dr.Field<string>("3-Name");
                Int32 skillToAdd3 = dr.Field<Int32>("3-Num");
                foreach (DataRow ds in SkillDataTable.Rows)
                {
                    string testString = ds[0].ToString();
                    if (polledString1.Equals(testString))
                    {
                        Int32 skillAlready = Int32.Parse(ds[1].ToString());
                        Int32 newSkillNum = skillAlready + skillToAdd1;
                        ds[1] = newSkillNum;
                    }
                    if (polledString2.Equals(testString))
                    {
                        Int32 skillAlready = Int32.Parse(ds[1].ToString());
                        Int32 newSkillNum = skillAlready + skillToAdd2;
                        ds[1] = newSkillNum;
                    }
                    if (polledString3.Equals(testString))
                    {
                        Int32 skillAlready = Int32.Parse(ds[1].ToString());
                        Int32 newSkillNum = skillAlready + skillToAdd3;
                        ds[1] = newSkillNum;
                    }
                }
            }
        }
        private void SetSkillDataZero()
        {
            foreach (DataRow dr in SkillDataTable.Rows)
            {
                dr[1] = 0;
            }
        }
        private void CreateSkillTable(DataTable dt)
        {
            if (stf_Data == null)
            {
                return;
            }
            dt.TableName = "Skill List";
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Skill";
            dc.DataType = typeof(String);
            dc.DefaultValue = "null";

            DataColumn dg = new DataColumn();
            dg.ColumnName = "Ranks";
            dg.DataType = typeof(Int32);
            dg.DefaultValue = 0;

            dt.Columns.Add(dc);
            dt.Columns.Add(dg);
            DataTable tblFiltered = stf_Data.skill_table.AsEnumerable().OrderBy(row => row.Field<String>("Skill")).CopyToDataTable();
            foreach (DataRow dr in tblFiltered.Rows)
            {
                DataRow newRow = dt.NewRow();
                newRow[0] = dr[0];
                newRow[1] = 0;
                dt.Rows.Add(newRow);
            }
        }
        public List<string> returnSkillsList()
        {
            List<string> newTable = new List<string>();
            newTable = SkillsList.ToList<string>();
            return newTable;
        }
        public List<string> returnNumList()
        {
            List<string> newTable = new List<string>();
            newTable = NumList.ToList<string>();
            return newTable;
        }
    }
}
