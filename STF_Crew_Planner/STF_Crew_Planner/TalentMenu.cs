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
    public partial class TalentMenu : UserControl
    {
        public DataStorage stf_Data;

        public TalentMenu()
        {
            InitializeComponent();
            stf_Data = DataStorage.Instance;
            stf_Data.InstatiateTables();
            populateBoxes();
        }

        private void searchTypeButton_Click(object sender, EventArgs e)
        {
            if (typeBox.SelectedText == null)
            {
                return;
            }
            TalentSearchForm myParent = (this.Parent as TalentSearchForm);
            var myText = typeBox.SelectedItem.ToString();

            myParent.talentSearchDisplay1.LoadNewSearchByType(myText);
        }

        private void searchTermButton_Click(object sender, EventArgs e)
        {
            if (typeBox.SelectedText == null)
            {
                return;
            }
            TalentSearchForm myParent = (this.Parent as TalentSearchForm);
            var myText = searchTermBox.Text.ToString();
            myParent.talentSearchDisplay1.LoadNewSearchByTerm(myText);
        }
        private void jobBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchJobButton_Click(object sender, EventArgs e)
        {
            if (jobBox.SelectedText == null)
            {
                return;
            }
            TalentSearchForm myParent = (this.Parent as TalentSearchForm);
            var myText = jobBox.SelectedItem.ToString();

            myParent.talentSearchDisplay1.LoadNewSearchByJob(myText);
        }
        private void populateBoxes()
        {
            populateJobBox();
            populateTypeBox();
        }
        private void populateJobBox()
        {
            var dt = new DataTable();
            dt = stf_Data.job_list;

            int count = dt.Rows.Count;
            if (count > 0)
            {
                jobBox.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    string jobString = dr[0].ToString();
                    jobBox.Items.Add(jobString);
                }
            }
        }
        private void populateTypeBox()
        {
            var dt = new DataTable();
            var typeDT = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Type";
            dc.DataType = typeof(String);
            dc.DefaultValue = "null";

            typeDT.Columns.Add(dc);

            dt = stf_Data.stf_talent_job_table;
            foreach (DataRow dr in dt.Rows)
            {
                var typeStr = dr.Field<string>("Type");
                var addtoDT = true;
                foreach (DataRow cr in typeDT.Rows)
                {
                    var aString = cr[0].ToString();
                    if (aString.Equals(typeStr))
                    {
                        addtoDT = false;
                    }
                }
                if (addtoDT)
                {
                    var newRow = typeDT.NewRow();
                    newRow[0] = typeStr;

                    typeDT.Rows.Add(newRow);
                }
            }
            int checkX = typeDT.Rows.Count;
            if (checkX > 0)
            {
                for (int x = 0; x < checkX; x++)
                {
                    var checkRow = typeDT.Rows[x];
                    var theString = checkRow[0].ToString();
                    if (theString.Equals("NOT") || theString.Equals(""))
                    {
                        typeDT.Rows.Remove(checkRow);
                        checkX = checkX - 1;
                    }
                }   
            }
            DataTable filteredType = typeDT.AsEnumerable().OrderBy(row => row.Field<String>("Type")).CopyToDataTable();
            int count = filteredType.Rows.Count;
            if (count > 0)
            {
                typeBox.Items.Clear();
                foreach (DataRow dr in filteredType.Rows)
                {
                    string typeString = dr[0].ToString();
                    typeBox.Items.Add(typeString);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
