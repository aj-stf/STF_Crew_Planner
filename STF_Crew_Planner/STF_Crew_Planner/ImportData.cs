using System;
using System.Data;
using System.IO;
using System.Text;
using CoreTechs.Common.Text;
using System.Linq;

namespace STF_CharacterPlanner
{
    public sealed class DataStorage
    {
        private static readonly Lazy<DataStorage> lazy =
            new Lazy<DataStorage>(() => new DataStorage());

        public static DataStorage Instance { get { return lazy.Value; } }
        public DataTable job_table;
        public DataTable skill_table;
        public DataTable skill_per_job_table;
        public DataTable stf_talent_job_table;
        public DataTable job_list;
        public DataTable capt_job_list;
        public DataTable talent_points_table;
        public DataTable CaptainInfo;
        public DataTable firstOfficerInfo;
        public DataTable secondOfficerInfo;
        public DataTable thirdOfficerInfo;
        public DataTable fourthOfficerInfo;
        public BridgeMember member1;
        public BridgeMember member2;
        public BridgeMember member3;
        public BridgeMember member4;
        public BridgeMember member5;

        private DataStorage()
        {
        }

        public void InstatiateTables()
        {
            createOfficerTables();
            //Load Game Data
            job_table = loadDataFromCSV(Properties.Resources.job_list);
            skill_table = loadDataFromCSV(Properties.Resources.skill_list);
            skill_per_job_table = loadDataFromCSV(Properties.Resources.skill_per_job_list);
            stf_talent_job_table = loadDataFromCSV(Properties.Resources.stf_talent_job);
            talent_points_table = loadDataFromCSV(Properties.Resources.talent_points);
            //Create Job Lists
            job_list = CreateJobList(job_table);
            capt_job_list = CreateCaptJobList(job_table);


            //Reconfigure integer rows
            ChangeColumnType(stf_talent_job_table, "Rank", typeof(int));
            ChangeColumnType(skill_per_job_table, "Rank", typeof(int));
            ChangeColumnType(skill_per_job_table, "1-Num", typeof(int));
            ChangeColumnType(skill_per_job_table, "2-Num", typeof(int));
            ChangeColumnType(skill_per_job_table, "3-Num", typeof(int));
        }
        public void setBridgeMember1(BridgeMember memberAye)
        {
            member1 = memberAye;
        }
        public void setBridgeMember2(BridgeMember memberAye)
        {
            member2 = memberAye;
        }
        public void setBridgeMember3(BridgeMember memberAye)
        {
            member3 = memberAye;
        }
        public void setBridgeMember4(BridgeMember memberAye)
        {
            member4 = memberAye;
        }
        public void setBridgeMember5(BridgeMember memberAye)
        {
            member5 = memberAye;
        }
        public void createOfficerTables()
        {
            CaptainInfo = setNewOfficerTable("Captain");
            firstOfficerInfo = setNewOfficerTable("First Officer");
            secondOfficerInfo = setNewOfficerTable("Second Officer");
            thirdOfficerInfo = setNewOfficerTable("Third Officer");
            fourthOfficerInfo = setNewOfficerTable("Fourth Officer");
        }
        private DataTable setNewOfficerTable(string name)
        {
            var dt = new DataTable();
            dt.TableName = name;
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Job";
            dc.DataType = typeof(String);
            dc.DefaultValue = "null";

            DataColumn dg = new DataColumn();
            dg.ColumnName = "Ranks";
            dg.DataType = typeof(Int32);
            dg.DefaultValue = 0;

            dt.Columns.Add(dc);
            dt.Columns.Add(dg);

            return dt;
        }

        private DataTable loadDataFromCSV(string theString)
        {
            var table = new DataTable();
            TextReader reader = new StringReader(theString);
            using (var it = reader.ReadCsvWithHeader(null, ':', '"').GetEnumerator())
            {

                if (!it.MoveNext()) return table;

                foreach (var k in it.Current.Keys)
                    table.Columns.Add(k);

                do
                {
                    var row = table.NewRow();
                    foreach (var k in it.Current.Keys)
                        row[k] = it.Current[k];

                    table.Rows.Add(row);
                } while (it.MoveNext());
            }
            return table;
        }

        private static void SortDataTable(DataTable dt, string col_name, string term)
        {
            DataTable tblFiltered = dt.AsEnumerable().Where(row => row.Field<String>(col_name) == term).OrderBy(row => row.Field<String>("Job")).CopyToDataTable();
            var myObject = new DataObject();
            var theString = myObject.TableToString(tblFiltered);
            Console.WriteLine(theString);
        }
        private DataTable CreateFilteredTable(DataTable dt, string col_name, string ordered, string term)
        {
            DataTable tblFiltered = dt.AsEnumerable().Where(row => row.Field<String>(col_name) == term).OrderBy(row => row.Field<Int32>(ordered)).CopyToDataTable();
            var myObject = new DataObject();
            var theString = myObject.TableToString(tblFiltered);
            Console.WriteLine(theString);
            return tblFiltered;
        }
        private void ChangeColumnType(DataTable dt, string p, Type type)
        {
            dt.Columns.Add(p + "_new", type);
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                dr[p + "_new"] = Int32.Parse(dr[p].ToString());
            }
            dt.Columns.Remove(p);
            dt.Columns[p + "_new"].ColumnName = p;
        }

        private DataTable CreateJobList(DataTable dt)
        {
            var newDataTable = new DataTable();
            newDataTable.Columns.Add("Job");

            foreach (DataRow item in dt.Rows)
                newDataTable.Rows.Add(item[0]);

            return newDataTable;
        }
        private DataTable CreateCaptJobList(DataTable dt)
        {
            var newDataTable = new DataTable();
            newDataTable.Columns.Add("Job");

            DataTable tblFiltered = dt.AsEnumerable().Where(row => row.Field<String>("Starter") == "Yes").OrderBy(row => row.Field<String>("Job")).CopyToDataTable();

            foreach (DataRow item in tblFiltered.Rows)
                newDataTable.Rows.Add(item[0]);

            return newDataTable;
        }
        public void TestTable(DataTable dt)
        {
            var myObject = new DataObject();

            var myString = myObject.TableToString(dt);
            Console.WriteLine(myString);
        }
    }
    class DataObject
    {
        public string TableToString(DataTable dt)
        {
            StringBuilder TableData = new StringBuilder();
            foreach (DataColumn dc in dt.Columns)
                TableData.AppendFormat("\t{0}", dc.ColumnName);
            TableData.AppendFormat("\n");

            int j = -1;
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    TableData.AppendFormat("\t{0}", dr[dc]);
                }
                TableData.AppendFormat("\n");
            }
            return TableData.ToString();
        }
    }
}

