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
    public partial class UC_AddUser : UserControl
    {

        function fn = new function();
        String query;


        public UC_AddUser()
        {
            InitializeComponent();
        }

        private void UC_AddUser_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            txtEmailUser.Clear();
            txtUsername.Clear();
            txtPasswordUser.Clear();
            txtDOB.ResetText();
            txtMobNum.Clear();
            txtName.Clear();
            txtUserRole.ResetText();

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            String role = txtUserRole.Text;
            String name = txtName.Text;
            String dob = txtDOB.Text;
            Int64 mobile = Int64.Parse(txtMobNum.Text);
            String email = txtEmailUser.Text;
            String username = txtUsername.Text;
            String pass = txtPasswordUser.Text;

            try
            {
                query = "insert into users(userRole, name, dob, mobile, email, username, pass) values ('"+role+"','" +name+ "','" +dob+ "','" +mobile+ "','" +email+ "','" +username+ "','" +pass+"')";
                fn.setData(query, "Новий профіль створено!");

            }
            catch(Exception)
            {
                MessageBox.Show("Такий користувач вже існує","Помилка",MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username='"+txtUsername.Text+"'";
            DataSet ds = fn.getData(query);

            if(ds.Tables[0].Rows.Count==0)
            {
                pictureBox1.ImageLocation = @"C:\Users\duost\Desktop\Курсова\imgs\yes.png";
            }
            else
            {
                pictureBox1.ImageLocation = @"C:\Users\duost\Desktop\Курсова\imgs\no.png";
            }
        }
    }
}
