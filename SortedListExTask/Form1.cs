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

        private void resetTheForm()
        {
            txtTask.Text = string.Empty;

            dtpTaskDate.Value = DateTime.Today;

            lstTasks.Items.Clear();

            lblTaskDetails.Text = string.Empty;

            foreach (KeyValuePair<string, string> kvp in Task)
            {
                lstTasks.Items.Add(kvp.Key);
            }
        }

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

                resetTheForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"invalid data",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string date = lstTasks.SelectedItem.ToString();

            lblTaskDetails.Text = Task[date];
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstTasks.SelectedIndex == -1)
                {
                    throw new Exception("please select a task to remove");
                }

                string date = lstTasks.SelectedItem.ToString();

                Task.Remove(date);

                resetTheForm();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "invalid data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            if (Task.Count != 0)
            {
                string message = string.Empty;
                foreach (KeyValuePair<string, string> kvp in Task)
                {
                    message += $"{kvp.Key}, {kvp.Value}\n";
                }

                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("no tasks were entered");
            }
        }
    }
}
