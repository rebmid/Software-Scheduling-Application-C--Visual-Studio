using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using C969Rebekah.Classes;
using MySqlX.XDevAPI.Relational;
using System.Security.Cryptography.X509Certificates;

namespace C969Rebekah
{
    public partial class MainForm : Form
    {
        private static CustomerClass customer = new CustomerClass();
        private static AppointmentClass appointment = new AppointmentClass();
        private static PublicClass universals = new PublicClass();
        
        public delegate string GoodBye(string name);
        DataTable custDt = new DataTable();
        DataTable apptDt = new DataTable();
        DateTime selectedDate = new DateTime();



        public MainForm()
        {
            InitializeComponent();

            selectedDate = DateTime.Now;
            myCal.AddBoldedDate(selectedDate);

            PublicClass.CurrentCustIndex = -1;
            customer.PopulateCustData(customer.findAllCustQuery, custDt);
            custDgv.RowHeadersVisible = false;
            custDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            custDgv.DefaultCellStyle.SelectionForeColor = custDgv.DefaultCellStyle.ForeColor;
            custDgv.DataSource = custDt;
            custDgv.Columns["country"].Visible = false;
            custDgv.Columns["customerId"].Visible = false;
            PublicClass.CurrentApptIndex = -1;
            appointment.PopulateApptData(appointment.apptQuery, apptDt);
            apptDgv.RowHeadersVisible = false;
            apptDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            apptDgv.DefaultCellStyle.SelectionForeColor = apptDgv.DefaultCellStyle.ForeColor;
            apptDgv.DataSource = apptDt;
            apptDgv.Columns["customerId"].Visible = false;
        }

        private void addCustBtn_Click(object sender, EventArgs e)
        {
            PublicClass.CustomerID = 0;
            this.Hide();
            CustomerForm newCust = new CustomerForm();
            newCust.Show();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            //lambda to shorten syntex to let user know leaving program
            GoodBye obj = (currentUserName) => { return "Have a nice day, " + currentUserName + " user."; };
            string GoodBye = obj.Invoke(PublicClass.CurrentUser);
            MessageBox.Show(GoodBye);
            Application.Exit();
        }

        private void addApptBtn_Click(object sender, EventArgs e)
        {
            PublicClass.CustomerID = 0;
            PublicClass.AppointmentID = 0;
            this.Hide();
            AppointmentForm newAppt = new AppointmentForm();
            newAppt.Show();
        }

        private void dayRb_CheckedChanged(object sender, EventArgs e)
        {
            HandleDay();
        }

        private void weekRb_CheckedChanged(object sender, EventArgs e)
        {
            HandleWeek();
        }

        private void monthRb_CheckedChanged(object sender, EventArgs e)
        {
            HandleMonth();
        }

        private void updateCustBtn_Click(object sender, EventArgs e)
        {
            if (PublicClass.CurrentCustIndex >= 0)
            {
                string selectCust = "SELECT * FROM customer;";
                DataTable custToUpdate = new DataTable();
                universals.TableReader(selectCust, custToUpdate);
                if (custToUpdate.Rows.Count > 0)
                {
                    int custId = (int)custToUpdate.Rows[PublicClass.CurrentCustIndex]["customerId"];
                    PublicClass.CustomerID = custId;
                }
                this.Hide();
                CustomerForm editCust = new CustomerForm();
                editCust.Show();
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }
        private void udpateApptBtn_Click(object sender, EventArgs e)
        {
            if (PublicClass.CurrentApptIndex >= 0)
            {
                string selectAppt = "SELECT * FROM appointment;";
                DataTable apptToUpdate = new DataTable();
                universals.TableReader(selectAppt, apptToUpdate);
                if (apptToUpdate.Rows.Count > 0)
                {
                    int appointId = (int)apptToUpdate.Rows[PublicClass.CurrentApptIndex]["appointmentId"];
                    PublicClass.AppointmentID = appointId;
                }
                this.Hide();
                AppointmentForm editAppt = new AppointmentForm();
                editAppt.Show();
            }
            else
            {
                MessageBox.Show("Please select an appointment to update.");
            }
        }
        private void custDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PublicClass.CurrentCustIndex = e.RowIndex;
            custDgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightYellow;
 
        }
        private void apptDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PublicClass.CurrentApptIndex = e.RowIndex;
            apptDgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightYellow;
        }

