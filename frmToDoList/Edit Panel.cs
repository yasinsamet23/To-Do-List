using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmToDoList
{
    
    public partial class Edit_Panel : Form
    {
        private frmToDoList frmMain; // `frmToDoList` formunun referansını tutacak bir değişken
        public Edit_Panel(frmToDoList frm)
        {
            InitializeComponent();
            frmMain = frm; // `frmToDoList` formunun referansını alıyoruz


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (frmMain.lstTasks.SelectedItem != null)
            {
                // Seçilen TaskItem nesnesini al
                frmToDoList.TaskItem taskItem = (frmToDoList.TaskItem)frmMain.lstTasks.SelectedItem;

                // TaskItem'in Text özelliğini güncelle
                taskItem.Text = renametextbox.Text;

                // ListBox'ı yeniden çiz
                frmMain.lstTasks.Invalidate();

                this.Close(); // Edit_Panel formunu kapat
            }
        }
    }
}
