﻿using C969Rebekah.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Windows.Markup;
using System.Text.RegularExpressions;

namespace C969Rebekah
{
    public partial class CustomerForm : Form
    {

        public static int cID;
        public static int aID;
        private static CustomerClass customer = new CustomerClass();
        private static PublicClass universals = new PublicClass();

        private bool SaveAllowed()
        {
            if (!universals.IsNotNullOrEmpty(nameTxt.Text))
            { return false; }
            if (!universals.IsNotNullOrEmpty(addressTxt.Text))
            { return false; }
            if (!universals.IsNotNullOrEmpty(zipTxt.Text))
            { return false; }
            if (!universals.IsNotNullOrEmpty(phoneTxt.Text))
            { return false; }
            return true;
        }
        public CustomerForm()
        {
            string city = "SELECT city from city;";
            DataTable cityDt = new DataTable();
            InitializeComponent();
            universals.GetData(city, cityDt);
            cityCB.DataSource = cityDt;
            cityCB.DisplayMember = "City";


        if (PublicClass.CustomerID > 0)
            {
                DataTable customerFill = new DataTable();
                string custInfo = customer.findAllCustQuery;

                universals.TableReader(custInfo, customerFill);
                nameTxt.Text = (string)customerFill.Rows[PublicClass.CurrentCustIndex]["customerName"];
                addressTxt.Text = (string)customerFill.Rows[PublicClass.CurrentCustIndex]["address"];
                zipTxt.Text = (string)customerFill.Rows[PublicClass.CurrentCustIndex]["postalCode"];
                phoneTxt.Text = (string)customerFill.Rows[PublicClass.CurrentCustIndex]["phone"];
                cityCB.Text = (string)customerFill.Rows[PublicClass.CurrentCustIndex]["city"];
            }
        }
        private void cancelCustBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm dash = new MainForm();
            dash.Show();
        }

        private void saveCustBtn_Click(object sender, EventArgs e)
        {

            if (PublicClass.CustomerID > 0)
            {
                UpdateCustomerData();
            }
            else
            {
                InsertCustomerData();
            }

        }
        private void nameTxt_TextChanged(object sender, EventArgs e)
        {
            bool validName = universals.IsNotNullOrEmpty(nameTxt.Text);
            universals.ValidateField(nameTxt, validName);
            saveCustBtn.Enabled = SaveAllowed();
        }

        private void addressTxt_TextChanged(object sender, EventArgs e)
        {
            bool validAddress = universals.IsNotNullOrEmpty(addressTxt.Text);
            universals.ValidateField(addressTxt, validAddress);
            saveCustBtn.Enabled = SaveAllowed();
        }

        private void zipTxt_TextChanged(object sender, EventArgs e)
        {
            bool zipFormat = universals.CheckZipFormat(zipTxt.Text.ToString());
            bool validZip = universals.IsNotNullOrEmpty(zipTxt.Text);
            universals.ValidateField(zipTxt, validZip);
            universals.ValidateField(zipTxt, zipFormat);
            saveCustBtn.Enabled = SaveAllowed();
        }

        private void phoneTxt_TextChanged(object sender, EventArgs e)
        {
            bool format = universals.CheckPhoneFormat(phoneTxt.Text.ToString());
            bool validPhone = universals.IsNotNullOrEmpty(phoneTxt.Text);
            universals.ValidateField(phoneTxt, validPhone);
            universals.ValidateField(phoneTxt, format);
            if (phoneTxt.BackColor.Equals(System.Drawing.Color.Salmon))
            {
                errorLbl.Text = "Please enter phone as ###-####";
                saveCustBtn.Enabled = false;
            }
            else if (phoneTxt.BackColor.Equals(System.Drawing.Color.White))
            {
                errorLbl.Text = "";
                saveCustBtn.Enabled = true;
            }
        }

        private void AddEditCustForm_Load(object sender, EventArgs e)
        {
            saveCustBtn.Enabled = SaveAllowed();
        }

