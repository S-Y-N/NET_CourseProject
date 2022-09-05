using System;
using System.Data;
using System.Windows.Forms;

namespace PetVet
{
    public partial class Form1 : Form
    {
        function fn = new function();
        String query;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            //Авторизація в програмі
            query = "select * from users";
            ds = fn.getData(query);
            if(ds.Tables[0].Rows.Count==0)
            {
                //перевірка на момент, коли не було БД
                if(txtUsername.Text=="root"&&txtPassword.Text=="root")
                {
                    Administrator admin = new Administrator();
                    admin.Show();
                    this.Hide();
                }
            }
            else
            {
                //Порівняти логіни з бази з полем для введення
                query = "select * from users where username ='" + txtUsername.Text + "' and pass='" + txtPassword.Text + "'";
                ds = fn.getData(query);
                //якщо такий запис є
                if(ds.Tables[0].Rows.Count!=0)
                {
                    //і він має тип Адміна то відкрити панель адміністратора
                    String role = ds.Tables[0].Rows[0][1].ToString();
                    if(role == "Адміністратор")
                    {
                        Administrator admin = new Administrator(txtUsername.Text);
                        admin.Show();
                        this.Hide();
                    }
                    else if (role == "Лікар")
                    {
                        //інакше - лікаря
                        Doctor doc = new Doctor();
                        doc.Show();
                        this.Hide();
                    }   
                }
                else
                {
                    MessageBox.Show("Не правильний логін чи пароль", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            //сховати вікно
            WindowState = FormWindowState.Minimized;
        }
    }
}
