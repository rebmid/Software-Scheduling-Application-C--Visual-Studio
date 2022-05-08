using C969Rebekah.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969Rebekah
{
    public partial class AppointmentByMonth : Form
    {
        string date;
        private static PublicClass universals = new PublicClass();

        public AppointmentByMonth()
        {
            InitializeComponent();
            monthCB.Items.Add("Feb 2022");
            monthCB.Items.Add("March 2022");
            monthCB.Items.Add("April 2022");
            monthCB.Items.Add("May 2022");
            monthCB.Items.Add("June 2022");
            monthCB.Items.Add("July 2022");
        }
        private void generateReportBtn_Click(object sender, EventArgs e)
        {
            if (monthCB.GetItemText(monthCB.Text) == "Feb 2022")
            {
                date = "2022-07%";
            }
            else if (monthCB.GetItemText(monthCB.Text) == "March 2022")
            {
                date = "2022-08%";
            }
            else if (monthCB.GetItemText(monthCB.Text) == "April 2022")
            {
                date = "2022-09%";
            }
            else if (monthCB.GetItemText(monthCB.Text) == "May 2022")
            {
                date = "2022-10%";
            }
            else if (monthCB.GetItemText(monthCB.Text) == "June 2022")
            {
                date = "2022-11%";
            }
            else if(monthCB.GetItemText(monthCB.Text) == "July 2022")
            {
                date = "2022-12%";
            }
            else
            {
                MessageBox.Show("Please select a month.");
            }

            string selectAllAppointmentsMonth = "SELECT  appointmentId, customerId, type FROM appointment WHERE start LIKE '" + date + "';";
            DataTable allAppointmentsDt = new DataTable();
            universals.TableReader(selectAllAppointmentsMonth, allAppointmentsDt);
            apptByMonDgv.DataSource = allAppointmentsDt;

            string selectDemoAppoinmentMonth = "SELECT COUNT(*) FROM appointment WHERE start LIKE '" + date + "' and type = 'Demo';";
            DataTable demo = new DataTable();
            universals.TableReader(selectDemoAppoinmentMonth, demo);
            if (demo.Rows.Count > 0)
            {
                demoCount.Text = demo.Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("No demo appointments this month.");
            }
            string selectContractReviewAppointmentMonth = "SELECT COUNT(*) FROM appointment WHERE start LIKE '" + date + "' and type = 'Contract Review';";
            DataTable contract = new DataTable();
            universals.TableReader(selectContractReviewAppointmentMonth, contract);
            if (contract.Rows.Count > 0)
            {
                contractReviewCount.Text = contract.Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("No contract review appointments this month");
            }
            string selectPresentationAppointmentMonth = "SELECT COUNT(*) FROM appointment WHERE start LIKE '" + date + "' and type = 'Presentation';";
            DataTable presentation = new DataTable();
            universals.TableReader(selectPresentationAppointmentMonth, presentation);
            if (presentation.Rows.Count > 0)
            {
                presentationCount.Text = presentation.Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("No presentation appointments this month.");
            }
            string selectScrumAppointmentMonth = "SELECT COUNT(*) FROM appointment WHERE start LIKE '" + date + "' and type = 'Scrum';";
            DataTable scrum = new DataTable();
            universals.TableReader(selectScrumAppointmentMonth, scrum);
            if (scrum.Rows.Count > 0)
            {
                scrumCount.Text = scrum.Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("No scrum appointments this month.");
            }

            string selectAppointmentCountMonth = "SELECT COUNT(*) FROM appointment WHERE start LIKE '" + date + "';";
            DataTable all = new DataTable();
            universals.TableReader(selectAllAppointmentsMonth, all);
            if (all.Rows.Count > 0)
            {
                totalCount.Text = all.Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("No Appointments scheduled this Month.");
            }
        }

        private void mainScreenBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm dash = new MainForm();
            dash.Show();
        }

        private void AppointmentByMonth_Load(object sender, EventArgs e)
        {

        }
    }
}
