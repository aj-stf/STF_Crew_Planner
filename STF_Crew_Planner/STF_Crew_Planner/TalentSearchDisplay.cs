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
    public partial class TalentSearchDisplay : UserControl
    {
        public DataStorage stf_Data;
        public DataTable TalentDataTable;
        public List<String> TalentList;
        BindingSource SBind;

        public TalentSearchDisplay()
        {
            InitializeComponent();
            stf_Data = DataStorage.Instance;
            stf_Data.InstatiateTables();
            TalentDataTable = new DataTable();
            TalentDataTable = stf_Data.stf_talent_job_table.Copy();
            TalentList = new List<String>();
            SBind = new BindingSource();
            talentSearchGrid.DataSource = SBind;
            talentSearchGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }
        public void LoadNewSearchByTerm(string term)
        {
            ConfigureTalentTable(term, "Description");
        }
        public void LoadNewSearchByType(string type)
        {
            ConfigureTalentTable(type, "Type");
        }
        public void LoadNewSearchByJob(string job)
        {
            ConfigureTalentTable(job, "Job");
        }
        private void ConfigureTalentTable(string term, string fieldIs)
        {
            TalentList.Clear();
            bool canGo = false;

            if (term == null)
            {
                return;
            }
            if (term.Length > 0)
            {
                canGo = true;
            }
            if (canGo == false)
            {
                return;
            }
            var newDT = new DataTable();
            
            if (fieldIs.Equals("Description"))
            {
                var LinqResult = TalentDataTable.AsEnumerable().Where(row => row.Field<String>(fieldIs).IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0).OrderBy(row => row.Field<String>("Job"));
                if (LinqResult.Count() > 0)
                {
                    newDT = TalentDataTable.AsEnumerable().Where(row => row.Field<String>(fieldIs).IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0).OrderBy(row => row.Field<String>("Job")).CopyToDataTable();
                }
                else {
                    return;
                }
            }
            else
            {
                var LinqResult = TalentDataTable.AsEnumerable().Where(row => row.Field<String>(fieldIs) == term).OrderBy(row => row.Field<String>("Job"));
                if (LinqResult.Count() > 0)
                {
                    newDT = TalentDataTable.AsEnumerable().Where(row => row.Field<String>(fieldIs) == term).OrderBy(row => row.Field<String>("Job")).CopyToDataTable();
                }
                else
                {
                    return;
                }
            }

            newDT.Columns["Rank"].SetOrdinal(0);
            newDT.Columns["Name"].SetOrdinal(1);
            newDT.Columns["Job"].SetOrdinal(2);
            newDT.Columns["Type"].SetOrdinal(3);
            newDT.Columns["Cooldown"].SetOrdinal(4);
            newDT.Columns["Description"].SetOrdinal(5);

            SBind.DataSource = newDT;
            
            talentSearchGrid.Refresh();
            talentSearchGrid.AutoResizeColumns();
            DataGridViewColumn dgvc1 = talentSearchGrid.Columns[0];
            DataGridViewColumn dgvc2 = talentSearchGrid.Columns[1];
            DataGridViewColumn dgvc3 = talentSearchGrid.Columns[2];
            DataGridViewColumn dgvc4 = talentSearchGrid.Columns[3];
            DataGridViewColumn dgvc5 = talentSearchGrid.Columns[4];
            DataGridViewColumn dgvc6 = talentSearchGrid.Columns[5];
            dgvc1.Width = 50;
            dgvc2.Width = 150;
            dgvc3.Width = 110;
            dgvc4.Width = 50;
            dgvc5.Width = 120;
            dgvc6.Width = 610;
            talentSearchGrid.AutoResizeRows();
            foreach (DataGridViewTextBoxColumn theCol in talentSearchGrid.Columns)
            {
                Console.WriteLine(theCol.DataPropertyName);
            }
        }
    }
}
