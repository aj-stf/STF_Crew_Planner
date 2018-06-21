using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STF_CharacterPlanner
{
    public partial class ShipCrewMenu : UserControl
    {
        MainForm theForm;

        public ShipCrewMenu()
        {
            InitializeComponent();
        }
        public void SetPrevForm(MainForm aForm)
        {
            theForm = aForm;
            SetShipMax();
        }
        private void SetShipMax()
        {
            if (theForm.theShip.isSet)
            {
                int myInt = Int32.Parse(theForm.theShip.Ship.Rows[0]["Max Crew"].ToString());
                ShipMaxCrew.Text = myInt.ToString();
            }
        }
        private void resetCrewButton_Click(object sender, EventArgs e)
        {
            ConfigureCrewForm theForm = (this.Parent as ConfigureCrewForm);
            theForm.crewInput1.ResetTheCrew();
        }
    }
}
