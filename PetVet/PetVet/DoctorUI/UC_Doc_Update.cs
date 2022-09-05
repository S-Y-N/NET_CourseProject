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
    public partial class UC_Doc_Update : UserControl
    {
        function fn = new function();
        String query;


        public UC_Doc_Update()
        {
            InitializeComponent();
        }

        private void UC_Doc_Update_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtMedID.Text != "")
            {
                query = "select * from medic where mid = '"+txtMedID.Text+"'";
                DataSet ds = fn.getData(query);
                if(ds.Tables[0].Rows.Count != 0)
                {
                    txtMedName.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtMedNum.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtMedDate.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtExDate.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtAvalQnt.Text = ds.Tables[0].Rows[0][6].ToString();
                    txtPricePerUnit.Text = ds.Tables[0].Rows[0][7].ToString();
                }
                else
                {
                    MessageBox.Show("Не знайдено ліків з таким ID: " + txtMedID.Text, "Пошук ліків за ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                clearAll();
            }
        }
        private void clearAll()
        {
            txtMedID.Clear();
            txtMedNum.Clear();
            txtMedName.Clear();
            txtMedName.ResetText();
            txtExDate.ResetText();
            txtAvalQnt.Clear();
            txtPricePerUnit.Clear();
            if (txtAddMed.Text != "0")
            {
                txtAddMed.Text = "0";
            }
            else
            {
                txtAddMed.Text = "0";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        int totalQnt;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string mname = txtMedName.Text;
            string mnumber = txtMedNum.Text;
            string mdate = txtMedDate.Text;
            string exdate = txtExDate.Text;
            int qnt = int.Parse(txtAvalQnt.Text);
            int addQnt = int.Parse(txtAddMed.Text);
            int price = int.Parse(txtPricePerUnit.Text);

            totalQnt = qnt + addQnt;
            query = "update medic set mname = '" + mname + "',mnumber = '" + mnumber + "', mDate ='" + mdate + "', " +
            "eDate = '" + exdate + "',quantity = '" + totalQnt + "',perUnit = '" + price + "' where mid = '"+txtMedID.Text+"'";

            fn.setData(query,"Дані оновлено!");

        }
    }
}
