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
    class OutputToTable
    {
        DataObject testObject;
        MainForm aForm;
        List<DataStorage.CrewDataStruct> theCrew;
        DataStorage stfData;
        string td1;
        string td2;
        string tr1;
        string tr2;
        string tb1;
        string tb2;

        public void createNewTextFile(MainForm theForm)
        {
            stfData = theForm.ReturnMainData();
            testObject = new DataObject();

            td1 = "[td style=\"padding: 6px; \"]";
            td2 = "[/td]\n";
            tr1 = "[tr]\n";
            tr2 = "[/tr]\n";
            tb1 = "[table][tbody]\n";
            tb2 = "[/tbody][/table]\n";
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
            DataTable dt = stfData.STF_Ship_Weapons.Clone();
            foreach (DataRow dr in theShip.Components.Large.Rows)
            {
                foreach (DataRow dw in stfData.STF_Ship_Weapons.Rows)
                {
                    if (dw["Name"].Equals(dr["Name"]))
                    {
                        dt.ImportRow(dw);
                    }
                }
            }
            foreach (DataRow dr in theShip.Components.Medium.Rows)
            {
                foreach (DataRow dw in stfData.STF_Ship_Weapons.Rows)
                {
                    if (dw["Name"].Equals(dr["Name"]))
                    {
                        dt.ImportRow(dw);
                    }
                }
            }
            foreach (DataRow dr in theShip.Components.Small.Rows)
            {
                foreach (DataRow dw in stfData.STF_Ship_Weapons.Rows)
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
        private string ReturnDTtoTableStringNoHeader(DataTable theTable)
        {
            var myString = "";
            myString += tb1;
            int x = theTable.Columns.Count;
            foreach (DataRow dr in theTable.Rows)
            {
                myString += tr1;
                for (int y = 0; y < x; y++)
                {
                    myString += td1 + dr[y].ToString() + td2;
                }
                myString += tr2;
            }
            myString += tb2;

            return myString;
        }
        private string ReturnDTtoTableStringHeader(DataTable theTable)
        {
            var myString = "";
            myString += tb1;
            int x = theTable.Columns.Count;
            myString += tr1;
            foreach (DataColumn dc in theTable.Columns)
            {
                myString += td1 + dc.ColumnName.ToString() + td2;
            }
            myString += tr2;
            foreach (DataRow dr in theTable.Rows)
            {
                myString += tr1;
                for (int y = 0; y < x; y++)
                {
                    myString += td1 + dr[y].ToString() + td2;
                }
                myString += tr2;
            }
            myString += tb2;

            return myString;
        }
        private string CombinedCharacterString(DataTable Jobs, DataTable Talents, DataTable Skills, string Officer)
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
            myString += ReturnDTtoTableStringNoHeader(Jobs);
            myString += "-------------------------------------------" + "\n";
            myString += "Skills" + rC;
            myString += "-------------------------------------------" + "\n";
            myString += ReturnDTtoTableStringNoHeader(Skills);
            myString += "-------------------------------------------" + "\n";
            myString += "Talents" + rC;
            myString += "-------------------------------------------" + "\n";
            myString += ReturnDTtoTableStringNoHeader(Talents);
            myString += "================================================================" + "\n";
            return myString;
        }
        
        private DataTable combinedSkillList(BridgeMember member)
        {
            var dt = new DataTable();

            var firstList = member.returnNumList();
            var secondList = member.returnSkillsList();

            DataColumn dc = new DataColumn();
            dc.ColumnName = "Skill";
            dc.DataType = typeof(String);
            dc.DefaultValue = "null";

            DataColumn dg = new DataColumn();
            dg.ColumnName = "Rank";
            dg.DataType = typeof(Int32);
            dg.DefaultValue = 0;

            dt.Columns.Add(dc);
            dt.Columns.Add(dg);

            if (firstList.Count > 0)
            {
                for (int x = 0; x < firstList.Count; x++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = secondList[x];
                    dr[1] = firstList[x];
                    dt.Rows.Add(dr);
                }
            }
            return dt;
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
            myString += ReturnDTtoTableStringNoHeader(ReturnCleanShipTable(theShip.Ship));
            
            myString += "---------------------------------------------------" + rC;
            myString += "Ship Components" + rC;
            myString += "---------------------------------------------------" + rC;
            myString += "-------------------------------------------" + rC;
            myString += "Large Components" + rC;
            myString += "-------------------------------------------" + rC;
            myString += ReturnDTtoTableStringNoHeader(ReturnCleanCompTable(largeTable));
            myString += "-------------------------------------------" + rC;
            myString += "Medium Components" + rC;
            myString += "-------------------------------------------" + rC;
            myString += ReturnDTtoTableStringNoHeader(ReturnCleanCompTable(mediumTable));
            myString += "-------------------------------------------" + rC;
            myString += "Small Components" + rC;
            myString += "-------------------------------------------" + rC;
            myString += ReturnDTtoTableStringNoHeader(ReturnCleanCompTable(smallTable));

            myString += ReturnDTtoTableStringHeader(ReturnWeaponsTable(theShip));
            myString += "================================================================" + rC;
            myString += "---------------------------------------------------" + rC;
            myString += "Dice Pools" + rC;
            myString += "---------------------------------------------------" + rC;
            myString += "-------------------------------------------" + rC;
            myString += "Ship Combat Dice (Standard Dice counted as 1/2 Strong Dice)" + rC;
            myString += "-------------------------------------------" + rC;
            
            CombatPools NewPools = new CombatPools();
            DataTable myPools = NewPools.CalculateTableCombatPools(aForm.theCrew, aForm);
            myString += ReturnDTtoTableStringHeader(myPools);
            myString += "-------------------------------------------" + rC;
            myString += "Crew Dice" + rC;
            myString += "-------------------------------------------" + rC;
            SkillPools Skills = new SkillPools();
            DataTable ShipSkillTable = Skills.CalculateShipSkillTable(aForm.theCrew, aForm);
            DataTable CrewSkillTable = Skills.CalculateCrewSkillTable(aForm.theCrew, aForm);

            if (ShipSkillTable.Rows.Count > 0)
            {
                myString += ReturnDTtoTableStringHeader(ShipSkillTable);
            }
            if (CrewSkillTable.Rows.Count > 0)
            {
                myString += ReturnDTtoTableStringHeader(CrewSkillTable);
            }
            myString += "================================================================" + rC;
            return myString;
        }
        private DataTable ReturnCleanShipTable(DataTable dt)
        {
            var newDT = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Stat";
            dc.DataType = typeof(String);
            dc.DefaultValue = "null";
            DataColumn dg = new DataColumn();
            dg.ColumnName = "Value";
            dg.DataType = typeof(String);
            dg.DefaultValue = "null";
            newDT.Columns.Add(dc);
            newDT.Columns.Add(dg);

            for (int x = 0; x < dt.Columns.Count; x++)
            {
                DataRow myRow = newDT.NewRow();
                myRow[0] = dt.Columns[x].ColumnName;
                myRow[1] = dt.Rows[0][x].ToString();
                newDT.Rows.Add(myRow);
            }

            return newDT;
        }
        private DataTable ReturnCleanCompTable(DataTable dt)
        {
            var newDT = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Component";
            dc.DataType = typeof(String);
            dc.DefaultValue = "null";
            newDT.Columns.Add(dc);

            foreach (DataRow dr in dt.Rows)
            {
                DataRow myRow = newDT.NewRow();
                myRow[0] = dr[0].ToString();
                newDT.Rows.Add(myRow);
            }

            return newDT;
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
            var myDT = ReturnCrewTable(theCrew);
            myString += ReturnDTtoTableStringHeader(myDT);
            return myString;
        }
        private DataTable ReturnCrewTable(List<DataStorage.CrewDataStruct> theCrew)
        {
            var dt = new DataTable();

            DataColumn dc = new DataColumn();
            dc.ColumnName = "Job";
            dc.DataType = typeof(String);
            dc.DefaultValue = "null";

            DataColumn dg = new DataColumn();
            dg.ColumnName = "Num";
            dg.DataType = typeof(Int32);
            dg.DefaultValue = 0;

            DataColumn dg2 = new DataColumn();
            dg2.ColumnName = "Rank";
            dg2.DataType = typeof(Int32);
            dg2.DefaultValue = 0;

            dt.Columns.Add(dc);
            dt.Columns.Add(dg);
            dt.Columns.Add(dg2);

            if (theCrew.Count > 0)
            {
                for (int x = 0; x < theCrew.Count; x++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = theCrew[x].Job;
                    dr[1] = theCrew[x].Num;
                    dr[2] = theCrew[x].Rank;
                    if (theCrew[x].Num > 0)
                    {
                        dt.Rows.Add(dr);
                    }
                }
            }


            return dt;
        }
    }
}
