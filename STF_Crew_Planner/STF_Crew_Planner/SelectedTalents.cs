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
    public partial class SelectedTalents : UserControl
    {
        DataTable TheSelectedTalents;
        List<String> TalentStrings;
        public SelectedTalents()
        {
            InitializeComponent();
            TheSelectedTalents = new DataTable();
            selectedTalentBox.ScrollAlwaysVisible = true;
            TalentStrings = new List<String>();
        }
        public void UpdateSelectedTalents(DataTable NewTalents)
        {
            TheSelectedTalents = new DataTable();
            TheSelectedTalents = NewTalents.Copy();
            TalentStrings.Clear();
            selectedTalentBox.Items.Clear();
            DataTable orderedTable = new DataTable();

            if (NewTalents.Rows.Count > 0)
            {
                orderedTable = NewTalents.AsEnumerable().OrderBy(row => row.Field<Int32>("Rank")).CopyToDataTable();
            }
            foreach (DataRow dr in orderedTable.Rows)
            {
                string newString = NewTalentString(dr);
                TalentStrings.Add(newString);
            }
            foreach (var str in TalentStrings)
            {
                selectedTalentBox.Items.Add(str);
            }
        }
        public string NewTalentString(DataRow dr)
        {
            var JobName = dr.Field<string>("Job");
            var Type = dr.Field<string>("Type");
            var Name = dr.Field<string>("Name");
            var Rank = dr.Field<Int32>("Rank");
            string displayRowString = Rank.ToString() + " " + Name + " " + Type + " " + JobName;
            return displayRowString;
        }
        public DataTable returnSelectedTalents()
        {
            DataTable newTable = new DataTable();
            newTable = TheSelectedTalents.Copy();
            return newTable;
        }
    }
}