        public void InsertCustomerData()
        {
            try
            {
                {
                    //finding name of city from drop down
                    string getCity = cityCB.GetItemText(cityCB.Text);
                    
                    //selecting city id based off of city name
                    string sql = "SELECT cityId from city where city = '" + getCity + "';";

                    DataTable cityResult = new DataTable();
                    universals.GetData(sql, cityResult);
                    if (cityResult.Rows.Count > 0)
                    {
                        int cID = Convert.ToInt32(cityResult.Rows[0][0]);
                        PublicClass.CityID = cID;
                    }
                    //query to enter address data in address table
                    string insertAddressData =
                        "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy)" +
                        "VALUES ('" + addressTxt.Text + "', ' ', '" + PublicClass.CityID + "', '" + zipTxt.Text + "', '"  + phoneTxt.Text + "', '"
                         + TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") + "', '" + PublicClass.CurrentUser + "', '" + PublicClass.CurrentUser + "');";

                    //query to get address ID from address table
                    string getAddress = "SELECT addressId FROM address WHERE address = '" + addressTxt.Text + "';";

                    DataTable addressResult = new DataTable();
                    customer.InsertAddress(insertAddressData, getAddress, addressResult);

                    if (addressResult.Rows.Count > 0)
                    {
                        int aID = Convert.ToInt32(addressResult.Rows[0][0]);
                        PublicClass.AddressID = aID;
                    }
                    
                    //query to insert customer data into customer table
                    string insertCustData =
                        "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdateBy)" +
                        "VALUES ('" + nameTxt.Text + "', '" + PublicClass.AddressID + "', 1 ,'" +
                        TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") + "', '" + PublicClass.CurrentUser + "', '" + PublicClass.CurrentUser + "');";

                    universals.ExecuteNonQueryUpdater(insertCustData);
                    this.Hide();
                    MainForm dash = new MainForm();
                    dash.Show();
                }
            }
            catch (Exception)
            {
                errorLbl.Text = "An error has occurred. Please try again.";
            }
        }

        public void UpdateCustomerData()
        {
            try
            {
                {
                    string updateCity = cityCB.GetItemText(cityCB.SelectedItem);
                    string citySql = "SELECT cityId FROM city WHERE city ='" + updateCity + "';";

                    DataTable cityCombo = new DataTable();
                    universals.GetData(citySql, cityCombo);
                    if (cityCombo.Rows.Count >0)
                    {
                        int id = (int)cityCombo.Rows[0][0];
                        PublicClass.CityID = id;
                    }

                    string addressID = "SELECT addressId FROM customer WHERE customerId = '" + PublicClass.CustomerID + "';";

                    DataTable addressDt = new DataTable();
                    universals.GetData(addressID, addressDt);
                    if (addressDt.Rows.Count > 0)
                    {
                        int addressid = (int)addressDt.Rows[0][0];
                        PublicClass.AddressID = addressid;
                    }
                    string addressUpdate =
                        "UPDATE address SET address = '" + addressTxt.Text + "', postalCode ='"  + zipTxt.Text + "', phone ='" + phoneTxt.Text + "', cityId ='" + PublicClass.CityID + "', " +
                        "lastUpdate = '" +
                        TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") + "',  " +
                        "lastUpdateBy = '" + PublicClass.CurrentUser + "' " +
                        "WHERE addressId = '" + PublicClass.AddressID + "';";

                    string customerUpdate = "UPDATE customer SET customerName = '" + nameTxt.Text + "', " + "lastUpdate = '" +
                        TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") + "',  " +
                        "lastUpdateBy = '" + PublicClass.CurrentUser + "' " +
                        "WHERE customerId = '" + PublicClass.CustomerID + "';";

                    universals.ExecuteNonQueryUpdater(addressUpdate);
                    universals.ExecuteNonQueryUpdater(customerUpdate);
                    this.Hide();
                    MainForm dash = new MainForm();
                    dash.Show();
                }
            }
            catch (Exception)
            {
                errorLbl.Text = "An error has occurred. Please try again.";
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cityCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
