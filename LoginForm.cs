﻿using MySql.Data.MySqlClient;
using C969Rebekah.Classes;
using C969Rebekah.Localization;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace C969Rebekah
{
    public partial class LoginForm : Form
    {
        public delegate string Hello(string uname);
        private static PublicClass universals = new PublicClass();
        
           
        public LoginForm()
        {
            InitializeComponent();
            
        }
                private void signInButton_Click(object sender, EventArgs e)
        {

            using (MySqlConnection connect = new MySqlConnection(SqlClass.ConnectionString))
            {
                string selectUser = "Select * From user where userName = '" + usernameTxt.Text + "' and password = '" + passwordTxt.Text + "'";
                DataTable loginDt = new DataTable();
                universals.GetData(selectUser, loginDt);
                if (loginDt.Rows.Count > 0)
                {
                    //lambda to shorten syntax
                    Hello obj = (currentUserName) => { return "Welcome to the scheduler system, " + currentUserName + " user."; };
                    string Hello = obj.Invoke(PublicClass.CurrentUser);
                    MessageBox.Show(Hello);
                    WriteLogin();
                    CheckAppt();

                    this.Hide();
                    MainForm dash = new MainForm();
                    dash.Show();
                }
                else
                {
                    if (RegionInfo.CurrentRegion.DisplayName == "Mexico")
                    {
                        errorLbl.Text = "El nombre de usuario o la contraseña son incorrectos.";

                    }
                    else
                    {
                        errorLbl.Text = "The username or password are incorrect.";
                    }
                }
            }
            universals.GetCurrentUserName();
            universals.GetCurrentUserID();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {
            Spanish();
        }

        public void Spanish()
        {
            ResourceManager location = new ResourceManager("C969Rebekah.Localization.Spanish", Assembly.GetExecutingAssembly());
            {
                if (RegionInfo.CurrentRegion.DisplayName == "Mexico")
                {
                    welcomeLbl.Text = location.GetString("welcomeLbl");
                    usernameLbl.Text = location.GetString("usernameLbl");
                    passwordLbl.Text = location.GetString("passwordLbl");
                    signInBtn.Text = location.GetString("signInBtn");
                    exitBtn.Text = location.GetString("exitBtn");
                }
            }
        }
        private void WriteLogin()
        {
            try
            {
                //Checking to see if loginRecord.txt exists
                //If it exists write to it
                if (File.Exists("loginRecord.txt"))
                {
                    using (StreamWriter e = File.AppendText("loginRecord.txt"))
                    {
                        e.WriteLine(usernameTxt.Text + " successfully logged in at " + DateTime.Now.ToString(), e);
                    }
                }
                //if it does not exist create new file and write
                else
                {
                    using (StreamWriter logUser = new StreamWriter("loginRecord.txt"))
                    {
                        logUser.WriteLine(usernameTxt.Text + " successfully logged in at " + DateTime.Now.ToString());
                    }
                }          
            }
            catch (Exception)
            {
                MessageBox.Show("The file could not be written to.");
            }
        }

        private void CheckAppt()
        {
            DateTime Current = Convert.ToDateTime(DateTime.UtcNow);
            DateTime Future = Convert.ToDateTime(DateTime.UtcNow).AddMinutes(15);

            string upcomingAppoinments = "SELECT customer.customerId, customer.customerName, appointment.appointmentId, appointment.start, appointment.end from appointment INNER JOIN customer on appointment.customerId = customer.customerId where start BETWEEN '" +
                Current.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" +
                Future.ToString("yyyy-MM-dd HH:mm:ss") + "';";
            DataTable upcoming = new DataTable();
            universals.TableReader(upcomingAppoinments, upcoming);

            if (upcoming.Rows.Count > 0)
            {
                for (int i = 0; i < upcoming.Rows.Count; i++)
                {
                    MessageBox.Show("You have an appointment with " + upcoming.Rows[i]["customerName"] + " within the next 15 minutes.", "Upcoming Appointments!");
                }
            }
        }

        private void welcomeLbl_Click(object sender, EventArgs e)
        {

        }

        private void signInBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
