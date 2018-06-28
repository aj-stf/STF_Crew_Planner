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
        DataObject testObject;
        MainForm aForm;
        List<DataStorage.CrewDataStruct> theCrew;

        public void createNewTextFile(MainForm theForm)
        {
            testObject = new DataObject();

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
            DataTable MyWeaponsTable = new DataTable();

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

            aForm = theForm;

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
            if (theForm.theCrew.Count > 0)
            {
                var myString = ReturnCrewString(theForm.theCrew);
                SaveMyFileBro += myString;
            }
            if (theForm.theShip.isSet)
            {
                var myString = ReturnShipString(theForm.theShip);
                SaveMyFileBro += myString;
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
        private DataTable ReturnWeaponsTable(DataStorage.SelectedShip theShip)
        {
            DataStorage stf_Data = DataStorage.Instance;
            stf_Data.InstatiateTables();

            DataTable dt = stf_Data.STF_Ship_Weapons.Clone();
            foreach (DataRow dr in theShip.Components.Large.Rows)
            {
                foreach (DataRow dw in stf_Data.STF_Ship_Weapons.Rows)
                {
                    if (dw["Name"].Equals(dr["Name"]))
                    {
                        dt.ImportRow(dw);
                    }
                }
            }
            foreach (DataRow dr in theShip.Components.Medium.Rows)
            {
                foreach (DataRow dw in stf_Data.STF_Ship_Weapons.Rows)
                {
                    if (dw["Name"].Equals(dr["Name"]))
                    {
                        dt.ImportRow(dw);
                    }
                }
            }
            foreach (DataRow dr in theShip.Components.Small.Rows)
            {
                foreach (DataRow dw in stf_Data.STF_Ship_Weapons.Rows)
                {
                    if (dw["Name"].Equals(dr["Name"]))
                    {
                        dt.ImportRow(dw);
                    }
                }
            }

            DataTable sortedDT = new DataTable();

            if (testObject.DataTableValid(dt))
            {
                sortedDT = dt.AsEnumerable().OrderBy(row => row.Field<string>("Name")).CopyToDataTable();
            }
            return dt;
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

        private string ReturnShipString(DataStorage.SelectedShip theShip)
        {
            String sT = "\t";
            String dT = "\t\t";
            String tT = "\t\t\t";
            String fT = "\t\t\t\t";
            String fiT = "\t\t\t\t\t";
            string rC = "\n";
            var myString = "";
            DataTable largeTable = new DataTable();
            DataTable mediumTable = new DataTable();
            DataTable smallTable = new DataTable();


            if (testObject.DataTableValid(theShip.Components.Large))
            {
                largeTable = theShip.Components.Large.AsEnumerable().OrderBy(row => row.Field<string>("Name")).CopyToDataTable();
            }
            if (testObject.DataTableValid(theShip.Components.Large))
            {
                mediumTable = theShip.Components.Medium.AsEnumerable().OrderBy(row => row.Field<string>("Name")).CopyToDataTable();
            }
            if (testObject.DataTableValid(theShip.Components.Large))
            {
                smallTable = theShip.Components.Small.AsEnumerable().OrderBy(row => row.Field<string>("Name")).CopyToDataTable();
            }


            myString += "================================================================" + rC;
            myString += "---------------------------------------------------" + rC;
            myString += "Ship Readout" + rC;
            myString += "---------------------------------------------------" + rC;
            if (theShip.Ship.Rows.Count > 0)
            {
                foreach (DataRow dr in theShip.Ship.Rows)
                {
                    for (int x = 0; x < theShip.Ship.Columns.Count; x++)
                    {
                        var colName = theShip.Ship.Columns[x].ColumnName;
                        var aString = dr[x].ToString();
                        var shipString = ShipRowString(colName, aString);
                        if (colName.Equals("Tier"))
                        {

                        }
                        else
                        {
                            myString += shipString + rC;
                        }
                    }
                }
            }
            
            myString += "---------------------------------------------------" + rC;
            myString += "Ship Components" + rC;
            myString += "---------------------------------------------------" + rC;
            myString += "-------------------------------------------" + rC;
            myString += "Large Components" + rC;
            myString += "-------------------------------------------" + rC;
            
            foreach (DataRow dr in largeTable.Rows)
            {
                var aString = dr[0].ToString();
                myString += aString + rC;
            }
            myString += "-------------------------------------------" + rC;
            myString += "Medium Components" + rC;
            myString += "-------------------------------------------" + rC;
            foreach (DataRow dr in mediumTable.Rows)
            {
                var aString = dr[0].ToString();
                myString += aString + rC;
            }
            myString += "-------------------------------------------" + rC;
            myString += "Small Components" + rC;
            myString += "-------------------------------------------" + rC;
            foreach (DataRow dr in smallTable.Rows)
            {
                var aString = dr[0].ToString();
                myString += aString + rC;
            }

            myString += WeaponsString(ReturnWeaponsTable(theShip));
            myString += "================================================================" + rC;
            myString += "---------------------------------------------------" + rC;
            myString += "Dice Pools" + rC;
            myString += "---------------------------------------------------" + rC;
            myString += "-------------------------------------------" + rC;
            myString += "Ship Combat Dice" + rC;
            myString += "-------------------------------------------" + rC;
            
            CombatPools NewPools = new CombatPools();
            List<string> myPools = NewPools.CalculateOutputCombatPools(aForm.theCrew, aForm);
            foreach (var aString in myPools)
            {
                myString += aString + rC;
            }
            myString += "-------------------------------------------" + rC;
            myString += "Crew Dice" + rC;
            myString += "-------------------------------------------" + rC;
            SkillPools Skills = new SkillPools();
            List<string> SkPools = Skills.CalculateSkillPools(aForm.theCrew, aForm);
            foreach (var aString in SkPools)
            {
                myString += aString + rC;
            }
            myString += "================================================================" + rC;
            return myString;
        }
        private string WeaponsString(DataTable dt)
        {
            var myString = "";
            String sT = "\t";
            String dT = "\t\t";
            String tT = "\t\t\t";
            String fT = "\t\t\t\t";
            String fiT = "\t\t\t\t\t";
            String siT = "\t\t\t\t\t\t";
            string rC = "\n";
            myString += "---------------------------------------------------" + rC;
            myString += "Ship Weapons" + rC;
            myString += "---------------------------------------------------" + rC;
            myString += "Name" + siT + "Rng" + dT + "Dmg" + dT + "Rad" + dT + "Void" + sT + "AP" + dT + "Acc" + dT + "Crit" + sT + "Cripple" + rC;
            foreach (DataRow dr in dt.Rows)
            {
                myString += FirstWeaponReturn(dr["Name"].ToString());

                myString += dr["Range"] + dT + dr["Damage"] + dT + dr["Radiation"] + dT + dr["Void"] + dT + dr["AP"] + dT + dr["Accuracy"] + dT + dr["Critical Chance"] + dT + dr["Cripple Chance"] + rC;
            }

            return myString;
        }
        private string FirstWeaponReturn(string theWeapon)
        {
            var myString = "";
            String sT = "\t";
            String dT = "\t\t";
            String tT = "\t\t\t";
            String fT = "\t\t\t\t";
            String fiT = "\t\t\t\t\t";
            String siT = "\t\t\t\t\t\t";
            string rC = "\n";

            if (theWeapon.Length > 23)
            {
                myString = theWeapon + sT;
            }
            else if (theWeapon.Length > 19)
            {
                myString = theWeapon + dT;
            }
            else if (theWeapon.Length > 15)
            {
                myString = theWeapon + tT;
            }
            else if (theWeapon.Length > 10)
            {
                myString = theWeapon + fT;
            }
            else if (theWeapon.Length > 6)
            {
                myString = theWeapon + fiT;
            }
            else
            {
                myString = theWeapon + siT;
            }

            return myString;
        }
        private string ShipRowString(string NameString, string ValueString)
        {
            var snglTab = "\t";
            var dblTab = "\t\t";
            var trpTab = "\t\t\t";
            var myString = "";
            if (NameString.Length > 15)
            {
                myString = NameString + ":" + snglTab + ValueString;
            }
            else if (NameString.Length > 10)
            {
                myString = NameString + ":" + snglTab + ValueString;
            }
            else if (NameString.Length > 6)
            {
                myString = NameString + ":" + dblTab + ValueString;
            }
            else
            {
                myString = NameString + ":" + trpTab + ValueString;
            }

            return myString;
        }
        private string ReturnCrewString(List<DataStorage.CrewDataStruct> theCrew)
        {
            String sT = "\t";
            String dT = "\t\t";
            String tT = "\t\t\t";
            String fT = "\t\t\t\t";
            String fiT = "\t\t\t\t\t";
            string rC = "\n";
            var myString = "";
            myString += "================================================================" + rC;
            myString += "---------------------------------------------------" + rC;
            myString += "Crew Manifest" + rC;
            myString += "---------------------------------------------------" + rC;
            myString += "Job" + fiT + "Num" + dT + "Rank" + rC;
            foreach (DataStorage.CrewDataStruct member in theCrew)
            {
                if (member.Num > 0)
                {
                    var aString = CrewRowString(member);
                    myString += aString + rC;
                }
            }
            return myString;
        }
        private string CrewRowString(DataStorage.CrewDataStruct aCrew)
        {
            var snglTab = "\t";
            var dblTab = "\t\t";
            var trpTab = "\t\t\t";
            String sT = "\t";
            String dT = "\t\t";
            String tT = "\t\t\t";
            String fT = "\t\t\t\t";
            String fiT = "\t\t\t\t\t";

            var myString = "";
            if (aCrew.Job.Length > 15)
            {
                myString = aCrew.Job + snglTab + aCrew.Num + dblTab + aCrew.Rank;
            }
            else if (aCrew.Job.Length > 11)
            {
                myString = aCrew.Job + dblTab + aCrew.Num + dblTab + aCrew.Rank;
            }
            else if (aCrew.Job.Length > 7)
            {
                myString = aCrew.Job + trpTab + aCrew.Num + dblTab + aCrew.Rank;
            }
            else
            {
                var newString = "";
                if (aCrew.Job.Contains("Spy"))
                {
                    newString = "Spy ";
                }
                else
                {
                    newString = aCrew.Job;
                }
                myString = newString + fT + aCrew.Num + dblTab + aCrew.Rank;
            }

            return myString;
        }
    }
}
