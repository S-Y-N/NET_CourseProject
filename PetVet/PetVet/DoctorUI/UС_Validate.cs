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
    public partial class UС_Validate : UserControl
    {
        function fn = new function();
        String query;


        public UС_Validate()
        {
            InitializeComponent();
        }

        private void txtCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtCheck.SelectedIndex == 2)
            {
                query = "select * from medic where eDate >= getdate()";
                setDGV(query, "Ліки придатні до використання", Color.Green);
            }
            else if(txtCheck.SelectedIndex == 1)
            {
                query = "select * from medic where eDate <= getdate()";
                setDGV(query, "Ліки не придатні до використання", Color.Red);
            }
            else if(txtCheck.SelectedIndex == 0)
            {
                query = "select * from medic";
                setDGV(query, "", Color.Black);
            }
        }

        private void setDGV(String query, String lbl, Color col)
        {
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
            setLb.Text = lbl;
            setLb.ForeColor = col;
        }

        private void UС_Validate_Load(object sender, EventArgs e)
        {
            setLb.Text = "";
        }
    }
}
