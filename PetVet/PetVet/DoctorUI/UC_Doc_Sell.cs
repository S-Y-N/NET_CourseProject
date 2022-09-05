using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PetVet.DoctorUI
{
    public partial class UC_Doc_Sell : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;

        public UC_Doc_Sell()
        {
            InitializeComponent();
        }

        private void UC_Doc_Sell_Load(object sender, EventArgs e)
        {
            listBoxMed.Items.Clear();
            query = "select mname from medic where eDate >= getdate() and quantity > '0'";
            ds = fn.getData(query);

            for( int i=0; i <ds.Tables[0].Rows.Count; i++)
            {
                listBoxMed.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_Doc_Sell_Load(this, null);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            listBoxMed.Items.Clear();
            query = "select mname from medic where mname like '"+txtSearch.Text+"%' and eDate >= getdate() and quantity > '0'";
            ds = fn.getData(query);

            for(int i=0; i<ds.Tables[0].Rows.Count; i++)
            {
                listBoxMed.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void listBoxMed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQnt.Clear();

            string name = listBoxMed.GetItemText(listBoxMed.SelectedItem);
            txtMedName.Text = name;
            query = "select mid, eDate, perUnit from medic where mname ='" + name + "'";
            ds = fn.getData(query);

            txtMedID.Text = ds.Tables[0].Rows[0][0].ToString();
            txtExDate.Text = ds.Tables[0].Rows[0][1].ToString();
            txtPrice.Text = ds.Tables[0].Rows[0][2].ToString();

        }

        private void txtQnt_TextChanged(object sender, EventArgs e)
        {
            if(txtQnt.Text != "")
            {
                int uPrice = int.Parse(txtPrice.Text);
                int qnt = int.Parse(txtQnt.Text);
                int total = uPrice * qnt;
                txtTotalPrice.Text = total.ToString();
            }
            else
            {
                txtTotalPrice.Clear();
            }
        }

        int value;
        String valueID;
        protected int numUnit;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                value = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                valueID = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                numUnit = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            catch (Exception) { }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(valueID != null)
            {
                try
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
                }
                catch
                {

                }
                finally
                {
                    query = "select quantity from medic where mid = '" + valueID + "'";
                    ds = fn.getData(query);
                    qnt = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    newQnt = qnt + numUnit;

                    query = "update medic set quantity = '" + newQnt + "' where mid = '" + valueID + "'";
                    fn.setData(query, "Ліки видалені з списку замовлення");
                    total = total - value;
                    totalLb.Text = total.ToString() + " грн";
                }
                UC_Doc_Sell_Load(this, null);
            }
        }

        protected int n, total = 0;
        protected int qnt, newQnt;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Рахунок";
            print.SubTitle = String.Format("Дата продажу: {0}", DateTime.Now.Date);
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Загальна сума до оплати: " + totalLb.Text;
            print.FooterSpacing = 15;
            print.PrintDataGridView(guna2DataGridView1);

            total = 0;
            totalLb.Text = "0.0 грн";
            guna2DataGridView1.DataSource = 0;

        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtMedID.Text != "")
            {
                query = "select quantity from medic where mid = '" + txtMedID.Text + "'";
                ds = fn.getData(query);

                qnt = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                newQnt = qnt - int.Parse(txtQnt.Text);

                if(newQnt >= 0)
                {
                    n = guna2DataGridView1.Rows.Add();
                    guna2DataGridView1.Rows[n].Cells[0].Value = txtMedID.Text;
                    guna2DataGridView1.Rows[n].Cells[1].Value = txtMedName.Text;
                    guna2DataGridView1.Rows[n].Cells[2].Value = txtExDate.Text;
                    guna2DataGridView1.Rows[n].Cells[3].Value = txtPrice.Text;
                    guna2DataGridView1.Rows[n].Cells[4].Value = txtQnt.Text;
                    guna2DataGridView1.Rows[n].Cells[5].Value = txtTotalPrice.Text;

                    total = total + int.Parse(txtTotalPrice.Text);
                    totalLb.Text = total.ToString() + " грн";

                    query ="update medic set quantity = '"+newQnt+"' where mid ='"+txtMedID.Text+"'";
                    fn.setData(query, "Ліки додано до списку замовлень");
                }
                else
                {
                    MessageBox.Show("Невистачає ліків на складі.\n Можливий продаж "+qnt+" одиниць","Попередження",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                clearAll();
                UC_Doc_Sell_Load(this, null);
            }
            else
            {
                MessageBox.Show("Виберіть ліки, щоб додати їх до списку замовлення", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }
        private void clearAll()
        {
            txtMedID.Clear();
            txtMedName.Clear();
            txtExDate.ResetText();
            txtPrice.Clear();
            txtTotalPrice.Clear();
        }
    }
}
