using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STF_CharacterPlanner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var our_stf_data = new STF_Data();
            //our_stf_data.InstatiateTable();
            //DataStorage stf_Data = DataStorage.Instance;
            //stf_Data.InstatiateTables();
            //stf_Data.TestTable(stf_Data.stf_talent_job_table);
            //myImport.loadSTFData();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
