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
    public partial class ConfigureShipForm : Form
    {
        MainForm myPrevForm;

        public ConfigureShipForm()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(ShipFormClosing);
        }
        private void ShipFormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (shipConfigureMenu1.SelectedShipTable.Rows.Count > 0)
            {
                myPrevForm.theShip = shipConfigureMenu1.SaveShipData();
                myPrevForm.shipCrewAndDiceControl1.UpdateCrewSkills();
            }
        }
        public void SetPrevForm(MainForm aForm)
        {
            myPrevForm = aForm;
        }
        public void ShipUpdate(DataStorage.SelectedShip myShip)
        {
            shipConfigureMenu1.ShipUpdate(myShip);
            componentSelect1.ShipUpdate(myShip);
        }
    }
}
