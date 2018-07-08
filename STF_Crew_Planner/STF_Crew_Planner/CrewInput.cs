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
    public partial class CrewInput : UserControl
    {
        public List<Int32> NumbersToUse;
        public List<Int32> RanksToUse;
        public List<DataStorage.CrewDataStruct> daCrew;
        public List<ComboBox> rankBoxes;
        public List<ComboBox> numBoxes;
        public DataStorage stf_Data;
        public DataTable AllJobsTable;
        private Color c1;
        private Color c2;
        int MaxCrewNum;
        int TotalInputCrew;
        int ShipCrewNum;
        int MaxCrewRanks;
        int CrewNumChoiceMax;


        public CrewInput()
        {
            InitializeComponent();
            NumbersToUse = new List<Int32>();
            RanksToUse = new List<Int32>();
            rankBoxes = new List<ComboBox>();
            numBoxes = new List<ComboBox>();
            daCrew = new List<DataStorage.CrewDataStruct>();
            stf_Data = DataStorage.Instance;
            stf_Data.InstatiateTables();
            AllJobsTable = new DataTable();

            ConfigureVariables();
            SetNumberLists();
            SetJobsTable();
            CreateCrewControls();
            UpdateControlsWithCrewData();
        }
        private void ConfigureVariables()
        {
            c1 = Color.FromArgb(226, 239, 250);
            c2 = Color.FromArgb(68, 152, 221);
            MaxCrewNum = 42;
            ShipCrewNum = 0;
            TotalInputCrew = 0;
            MaxCrewRanks = 32;
            CrewNumChoiceMax = 10;
        }
        private void UpdateControlsWithCrewData()
        {
            int totalCount = numBoxes.Count;
            for (int x = 0; x < totalCount; x++)
            {
                int theRank = daCrew[x].Rank-1;
                int theNum = daCrew[x].Num;

                rankBoxes[x].SelectedIndex = theRank;
                numBoxes[x].SelectedIndex = theNum;
            }
        }

        private void SetJobsTable()
        {
            AllJobsTable = stf_Data.job_table.Copy();
            foreach (DataRow dr in AllJobsTable.Rows)
            {
                var checkString = dr[0].ToString();
                if (checkString.Equals("None"))
                {
                    AllJobsTable.Rows.Remove(dr);
                    break;
                }
            }
        }
        private void SetNumberLists()
        {
            for (int count = 0; count < CrewNumChoiceMax + 1; count++)
            {
                NumbersToUse.Add(count);
            }
            for (int count = 1; count < MaxCrewRanks + 1; count++)
            {
                RanksToUse.Add(count);
            }
        }
        private void CreateCrewControls()
        {
            int y = 20;
            int x = 6;
            foreach (DataRow dr in AllJobsTable.Rows)
            {
                string JobName = dr[0].ToString();
                createCrewJobRow(x, y, JobName);
                y = y + 22;
            }
            
            foreach (var myInt in RanksToUse)
            {
                setAllCrewBox.Items.Add(myInt);
            }
        }
        private void createCrewJobRow(int x, int y, string Job)
        {
            getTextLabel(x, y, Job);
            var myNumBox = getNumTextBox(x + 130, y, Job);
            var myRankBox = getRankTextBox(x + 170, y, Job);
            var newCrewData = SetNewCrewData(Job);

            numBoxes.Add(myNumBox);
            rankBoxes.Add(myRankBox);
            daCrew.Add(newCrewData);
        }

        private Label getTextLabel(int x, int y, string Job)
        {
            var txtSize = new Size();
            txtSize.Width = 120;
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

            return txt;
        }
        private ComboBox getNumTextBox(int x, int y, string Job)
        {
            var txtSize = new Size();
            txtSize.Width = 40;
            txtSize.Height = 16;
            System.Windows.Forms.ComboBox txt = new System.Windows.Forms.ComboBox();
            txt.AutoSize = false;
            txt.Size = txtSize;
            this.Controls.Add(txt);
            txt.Top = y;
            txt.Left = x;
            txt.BackColor = c1;

            foreach (var myInt in NumbersToUse)
            {
                txt.Items.Add(myInt.ToString());
            }
            txt.SelectedItem = txt.Items[0];
            txt.SelectedIndexChanged += new System.EventHandler(this.availableTalentBox_SelectedIndexChanged);
            return txt;
        }

        private ComboBox getRankTextBox(int x, int y, string Job)
        {
            var txtSize = new Size();
            txtSize.Width = 40;
            txtSize.Height = 16;
            System.Windows.Forms.ComboBox txt = new System.Windows.Forms.ComboBox();
            txt.AutoSize = false;
            txt.Size = txtSize;
            this.Controls.Add(txt);
            txt.Top = y;
            txt.Left = x;
            txt.BackColor = c1;

            foreach (var myInt in RanksToUse)
            {
                txt.Items.Add(myInt);
            }
            txt.SelectedItem = txt.Items[0];
            txt.SelectedIndexChanged += new System.EventHandler(this.availableTalentBox_SelectedIndexChanged);
            return txt;
        }
        private void availableTalentBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int totalCountCrew = 0;
            foreach (ComboBox derBox in numBoxes)
            {
                int derBoxCount = 0;
                if (derBox.SelectedItem == null)
                {
                    derBoxCount = 0;
                }else
                {
                    derBoxCount = Int32.Parse(derBox.SelectedItem.ToString());
                }
                
                if (derBoxCount > 0)
                {
                    totalCountCrew += derBoxCount;
                }
            }
            ConfigureCrewForm parentForm = (this.Parent as ConfigureCrewForm);
            if (parentForm == null)
            {
                return;
            }
            parentForm.shipCrewMenu1.NumberOfCrew.Text = totalCountCrew.ToString();
        }
        private DataStorage.CrewDataStruct SetNewCrewData(string Name)
        {
            var aCrew = new DataStorage.CrewDataStruct();
            aCrew.Job = Name;
            aCrew.Num = ReturnCrewNumInt(Name);
            aCrew.Rank = 11;

            return aCrew;
        }

        private int ReturnCrewNumInt(string Name)
        {
            var myInt = 0;

            if (Name.Equals("Pilot"))
            {
                myInt = 4;
            }else if (Name.Equals("Hyperwarp Navigator"))
            {
                myInt = 4;
            }
            else if (Name.Equals("Gunner"))
            {
                myInt = 5;
            }
            else if (Name.Equals("Mechanic"))
            {
                myInt = 1;
            }
            else if (Name.Equals("Electronics Tech"))
            {
                myInt = 1;
            }
            else if (Name.Equals("Crew Dog"))
            {
                myInt = 3;
            }
            else if (Name.Equals("Swordsman"))
            {
                myInt = 1;
            }
            else if (Name.Equals("Pistoleer"))
            {
                myInt = 1;
            }
            else if (Name.Equals("Soldier"))
            {
                myInt = 2;
            }


            return myInt;
        }

        
        private void setAllCrewButton_Click(object sender, EventArgs e)
        {
            int myCount = daCrew.Count;
            int theRank = setAllCrewBox.SelectedIndex;

            for (int x = 0; x < myCount; x++)
            {
                rankBoxes[x].SelectedIndex = theRank;
            }
        }

        public void ResetTheCrew()
        {
            int myCount = numBoxes.Count;

            for (int x = 0; x < myCount; x++)
            {
                numBoxes[x].SelectedIndex = -1;
                rankBoxes[x].SelectedIndex = -1;
            }
        }

        public void SetTheCrewData(List<DataStorage.CrewDataStruct> aCrew)
        {
            daCrew = aCrew;
            int myCount = numBoxes.Count;
            
            for (int x = 0; x < myCount; x++)
            {
                numBoxes[x].SelectedIndex = daCrew[x].Num;
                rankBoxes[x].SelectedIndex = daCrew[x].Rank - 1;
            }
        }
        public void MatchCrewData()
        {
            int myCount = numBoxes.Count;
            for (int x = 0; x < myCount; x++)
            {
                var aCrew = daCrew[x];
                if (numBoxes[x].SelectedItem == null)
                {
                    aCrew.Num = 0;
                }
                else
                {
                    aCrew.Num = Int32.Parse(numBoxes[x].SelectedItem.ToString());
                }
                if (rankBoxes[x].SelectedItem == null)
                {
                    aCrew.Rank = 0;
                }
                else
                {
                    aCrew.Rank = Int32.Parse(rankBoxes[x].SelectedItem.ToString());
                }
                daCrew[x] = aCrew;
            }
        }
        public void SyncCrewNumber()
        {
            int totalCountCrew = 0;
            foreach (ComboBox derBox in numBoxes)
            {
                int derBoxCount = 0;
                if (derBox.SelectedItem == null)
                {
                    derBoxCount = 0;
                }
                else
                {
                    derBoxCount = Int32.Parse(derBox.SelectedItem.ToString());
                }

                if (derBoxCount > 0)
                {
                    totalCountCrew += derBoxCount;
                }
            }
            ConfigureCrewForm parentForm = (this.Parent as ConfigureCrewForm);
            if (parentForm == null)
            {
                return;
            }
            parentForm.shipCrewMenu1.NumberOfCrew.Text = totalCountCrew.ToString();
        }
    }
}
