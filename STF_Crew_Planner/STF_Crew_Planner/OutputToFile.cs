using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STF_CharacterPlanner
{
    class OutputToFile
    {
        public void createNewTextFile(MainForm theForm)
        {
            CreateDataFile(theForm);
        }
        private void CreateDataFile(MainForm theForm)
        {
            DataTable MemberJobs1 = new DataTable();
            DataTable MemberJobs2 = new DataTable();
            DataTable MemberJobs3 = new DataTable();
            DataTable MemberJobs4 = new DataTable();
            DataTable MemberJobs5 = new DataTable();
            DataTable MemberJobs6 = new DataTable();
            DataTable MemberJobs7 = new DataTable();
            String SaveMyFileBro = "";
            var GroupName = theForm.menu_Control1.ReturnGroupName();
            if (GroupName.Length > 0)
            {
                SaveMyFileBro += "Crew Name: " + GroupName + "\n";
            }
            else
            {
                SaveMyFileBro += "Crew Name: " + "The No Names" + "\n";
            }
            SaveMyFileBro += "================================================================" + "\n";
            MemberJobs1 = theForm.bridgeMember1.returnSelectedJobs();
            MemberJobs2 = theForm.bridgeMember2.returnSelectedJobs();
            MemberJobs3 = theForm.bridgeMember3.returnSelectedJobs();
            MemberJobs4 = theForm.bridgeMember4.returnSelectedJobs();
            MemberJobs5 = theForm.bridgeMember5.returnSelectedJobs();
            MemberJobs6 = theForm.bridgeMember6.returnSelectedJobs();
            MemberJobs7 = theForm.bridgeMember7.returnSelectedJobs();

            if (MemberJobs1 == null)
            {
                return;
            }

            if (MemberJobs1.Rows.Count > 0)
            {
                var Jobs1 = MemberJobs1.AsEnumerable().OrderBy(row => row.Field<string>("Job")).CopyToDataTable();
                var SkillsList1 = combinedSkillList(theForm.bridgeMember1);
                var SelectedTalents1 = theForm.bridgeMember1.returnSelectedTalents();
                var Officer1_String = CombinedCharacterString(Jobs1, SelectedTalents1, SkillsList1, theForm.bridgeMember1.whichOfficer);
                SaveMyFileBro += Officer1_String;
            }
            if (MemberJobs2.Rows.Count > 0)
            {
                var Jobs2 = MemberJobs2.AsEnumerable().OrderBy(row => row.Field<string>("Job")).CopyToDataTable();
                var SkillsList2 = combinedSkillList(theForm.bridgeMember2);
                var SelectedTalents2 = theForm.bridgeMember2.returnSelectedTalents();
                var Officer1_String = CombinedCharacterString(Jobs2, SelectedTalents2, SkillsList2, theForm.bridgeMember2.whichOfficer);
                SaveMyFileBro += Officer1_String;
            }
            if (MemberJobs3.Rows.Count > 0)
            {
                var Jobs3 = MemberJobs3.AsEnumerable().OrderBy(row => row.Field<string>("Job")).CopyToDataTable();
                var SkillsList3 = combinedSkillList(theForm.bridgeMember3);
                var SelectedTalents3 = theForm.bridgeMember3.returnSelectedTalents();
                var Officer1_String = CombinedCharacterString(Jobs3, SelectedTalents3, SkillsList3, theForm.bridgeMember3.whichOfficer);
                SaveMyFileBro += Officer1_String;
            }
            if (MemberJobs4.Rows.Count > 0)
            {
                var Jobs4 = MemberJobs4.AsEnumerable().OrderBy(row => row.Field<string>("Job")).CopyToDataTable();
                var SkillsList4 = combinedSkillList(theForm.bridgeMember4);
                var SelectedTalents4 = theForm.bridgeMember4.returnSelectedTalents();
                var Officer1_String = CombinedCharacterString(Jobs4, SelectedTalents4, SkillsList4, theForm.bridgeMember4.whichOfficer);
                SaveMyFileBro += Officer1_String;
            }
            if (MemberJobs5.Rows.Count > 0)
            {
                var Jobs5 = MemberJobs5.AsEnumerable().OrderBy(row => row.Field<string>("Job")).CopyToDataTable();
                var SkillsList5 = combinedSkillList(theForm.bridgeMember5);
                var SelectedTalents5 = theForm.bridgeMember5.returnSelectedTalents();
                var Officer1_String = CombinedCharacterString(Jobs5, SelectedTalents5, SkillsList5, theForm.bridgeMember5.whichOfficer);
                SaveMyFileBro += Officer1_String;
            }
            if (MemberJobs6.Rows.Count > 0)
            {
                var Jobs6 = MemberJobs6.AsEnumerable().OrderBy(row => row.Field<string>("Job")).CopyToDataTable();
                var SkillsList6 = combinedSkillList(theForm.bridgeMember6);
                var SelectedTalents6 = theForm.bridgeMember6.returnSelectedTalents();
                var Officer1_String = CombinedCharacterString(Jobs6, SelectedTalents6, SkillsList6, theForm.bridgeMember6.whichOfficer);
                SaveMyFileBro += Officer1_String;
            }
            if (MemberJobs7.Rows.Count > 0)
            {
                var Jobs7 = MemberJobs7.AsEnumerable().OrderBy(row => row.Field<string>("Job")).CopyToDataTable();
                var SkillsList7 = combinedSkillList(theForm.bridgeMember7);
                var SelectedTalents7 = theForm.bridgeMember7.returnSelectedTalents();
                var Officer1_String = CombinedCharacterString(Jobs7, SelectedTalents7, SkillsList7, theForm.bridgeMember7.whichOfficer);
                SaveMyFileBro += Officer1_String;
            }

            ShalunSaves(SaveMyFileBro, GroupName);
        }
        private void ShalunSaves(string saveString, string GroupName)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "STF_Crew_" + GroupName + ".txt";
            savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(savefile.FileName))
                    sw.Write(saveString);
            }
        }
        private string CombinedCharacterString(DataTable Jobs, DataTable Talents, List<string> Skills, string Officer)
        {
            String sT = "\t";
            String dT = "\t\t";
            String tT = "\t\t\t";
            string myString = "";
            string rC = "\n";
            myString += "---------------------------------------------------" + "\n";
            myString += Officer + rC;
            myString += "---------------------------------------------------" + "\n";
            myString += "-------------------------------------------" + "\n";
            myString += "Jobs" + rC;
            myString += "-------------------------------------------" + "\n";
            foreach (DataRow dr in Jobs.Rows)
            {
                var newString = dr[1].ToString() + sT + dr[0].ToString() + rC;
                myString += newString;
            }
            myString += "-------------------------------------------" + "\n";
            myString += "Skills" + rC;
            myString += "-------------------------------------------" + "\n";
            foreach (string aString in Skills)
            {
                myString += aString + rC;
            }
            myString += "-------------------------------------------" + "\n";
            myString += "Talents" + rC;
            myString += "-------------------------------------------" + "\n";
            foreach (DataRow dr in Talents.Rows)
            {
                var newString = NewTalentString(dr);
                myString += newString + rC;
            }
            myString += "================================================================" + "\n";
            return myString;
        }
        private List<string> combinedSkillList(BridgeMember member)
        {
            String sT = "\t";
            String dT = "\t\t";
            String tT = "\t\t\t";
            List<string> myList = new List<string>();
            var firstList = member.returnNumList();
            var secondList = member.returnSkillsList();

            if (firstList.Count > 0)
            {
                for (int x = 0; x < firstList.Count; x++)
                {
                    string newString = firstList[x].ToString() + sT + secondList[x].ToString();
                    myList.Add(newString);
                }
            }
            return myList;
        }
        private string NewTalentString(DataRow dr)
        {
            String sT = "\t";
            String dT = "\t\t";
            String tT = "\t\t\t";
            String fT = "\t\t\t\t";
            String fiT = "\t\t\t\t\t";
            String firstTab = tT;
            String secondTab = dT;
            String thirdTab = sT;
            String fourthTab = sT;
            String wrapBreak = "\n\t\t\t\t\t\t\t\t\t\t\t\t";
            var JobName = dr.Field<string>("Job");
            var Type = dr.Field<string>("Type");
            var Name = dr.Field<string>("Name");
            var Rank = dr.Field<Int32>("Rank");
            var Desc = dr.Field<string>("Description");
            var Cooldown = dr.Field<string>("Cooldown");

            if (Name.Length < 12)
            {
                firstTab = fT;
            }
            else if (Name.Length > 19)
            {
                firstTab = sT;
            }
            else if (Name.Length > 15)
            {
                firstTab = dT;
            }

            
            if (JobName.Length < 5)
            {
                secondTab = fiT;
            }
            else if (JobName.Length < 8)
            {
                secondTab = fT;
            }
            else if (JobName.Length < 12)
            {
                secondTab = tT;
            }
            else if (JobName.Length > 13)
            {
                secondTab = sT;
            }

            if (Desc.Length > 120)
            {
                Desc = Desc.Insert(120, wrapBreak);
                Desc = Desc.Insert(60, wrapBreak);
            }else if (Desc.Length > 60)
            {
                Desc = Desc.Insert(60, wrapBreak);
            }

            string displayRowString = Rank.ToString() + sT + Name + firstTab + JobName + secondTab + Type;
            return displayRowString;
        }
    }
}
