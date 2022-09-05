using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetVet.DoctorUI
{
    public partial class UC_Doc_AddMed : UserControl
    {
        function fn = new function();
        String query;

        public UC_Doc_AddMed()
        {
            InitializeComponent();
        }

      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtMedicID.Text!="" && txtMedName.Text !="" && txtMedNum.Text!="" && txtQuantity.Text!="" && txtPricePerUnit.Text != "")
            {
                String mid = txtMedicID.Text;
                String mname = txtMedName.Text;
                String mnumber = txtMedNum.Text;
                String mdate = txtManufDate.Text;
                String edate = txtExpDate.Text;
                Int64 quant = Int64.Parse(txtQuantity.Text);
                Int64 perunit = Int64.Parse(txtPricePerUnit.Text);

                query = "insert into medic (mid, mname, mnumber, mDate, eDate, quantity, perUnit) " +
                "values('"+mid+ "','" + mname + "','" + mnumber + "','" + mdate + "','" + edate + "','" + quant + "','" + perunit + "')";

                fn.setData(query, "Препарат доданий в БД");
            
            }
            else
            {
                MessageBox.Show("Заповніть всі поля!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        public void clearAll()
        {
            txtMedicID.Clear();
            txtMedName.Clear();
            txtMedNum.Clear();
            txtQuantity.Clear();
            txtPricePerUnit.Clear();
            txtManufDate.ResetText();
            txtExpDate.ResetText();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
