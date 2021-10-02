using FamilyTree.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FamilyTree
{
    public partial class formProject : Form
    {
        public formProject()
        {
            InitializeComponent();
        }
        
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(userControl);
            userControl.BringToFront();
        }
        
        private void view_Click(object sender, EventArgs e)
        {
            UC_View UC = new UC_View();
            addUserControl(UC);
        }

        private void add_Click(object sender, EventArgs e)
        {
            UC_Add UC = new UC_Add();
            addUserControl(UC);
        }

        private void update_Click(object sender, EventArgs e)
        {
            UC_Update UC = new UC_Update();
            addUserControl(UC);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            UC_Delete UC = new UC_Delete();
            addUserControl(UC);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uC_Update1_Load(object sender, EventArgs e)
        {

        }
    }
}
