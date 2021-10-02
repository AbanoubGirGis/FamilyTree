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
    public partial class UC_Update : UserControl
    {
        public UC_Update()
        {
            InitializeComponent();
        }

        private void UC_Update_Load(object sender, EventArgs e)
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

            //foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //{
            //    nameIndex.Text = row.Cells[1].Value.ToString();
            //    birthDateIndex.Value.ToString() = row.Cells[2].Value.ToString();
            //    genderIndex.Text = row.Cells[3].Value.ToString();
            //    certefecateIndex.Text = row.Cells[4].Value.ToString();
            //    jobIndex.Text = row.Cells[5].Value.ToString();
            //    addressIndex.Text = row.Cells[6].Value.ToString();
            //    PhoneIndex.Text = row.Cells[7].Value.ToString();
            //    skillsIndex.Text = row.Cells[8].Value.ToString();


            //}

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }







        private void idIndex_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-MLSL318;Initial Catalog=FamilyTree;Integrated Security=True");
            SqlCommand cmd;

            string query = "update Info set Name = @name,Birthdate=@birthdate,Gender=@gender,EducationCertificate=@certeficate,JobTitle=@job,Address=@address,PhoneNumber = @phone,Skills = @skills  where ID = @id";
            
            
            con.Open();
           
            for (int i = 0; i < dataGridView1.Rows.Count-1 ; i++)
            {
                string id = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string ay = dataGridView1.Rows[i].Cells[2].Value.ToString();
                DateTime birthdate = DateTime.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                string Gender = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string Cirtificate = dataGridView1.Rows[i].Cells[4].Value.ToString();
                string Job = dataGridView1.Rows[i].Cells[5].Value.ToString();
                string Address = dataGridView1.Rows[i].Cells[6].Value.ToString();
                string Phone = dataGridView1.Rows[i].Cells[7].Value.ToString();
                string skills = dataGridView1.Rows[i].Cells[8].Value.ToString();

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id );
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@birthdate", birthdate);
                cmd.Parameters.AddWithValue("@gender", Gender);
                cmd.Parameters.AddWithValue("@certeficate", Cirtificate);
                cmd.Parameters.AddWithValue("@job", Job);
                cmd.Parameters.AddWithValue("@address", Address);
                cmd.Parameters.AddWithValue("@phone", Phone);
                cmd.Parameters.AddWithValue("@skills", skills);

                cmd.ExecuteNonQuery();


            }

            MessageBox.Show("Update Successfully");
            con.Close();



        }
    }

}
