using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STF_CharacterPlanner
{
    public partial class ConfigureCrewForm : Form
    {
        MainForm myPrevForm;
        public ConfigureCrewForm()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(CrewFormClosing);
            crewInput1.SyncCrewNumber();
        }
        private void CrewFormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            crewInput1.MatchCrewData();
            SaveCrewToMain();
        }
        private void SaveCrewToMain()
        {
            myPrevForm.theCrew = crewInput1.daCrew;
            myPrevForm.shipCrewAndDiceControl1.UpdateCrewSkills();
        }
        public void SetPrevForm(MainForm aForm)
        {
            myPrevForm = aForm;
        }
        public void CrewUpdateToOld(List<DataStorage.CrewDataStruct> myData)
        {
            crewInput1.SetTheCrewData(myData);
        }
    }
}