        private void deleteCustBtn_Click(object sender, EventArgs e)
        {
            if (PublicClass.CurrentCustIndex >= 0)
            {
                DataTable deleteCust = new DataTable();
                universals.TableReader(customer.findAllCustQuery, deleteCust);
                PublicClass.CustomerID = (int)deleteCust.Rows[PublicClass.CurrentCustIndex]["customerId"];
                DataTable deleteAddress = new DataTable();
                string addressToDelete = "SELECT addressId from customer WHERE customerId = '" + PublicClass.CustomerID + "';";
                universals.TableReader(addressToDelete, deleteAddress);

                PublicClass.AddressID = (int)deleteAddress.Rows[0][0];

                if (PublicClass.CustomerID != 0)
                {

                    string deleteCustomerAndAddress = "DELETE customer FROM customer WHERE customerId = '" + PublicClass.CustomerID + "';" +
                            "DELETE address FROM address WHERE addressId = '" + PublicClass.AddressID + "';";


                    DialogResult dialogResult = MessageBox.Show("This will permanently delete the customer. Continue?", "", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            DataTable customerDeleteCompleted = new DataTable();
                            universals.ExecuteNonQueryUpdater(deleteCustomerAndAddress);
                            universals.GetData(customer.findAllCustQuery, customerDeleteCompleted);
                            custDgv.DataSource = customerDeleteCompleted;
                        }
                        catch
                        {
                            MessageBox.Show("Unable to delete customer. Recommend checking for currently scheduled appointments for selected customer.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }

        private void deleteApptBtn_Click(object sender, EventArgs e)
        {
            if (PublicClass.CurrentApptIndex > 0)
            {
                DataTable deleteAppointment = new DataTable();
                universals.TableReader(appointment.apptQuery, deleteAppointment);
                PublicClass.AppointmentID = (int)deleteAppointment.Rows[PublicClass.CurrentApptIndex]["appointmentId"];

                if (PublicClass.AppointmentID != 0)
                {
                    string deleteSelectedAppointment = "DELETE appointment FROM appointment WHERE appointmentId = '" + PublicClass.AppointmentID + "';";

                    DialogResult dialog = MessageBox.Show("Are you sure you want to delete this appointment?", "", MessageBoxButtons.YesNo);

                    if (dialog == DialogResult.Yes)
                    {
                        universals.ExecuteNonQueryUpdater(deleteSelectedAppointment);
                        DataTable appointmentDeleted = new DataTable();
                        universals.GetData(appointment.apptQuery, appointmentDeleted);
                        apptDgv.DataSource = appointmentDeleted;

                        this.Hide();
                        MainForm dash = new MainForm();
                        dash.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to delete.");
            }
        }

        private void HandleDay()
        {
            myCal.MaxSelectionCount = 1;
            DateTime dayStart = new DateTime();
            DateTime dayEnd = new DateTime();

            dayStart = selectedDate;
            dayEnd = selectedDate.AddDays(1);

            myCal.SetSelectionRange(dayStart, dayEnd);

            string todayAppt = "SELECT customer.customerId, customer.customerName, appointment.appointmentId, appointment.type, appointment.start, appointment.end  FROM " +
                "appointment INNER JOIN customer ON appointment.customerId = customer.customerId WHERE appointment.start BETWEEN  '" +
                TimeZoneInfo.ConvertTimeToUtc(dayStart).ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + TimeZoneInfo.ConvertTimeToUtc(dayEnd).ToString("yyyy-MM-dd HH:mm:ss") + "' ;";

            DataTable handleDay = new DataTable();
            universals.TableReader(todayAppt, handleDay);

            if (handleDay.Rows.Count > 0)
            {
                for (int i = 0; i < handleDay.Rows.Count; i++)
                {
                    apptDgv.DataSource = handleDay;
                    handleDay.Rows[i]["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)handleDay.Rows[i]["start"],
                        TimeZoneInfo.Local).ToString();
                    handleDay.Rows[i]["end"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)handleDay.Rows[i]["end"],
                        TimeZoneInfo.Local).ToString();
                }
            }
            else
            {
                MessageBox.Show("No appointments found for this date.");
            }
        }

        private void HandleWeek()
        {
            myCal.MaxSelectionCount = 7;
            DateTime weekStart = new DateTime();
            DateTime weekEnd = new DateTime();

            weekStart = selectedDate;
            weekEnd = selectedDate.AddDays(7);
            myCal.SetSelectionRange(weekStart, weekEnd);

            string weekAppts = "SELECT customer.customerId, customer.customerName, appointment.appointmentId, appointment.type, appointment.start, appointment.end  FROM " +
                "appointment INNER JOIN customer ON appointment.customerId = customer.customerId WHERE appointment.start BETWEEN '" +
                TimeZoneInfo.ConvertTimeToUtc(weekStart).ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + TimeZoneInfo.ConvertTimeToUtc(weekEnd).ToString("yyyy-MM-dd HH:mm:ss") + "' ;";

            DataTable handleWeek = new DataTable();
            universals.TableReader(weekAppts, handleWeek);
            if (handleWeek.Rows.Count > 0)
            {
                for (int i = 0; i < handleWeek.Rows.Count; i++)
                {
                    apptDgv.DataSource = handleWeek;
                    handleWeek.Rows[i]["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)handleWeek.Rows[i]["start"],
                        TimeZoneInfo.Local).ToString();
                    handleWeek.Rows[i]["end"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)handleWeek.Rows[i]["end"],
                        TimeZoneInfo.Local).ToString();
                }
            }
            else
            {
                MessageBox.Show("No appointments found for this date range.");
            }
        }

        private void HandleMonth()
        {
            myCal.MaxSelectionCount = 31;
            DateTime monthStart = new DateTime();
            DateTime monthEnd = new DateTime();
            monthStart = selectedDate;
            monthEnd = selectedDate.AddDays(31);
            myCal.SetSelectionRange(monthStart, monthEnd);

            string monthAppts = "SELECT customer.customerId, customer.customerName, appointment.appointmentId, appointment.type, appointment.start, appointment.end FROM " +
                "appointment INNER JOIN customer ON appointment.customerId = customer.customerId WHERE appointment.start BETWEEN '" +
                    TimeZoneInfo.ConvertTimeToUtc(monthStart).ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + TimeZoneInfo.ConvertTimeToUtc(monthEnd).ToString("yyyy-MM-dd HH:mm:ss") + "' ;";

            DataTable handleMon = new DataTable();
            universals.TableReader(monthAppts, handleMon);

            if (handleMon.Rows.Count > 0)
            {
                //convert start and end times from UTC
                for (int i = 0; i < handleMon.Rows.Count; i++)
                {
                    apptDgv.DataSource = handleMon;
                    handleMon.Rows[i]["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)handleMon.Rows[i]["start"],
                        TimeZoneInfo.Local).ToString();
                    handleMon.Rows[i]["end"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)handleMon.Rows[i]["end"],
                        TimeZoneInfo.Local).ToString();
                }
            }
            else
            {
                MessageBox.Show("No appointments found for this date range.");
            }
        }
    
        private void myCal_DateSelected(object sender, DateRangeEventArgs e)
        {
            selectedDate = e.Start;
            if (monthRb.Checked)
            {
                HandleMonth();
            }
            else
            {
                if (weekRb.Checked)
                {
                    HandleWeek();
                }
                else
                {
                    HandleDay();
                }
            }
        }

        private void apptByMonBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AppointmentByMonth monReport = new AppointmentByMonth();
            monReport.Show();
        }
        private void apptByCustBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AppointmentByCustomer custReport = new AppointmentByCustomer();
            custReport.Show();
        }
        private void userSchedBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportsForm userSched = new ReportsForm();
            userSched.Show();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string customerText = searchTextBox.Text;
            DataTable customerSearchResult = new DataTable();

            string searchParams = "SELECT customerId, customerName, address.address, city.city, address.postalCode, country.country, address.phone "
            + "FROM customer "
            + "INNER JOIN address ON customer.addressId = address.addressId "
            + "INNER JOIN city ON address.cityId = city.cityId "
            + "INNER JOIN country on city.countryId = country.countryId "
            + "WHERE customerName LIKE \"%" + customerText + "%\";";

            universals.TableReader(searchParams, customerSearchResult);

            if (customerSearchResult.Rows.Count > 0)
            {
                custDgv.DataSource = customerSearchResult;
                custDgv.RowHeadersVisible = false;
                custDgv.Columns["country"].Visible = false;
                custDgv.Columns["customerId"].Visible = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
