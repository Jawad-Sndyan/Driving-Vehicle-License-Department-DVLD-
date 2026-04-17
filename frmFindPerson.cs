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
    public partial class frmFindPerson : Form
    {

        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;
        public frmFindPerson(int PersonID)
        {
            InitializeComponent();
            ucPersonCardWithFilter.LoadPersonInfo(PersonID);
        }

        public frmFindPerson(string NationalNo)
        {
            InitializeComponent();
            ucPersonCardWithFilter.LoadPersonInfo(NationalNo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ucPersonCardWithFilter.PersonID);
            this.Close();
        }

        private void frmFindPerson_Load(object sender, EventArgs e)
        {

        }
    }
}
