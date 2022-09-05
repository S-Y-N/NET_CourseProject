using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetVet.AdminUI
{
    public partial class UС_Profile : UserControl
    {
        function fn = new function();
        String query;

        public UС_Profile()
        {
            InitializeComponent();
        }

        public string ID
        {
            set { userNameLabel.Text = value; }
        }

        private void UС_Profile_Enter(object sender, EventArgs e)
        {
            query="select * from users where username ='"+userNameLabel.Text+"'";
            DataSet ds= fn.getData(query);
            txtUserRole.Text = ds.Tables[0].Rows[0][1].ToString();
            txtUserName.Text = ds.Tables[0].Rows[0][2].ToString();
            txtUserDOB.Text = ds.Tables[0].Rows[0][3].ToString();
            txtMobile.Text = ds.Tables[0].Rows[0][4].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
            txtPassword.Text = ds.Tables[0].Rows[0][7].ToString();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String role = txtUserRole.Text;
            String name = txtUserName.Text;
            String dob = txtUserDOB.Text;
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String email = txtEmail.Text;
            String username = userNameLabel.Text;
            String pass = txtPassword.Text;

            query = "update users set userRole='" + role + "',name='" + name + "',dob='" + dob + "', mobile='" + mobile + "',email='" + email + "',pass='" + pass + "' where username='" + username + "'";
            fn.setData(query, "Профіль оновлено!");
        
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            UС_Profile_Enter(this, null);
        }
    }
}
