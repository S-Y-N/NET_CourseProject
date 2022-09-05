using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetVet
{
    public partial class Doctor : Form
    {
        public Doctor()
        {
            InitializeComponent();
           
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            uC_Doc_Dashbord1.Visible = true;
            uC_Doc_Dashbord1.BringToFront();
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            btnDashbord.PerformClick();
            uC_Doc_AddMed1.Visible = false;
            uC_Doc_ViewMed1.Visible = false;
            uC_Doc_Update1.Visible = false;
            uС_Validate1.Visible = false;
            uC_Doc_Sell1.Visible = false;
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            uC_Doc_AddMed1.Visible = true;
            uC_Doc_AddMed1.BringToFront();
        }

        private void btnViewMed_Click(object sender, EventArgs e)
        {
            uC_Doc_ViewMed1.Visible = true;
            uC_Doc_ViewMed1.BringToFront();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            uC_Doc_Update1.Visible = true;
            uC_Doc_Update1.BringToFront();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            uС_Validate1.Visible = true;
            uС_Validate1.BringToFront();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            uC_Doc_Sell1.Visible = true;
            uC_Doc_Sell1.BringToFront();
        }
    }
}
