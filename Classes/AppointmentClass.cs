﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace C969Rebekah.Classes
{
    public class AppointmentClass

    {
        //Create appointment view 
        public string apptQuery =
            "SELECT customer.customerId, customer.customerName, appointment.appointmentId, appointment.type, appointment.start, appointment.end "
            + " FROM appointment "
            + " INNER JOIN customer ON appointment.customerId = customer.customerId;";
        public void PopulateApptData(string a, DataTable dt)
        {
            using (MySqlConnection connect = new MySqlConnection(SqlClass.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand(a, connect);
                connect.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[i]["start"], TimeZoneInfo.Local).ToString();
                        dt.Rows[i]["end"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[i]["end"], TimeZoneInfo.Local).ToString();

                    }
                    connect.Close();
                }
                else
                {
                    MessageBox.Show("Cann't get appointment data");
                }
            }
        }
    }
}
