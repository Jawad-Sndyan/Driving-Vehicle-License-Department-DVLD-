using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmPersonDetailes : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;
        public frmPersonDetailes(int PersonID)
        {
            InitializeComponent();
            ucPersonCard.LoadPersonInfo(PersonID);
        }

        public frmPersonDetailes(string NationalNo)
        {
            InitializeComponent();
            ucPersonCard.LoadPersonInfo(NationalNo);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonDetailes_Load(object sender, EventArgs e)
        {

        }
    }
}
