using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STF_CharacterPlanner
{
    public partial class MainForm : Form
    {
        public DataStorage stf_Data;

        public MainForm()
        {
            InitializeComponent();
            stf_Data = DataStorage.Instance;
            stf_Data.InstatiateTables();
            bridgeMember1.setWhichOfficer("Captain");
            bridgeMember2.setWhichOfficer("First Officer");
            bridgeMember3.setWhichOfficer("Second Officer");
            bridgeMember4.setWhichOfficer("Third Officer");
            bridgeMember5.setWhichOfficer("Fourth Officer");
            stf_Data.setBridgeMember1(bridgeMember1);
            stf_Data.setBridgeMember2(bridgeMember1);
            stf_Data.setBridgeMember3(bridgeMember1);
            stf_Data.setBridgeMember4(bridgeMember1);
            stf_Data.setBridgeMember5(bridgeMember1);
        }
        public void resetCrewForms()
        {
            bridgeMember1.resetTheBridge();
            bridgeMember2.resetTheBridge();
            bridgeMember3.resetTheBridge();
            bridgeMember4.resetTheBridge();
            bridgeMember5.resetTheBridge();
            menu_Control1.SetGroupName("");
        }
        public void createNewTextFile()
        {
            OutputToFile NewSave = new OutputToFile();
            NewSave.createNewTextFile(this);
        }
        public void SaveCrewTemplate()
        {
            var NewTemplateSave = new SaveLoadHandler();
            NewTemplateSave.SaveCrewTemplate(this);
        }
        public void LoadCrewTemplate()
        {
            var NewTemplateSave = new SaveLoadHandler();
            resetCrewForms();
            NewTemplateSave.LoadCrewTemplate(this);
        }
    }
}
