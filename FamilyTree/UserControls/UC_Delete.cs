using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FamilyTree.UserControls
{
    public partial class UC_Delete : UserControl
    {
        public UC_Delete()
        {
            InitializeComponent();
        }

        private void UC_Delete_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-MLSL318;Initial Catalog=FamilyTree;Integrated Security=True");
                SqlDataAdapter adapt;

                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select * from Info", con);
                adapt.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].ReadOnly = true;
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-MLSL318;Initial Catalog=FamilyTree;Integrated Security=True");
            SqlCommand cmd;

            if (idIndex.Text != "")
            {
                cmd = new SqlCommand("delete from Info where ID=@id", con);
                con.Open();

                cmd.Parameters.AddWithValue("@id", idIndex.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show(" Deleted Successfully!");
                con.Close();

            }
            else
            {
                MessageBox.Show("Please Input Record to Delete");
            }
        }
    }
}
