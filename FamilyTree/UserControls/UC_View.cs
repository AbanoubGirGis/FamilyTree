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
    public partial class UC_View : UserControl
    {
        public UC_View()
        {
            InitializeComponent();
        }

        private void UC_View_Load(object sender, EventArgs e)
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


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
