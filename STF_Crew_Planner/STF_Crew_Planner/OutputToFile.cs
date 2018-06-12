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

            if (MemberJobs1 == null)
            {
                return;
            }

            if (MemberJobs1.Rows.Count > 0)
            {
                var SkillsList1 = combinedSkillList(theForm.bridgeMember1);
                var SelectedTalents1 = theForm.bridgeMember1.returnSelectedTalents();
                var Officer1_String = CombinedCharacterString(MemberJobs1, SelectedTalents1, SkillsList1, theForm.bridgeMember1.whichOfficer);
                SaveMyFileBro += Officer1_String;
            }
            if (MemberJobs2.Rows.Count > 0)
            {
                var SkillsList2 = combinedSkillList(theForm.bridgeMember2);
                var SelectedTalents2 = theForm.bridgeMember2.returnSelectedTalents();
                var Officer1_String = CombinedCharacterString(MemberJobs2, SelectedTalents2, SkillsList2, theForm.bridgeMember2.whichOfficer);
                SaveMyFileBro += Officer1_String;
            }
            if (MemberJobs3.Rows.Count > 0)
            {
                var SkillsList3 = combinedSkillList(theForm.bridgeMember3);
                var SelectedTalents3 = theForm.bridgeMember3.returnSelectedTalents();
                var Officer1_String = CombinedCharacterString(MemberJobs3, SelectedTalents3, SkillsList3, theForm.bridgeMember3.whichOfficer);
                SaveMyFileBro += Officer1_String;
            }
            if (MemberJobs4.Rows.Count > 0)
            {
                var SkillsList4 = combinedSkillList(theForm.bridgeMember4);
                var SelectedTalents4 = theForm.bridgeMember4.returnSelectedTalents();
                var Officer1_String = CombinedCharacterString(MemberJobs4, SelectedTalents4, SkillsList4, theForm.bridgeMember4.whichOfficer);
                SaveMyFileBro += Officer1_String;
            }
            if (MemberJobs5.Rows.Count > 0)
            {
                var SkillsList5 = combinedSkillList(theForm.bridgeMember5);
                var SelectedTalents5 = theForm.bridgeMember5.returnSelectedTalents();
                var Officer1_String = CombinedCharacterString(MemberJobs5, SelectedTalents5, SkillsList5, theForm.bridgeMember5.whichOfficer);
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
                var newString = dr[1].ToString() + "    " + dr[0].ToString() + rC;
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
            Console.WriteLine(myString);
            return myString;
        }
        private List<string> combinedSkillList(BridgeMember member)
        {
            List<string> myList = new List<string>();
            var firstList = member.returnNumList();
            var secondList = member.returnSkillsList();

            if (firstList.Count > 0)
            {
                for (int x = 0; x < firstList.Count; x++)
                {
                    string newString = firstList[x].ToString() + "    " + secondList[x].ToString();
                    myList.Add(newString);
                }
            }
            return myList;
        }
        private string NewTalentString(DataRow dr)
        {
            var JobName = dr.Field<string>("Job");
            var Type = dr.Field<string>("Type");
            var Name = dr.Field<string>("Name");
            var Rank = dr.Field<Int32>("Rank");
            var Desc = dr.Field<string>("Description");
            string displayRowString = Rank.ToString() + "    " + Name + "    " + JobName + "    " + Type + "    " + Desc;
            return displayRowString;
        }
    }
}
