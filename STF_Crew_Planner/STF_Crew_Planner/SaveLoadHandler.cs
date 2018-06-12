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
            DataTable SelectedTalents1 = new DataTable();
            DataTable SelectedTalents2 = new DataTable();
            DataTable SelectedTalents3 = new DataTable();
            DataTable SelectedTalents4 = new DataTable();
            DataTable SelectedTalents5 = new DataTable();
            DataTable CrewName = new DataTable();

            foreach(DataTable dt in ds.Tables)
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
                if (dt.TableName.Contains("Captain"))
                {
                    MemberJobs1 = dt.Copy();
                    theForm.bridgeMember1.officerControl1.LoadFromTemplate(MemberJobs1);
                }
                if (dt.TableName.Contains("First Officer"))
                {
                    MemberJobs2 = dt.Copy();
                    theForm.bridgeMember2.officerControl1.LoadFromTemplate(MemberJobs2);
                }
                if (dt.TableName.Contains("Second Officer"))
                {
                    MemberJobs3 = dt.Copy();
                    theForm.bridgeMember3.officerControl1.LoadFromTemplate(MemberJobs3);
                }
                if (dt.TableName.Contains("Third Officer"))
                {
                    MemberJobs4 = dt.Copy();
                    theForm.bridgeMember4.officerControl1.LoadFromTemplate(MemberJobs4);
                }
                if (dt.TableName.Contains("Fourth Officer"))
                {
                    MemberJobs5 = dt.Copy();
                    theForm.bridgeMember5.officerControl1.LoadFromTemplate(MemberJobs5);
                }
                if (dt.TableName.Contains("Table1"))
                {
                    SelectedTalents1 = dt.Copy();
                    theForm.bridgeMember1.availableTalents1.LoadTalentsFromFile(SelectedTalents1);
                }
                if (dt.TableName.Contains("Table2"))
                {
                    SelectedTalents2 = dt.Copy();
                    theForm.bridgeMember2.availableTalents1.LoadTalentsFromFile(SelectedTalents2);
                }
                if (dt.TableName.Contains("Table3"))
                {
                    SelectedTalents3 = dt.Copy();
                    theForm.bridgeMember3.availableTalents1.LoadTalentsFromFile(SelectedTalents3);
                }
                if (dt.TableName.Contains("Table4"))
                {
                    SelectedTalents4 = dt.Copy();
                    theForm.bridgeMember4.availableTalents1.LoadTalentsFromFile(SelectedTalents4);
                }
                if (dt.TableName.Contains("Table5"))
                {
                    SelectedTalents5 = dt.Copy();
                    theForm.bridgeMember5.availableTalents1.LoadTalentsFromFile(SelectedTalents5);
                }
            }
        }
        private void CreateTemplateFile(MainForm theForm)
        {
            DataTable MemberJobs1 = new DataTable();
            DataTable MemberJobs2 = new DataTable();
            DataTable MemberJobs3 = new DataTable();
            DataTable MemberJobs4 = new DataTable();
            DataTable MemberJobs5 = new DataTable();
            DataTable SelectedTalents1 = new DataTable();
            DataTable SelectedTalents2 = new DataTable();
            DataTable SelectedTalents3 = new DataTable();
            DataTable SelectedTalents4 = new DataTable();
            DataTable SelectedTalents5 = new DataTable();
            DataTable CrewName = new DataTable();

            var GroupName = theForm.menu_Control1.ReturnGroupName();
            MemberJobs1 = theForm.bridgeMember1.returnSelectedJobs();
            MemberJobs2 = theForm.bridgeMember2.returnSelectedJobs();
            MemberJobs3 = theForm.bridgeMember3.returnSelectedJobs();
            MemberJobs4 = theForm.bridgeMember4.returnSelectedJobs();
            MemberJobs5 = theForm.bridgeMember5.returnSelectedJobs();
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
            DataSet CrewTemplate = new DataSet();
            CrewTemplate.Tables.Add(CrewName);
            CrewTemplate.Tables.Add(MemberJobs1);
            CrewTemplate.Tables.Add(MemberJobs2);
            CrewTemplate.Tables.Add(MemberJobs3);
            CrewTemplate.Tables.Add(MemberJobs4);
            CrewTemplate.Tables.Add(MemberJobs5);
            CrewTemplate.Tables.Add(SelectedTalents1);
            CrewTemplate.Tables.Add(SelectedTalents2);
            CrewTemplate.Tables.Add(SelectedTalents3);
            CrewTemplate.Tables.Add(SelectedTalents4);
            CrewTemplate.Tables.Add(SelectedTalents5);
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
    }
}
