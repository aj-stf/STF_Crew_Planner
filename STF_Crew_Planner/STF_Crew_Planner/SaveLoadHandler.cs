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
    class SaveLoadHandler
    {
        public void SaveCrewTemplate(MainForm theForm)
        {
            CreateTemplateFile(theForm);
        }
        public void LoadCrewTemplate(MainForm theForm)
        {
            LoadTemplateFile(theForm);
        }
        private void LoadTemplateFile(MainForm theForm)
        {
            DataSet CrewTemplate = new DataSet();
            OpenFileDialog loadFile = new OpenFileDialog();
            loadFile.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            if (loadFile.ShowDialog() == DialogResult.OK)
            {
                CrewTemplate.ReadXml(loadFile.FileName);
            }
            if (CrewTemplate == null)
            {
                return;
            }
            if (CrewTemplate.Tables.Count > 1)
            {
                LoadTemplateToGUI(theForm, CrewTemplate);
            }
        }
        private void LoadTemplateToGUI(MainForm theForm, DataSet ds)
        {
            DataTable MemberJobs1 = new DataTable();
            DataTable MemberJobs2 = new DataTable();
            DataTable MemberJobs3 = new DataTable();
            DataTable MemberJobs4 = new DataTable();
            DataTable MemberJobs5 = new DataTable();
            DataTable MemberJobs6 = new DataTable();
            DataTable MemberJobs7 = new DataTable();
            DataTable SelectedTalents1 = new DataTable();
            DataTable SelectedTalents2 = new DataTable();
            DataTable SelectedTalents3 = new DataTable();
            DataTable SelectedTalents4 = new DataTable();
            DataTable SelectedTalents5 = new DataTable();
            DataTable SelectedTalents6 = new DataTable();
            DataTable SelectedTalents7 = new DataTable();
            DataTable CrewName = new DataTable();
            DataTable ShipData = new DataTable();
            DataTable SmallComponentData = new DataTable();
            DataTable MediumComponentData = new DataTable();
            DataTable LargeComponentData = new DataTable();

            foreach (DataTable dt in ds.Tables)
            {
                if (dt.TableName.Contains("Crew Name"))
                {
                    CrewName = dt.Copy();
                    string theName = "";
                    foreach (DataRow dr in CrewName.Rows)
                    {
                        theName = dr[0].ToString();
                    }
                    theForm.menu_Control1.SetGroupName(theName);
                }
                if (dt.TableName.Contains("Crew Data"))
                {
                    theForm.theCrew = CreateCrewObject(dt);
                }
                if (dt.TableName.Contains("Ship Data"))
                {
                    theForm.theShip.Ship = dt.Copy();
                    theForm.theShip.Name = dt.Rows[0][0].ToString();
                    theForm.theShip.isSet = true;
                }
                if (dt.TableName.Contains("Small Components"))
                {
                    theForm.theShip.Components.Small = dt.Copy();
                }
                if (dt.TableName.Contains("Medium Components"))
                {
                    theForm.theShip.Components.Medium = dt.Copy();
                }
                if (dt.TableName.Contains("Large Components"))
                {
                    theForm.theShip.Components.Large = dt.Copy();
                }
                if (dt.TableName.Contains("Job1"))
                {
                    MemberJobs1 = dt.Copy();
                    theForm.bridgeMember1.officerControl1.LoadFromTemplate(MemberJobs1);
                }
                if (dt.TableName.Contains("Job2"))
                {
                    MemberJobs2 = dt.Copy();
                    theForm.bridgeMember2.officerControl1.LoadFromTemplate(MemberJobs2);
                }
                if (dt.TableName.Contains("Job3"))
                {
                    MemberJobs3 = dt.Copy();
                    theForm.bridgeMember3.officerControl1.LoadFromTemplate(MemberJobs3);
                }
                if (dt.TableName.Contains("Job4"))
                {
                    MemberJobs4 = dt.Copy();
                    theForm.bridgeMember4.officerControl1.LoadFromTemplate(MemberJobs4);
                }
                if (dt.TableName.Contains("Job5"))
                {
                    MemberJobs5 = dt.Copy();
                    theForm.bridgeMember5.officerControl1.LoadFromTemplate(MemberJobs5);
                }
                if (dt.TableName.Contains("Job6"))
                {
                    MemberJobs6 = dt.Copy();
                    theForm.bridgeMember6.officerControl1.LoadFromTemplate(MemberJobs6);
                }
                if (dt.TableName.Contains("Job7"))
                {
                    MemberJobs7 = dt.Copy();
                    theForm.bridgeMember7.officerControl1.LoadFromTemplate(MemberJobs7);
                }
                if (dt.TableName.Contains("Talent1"))
                {
                    SelectedTalents1 = dt.Copy();
                    theForm.bridgeMember1.availableTalents1.LoadTalentsFromFile(SelectedTalents1);
                }
                if (dt.TableName.Contains("Talent2"))
                {
                    SelectedTalents2 = dt.Copy();
                    theForm.bridgeMember2.availableTalents1.LoadTalentsFromFile(SelectedTalents2);
                }
                if (dt.TableName.Contains("Talent3"))
                {
                    SelectedTalents3 = dt.Copy();
                    theForm.bridgeMember3.availableTalents1.LoadTalentsFromFile(SelectedTalents3);
                }
                if (dt.TableName.Contains("Talent4"))
                {
                    SelectedTalents4 = dt.Copy();
                    theForm.bridgeMember4.availableTalents1.LoadTalentsFromFile(SelectedTalents4);
                }
                if (dt.TableName.Contains("Talent5"))
                {
                    SelectedTalents5 = dt.Copy();
                    theForm.bridgeMember5.availableTalents1.LoadTalentsFromFile(SelectedTalents5);
                }
                if (dt.TableName.Contains("Talent6"))
                {
                    SelectedTalents6 = dt.Copy();
                    theForm.bridgeMember6.availableTalents1.LoadTalentsFromFile(SelectedTalents6);
                }
                if (dt.TableName.Contains("Talent7"))
                {
                    SelectedTalents7 = dt.Copy();
                    theForm.bridgeMember7.availableTalents1.LoadTalentsFromFile(SelectedTalents7);
                }
            }
            theForm.shipCrewAndDiceControl1.UpdateCrewSkills();
        }
        private void CreateTemplateFile(MainForm theForm)
        {
            DataTable MemberJobs1 = new DataTable();
            DataTable MemberJobs2 = new DataTable();
            DataTable MemberJobs3 = new DataTable();
            DataTable MemberJobs4 = new DataTable();
            DataTable MemberJobs5 = new DataTable();
            DataTable MemberJobs6 = new DataTable();
            DataTable MemberJobs7 = new DataTable();
            DataTable SelectedTalents1 = new DataTable();
            DataTable SelectedTalents2 = new DataTable();
            DataTable SelectedTalents3 = new DataTable();
            DataTable SelectedTalents4 = new DataTable();
            DataTable SelectedTalents5 = new DataTable();
            DataTable SelectedTalents6 = new DataTable();
            DataTable SelectedTalents7 = new DataTable();
            DataTable CrewName = new DataTable();
            DataTable ShipData = new DataTable();
            DataTable CrewData = new DataTable();
            DataTable SmallComponentData = new DataTable();
            DataTable MediumComponentData = new DataTable();
            DataTable LargeComponentData = new DataTable();

            var GroupName = theForm.menu_Control1.ReturnGroupName();
            MemberJobs1 = theForm.bridgeMember1.returnSelectedJobs();
            MemberJobs2 = theForm.bridgeMember2.returnSelectedJobs();
            MemberJobs3 = theForm.bridgeMember3.returnSelectedJobs();
            MemberJobs4 = theForm.bridgeMember4.returnSelectedJobs();
            MemberJobs5 = theForm.bridgeMember5.returnSelectedJobs();
            MemberJobs6 = theForm.bridgeMember6.returnSelectedJobs();
            MemberJobs7 = theForm.bridgeMember7.returnSelectedJobs();
            MemberJobs1.TableName = "Job1";
            MemberJobs2.TableName = "Job2";
            MemberJobs3.TableName = "Job3";
            MemberJobs4.TableName = "Job4";
            MemberJobs5.TableName = "Job5";
            MemberJobs6.TableName = "Job6";
            MemberJobs7.TableName = "Job7";
            
            CrewName = CreateCrewNameDT(GroupName);

            if (MemberJobs1 == null)
            {
                return;
            }

            if (MemberJobs1.Rows.Count > 0)
            {
                SelectedTalents1 = theForm.bridgeMember1.returnSelectedTalents();
            }
            if (MemberJobs2.Rows.Count > 0)
            {
                SelectedTalents2 = theForm.bridgeMember2.returnSelectedTalents();
            }
            if (MemberJobs3.Rows.Count > 0)
            {
                SelectedTalents3 = theForm.bridgeMember3.returnSelectedTalents();
            }
            if (MemberJobs4.Rows.Count > 0)
            {
                SelectedTalents4 = theForm.bridgeMember4.returnSelectedTalents();
            }
            if (MemberJobs5.Rows.Count > 0)
            {
                SelectedTalents5 = theForm.bridgeMember5.returnSelectedTalents();
            }
            if (MemberJobs6.Rows.Count > 0)
            {
                SelectedTalents6 = theForm.bridgeMember6.returnSelectedTalents();
            }
            if (MemberJobs7.Rows.Count > 0)
            {
                SelectedTalents7 = theForm.bridgeMember7.returnSelectedTalents();
            }
            if (theForm.theShip.isSet)
            {
                ShipData = theForm.theShip.Ship.Copy();
                ShipData.TableName = "Ship Data";
                SmallComponentData = theForm.theShip.Components.Small.Copy();
                MediumComponentData = theForm.theShip.Components.Medium.Copy();
                LargeComponentData = theForm.theShip.Components.Large.Copy();
                SmallComponentData.TableName = "Small Components";
                MediumComponentData.TableName = "Medium Components";
                LargeComponentData.TableName = "Large Components";
            }
            if (theForm.theCrew.Count > 0)
            {
                CrewData = CreateCrewTable(theForm.theCrew);
            }
            SelectedTalents1.TableName = "Talent1";
            SelectedTalents2.TableName = "Talent2";
            SelectedTalents3.TableName = "Talent3";
            SelectedTalents4.TableName = "Talent4";
            SelectedTalents5.TableName = "Talent5";
            SelectedTalents6.TableName = "Talent6";
            SelectedTalents7.TableName = "Talent7";
            DataSet CrewTemplate = new DataSet();
            CrewTemplate.Tables.Add(CrewName);
            CrewTemplate.Tables.Add(MemberJobs1);
            CrewTemplate.Tables.Add(MemberJobs2);
            CrewTemplate.Tables.Add(MemberJobs3);
            CrewTemplate.Tables.Add(MemberJobs4);
            CrewTemplate.Tables.Add(MemberJobs5);
            CrewTemplate.Tables.Add(MemberJobs6);
            CrewTemplate.Tables.Add(MemberJobs7);
            CrewTemplate.Tables.Add(SelectedTalents1);
            CrewTemplate.Tables.Add(SelectedTalents2);
            CrewTemplate.Tables.Add(SelectedTalents3);
            CrewTemplate.Tables.Add(SelectedTalents4);
            CrewTemplate.Tables.Add(SelectedTalents5);
            CrewTemplate.Tables.Add(SelectedTalents6);
            CrewTemplate.Tables.Add(SelectedTalents7);
            CrewTemplate.Tables.Add(CrewData);
            CrewTemplate.Tables.Add(ShipData);
            CrewTemplate.Tables.Add(SmallComponentData);
            CrewTemplate.Tables.Add(MediumComponentData);
            CrewTemplate.Tables.Add(LargeComponentData);

            ShalunSaves(CrewTemplate, GroupName);
        }
        private void ShalunSaves(DataSet CrewTemplate, string GroupName)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "STF_Crew_" + GroupName + ".xml";
            savefile.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                CrewTemplate.WriteXml(savefile.FileName);
            }
        }
        private DataTable CreateCrewNameDT(string CrewName)
        {
            DataTable dt = new DataTable();
            dt.TableName = "Crew Name";
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Name";
            dc.DataType = typeof(String);
            dc.DefaultValue = "null";
            dt.Columns.Add(dc);
            if (CrewName.Length > 0)
            {

            }else
            {
                CrewName = "The No Names";
            }
            DataRow dr = dt.NewRow();
            dr[0] = CrewName.ToString();
            dt.Rows.Add(dr);

            return dt;
        }
        private DataTable CreateCrewTable(List<DataStorage.CrewDataStruct>CrewList)
        {
            var dt = new DataTable();
            dt.TableName = "Crew Data";
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Job";
            dc.DataType = typeof(String);
            dc.DefaultValue = "null";

            DataColumn df = new DataColumn();
            df.ColumnName = "Num";
            df.DataType = typeof(Int32);
            df.DefaultValue = 0;

            DataColumn dg = new DataColumn();
            dg.ColumnName = "Rank";
            dg.DataType = typeof(Int32);
            dg.DefaultValue = 0;

            dt.Columns.Add(dc);
            dt.Columns.Add(df);
            dt.Columns.Add(dg);

            foreach (DataStorage.CrewDataStruct member in CrewList)
            {
                DataRow dr = dt.NewRow();
                dr[0] = member.Job;
                dr[1] = member.Num;
                dr[2] = member.Rank;
                dt.Rows.Add(dr);
             }
            return dt;
        }
        private List<DataStorage.CrewDataStruct>CreateCrewObject(DataTable theCrew)
        {
            var myCrew = new List<DataStorage.CrewDataStruct>();

            foreach(DataRow dr in theCrew.Rows)
            {
                var aCrew = new DataStorage.CrewDataStruct();
                aCrew.Job = dr[0].ToString();
                aCrew.Num = Int32.Parse(dr[1].ToString());
                aCrew.Rank = Int32.Parse(dr[2].ToString());

                myCrew.Add(aCrew);
            }

            return myCrew;
        }
    }
}
