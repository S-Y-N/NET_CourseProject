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
    public partial class UC_Doc_Dashbord : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;
        Int64 count;

        public UC_Doc_Dashbord()
        {
            InitializeComponent();
        }

        private void UC_Doc_Dashbord_Load(object sender, EventArgs e)
        {
            loadChart();
        }

        public void loadChart()
        {
            query = "select count(mname) from medic where eDate >=getdate()";
            ds = fn.getData(query);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["Придатні "].Points.AddXY("Валідація ліків", count);

            query = "select count(mname) from medic where eDate <=getdate()";
            ds = fn.getData(query);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["Прострочений препарат"].Points.AddXY("Співвідншення придатних до прострочених ліків", count);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            chart1.Series["Придатні "].Points.Clear();
            chart1.Series["Прострочений препарат"].Points.Clear();
            
            loadChart();
        }
    }
}
