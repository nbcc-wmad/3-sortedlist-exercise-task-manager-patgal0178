using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private SortedList<string, string> Task = new SortedList<string, string>();

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTask.Text == string.Empty)
                {
                    throw new Exception("you must enter a task");
                }
                else if (Task.ContainsKey(dtpTaskDate.Value.ToShortDateString()))
                {
                    throw new Exception("only one task can be scheduled per day");
                }

                string taskName = txtTask.Text, dateString = dtpTaskDate.Value.ToShortDateString();

                Task.Add(dateString, taskName);

                lstTasks.Items.Add(dateString);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
