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
    public partial class UC_Add : UserControl
    {
        public UC_Add()
        {
            InitializeComponent();
        }




        private void UC_Add_Load(object sender, EventArgs e)
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

                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-MLSL318;Initial Catalog=FamilyTree;Integrated Security=True");
                    SqlCommand cmd;

                    cmd = new SqlCommand("insert into Info(Name,BirthDate,Gender,EducationCertificate,JobTitle,Address,PhoneNumber,Skills) values( @Name , @BirthDate , @Gender , @EducationCertificate ,@JobTitle , @Address, @PhoneNumber,@Skills)", con);
                    con.Open();

                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@BirthDate", dateTimePicker1.Value.Date.ToString());
                    cmd.Parameters.AddWithValue("@Gender", textBox2.Text);
                    cmd.Parameters.AddWithValue("@EducationCertificate", textBox3.Text);
                    cmd.Parameters.AddWithValue("@JobTitle", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox5.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Skills", textBox7.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully Completed");
                    con.Close();

                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }
            else
            {
                MessageBox.Show("Complete..!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
