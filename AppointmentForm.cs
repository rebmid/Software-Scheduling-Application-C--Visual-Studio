﻿using MySql.Data.MySqlClient;
using C969Rebekah.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969Rebekah

{
    public partial class AppointmentForm : Form
    {
        private static AppointmentClass appointment = new AppointmentClass ();
        private static CustomerClass customer = new CustomerClass();
        private static PublicClass universals = new PublicClass();
        delegate void del();
        private string getAllAppts = "SELECT appointmentId, customerId, type, start, end FROM appointment;";
        public AppointmentForm()
        {
            string customerName = "SELECT customerName from customer;";
            string apptType = "SELECT DISTINCT type from appointment;"; //grabbing only one instance of each type of appointment
            DataTable customers = new DataTable();
            DataTable type = new DataTable();
            InitializeComponent();
            universals.GetData(customerName, customers);
            custCB.DataSource = customers;
            custCB.DisplayMember = "customerName";
            universals.GetData(apptType, type);
            typeCB.DataSource = type;
            typeCB.DisplayMember = "type";


            if (PublicClass.AppointmentID > 0)
            {
             
                DataTable ApptFill = new DataTable();
                string apptInfo = appointment.apptQuery;
                universals.TableReader(apptInfo, ApptFill);

                custCB.Text = (string)ApptFill.Rows[PublicClass.CurrentApptIndex]["customerName"];
                typeCB.Text = (string)ApptFill.Rows[PublicClass.CurrentApptIndex]["type"];
                startTimePicker.Value = TimeZoneInfo.ConvertTimeFromUtc((DateTime)ApptFill.Rows[PublicClass.CurrentApptIndex]["start"], TimeZoneInfo.Local);
                endTimePicker.Value = TimeZoneInfo.ConvertTimeFromUtc((DateTime)ApptFill.Rows[PublicClass.CurrentApptIndex]["end"], TimeZoneInfo.Local);
            }
        }
        private void cancelApptBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm dash = new MainForm();
            dash.Show();
        }
        private void saveApptBtn_Click(object sender, EventArgs e)
        {
            errorLbl.Text = "";
            if (HourCheck() != false)
            {

                if (PublicClass.AppointmentID > 0)
                {
                    UpdateAppointment();
                }
                else
                {
                    InsertAppointment();
                }
            }
        }

        private void InsertAppointment()
        {
            DataTable overlap = new DataTable();
            {
                try
                {
                    universals.TableReader(getAllAppts, overlap);
                    DateTime currentStart = TimeZoneInfo.ConvertTimeToUtc(startTimePicker.Value);
                    DateTime currentEnd = TimeZoneInfo.ConvertTimeToUtc(endTimePicker.Value);

                    if (overlap.Rows.Count > 0)
                    {
                        for (int j = 0; j < overlap.Rows.Count; j++)
                        {
                            DateTime scheduledStart = Convert.ToDateTime(overlap.Rows[j]["start"]);
                            DateTime scheduledEnd = Convert.ToDateTime(overlap.Rows[j]["end"]);

                            if ((DateTime.Compare(currentStart, scheduledStart) == 0) &&
                                (DateTime.Compare(currentEnd, scheduledEnd) == 0))
                            //this means these don't match
                            {
                                errorLbl.Text = "Cannot schedule overlapping appointments.";
                            }
                        }
                    }
                    if (universals.IsNotNullOrEmpty(errorLbl.Text))
                    {
                    }
                    else
                    {
                        DataTable custResult = new DataTable();
                        string getCustomer = custCB.GetItemText(custCB.Text);
                        string getType = typeCB.GetItemText(typeCB.Text);
                        string getStart = TimeZoneInfo.ConvertTimeToUtc(startTimePicker.Value).ToString("yyyy-MM-dd HH:mm:ss");
                        string getEnd = TimeZoneInfo.ConvertTimeToUtc(endTimePicker.Value).ToString("yyyy-MM-dd HH:mm:ss");

                        string sql = "SELECT customerId FROM customer WHERE customerName = '" + getCustomer + "';";
                        
                        customer.PopulateCustData(sql, custResult);

                        if (custResult.Rows.Count > 0)
                        {
                            int custID = Convert.ToInt32(custResult.Rows[0][0]);
                            PublicClass.CustomerID = custID;
                        }
                        //SQL query to insert appointment data
                        string appointmentData = "INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdateBy) " +
                            "VALUES ('" + PublicClass.CustomerID + "', '" + PublicClass.CurrentUserID + "', 'not needed', 'not needed', 'not needed', 'not needed', '" + getType + "', 'not needed', '" + getStart + "', '" + getEnd + "', '" +
                            TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") + "', '" + PublicClass.CurrentUser + "', '" + PublicClass.CurrentUser + "');";
                        universals.ExecuteNonQueryUpdater(appointmentData);

                        this.Hide();
                        MainForm dash = new MainForm();
                        dash.Show();
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show(e.ToString());
                    errorLbl.Text = "Unable to create appointment. Please try again.";
                }
            }

        }

        private void UpdateAppointment()
        {
            DataTable overlap = new DataTable();
            {
                try
                {
                    universals.TableReader(getAllAppts, overlap);
                    DateTime currentStart = TimeZoneInfo.ConvertTimeToUtc(startTimePicker.Value);
                    DateTime currentEnd = TimeZoneInfo.ConvertTimeToUtc(endTimePicker.Value);

                    if (overlap.Rows.Count > 0)
                    {
                        for (int j = 0; j < overlap.Rows.Count; j++)
                        {
                            DateTime scheduledStart = Convert.ToDateTime(overlap.Rows[j]["start"]);
                            DateTime scheduledEnd = Convert.ToDateTime(overlap.Rows[j]["end"]);

                            if ((DateTime.Compare(currentStart, scheduledStart) == 0) &&
                                (DateTime.Compare(currentEnd, scheduledEnd) == 0))
                            //this means these don't match
                            {
                                errorLbl.Text = "Cannot schedule overlapping appointments.";
                            }
                        }
                    }
                    if (universals.IsNotNullOrEmpty(errorLbl.Text))
                    {
                    }
                    else
                    {
                        DataTable custIdResult = new DataTable();
                        string getCustomer = custCB.GetItemText(custCB.Text);
                        string getType = typeCB.GetItemText(typeCB.Text);
                        string getStart = TimeZoneInfo.ConvertTimeToUtc(startTimePicker.Value).ToString("yyyy-MM-dd HH:mm:ss");
                        string getEnd = TimeZoneInfo.ConvertTimeToUtc(endTimePicker.Value).ToString("yyyy-MM-dd HH:mm:ss");

                        string sql = "SELECT customerId FROM customer WHERE customerName = '" + getCustomer + "';";

                        customer.PopulateCustData(sql, custIdResult);

                        if (custIdResult.Rows.Count > 0)
                        {
                            int customerid = Convert.ToInt32(custIdResult.Rows[0][0]);
                            PublicClass.CustomerID = customerid;
                        }
                        // SQL query to update appointment data
                        string updateAppointment = "UPDATE appointment SET customerId = '" + PublicClass.CustomerID + "', userId = '" + PublicClass.CurrentUserID +
                            "', title = 'not needed', description = 'not needed', location = 'not needed', contact = 'not needed', type = '" + getType +
                            "', url = 'not needed', start = '" + getStart + "', end = '" + getEnd + "', lastUpdate = '" +
                            TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") + "', lastUpdateBy ='" + PublicClass.CurrentUser + "'" +
                            " WHERE appointmentID = '" + PublicClass.AppointmentID + "';";

                        universals.ExecuteNonQueryUpdater(updateAppointment);
                        this.Hide();
                        MainForm dash = new MainForm();
                        dash.Show();
                    }
                }
                catch (Exception)
                {
                    errorLbl.Text = "Unable to update appointment.Please try again.";
                }
            }
        }

        private bool HourCheck()
        {
            TimeSpan open = new TimeSpan(8, 0, 0);
            TimeSpan close = new TimeSpan(17, 1, 0);

            TimeSpan appointmentStart = startTimePicker.Value.TimeOfDay;
            TimeSpan appointmentEnd = endTimePicker.Value.TimeOfDay;

            if (appointmentStart < open || appointmentEnd > close)
            {
                errorLbl.Text = "Appointment must be scheduled between 8am and 5pm.";
                return false;
            }
            else
            {
                return true;
            }

        }

        private void startTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
