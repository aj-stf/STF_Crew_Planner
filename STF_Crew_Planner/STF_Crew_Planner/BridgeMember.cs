using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreTechs.Common.Text;
using System.IO;

namespace STF_CharacterPlanner
{
    public partial class BridgeMember : UserControl
    {
        public string whichOfficer;

        public BridgeMember()
        {
            InitializeComponent();
        }

        public void setWhichOfficer(string theOne)
        {
            whichOfficer = theOne;
            officerControl1.setWhichOfficer(theOne);
        }
        public void updateSkillShow(DataTable SelectedJobs, Int32 availableTalents)
        {
            officerSkillDisplay1.UpdateSkills(SelectedJobs);
            updateTalentShow(SelectedJobs, availableTalents);
        }
        public void updateTalentShow(DataTable SelectedJobs, Int32 availableTalents)
        {
            availableTalents1.UpdateTalents(SelectedJobs, availableTalents);
        }
        public void updateTalentSelected(DataTable SelectedTalents)
        {
            selectedTalents1.UpdateSelectedTalents(SelectedTalents);
        }
        public void resetTheBridge()
        {
            officerControl1.ResetOfficerControl();
        }
        public DataTable returnSelectedJobs()
        {
            DataTable newTable = new DataTable();
            newTable = officerControl1.getSelectedJobsTable();
            return newTable;
        }
        public List<string> returnSkillsList()
        {
            List<string> newTable = new List<string>();
            newTable = officerSkillDisplay1.returnSkillsList();
            return newTable;
        }
        public List<string> returnNumList()
        {
            List<string> newTable = new List<string>();
            newTable = officerSkillDisplay1.returnNumList();
            return newTable;
        }
        public DataTable returnSelectedTalents()
        {
            DataTable newTable = new DataTable();
            newTable = selectedTalents1.returnSelectedTalents();
            DataTable filteredTable = newTable.Clone();
            if (newTable.Rows.Count > 0)
            {
                filteredTable = newTable.AsEnumerable().OrderBy(row => row.Field<Int32>("Rank")).CopyToDataTable();
            }
            

            return filteredTable;
        }
    }
}
