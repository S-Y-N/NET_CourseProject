using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PetVet
{
    //клас який звязує форми з БД і проводить з нею всі маніпулялії
    class function
    {
            //з'єднання з БД
        protected SqlConnection getConnection()
        {
            //поки статичне з'єднання - замінити на динамічне
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-LP2H90G\\SQLEXPRESS; database=petvet; integrated security = true";
            return con;
        }
        //отримання даних з БД
        public DataSet getData(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        //отримання нових даних в БД ( при оновленні, видаленні, додаванні)
        public void setData(String query, String msg)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(msg,"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
