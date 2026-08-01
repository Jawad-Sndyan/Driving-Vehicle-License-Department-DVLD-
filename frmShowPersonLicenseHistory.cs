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
    public partial class frmShowPersonLicenseHistory : Form
    {

        private int _PersonID;
        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
            _PersonID = -1;
        }

        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void frmShowPersonLicenseHistoryForm_Load(object sender, EventArgs e)
        {
            if(_PersonID!=-1)
            {
                ucPersonCardWithFilter.LoadPersonInfo(_PersonID);
                ucPersonCardWithFilter.FilterEnalbled = false;
                ucDriverLicenses.LoadInfoByPersonID(_PersonID);
            }
            else
            {
                ucPersonCardWithFilter.FilterEnalbled = true;
                ucPersonCardWithFilter.FilterFocus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate= AutoValidate.Disable;
            this.Close();
        }

        private void ucPersonCardWithFilter_OnPersonSelected(int obj)
        {
            _PersonID= obj;
            if(_PersonID==-1)
            {
                ucDriverLicenses.Clear();
            }
            else
            {
                ucDriverLicenses.LoadInfoByPersonID(_PersonID);
            }
        }
    }
}
