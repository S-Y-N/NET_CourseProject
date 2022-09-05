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
    public partial class UC_Doc_ViewMed : UserControl
    {
        function fn = new function();
        String query;
       

        public UC_Doc_ViewMed()
        {
            InitializeComponent();
        }
        private void UC_Doc_ViewMed_Load(object sender, EventArgs e)
        {
            query = "select * from medic";
            setDGV(query);

        }

        private void txtMedName_TextChanged(object sender, EventArgs e)
        {
            query = "select * from medic where mname like '" + txtMedName.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void setDGV(String query)
        {
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        String medId;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                medId = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Видалити препарат?", "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                query = "delete from medic where mid='" + medId + "'";
                fn.setData(query, "Препарат видалений");
                UC_Doc_ViewMed_Load(this, null);
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_Doc_ViewMed_Load(this, null);
        }
    }
}
